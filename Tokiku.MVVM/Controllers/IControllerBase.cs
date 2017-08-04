using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Tokiku.MVVM
{
    public interface IControllerBase
    {
        void Execute(RequestContext requestContext);
    }
}