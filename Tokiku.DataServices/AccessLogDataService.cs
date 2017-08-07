using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    public class AccessLogDataService : DataServiceBase, IAccessLogDataService
    {
        private IAccessLogRepository _AccessLogRepo;
        private IUsersRepository _UsersRepo;
        private IUnitOfWork _UnitOfWork;

        public AccessLogDataService(IUnitOfWork UnitOfWork, IAccessLogRepository AccessLogRepo, IUsersRepository UsersRepo)
        {
            _UnitOfWork = UnitOfWork;
            _AccessLogRepo = AccessLogRepo;
            _AccessLogRepo.UnitOfWork = _UnitOfWork;
            _UsersRepo = UsersRepo;
            _UsersRepo.UnitOfWork = _UnitOfWork;
        }

        public void AddAccessLog(string DataTableName, string DataId, object UserId, string Reason, ActionCodes Action)
        {
            try
            {
                AccessLog newLog = new AccessLog();

                newLog.ActionCode = (byte)Action;
                newLog.CreateTime = DateTime.Now;
                newLog.DataId = DataId;
                newLog.DataTableName = DataTableName;
                newLog.Reason = Reason;
                newLog.UserId = (Guid)(UserId ?? Guid.Empty);

                _AccessLogRepo.Add(newLog);
                _AccessLogRepo.UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
            }
        }

        public DateTime? GetLastUpdateTime(string DataTable, string DataId)
        {
            try
            {
                var result = (from q in _AccessLogRepo
                              where q.DataTableName == DataTable
                              && q.DataId == DataId
                              orderby q.CreateTime descending
                              select q.CreateTime).FirstOrDefault();

                return result;

            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return default(DateTime?);
            }
        }

        public IUserViewModel GetLastUpdateUser(string DataTable, string DataId)
        {
            throw new NotImplementedException();
        }
    }
}