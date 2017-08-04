using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    [TypeForwardedFrom("System.Web.Routing, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public class RequestContext
    {
        public RequestContext()
        {
        }

        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "The virtual property setters are only to support mocking frameworks, in which case this constructor shouldn't be called anyway.")]
        public RequestContext(IFrameNavigationService wpfContext, RouteData routeData)
        {
            WPFContext = wpfContext ?? throw new ArgumentNullException("wpfContext");
            RouteData = routeData ?? throw new ArgumentNullException("routeData");
        }

        public virtual IFrameNavigationService WPFContext
        {
            get;
            set;
        }

        public virtual RouteData RouteData
        {
            get;
            set;
        }
    }
}