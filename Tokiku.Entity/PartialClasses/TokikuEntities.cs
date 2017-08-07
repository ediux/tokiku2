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

        public static void StartUp()
        {
            TokikuEntities database = new TokikuEntities();

            if (!database.Database.Exists())
            {
                database.Database.Create();
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
                database.TicketTypes.Add(new TicketTypes() { Id = 1, Name = "銀行本票", IsPromissoryNote = true });
                database.TicketTypes.Add(new TicketTypes() { Id = 2, Name = "公司本票", IsPromissoryNote = true });
                database.TicketTypes.Add(new TicketTypes() { Id = 3, Name = "預付轉保固票", IsPromissoryNote = false });
                database.TicketTypes.Add(new TicketTypes() { Id = 4, Name = "新開立保固票", IsPromissoryNote = false });
                database.SaveChanges();
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
                Root.Membership.CreateDate = DateTime.Now;
                Root.Membership.Email = "root@local.host";
                Root.Membership.IsApproved = true;
                Root.Membership.IsLockedOut = false;
                Root.Membership.LoweredEmail = Root.Membership.Email;
                Root.Membership.Password = "1234";
                Root.Membership.PasswordFormat = 0;

                database.Users.Add(Root);
            }

            if (!database.Users.Any(a => a.LoweredUserName == "guest"))
            {
                Users guestuser = new Users();
                guestuser.UserId = Guid.NewGuid();
                guestuser.UserName = "Guest";
                guestuser.LoweredUserName = "guest";
                guestuser.IsAnonymous = false;
                guestuser.MobileAlias = "訪客";
                guestuser.Membership = new Membership();
                guestuser.Membership.UserId = guestuser.UserId;
                guestuser.Membership.CreateDate = DateTime.Now;
                guestuser.Membership.Email = "anonymous@local.host";
                guestuser.Membership.IsApproved = true;
                guestuser.Membership.IsLockedOut = false;
                guestuser.Membership.LoweredEmail = guestuser.Membership.Email;
                guestuser.Membership.Password = "1234";
                guestuser.Membership.PasswordFormat = 0;

                database.Users.Add(guestuser);
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
                    Users Root = database.Users.Single(a=>a.LoweredUserName == "root");
                   
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

        }
    }
}
