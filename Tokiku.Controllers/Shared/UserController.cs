using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class UserController : BaseController
    {
        private TokikuEntities database;

        public UserController()
        {
            database = new TokikuEntities();
        }
        

        public void AddUser(string UserName, string pwd, string role, string email = "abc@cde.com")
        {
            string LoweredUserName = UserName.ToLowerInvariant();
            string LoweredRoleName = role.ToLowerInvariant();

            Users newUser = new Users()
            {
                IsAnonymous = false,
                LastActivityDate = new DateTime(1754, 1, 1),
                LoweredUserName = LoweredUserName,
                UserId = Guid.NewGuid(),
                UserName = UserName

            };

            Membership newMembership = new Membership()
            {
                CreateDate = DateTime.UtcNow,
                FailedPasswordAnswerAttemptCount = 0,
                FailedPasswordAnswerAttemptWindowStart = new DateTime(1754, 1, 1),
                FailedPasswordAttemptCount = 0,
                FailedPasswordAttemptWindowStart = new DateTime(1754, 1, 1),
                IsApproved = true,
                Comment = string.Empty,
                Email = email,
                LoweredEmail = email.ToLowerInvariant(),
                MobilePIN = string.Empty,
                PasswordAnswer = string.Empty,
                PasswordQuestion = string.Empty,
                PasswordSalt = string.Empty,
                IsLockedOut = false,
                LastLockoutDate = new DateTime(1754, 1, 1),
                LastLoginDate = new DateTime(1754, 1, 1),
                Password = pwd,
                PasswordFormat = 0,
                LastPasswordChangedDate = new DateTime(1754, 1, 1),
                UserId = newUser.UserId,
                Users = newUser
            };



            if (!database.Users.Where(w => w.UserName == UserName).Any())
            {
                if (!database.Roles.Where(w => w.LoweredRoleName == LoweredRoleName).Any())
                {
                    Roles newRole = new Roles()
                    {
                        Description = role,
                        LoweredRoleName = LoweredRoleName,
                        RoleId = Guid.NewGuid(),
                        RoleName = role,
                    };
                    newRole.Users.Add(newUser);
                    database.Roles.Add(newRole);
                }
                else
                {
                    Roles adminRole = (from r in database.Roles
                                       where r.LoweredRoleName == LoweredRoleName
                                       select r).SingleOrDefault();

                    adminRole.Users.Add(newUser);
                }

                newUser.Membership = newMembership;
                database.Users.Add(newUser);
                database.SaveChanges();
            }

        }

        public UserViewModel AddUser(UserViewModel model)
        {
            var user = new Users();
            CopyToNotModel(user, model);
            user = database.Users.Add(user);
            database.SaveChanges();

            return BindingFromNotModel<Users, UserViewModel>(user);
        }

        public Users GetUser(string UserName)
        {
            string LoweredUserName = UserName.ToLowerInvariant();

            var user = (from u in database.Users
                        where u.UserName == UserName || u.LoweredUserName == LoweredUserName
                        select u).SingleOrDefault();

            return user;
        }

        public UserViewModel Login(LoginViewModel model)
        {
            try
            {
                return BindingFromNotModel<Users, UserViewModel>(Login(model.UserName, model.Password));
            }
            catch (Exception ex)
            {
                UserViewModel vm = new UserViewModel();
                vm.Error = ex;
                return vm;
            }

        }

        public Users Login(string UserName, string pwd)
        {
            try
            {
                var lowedUserName = UserName.ToLowerInvariant();
                var result = (from u in database.Users
                              where u.LoweredUserName == lowedUserName && u.Membership.Password == pwd
                              select u).SingleOrDefault();

                if (result != null)
                {
                    return result;
                }

                if (UserName.ToLowerInvariant() == "root" && pwd == "1234")
                {
                    var isexists = GetUser("root");

                    if (isexists != null)
                    {
                        return null;
                    }
                    else
                    {
                        AddUser("root", pwd, "Admins");
                        return GetUser("root");
                    }

                }
                return null;
            }
            catch
            {
                throw;
            }


        }
    }
}
