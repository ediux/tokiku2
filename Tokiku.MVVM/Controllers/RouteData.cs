using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tokiku.MVVM
{
    [TypeForwardedFrom("System.Web.Routing, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public class RouteData
    {
        private IRouteHandler _routeHandler;
        private RouteValueDictionary _values = new RouteValueDictionary();
        private RouteValueDictionary _dataTokens = new RouteValueDictionary();

        public RouteData()
        {
        }

        public RouteData(IRouteHandler routeHandler)
        {

            RouteHandler = routeHandler;
        }

        public RouteValueDictionary DataTokens
        {
            get
            {
                return _dataTokens;
            }
        }

        public IRouteHandler RouteHandler
        {
            get
            {
                return _routeHandler;
            }
            set
            {
                _routeHandler = value;
            }
        }

        public RouteValueDictionary Values
        {
            get
            {
                return _values;
            }
        }

        public string GetRequiredString(string valueName)
        {
            object value;
            if (Values.TryGetValue(valueName, out value))
            {
                string valueString = value as string;
                if (!String.IsNullOrEmpty(valueString))
                {
                    return valueString;
                }
            }
            return string.Empty;
            //throw new InvalidOperationException(
            //String.Format(
            //    CultureInfo.CurrentUICulture,
            //    SR.GetString(SR.RouteData_RequiredValue),
            //    valueName));
        }
    }
}