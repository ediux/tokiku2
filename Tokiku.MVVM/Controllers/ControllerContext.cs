using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Windows;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    public class ControllerContext
    {
        internal const string ParentActionViewContextToken = "ParentActionViewContext";
        private IFrameNavigationService _wpfContext;
        private RequestContext _requestContext;
        private RouteData _routeData;
        private RelayCommand _RelayCommand;

        public ControllerContext()
        {

        }

        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "The virtual property setters are only to support mocking frameworks, in which case this constructor shouldn't be called anyway.")]
        protected ControllerContext(ControllerContext controllerContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            Controller = controllerContext.Controller;
            RequestContext = controllerContext.RequestContext;
        }

        public ControllerContext(IFrameNavigationService wpfContext, RouteData routeData, ControllerBase controller)
            : this(new RequestContext(wpfContext, routeData), controller)
        {
        }

        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "The virtual property setters are only to support mocking frameworks, in which case this constructor shouldn't be called anyway.")]
        public ControllerContext(RequestContext requestContext, ControllerBase controller)
        {
            RequestContext = requestContext ?? throw new ArgumentNullException("requestContext");
            Controller = controller ?? throw new ArgumentNullException("controller");
        }

        public virtual ControllerBase Controller
        {
            get; set;
        }

        public virtual IFrameNavigationService WPFContext
        {
            get
            {
                if (_wpfContext == null)
                {
                    _wpfContext = (SimpleIoc.Default != null) ? SimpleIoc.Default.GetInstance<IFrameNavigationService>() : new EmptyHttpContext();
                }

                return _wpfContext;
            }
            set { _wpfContext = value; }
        }

        public virtual bool IsChildAction
        {
            get
            {
                RouteData routeData = RouteData;

                if (routeData == null)
                {
                    return false;
                }
                return routeData.DataTokens.ContainsKey(ParentActionViewContextToken);
            }
        }

        public Uri ParentActionViewContext
        {
            get { return RouteData.DataTokens[ParentActionViewContextToken] as Uri; }
        }

        public RequestContext RequestContext
        {
            get
            {
                if (_requestContext == null)
                {
                    // still need explicit calls to constructors since the property getters are virtual and might return null
                    IFrameNavigationService wpfContext = SimpleIoc.Default.GetInstance<IFrameNavigationService>() ?? new EmptyHttpContext();
                    RouteData routeData = RouteData ?? new RouteData();

                    _requestContext = new RequestContext(wpfContext, routeData);
                }
                return _requestContext;
            }
            set { _requestContext = value; }
        }

        public virtual RouteData RouteData
        {
            get
            {
                if (_routeData == null)
                {
                    _routeData = (_requestContext != null) ? _wpfContext.RouteData : new RouteData();
                }
                return _routeData;
            }
            set { _routeData = value; }
        }

        private sealed class EmptyHttpContext : FrameNavigationService
        {
            public EmptyHttpContext() : base()
            {

            }
        }
    }
}