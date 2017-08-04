using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.MVVM
{
    public class FrameworkElementNotFoundResult : ActionResult
    {

        public FrameworkElementNotFoundResult()
        {
        }

        public FrameworkElementNotFoundResult( string statusDescription)
        {
            StatusDescription = statusDescription;
        }

        public string StatusDescription { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            //context.HttpContext.Response.StatusCode = StatusCode;
            if (StatusDescription != null)
            {
                //context.HttpContext.Response.StatusDescription = StatusDescription;
            }
        }
    }
}