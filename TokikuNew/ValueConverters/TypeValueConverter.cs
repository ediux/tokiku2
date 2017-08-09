using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TokikuNew.ValueConverters
{
    public class TypeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value.GetType() != targetType)
            {
                if (parameter is Type)
                {
                    return System.Convert.ChangeType(value, (Type)parameter);
                }
                return System.Convert.ChangeType(value, targetType);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != targetType)
            {
                if (parameter is Type)
                {
                    return System.Convert.ChangeType(value, (Type)parameter);
                }

                return System.Convert.ChangeType(value, targetType);
            }

            return value;
        }
    }
}
