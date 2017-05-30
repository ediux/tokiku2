using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.ValueConverters
{
    public class ReadModeToDisabledControllerValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DocumentLifeCircle)
            {
                DocumentLifeCircle DocMode = (DocumentLifeCircle)value;
                if (DocMode == DocumentLifeCircle.Create ||
                    DocMode == DocumentLifeCircle.Update)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if (parameter is DocumentLifeCircle)
                {
                    switch ((DocumentLifeCircle)parameter)
                    {
                        default:
                        case DocumentLifeCircle.Create:
                        case DocumentLifeCircle.Update:
                            return true;
                        case DocumentLifeCircle.Read:
                        case DocumentLifeCircle.Delete:
                        case DocumentLifeCircle.Save:
                            return false;
                    }
                }
            }
            return value;
        }
    }
}
