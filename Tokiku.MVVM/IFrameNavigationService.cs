using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.MVVM
{
    public interface IFrameNavigationService :INavigationService
    {
        object Parameter { get;  }
       
    }
}