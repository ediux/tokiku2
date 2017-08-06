using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    public interface IViewController
    {
        void Execute(ControllerContext context,params object[] Paramters);

  
    }
}