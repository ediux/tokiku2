using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class StartUpWindowController : BaseController
    {
        public StartUpWindowController()
        {
        }

        public void AddUser(string UserName, string pwd, string role, string email = "abc@cde.com")
        {
            try
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

                //if (!database.Users.Where(w => w.UserName == UserName).Any())
                //{
                //    if (!database.Roles.Where(w => w.LoweredRoleName == LoweredRoleName).Any())
                //    {
                //        Roles newRole = new Roles()
                //        {
                //            Description = role,
                //            LoweredRoleName = LoweredRoleName,
                //            RoleId = Guid.NewGuid(),
                //            RoleName = role,
                //        };
                //        newRole.Users.Add(newUser);
                //        database.Roles.Add(newRole);
                //    }
                //    else
                //    {
                //        Roles adminRole = (from r in database.Roles
                //                           where r.LoweredRoleName == LoweredRoleName
                //                           select r).SingleOrDefault();

                //        adminRole.Users.Add(newUser);
                //    }

                //    newUser.Membership = newMembership;
                //    database.Users.Add(newUser);
                //    database.SaveChanges();
                //}
            }
            catch
            {
            }

        }





        //    public override UserViewModel CreateNew()
        //    {
        //        return new UserViewModel()
        //        {
        //            IsAnonymous = true,
        //            LastActivityDate = new DateTime(1754, 1, 1),
        //            LoweredUserName = Environment.UserName.ToLowerInvariant(),
        //            UserName = Environment.UserName,
        //            UserId = Guid.NewGuid()
        //        };
        //    }

        //    public override void Add(UserViewModel model)
        //    {
        //        try
        //        {
        //            using (database)
        //            {
        //Users newUser = new Users();
        //            CopyToModel(newUser, model);
        //            database.Users.Add(newUser);
        //            database.SaveChanges();
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            setErrortoModel(model, ex);
        //        }
        //        finally
        //        {
        //            database = new TokikuEntities();
        //        }
        //    }




    }
}
