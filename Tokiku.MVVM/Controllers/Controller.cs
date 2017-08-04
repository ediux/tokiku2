using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Tokiku.MVVM
{
    public abstract class Controller : ControllerBase
    {
        private IDependencyResolver _resolver;

        /// <summary>
        /// Represents a replaceable dependency resolver providing services.
        /// By default, it uses the <see cref="DependencyResolver.CurrentCache"/>. 
        /// </summary>
        public IDependencyResolver Resolver
        {
            get { return _resolver ?? DependencyResolver.CurrentCache; }
            set { _resolver = value; }
        }

        public IFrameNavigationService WPFContext
        {
            get { return ControllerContext == null ? null : ControllerContext.WPFContext; }
        }

        public RouteData RouteData
        {
            get { return ControllerContext == null ? null : ControllerContext.RouteData; }
        }

        private static string GetActionName(RouteData routeData)
        {
            Contract.Assert(routeData != null);
            
            return routeData.GetRequiredString("action");
            //// If this is an attribute routing match then the 'RouteData' has a list of sub-matches rather than
            //// the traditional controller and action values. When the match is an attribute routing match
            //// we'll pass null to the action selector, and let it choose a sub-match to use.
            //if (routeData.HasDirectRouteMatch())
            //{
            //    return null;
            //}
            //else
            //{

            //}
        }

        protected virtual void HandleUnknownAction(string actionName)
        {
            //// If this is a direct route we might not yet have an action name
            //if (String.IsNullOrEmpty(actionName))
            //{
            //    throw new HttpException(404, String.Format(CultureInfo.CurrentCulture,
            //                               MvcResources.Controller_UnknownAction_NoActionName, GetType().FullName));
            //}
            //else
            //{
            //    throw new HttpException(404, String.Format(CultureInfo.CurrentCulture,
            //                                               MvcResources.Controller_UnknownAction, actionName, GetType().FullName));
            //}
        }

        protected internal FrameworkElementNotFoundResult HttpNotFound()
        {
            return HttpNotFound(null);
        }

        protected internal virtual FrameworkElementNotFoundResult HttpNotFound(string statusDescription)
        {
            return new FrameworkElementNotFoundResult(statusDescription);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            //base.Initialize(requestContext);
            //Url = new UrlHelper(requestContext);
        }

        protected internal PartialViewResult PartialView()
        {
            return PartialView(null /* viewName */, null /* model */);
        }

        protected internal PartialViewResult PartialView(object model)
        {
            return PartialView(null /* viewName */, model);
        }

        protected internal PartialViewResult PartialView(string viewName)
        {
            return PartialView(viewName, null /* model */);
        }

        protected internal virtual PartialViewResult PartialView(string viewName, object model)
        {
            if (model != null)
            {

                //ViewData.Model = model;
            }

            return new PartialViewResult
            {
                ViewName = viewName


            };
        }

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Response.Redirect() takes its URI as a string parameter.")]
        protected internal virtual RedirectResult Redirect(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException(Properties.Resources.Common_NullOrEmpty, "url");
            }

            return new RedirectResult(url);
        }

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Response.RedirectPermanent() takes its URI as a string parameter.")]
        protected internal virtual RedirectResult RedirectPermanent(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException(Properties.Resources.Common_NullOrEmpty, "url");
            }

            return new RedirectResult(url, permanent: true);
        }



        //protected internal bool TryValidateModel(object model)
        //{
        //    return TryValidateModel(model, null /* prefix */);
        //}

        //protected internal bool TryValidateModel(object model, string prefix)
        //{
        //    if (model == null)
        //    {
        //        throw new ArgumentNullException("model");
        //    }

        //    ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType());

        //    foreach (ModelValidationResult validationResult in ModelValidator.GetModelValidator(metadata, ControllerContext).Validate(null))
        //    {
        //        ModelState.AddModelError(DefaultModelBinder.CreateSubPropertyName(prefix, validationResult.MemberName), validationResult.Message);
        //    }

        //    return ModelState.IsValid;
        //}

        //protected internal void ValidateModel(object model)
        //{
        //    ValidateModel(model, null /* prefix */);
        //}

        //protected internal void ValidateModel(object model, string prefix)
        //{
        //    if (!TryValidateModel(model, prefix))
        //    {
        //        throw new InvalidOperationException(
        //            String.Format(
        //                CultureInfo.CurrentCulture,
        //                MvcResources.Controller_Validate_ValidationFailed,
        //                model.GetType().FullName));
        //    }
        //}

        protected internal ViewResult View()
        {
            return View(viewName: null, masterName: null, model: null);
        }

        protected internal ViewResult View(object model)
        {
            return View(null /* viewName */, null /* masterName */, model);
        }

        protected internal ViewResult View(string viewName)
        {
            return View(viewName, masterName: null, model: null);
        }

        protected internal ViewResult View(string viewName, string masterName)
        {
            return View(viewName, masterName, null /* model */);
        }

        protected internal ViewResult View(string viewName, object model)
        {
            return View(viewName, null /* masterName */, model);
        }

        protected internal virtual ViewResult View(string viewName, string masterName, object model)
        {
            if (model != null)
            {
                
            }

            return new ViewResult
            {
                ViewName = viewName,
                MasterName = masterName
            };
        }

        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#", Justification = "The method name 'View' is a convenient shorthand for 'CreateViewResult'.")]
        protected internal ViewResult View(Control view)
        {
            return View(view, null /* model */);
        }

        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#", Justification = "The method name 'View' is a convenient shorthand for 'CreateViewResult'.")]
        protected internal virtual ViewResult View(Control view, object model)
        {
            if (model != null)
            {
                view.DataContext = model;
            }

            return new ViewResult
            {
                View = view          
            };
        }

        // Keep as value type to avoid allocating
        private struct ExecuteCoreState
        {
            //internal IAsyncActionInvoker AsyncInvoker; WPF控制器不實作非同步呼叫
            internal Controller Controller;
            internal string ActionName;
        }
    }
}