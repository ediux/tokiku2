using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class MaterialsViewModelCollection : ObservableCollection<MaterialsViewModel>, IBaseViewModel
    {
        public MaterialsViewModelCollection()
        {

        }

        public MaterialsViewModelCollection(IEnumerable<MaterialsViewModel> source) : base(source)
        {

        }

        private IEnumerable<string> _Errors;
        public IEnumerable<string> Errors { get => _Errors; set => _Errors = value; }
        private bool _HasError = false;
        public bool HasError { get => _HasError; set => _HasError = value; }
    }

    public class MaterialsViewModel : BaseViewModel
    {
    }
}
