using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class 保固票ViewModelCollection : BaseViewModelCollection<保固票ViewModel>
    {
        public 保固票ViewModelCollection()
        {
            保固票ViewModel vo = new 保固票ViewModel();
            vo.Id = 0;
            vo.Name = "預付款轉保固票";
            vo.obj = new 保固票ViewModel();

            Add(vo);
            Add(new 保固票ViewModel() { Id = 1, Name = "開立保固票", obj = new 保固票ViewModel() });
        }
    }

    public class 保固票ViewModel : BaseViewModelWithPOCOClass<PromissoryNoteManagement>
    {
        public new int Id { get; set; }
        public string Name { get; set; }
        public Object obj { get; set; }
    }

}
