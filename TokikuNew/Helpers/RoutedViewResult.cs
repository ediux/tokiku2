using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokikuNew.Helpers
{
    public class RoutedViewResult
    {
        public RoutedViewResult()
        {
            RoutedValues = new Dictionary<string, object>();
        }
        public string DisplayText { get; set; }
        public string FormatedDisplay { get; set; }
        public object[] FormatedParameters { get; set; }

        public Type ViewType { get; set; }
        public object DataContent { get; set; }
        public Dictionary<string,object> RoutedValues { get; set; }

    }
}
