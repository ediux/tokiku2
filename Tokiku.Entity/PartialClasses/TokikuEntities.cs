using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public partial class TokikuEntities
    {

        public TokikuEntities(string connectionString) : base(connectionString)
        {

        }

        public void StartUp()
        {
            TokikuEntities database = this;

            if (!database.Database.Exists())
            {
                database.Database.Create();
            }



            if (!database.Users.Any(a => a.LoweredUserName == "root"))
            {
                Users Root = new Users();
                Root.UserId = Guid.NewGuid();
                Root.UserName = "Root";
                Root.LoweredUserName = "root";
                Root.IsAnonymous = false;
                Root.MobileAlias = "Root";
                Root.Membership = new Membership();
                Root.Membership.UserId = Root.UserId;
                Root.Membership.LastLoginDate = new DateTime(1754, 1, 1);
                Root.Membership.FailedPasswordAnswerAttemptCount = 0;
                Root.Membership.FailedPasswordAnswerAttemptWindowStart = new DateTime(1754, 1, 1, 0, 0, 0);
                Root.Membership.FailedPasswordAttemptCount = 0;
                Root.Membership.FailedPasswordAttemptWindowStart = new DateTime(1754, 1, 1, 0, 0, 0);

                Root.Membership.LastPasswordChangedDate = Root.Membership.CreateDate = Root.LastActivityDate = DateTime.Now;
                Root.Membership.Email = "root@local.host";
                Root.Membership.IsApproved = true;
                Root.Membership.IsLockedOut = false;
                Root.Membership.LastLockoutDate = new DateTime(1754, 1, 1, 0, 0, 0);
                Root.Membership.LoweredEmail = Root.Membership.Email;
                Root.Membership.Password = "1234";
                Root.Membership.PasswordFormat = 0;
                Root.Membership.PasswordSalt = Guid.NewGuid().ToString("N");
                
                database.Users.Add(Root);
                database.SaveChanges();
            }

            if (!database.Users.Any(a => a.LoweredUserName == "guest"))
            {
                Users guestuser = new Users();

                guestuser.UserId = Guid.NewGuid();
                guestuser.UserName = "Guest";
                guestuser.LoweredUserName = "guest";
                guestuser.IsAnonymous = true;
                guestuser.MobileAlias = "訪客";
                guestuser.Membership = new Membership();
                guestuser.Membership.UserId = guestuser.UserId;
                guestuser.Membership.LastLoginDate = new DateTime(1754, 1, 1);
                guestuser.Membership.FailedPasswordAnswerAttemptCount = 0;
                guestuser.Membership.FailedPasswordAnswerAttemptWindowStart = new DateTime(1754, 1, 1, 0, 0, 0);
                guestuser.Membership.FailedPasswordAttemptCount = 0;
                guestuser.Membership.FailedPasswordAttemptWindowStart = new DateTime(1754, 1, 1, 0, 0, 0);

                guestuser.Membership.LastPasswordChangedDate = guestuser.Membership.CreateDate = guestuser.LastActivityDate = DateTime.Now;
                guestuser.Membership.CreateDate = DateTime.Now;
                guestuser.Membership.Email = "anonymous@local.host";
                guestuser.Membership.IsApproved = true;
                guestuser.Membership.IsLockedOut = false;
                guestuser.Membership.LastLockoutDate = new DateTime(1754, 1, 1, 0, 0, 0);
                guestuser.Membership.LoweredEmail = guestuser.Membership.Email;
                guestuser.Membership.Password = "1234";
                guestuser.Membership.PasswordFormat = 0;
                guestuser.Membership.PasswordSalt = Guid.NewGuid().ToString("N");

                database.Users.Add(guestuser);
                database.SaveChanges();
            }

            if (!database.Roles.Any(a => a.LoweredRoleName == "Roots"))
            {
                Roles AdminsRole = new Roles();
                AdminsRole.Description = "超級管理員";
                AdminsRole.LoweredRoleName = "roots";
                AdminsRole.RoleId = Guid.NewGuid();
                AdminsRole.RoleName = "Roots";

                database.Roles.Add(AdminsRole);

                if (database.Users.Any(a => a.LoweredUserName == "root"))
                {
                    Users Root = database.Users.Single(a => a.LoweredUserName == "root");

                    AdminsRole.Users.Add(Root);
                }

                database.SaveChanges();

            }

            if (!database.Roles.Any(a => a.LoweredRoleName == "admins"))
            {
                Roles AdminsRole = new Roles();
                AdminsRole.Description = "系統管理員";
                AdminsRole.LoweredRoleName = "admins";
                AdminsRole.RoleId = Guid.NewGuid();
                AdminsRole.RoleName = "Admins";

                database.Roles.Add(AdminsRole);
                database.SaveChanges();

            }

            if (!database.Roles.Any(a => a.LoweredRoleName == "users"))
            {
                Roles UsersRole = new Roles();
                UsersRole.Description = "一般使用者";
                UsersRole.LoweredRoleName = "users";
                UsersRole.RoleId = Guid.NewGuid();
                UsersRole.RoleName = "Users";

                database.Roles.Add(UsersRole);
                database.SaveChanges();

            }

            if (!database.Roles.Any(a => a.LoweredRoleName == "guests"))
            {
                Roles GuestRole = new Roles();
                GuestRole.Description = "訪客";
                GuestRole.LoweredRoleName = "guests";
                GuestRole.RoleId = Guid.NewGuid();
                GuestRole.RoleName = "Guests";

                database.Roles.Add(GuestRole);

                if (database.Users.Any(a => a.LoweredUserName == "guest"))
                {
                    Users GuestUser = database.Users.Single(a => a.LoweredUserName == "guest");

                    GuestRole.Users.Add(GuestUser);
                }

                database.SaveChanges();

            }

            if (!database.PaymentTypes.Any())
            {
                database.PaymentTypes.Add(new PaymentTypes() { Id = 0, PaymentTypeName = "現金" });
                database.PaymentTypes.Add(new PaymentTypes() { Id = 1, PaymentTypeName = "匯款" });
                database.PaymentTypes.Add(new PaymentTypes() { Id = 2, PaymentTypeName = "支票" });
                database.PaymentTypes.Add(new PaymentTypes() { Id = 99, PaymentTypeName = "其他" });
                database.SaveChanges();
            }

            if (!database.States.Any())
            {
                database.States.Add(new States() { Id = 1, StateName = "施工中" });
                database.States.Add(new States() { Id = 2, StateName = "保固中" });
                database.States.Add(new States() { Id = 4, StateName = "過保固" });
                database.SaveChanges();
            }

            if (!database.TicketTypes.Any())
            {
                Users Root = new Users() { UserId = Guid.Empty };

                if (database.Users.Any(a => a.LoweredUserName == "root"))
                {
                    Root = database.Users.Single(a => a.LoweredUserName == "root");
                }

                database.TicketTypes.Add(new TicketTypes() { Id = 1, Name = "銀行本票", IsPromissoryNote = true, CreateTime = DateTime.Now, CreateUserId = Root.UserId });
                database.TicketTypes.Add(new TicketTypes() { Id = 2, Name = "公司本票", IsPromissoryNote = true, CreateTime = DateTime.Now, CreateUserId = Root.UserId });
                database.TicketTypes.Add(new TicketTypes() { Id = 3, Name = "預付轉保固票", IsPromissoryNote = false, CreateTime = DateTime.Now, CreateUserId = Root.UserId });
                database.TicketTypes.Add(new TicketTypes() { Id = 4, Name = "新開立保固票", IsPromissoryNote = false, CreateTime = DateTime.Now, CreateUserId = Root.UserId });
                database.SaveChanges();
            }
        }
    }
}
