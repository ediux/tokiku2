using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Tokiku.MVVM
{
    public abstract class ControllerBase : IControllerBase
    {
        public ControllerContext ControllerContext { get; set; }

        protected virtual void Execute(RequestContext requestContext)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }

            Initialize(requestContext);
        }

        protected abstract void ExecuteCore();

        protected virtual void Initialize(RequestContext requestContext)
        {
            ControllerContext = new ControllerContext(requestContext, this);
        }

        private Control _view;

        public Control ViewData
        {
            get => ControllerContext.RouteData.Values["view"] as Control;
            set => _view = value;
        }

        #region IController Members

        void IControllerBase.Execute(RequestContext requestContext)
        {
            Execute(requestContext);
        }

        #endregion
    }
}