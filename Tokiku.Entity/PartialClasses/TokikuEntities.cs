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
        }
    }
}
