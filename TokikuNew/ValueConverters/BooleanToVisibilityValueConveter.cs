using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TokikuNew.ValueConverters
{
    public class BooleanToVisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                if (value is bool)
                {
                    if ((bool)value)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Hidden;
                    }

                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(bool))
            {
                if (value is Visibility)
                {
                    if (((Visibility)value) == Visibility.Visible)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }

            return value;
        }
    }
}
