using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class StateController : BaseController<StatesViewModel, States>
    {
        public StatesViewModelCollection QueryAll()
        {
            try
            {
                var result = from s in database.States
                             select s;

                StatesViewModelCollection rtn = new StatesViewModelCollection();

                if (result.Any())
                {
                    foreach (var row in result)
                    {
                        StatesViewModel model = new StatesViewModel();
                        model = BindingFromModel(row);
                        rtn.Add(model);
                    }
                }

                return rtn;

            }
            catch (Exception ex)
            {
                StatesViewModelCollection rtn = new StatesViewModelCollection();
                setErrortoModel(rtn, ex);
                return rtn;
            }
        }
    }
}
