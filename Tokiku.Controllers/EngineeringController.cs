using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class EngineeringController : BaseController<EngineeringViewModel, Engineering>
    {
        public override EngineeringViewModel Query(Expression<Func<Engineering, bool>> filiter)
        {
            return base.Query(filiter);
        }

        private void ResultBindToViewModel(Engineering entity,EngineeringViewModel model)
        {

        }

        private EngineeringViewModelCollection ResultBindToViewModelCollection(IQueryable<Engineering> queries)
        {
            return new EngineeringViewModelCollection();
        }
    }
}
