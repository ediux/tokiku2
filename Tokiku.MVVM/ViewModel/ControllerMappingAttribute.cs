using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class ControllerMappingAttribute : Attribute
    {

        public string Name { get; set; }
        public string Action { get; set; }
        public Type ControllerType { get; set; }

        // This is a positional argument
        public ControllerMappingAttribute(Type ControllerType)
        {
            Name = ControllerType.Name.Replace("Controller", ""); ;
            Action = "Default";
            this.ControllerType = ControllerType;
        }


    }

}
