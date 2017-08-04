using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Tokiku.MVVM
{
    public class RedirectResult : ActionResult
    {

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Response.Redirect() takes its URI as a string parameter.")]
        public RedirectResult(string url)
            : this(url, permanent: false)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Response.Redirect() takes its URI as a string parameter.")]
        public RedirectResult(string url, bool permanent)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException(Properties.Resources.Common_NullOrEmpty, "url");
            }

            Permanent = permanent;
            Url = url;
        }

        public bool Permanent { get; private set; }

        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Response.Redirect() takes its URI as a string parameter.")]
        public string Url { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.IsChildAction)
            {
                throw new InvalidOperationException(Properties.Resources.RedirectAction_CannotRedirectInChildAction);
            }

            //string destinationUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
            //context.Controller.TempData.Keep();

            //if (Permanent)
            //{
            //    context.HttpContext.Response.RedirectPermanent(destinationUrl, endResponse: false);
            //}
            //else
            //{
            //    context.HttpContext.Response.Redirect(destinationUrl, endResponse: false);
            //}
        }
    }
}