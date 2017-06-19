using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class PaymentTypesManageController : BaseController<PaymentTypes>
    {
        public ExecuteResultEntity<ICollection<PaymentTypes>> QueryAll()
        {
            try
            {
                PaymentTypesRepository repo = RepositoryHelper.GetPaymentTypesRepository(database);
                
                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

                return ExecuteResultEntity<ICollection<PaymentTypes>>.CreateResultEntity(new Collection<PaymentTypes>(queryresult.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<PaymentTypes>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
