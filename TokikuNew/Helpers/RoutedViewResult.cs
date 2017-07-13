using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokikuNew.Helpers
{
    public class RoutedViewResult
    {
        public string DisplayText { get; set; }
        public string FormatedDisplay { get; set; }
        public object[] FormatedParameters { get; set; }

        public Type ViewType { get; set; }
        public object DataContent { get; set; }
        public object[] RoutedValues { get; set; }

    }
}
