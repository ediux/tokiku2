using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    public abstract class ActionResult
    {   
        public string Area { get; set; }
        public string ViewName { get; set; }
        public string Action { get; set; }
        public IBaseViewModel Model { get; set; }
        public object[] RoutedValues { get; set; }
    }
}