using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class InvoicesController : BaseController
    {
        public ExecuteResultEntity<ICollection<Invoices>> QueryAll()
        {
            try {
                var repo = RepositoryHelper.GetInvoicesRepository();
                return ExecuteResultEntity<ICollection<Invoices>>.CreateResultEntity(
                    new Collection<Invoices>(repo.All().ToList()));
            }catch(Exception ex) {
                return ExecuteResultEntity<ICollection<Invoices>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
