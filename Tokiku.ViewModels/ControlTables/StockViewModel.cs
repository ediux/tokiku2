using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class StockViewModel : BaseViewModelWithPOCOClass<Stocks>
    {
        public StockViewModel()
        {

        }
        public StockViewModel(Stocks entity) : base(entity)
        {
            
        }


        public string Name { get => CopyofPOCOInstance.Name; set {
                CopyofPOCOInstance.Name = value;
                RaisePropertyChanged("Name");
            } }

    }
}
