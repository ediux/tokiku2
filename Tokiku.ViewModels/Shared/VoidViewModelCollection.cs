using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class VoidViewModelCollection : ObservableCollection<VoidViewModel>
    {
        public VoidViewModelCollection()
        {
            
        }
        public VoidViewModelCollection(IEnumerable<VoidViewModel> source):base(source)
        {

        }
        public static VoidViewModelCollection Query()
        {
            try
            {
                VoidViewModelCollection collection = new VoidViewModelCollection();
                collection.Add(new VoidViewModel() { Value = false, Text = "啟用" });
                collection.Add(new VoidViewModel() { Value = true, Text = "停用" });
                return collection;
            }
            catch 
            {
                VoidViewModelCollection collection = new VoidViewModelCollection();
                return collection;
            }
            
            
        }
    }
}
