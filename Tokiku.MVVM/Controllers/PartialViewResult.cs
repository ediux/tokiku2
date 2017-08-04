using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Tokiku.MVVM
{
    public class PartialViewResult : ViewResultBase
    {
        protected override FrameworkElement FindView(ControllerContext context)
        {
           //context.RequestContext.WPFContext.
            VisualTreeHelper result = VisualTreeHelper.GetChildrenCount(, ViewName);

            //if (result.View != null)
            //{
            //    return result;
            //}

            //// we need to generate an exception containing all the locations we searched
            //StringBuilder locationsText = new StringBuilder();
            //foreach (string location in result.SearchedLocations)
            //{
            //    locationsText.AppendLine();
            //    locationsText.Append(location);
            //}
            //throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
            //                                                  Properties.Resources.Common_PartialViewNotFound, ViewName, locationsText));
        }
    }
}