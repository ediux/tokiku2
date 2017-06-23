using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class 預付款保證票ViewModelCollection : BaseViewModelCollection<預付款保證票ViewModel>
    {
        public 預付款保證票ViewModelCollection()
        {
            Add(new 預付款保證票ViewModel() { Name = "公司本票" });
            Add(new 預付款保證票ViewModel() { Name = "銀行本票" });

        }
    }

    public class 預付款保證票ViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }

}
