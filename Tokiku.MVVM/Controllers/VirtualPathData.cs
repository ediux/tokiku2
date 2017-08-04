using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tokiku.MVVM
{
    [TypeForwardedFrom("System.Web.Routing, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public class VirtualPathData
    {
        private string _virtualPath;
        private RouteValueDictionary _dataTokens = new RouteValueDictionary();

        public VirtualPathData( string virtualPath)
        {
          
            VirtualPath = virtualPath;
        }

        public RouteValueDictionary DataTokens
        {
            get
            {
                return _dataTokens;
            }
        }

     

        public string VirtualPath
        {
            get
            {
                return _virtualPath ?? String.Empty;
            }
            set
            {
                _virtualPath = value;
            }
        }
    }
}