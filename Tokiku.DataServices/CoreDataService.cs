using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 系統核心資料存取服務
    /// </summary>
    public class CoreDataService : DataServiceBase, ICoreDataService
    {
        private IAccessLogRepository _AccessLogRepo;
        private IUnitOfWork _UnitOfWork;
        private IUsersRepository _UsersRepo;
        private IRolesRepository _RolesRepo;
        private IContactsRepository _ContactsRepository;

        #region 建構式
        public CoreDataService(IUnitOfWork UnitOfWork,
            IUsersRepository UsersRepo,
            IRolesRepository RolesRepository,
            IContactsRepository ContactsRepository,
            IAccessLogRepository AccessLogRepository)
        {
            _UnitOfWork = UnitOfWork;

            _AccessLogRepo = AccessLogRepository;
            _AccessLogRepo.UnitOfWork = _UnitOfWork;

            _UsersRepo = UsersRepo;
            _UsersRepo.UnitOfWork = _UnitOfWork;

            _ContactsRepository = ContactsRepository;
            _ContactsRepository.UnitOfWork = UnitOfWork;

            _RolesRepo = RolesRepository;
            _RolesRepo.UnitOfWork = _UnitOfWork;
        }
        #endregion

        #region 資料存取紀錄資料操作
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
        #endregion

        #region 帳號操作管理
        private static Users _CurrentLoginedUser;

        public bool? Login(ILoginViewModel model)
        {
            try
            {
                string loweredUserName = model.UserName.ToLowerInvariant();

                var checkAccountExist = from q in _UsersRepo.All()
                                        where (q.UserName == model.UserName || q.LoweredUserName == loweredUserName)
                                        && q.Membership.Password == model.Password
                                        select q;

                if (checkAccountExist.Any())
                {
                    _CurrentLoginedUser = checkAccountExist.Single();

#if CheckIsLogin
                    if (!string.IsNullOrEmpty(_CurrentLoginedUser.Membership.Comment)
                        && _CurrentLoginedUser.Membership.Comment == "LoginLocker")
                    {
                        _AccessLogService.AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser.UserId, "Logined on other computer.", ActionCodes.SystemLogin);

                        throw new Exception("此帳號已在其他電腦上登入!");
                    }
                    _CurrentLoginedUser.Membership.Comment = "LoginLocker";
#endif
                    _CurrentLoginedUser.Membership.Comment = "LoginLocker";
                    _CurrentLoginedUser.LastActivityDate = DateTime.Now;
                    _CurrentLoginedUser.Membership.LastLoginDate = DateTime.Now;

                    _UsersRepo.UnitOfWork.Commit();

                    AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser.UserId, "Login Success", ActionCodes.SystemLogin);
                    AddAccessLog("Membership", _CurrentLoginedUser.Membership.UserId.ToString(), _CurrentLoginedUser.UserId, "Login Success", ActionCodes.SystemLogin);

                    _CurrentLoginedUser = _UsersRepo.Reload(_CurrentLoginedUser);

                    return true;
                }

                AddAccessLog("Users", Guid.Empty.ToString(), Guid.Empty, "Login Fail", ActionCodes.SystemLogin);

                return false;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public bool? Logout()
        {
            try
            {
                if (_CurrentLoginedUser != null)
                {
                    _CurrentLoginedUser.LastActivityDate = DateTime.Now;
                    _CurrentLoginedUser.Membership.Comment = "";

                    _UsersRepo.UnitOfWork.Commit();

                    AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser.UserId, "Logout System", ActionCodes.SystemLogout);

                    _CurrentLoginedUser = null;
                }

                return false;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IUserViewModel GetCurrentLoginedUser()
        {
            try
            {
                IUserViewModel model = SimpleIoc.Default.GetInstanceWithoutCaching<IUserViewModel>();

                if (_CurrentLoginedUser != null)
                {
                    model.IsAnonymous = _CurrentLoginedUser.IsAnonymous;
                    model.LastActivityDate = _CurrentLoginedUser.LastActivityDate;
                    model.LoweredUserName = _CurrentLoginedUser.LoweredUserName;
                    model.MobileAlias = _CurrentLoginedUser.MobileAlias;

                    model.UserName = _CurrentLoginedUser.UserName;
                    model.UserId = _CurrentLoginedUser.UserId;

                    return model;
                }

                return null;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IUsers Add(IUsers model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUsers> AddRange(IEnumerable<IUsers> models)
        {
            throw new NotImplementedException();
        }

        public IUsers GetSingle(Expression<Func<IUsers, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUsers> GetAll(Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IUsers Update(IUsers Source, Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUsers> UpdateRange(IEnumerable<IUsers> MultiSource, Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(IUsers model)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IUsers> IDataService<IUsers>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ICollection<IUsers> IDataService<IUsers>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region 聯絡人
        public Contacts Add(Contacts model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contacts> AddRange(IEnumerable<Contacts> models)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contacts> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contacts> GetAll(Expression<Func<Contacts, bool>> filiter = null)
        {
            try
            {
                var result = from p in _ContactsRepository.All()
                             orderby p.IsDefault ascending
                             select p;

                if (filiter == null)
                {
                    return result.AsEnumerable();
                }
                else
                {
                    return result.Where(filiter).AsEnumerable();
                }

            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public Contacts GetSingle(Expression<Func<Contacts, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(Contacts model)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<Contacts, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<Contacts> SearchByText(string filiter, Guid ManufactoryId, bool isClient)
        {
            try
            {
                if (filiter != null && filiter.Length > 0)
                {
                    var result = (from p in ((IContactsDataService)this).GetAll()
                                  from q in p.Manufacturers
                                  where (p.Void == false && q.Id == ManufactoryId
                                  && q.IsClient == isClient) ||
                                  (p.Name.Contains(filiter) || p.Phone.Contains(filiter))
                                  orderby q.Name ascending, p.IsDefault descending
                                  select p);

                    var rtn = new Collection<Contacts>(result.ToList());

                    return rtn;
                }
                else
                {
                    var result = (from p in ((IContactsDataService)this).GetAll()
                                  from q in p.Manufacturers
                                  where q.Void == false && q.IsClient == isClient
                                  && q.Id == ManufactoryId
                                  orderby p.Name ascending, p.IsDefault descending
                                  select p);

                    var rtn = new Collection<Contacts>(result.ToList());

                    return rtn;
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public ICollection<Contacts> SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        public Contacts Update(Contacts Source, Expression<Func<Contacts, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contacts> UpdateRange(IEnumerable<Contacts> MultiSource, Expression<Func<Contacts, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 角色資料存取服務  
        public Roles Add(Roles model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Roles> AddRange(IEnumerable<Roles> models)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Roles> GetAll(Expression<Func<Roles, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public Roles GetSingle(Expression<Func<Roles, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(Roles model)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<Roles, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public Roles Update(Roles Source, Expression<Func<Roles, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Roles> UpdateRange(IEnumerable<Roles> MultiSource, Expression<Func<Roles, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Roles> IDataService<Roles>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ICollection<Roles> IDataService<Roles>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}