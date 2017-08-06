using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    public abstract class ControllerBase : IViewController
    {
        public void Execute(ControllerContext context, params object[] Paramters)
        {
            Assembly loadableasm = Assembly.Load(context.AssemblyName);
            var ControllerClassName = string.Format("{0}Controller", context.Controller);
            List<Type> findctrtypes = loadableasm.GetTypes().Where(w => w.Name == ControllerClassName && w.Namespace.ToLowerInvariant().EndsWith("controllers")).ToList();
            if (findctrtypes.Any())
            {
                foreach (var type in findctrtypes)
                {
                    var findresult = type.GetMethods().Where(w => w.Name == context.Action);

                    foreach (var methodinfo in findresult)
                    {
                        var ptypes = methodinfo.GetParameters().Select(s => s.GetType()).ToArray();

                    }
                }
            }

        }

        protected ActionResult View<TModel>(TModel model) where TModel : IBaseViewModel
        {
            return null;
        }

        protected ActionResult View<TModel>(string ViewName, TModel model) where TModel : IBaseViewModel { return null; }

        protected ActionResult PartialView<TModel>(string ViewName, TModel model) where TModel : IBaseViewModel { return null; }

        protected ActionResult Redirect(string ViewName, string Action, params object[] RouteValues) { return null; }
    }
}