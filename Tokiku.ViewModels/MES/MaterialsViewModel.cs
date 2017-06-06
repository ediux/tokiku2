using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class MaterialsViewModelCollection : BaseViewModelCollection<MaterialsViewModel>
    {
        public MaterialsViewModelCollection()
        {

        }

        public MaterialsViewModelCollection(IEnumerable<MaterialsViewModel> source) : base(source)
        {

        }        
    }

    public class MaterialsViewModel : BaseViewModel
    {
    }
}
