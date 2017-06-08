using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class TicketPeriodsManagementController : BaseController<TicketPeriod>
    {
        public ExecuteResultEntity<ICollection<TicketPeriod>> QueryAll()
        {
            try
            {
                TicketPeriodRepository repo = RepositoryHelper.GetTicketPeriodRepository(database);
                var queryresult = from q in repo.All()
                                  orderby q.DayLimit ascending
                                  select q;

                return ExecuteResultEntity<ICollection<TicketPeriod>>.CreateResultEntity(
                    new Collection<TicketPeriod>(queryresult.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<TicketPeriod>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
