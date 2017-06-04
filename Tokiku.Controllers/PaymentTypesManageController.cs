using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class PaymentTypesManageController : BaseController<PaymentTypes>
    {
        public override PaymentTypesManageViewModel Query(Expression<Func<PaymentTypes, bool>> filiter)
        {
            return base.Query(filiter);
        }
    }
}
