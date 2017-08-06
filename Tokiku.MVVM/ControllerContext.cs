using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    public class ControllerContext
    {
        /// <summary>
        /// 組件名稱(同等於MVC中的Area)
        /// </summary>
        public string AssemblyName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public IBaseViewModel Model { get; set; }
        public Type ModelType { get; set; }
        public object Parameter { get; set; }
    }
}