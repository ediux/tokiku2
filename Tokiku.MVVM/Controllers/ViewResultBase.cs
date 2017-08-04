using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Tokiku.MVVM
{
    public abstract class ViewResultBase : ActionResult
    {
        //private DynamicViewDataDictionary _dynamicViewData;
        //private TempDataDictionary _tempData;
        //private ViewDataDictionary _viewData;

        private string _viewName;

        public object Model
        {
            get { return SimpleIoc.Default.GetInstance(GetType()); }
        }

        public Control View { get; set; }

        public string ViewName
        {
            get { return _viewName ?? String.Empty; }
            set { _viewName = value; }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (String.IsNullOrEmpty(ViewName))
            {
                ViewName = context.RouteData.GetRequiredString("action");
            }

            FrameworkElement result = null;

            if (View == null)
            {
                result = FindView(context);
                View = result as Control;
            }

            //TextWriter writer = context.HttpContext.Response.Output;
            //ViewContext viewContext = new ViewContext(context, View, ViewData, TempData, writer);
            //View.Render(viewContext, writer);

            //if (result != null)
            //{
            //    result.ViewEngine.ReleaseView(context, View);
            //}
        }

        protected abstract FrameworkElement FindView(ControllerContext context);
    }
}