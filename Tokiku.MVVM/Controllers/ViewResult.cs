using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;

namespace Tokiku.MVVM
{
    public class ViewResult : ViewResultBase
    {
        private string _masterName;

        public string MasterName
        {
            get { return _masterName ?? String.Empty; }
            set { _masterName = value; }
        }

        protected override FrameworkElement FindView(ControllerContext context)
        {
            //ViewEngineResult result = ViewEngineCollection.FindView(context, ViewName, MasterName);
            //if (result.View != null)
            //{
            //    return result;
            //}

            // we need to generate an exception containing all the locations we searched
            StringBuilder locationsText = new StringBuilder();
            //foreach (string location in result.SearchedLocations)
            //{
            //    locationsText.AppendLine();
            //    locationsText.Append(location);
            //}
            throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                                              Properties.Resources.Common_ViewNotFound, ViewName, locationsText));
        }
    }
}