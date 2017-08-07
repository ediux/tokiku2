using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    public class UsersDataService : DataServiceBase, IUserDataService
    {
        private IUsersRepository _UsersRepo;
        private IAccessLogDataService _AccessLogService;

        public UsersDataService(IUnitOfWork UnitOfWork, IUsersRepository UsersRepo, IAccessLogDataService AccessLogService)
        {
            _AccessLogService = AccessLogService;
            _UsersRepo = UsersRepo;
            _UsersRepo.UnitOfWork = UnitOfWork;
        }

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

                    if (_CurrentLoginedUser.Membership.Comment.Length > 0
                        && _CurrentLoginedUser.Membership.Comment == "LoginLocker")
                    {
                        _AccessLogService.AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser, "Login Fail", ActionCodes.SystemLogin);

                        throw new Exception("此帳號已在其他電腦上登入!");
                    }

                    _CurrentLoginedUser.Membership.Comment = "LoginLocker";
                    _CurrentLoginedUser.LastActivityDate = DateTime.Now;
                    _CurrentLoginedUser.Membership.LastLoginDate = DateTime.Now;

                    _UsersRepo.UnitOfWork.Commit();

                    _AccessLogService.AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser, "Login Success", ActionCodes.SystemLogin);
                    _AccessLogService.AddAccessLog("Membership", _CurrentLoginedUser.Membership.UserId.ToString(), _CurrentLoginedUser, "Login Success", ActionCodes.SystemLogin);

                    _CurrentLoginedUser = _UsersRepo.Reload(_CurrentLoginedUser);

                    return true;
                }

                _AccessLogService.AddAccessLog("Users", Guid.Empty.ToString(), null, "Login Fail", ActionCodes.SystemLogin);

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

                    _UsersRepo.UnitOfWork.Commit();

                    _AccessLogService.AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser, "Logout System", ActionCodes.SystemLogout);

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

        private static Users _CurrentLoginedUser;
    }
}
