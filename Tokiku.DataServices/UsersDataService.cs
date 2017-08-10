using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace Tokiku.DataServices
{
    public class UsersDataService : DataServiceBase<IUsers>, IUserDataService
    {
        private IUsersRepository _UsersRepo;
        private IAccessLogDataService _AccessLogService;
        private IContactsRepository _ContactsRepository;

        #region 建構式
        public UsersDataService(IUnitOfWork UnitOfWork,
            IUsersRepository UsersRepo,
            IContactsRepository ContactsRepository,
            IAccessLogDataService AccessLogService)
        {
            _AccessLogService = AccessLogService;
            _UsersRepo = UsersRepo;
            _ContactsRepository = ContactsRepository;
            _UsersRepo.UnitOfWork = UnitOfWork;
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

                    _AccessLogService.AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser.UserId, "Login Success", ActionCodes.SystemLogin);
                    _AccessLogService.AddAccessLog("Membership", _CurrentLoginedUser.Membership.UserId.ToString(), _CurrentLoginedUser.UserId, "Login Success", ActionCodes.SystemLogin);

                    _CurrentLoginedUser = _UsersRepo.Reload(_CurrentLoginedUser);

                    return true;
                }

                _AccessLogService.AddAccessLog("Users", Guid.Empty.ToString(), Guid.Empty, "Login Fail", ActionCodes.SystemLogin);

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

                    _AccessLogService.AddAccessLog("Users", _CurrentLoginedUser.UserId.ToString(), _CurrentLoginedUser.UserId, "Logout System", ActionCodes.SystemLogout);

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
                IUserViewModel model = SimpleIoc.Default.GetInstance<IUserViewModel>();

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

        public override IUsers Add(IUsers model)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IUsers> AddRange(IEnumerable<IUsers> models)
        {
            throw new NotImplementedException();
        }

        public override IUsers GetSingle(Expression<Func<IUsers, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IUsers> GetAll(Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public override IUsers Update(IUsers Source, Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IUsers> UpdateRange(IEnumerable<IUsers> MultiSource, Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public override void Remove(IUsers model)
        {
            throw new NotImplementedException();
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override void RemoveWhere(Expression<Func<IUsers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }


        public override ICollection<IUsers> SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 聯絡人資料存取服務
        public Contacts Add(Contacts model)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Contacts> AddRange(IEnumerable<Contacts> models)
        {
            throw new NotImplementedException();
        }

        public Contacts GetSingle(Expression<Func<Contacts, bool>> filiter)
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

        public Contacts Update(Contacts Source, Expression<Func<Contacts, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contacts> UpdateRange(IEnumerable<Contacts> MultiSource, Expression<Func<Contacts, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Contacts model)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<Contacts, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contacts> IDataService<Contacts>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ICollection<Contacts> IDataService<Contacts>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        void IDataService<Contacts>.RemoveAll()
        {

        }

        public ICollection<Contacts> SearchByText(string filiter, Guid ManufactoryId, bool isClient)
        {
            try
            {
                if (filiter != null && filiter.Length > 0)
                {                 
                    var result = (from p in GetAll()
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
                    var result = (from p in GetAll()
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
        #endregion

    }
}
