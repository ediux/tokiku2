using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MoldsViewModelCollection : BaseViewModelCollection<MoldsViewModel>
    {
        public async override void SaveModel()
        {
            try
            {
                MoldsController controller = new MoldsController();
                Collection<Molds> dataset = new Collection<Molds>();
                if (Items.Any())
                {
                    foreach (var model in Items)
                    {
                        Molds data = new Molds();
                        CopyToModel(data, model);
                        dataset.Add(data);
                    }
                }
                await controller.CreateOrUpdateAsync(dataset);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
