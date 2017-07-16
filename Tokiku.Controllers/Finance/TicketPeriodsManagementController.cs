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
        public ExecuteResultEntity<TicketPeriod> QuerySingle(int TicketPeriodId)
        {
            try
            {
                var repo = this.GetReoisitory();
                //database = repo.UnitOfWork;
                var queryresult = (from q in repo.All()
                                   where q.Id == TicketPeriodId
                                  orderby q.DayLimit ascending
                                  select q).SingleOrDefault();

                return ExecuteResultEntity<TicketPeriod>.CreateResultEntity(
                    queryresult);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<TicketPeriod>.CreateErrorResultEntity(ex);
            }
        }
        public ExecuteResultEntity<ICollection<TicketPeriod>> QueryAll()
        {
            try
            {
                var repo = this.GetReoisitory();
                //database = repo.UnitOfWork;
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

        public ExecuteResultEntity<ICollection<TicketPeriod>> QueryForSelectBusinessItem(Guid MaterialCategoriesId, string BusinessItem, Guid ManufacturersId)
        {
            try
            {
                var repo = this.GetReoisitory();
                //database = repo.UnitOfWork;
                var queryresult = from q in repo.All()
                                  from b in q.ManufacturersBussinessItems
                                  where b.MaterialCategoriesId == MaterialCategoriesId
                                  && b.Name.Contains(BusinessItem) && b.ManufacturersId == ManufacturersId
                                  orderby q.DayLimit ascending
                                  select q;

                return ExecuteResultEntity<ICollection<TicketPeriod>>.CreateResultEntity(
                   new Collection<TicketPeriod>(queryresult.Distinct().ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<TicketPeriod>>.CreateErrorResultEntity(ex);
            }
        }

        public Task<ExecuteResultEntity<ICollection<TicketPeriod>>> QueryForSelectBusinessItemAsync(Guid MaterialCategoriesId, string BusinessItem, Guid ManufacturersId)
        {
            try
            {
                var repo = this.GetReoisitory();
                //database = repo.UnitOfWork;
                var queryresult = from q in repo.All()
                                  from b in q.ManufacturersBussinessItems
                                  where b.MaterialCategoriesId == MaterialCategoriesId
                                  && b.Name.Contains(BusinessItem) && b.ManufacturersId == ManufacturersId
                                  orderby q.DayLimit ascending
                                  select q;

                return Task.FromResult(ExecuteResultEntity<ICollection<TicketPeriod>>.CreateResultEntity(
                   new Collection<TicketPeriod>(queryresult.Distinct().ToList())));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<TicketPeriod>>.CreateErrorResultEntity(ex));
            }
        }
    }
}
