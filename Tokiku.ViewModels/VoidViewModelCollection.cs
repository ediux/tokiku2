using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class VoidViewModelCollection : BaseViewModelCollection<VoidViewModel>
    {
        public override void Initialized()
        {
            base.Initialized();
            ClearItems();
            Add(new VoidViewModel() { Value = false, Text = "啟用" });
            Add(new VoidViewModel() { Value = true, Text = "停用" });
        }
    }
}
