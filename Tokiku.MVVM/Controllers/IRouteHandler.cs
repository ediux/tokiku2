using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tokiku.MVVM
{
    [TypeForwardedFrom("System.Web.Routing, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public interface IRouteHandler
    {
        IWPFHandler GetWPFHandler(RequestContext requestContext);
    }
}