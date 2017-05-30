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
        public static void AddLogRecord(Guid DataId, Guid UserId, byte ActionCode)
        {
            try
            {
                AccessLog newLogData = new AccessLog()
                {
                    ActionCode = ActionCode,
                    CreateTime = DateTime.Now,
                    DataId = DataId,
                    UserId = UserId
                };

                using(var db = new TokikuEntities())
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
    }
}
