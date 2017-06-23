using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class SystemController : BaseController
    {
        public static void AddLogRecord(Guid DataId, Guid UserId, byte ActionCode, string TableName = "", string ActionReason = "")
        {
            try
            {
                AccessLog newLogData = new AccessLog()
                {
                    ActionCode = ActionCode,
                    CreateTime = DateTime.Now,
                    DataId = DataId.ToString("N"),
                    UserId = UserId,
                    DataTableName = TableName,
                    Reason = ActionReason
                };

                using (var db = new TokikuEntities())
                {
                    db.AccessLog.Add(newLogData);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void StartUp()
        {
            try
            {
                TokikuEntities.StartUp();

            }
            catch
            {


            }

        }
    }
}
