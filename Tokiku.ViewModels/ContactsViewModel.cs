using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Dep { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string ExtensionNumber { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public bool IsPrincipal { get; set; }
        public bool Void { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }     
    }
}
