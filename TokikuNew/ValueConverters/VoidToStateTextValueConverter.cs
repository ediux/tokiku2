using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TokikuNew.ValueConverters
{
    class VoidToStateTextValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if(value is bool)
                {
                    if ((bool)value)
                    {
                        return "停用";
                    }
                    else
                    {
                        return "啟用";
                    }
                }

                return value;
            }
            catch
            {
                if (targetType == typeof(string))
                {
                    return "#ERROR";
                }

                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if(value is string)
                {
                    if ((string)value == "啟用")
                        return false;
                    else if((string)value== "停用")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return value;
            }
            catch
            {
                if (targetType == typeof(string))
                {
                    return "#ERROR";
                }

                return false;
            }
        }
    }
}
