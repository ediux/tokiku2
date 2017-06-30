using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TokikuNew.ValueConverters
{
    public class DateTime2StringFormatingValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (targetType == typeof(string))
                {
                    string DisplayFormater = "{0:yyyy年MM月dd日}";

                    if (parameter != null)
                    {
                        DisplayFormater = (string)parameter;
                    }

                    return string.Format(DisplayFormater, value);
                }

                return value;
            }
            catch
            {

                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (targetType == typeof(DateTime))
                {
                    DateTime convertto;

                    if (DateTime.TryParse((string)value, out convertto))
                    {
                        return convertto;
                    }
                    else
                    {
                        return default(DateTime);
                    }
                }
                if (targetType == typeof(DateTime?))
                {
                    DateTime convertto;

                    if (DateTime.TryParse((string)value, out convertto))
                    {
                        return (DateTime?)convertto;
                    }
                    else
                    {
                        return default(DateTime?);
                    }
                }

                return default(DateTime?);
            }
            catch
            {
                if (targetType == typeof(DateTime))
                    return default(DateTime);

                if (targetType == typeof(DateTime?))
                    return default(DateTime?);

                return null;
            }
        }
    }
}
