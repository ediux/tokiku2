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
        public override EngineeringViewModel CreateNew()
        {
            EngineeringViewModel model = new EngineeringViewModel();
            try
            {
                model.Compositions = new CompositionsViewModelCollection();
                model.Compositions2 = new CompositionsViewModelCollection();
                return model;
            }
            catch (Exception ex)
            {
                setErrortoModel(model, ex);
                return model;
            }
        }
        public override EngineeringViewModel Query(Expression<Func<Engineering, bool>> filiter)
        {
            try
            {
                var result = database.Engineering
                    .Where(filiter)
                    .OrderBy(s => s.Code)
                    .SingleOrDefault();

                var rtn = ResultBindToViewModel(result);

                return rtn;
            }
            catch (Exception ex)
            {
                EngineeringViewModel model = new EngineeringViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }

        private EngineeringViewModel ResultBindToViewModel(Engineering entity)
        {
            EngineeringViewModel model = new EngineeringViewModel();
            try
            {
                model = BindingFromModel(entity);
                model.Architect = entity.ProjectContract.Architect;
                model.Compositions = new CompositionsViewModelCollection();

                model.Compositions2 = new CompositionsViewModelCollection();
            }
            catch (Exception ex)
            {
                model = new EngineeringViewModel();
                setErrortoModel(model, ex);
            }

            return model;
        }

        private EngineeringViewModelCollection ResultBindToViewModelCollection(IQueryable<Engineering> queries)
        {
            EngineeringViewModelCollection rtn = new EngineeringViewModelCollection();
            try
            {
                if (queries.Any())
                {
                    foreach (var row in queries)
                    {
                        rtn.Add(ResultBindToViewModel(row));
                    }
                }

                return rtn;
            }
            catch (Exception ex)
            {
                setErrortoModel(rtn, ex);
                return rtn;
            }
        }
    }
}
