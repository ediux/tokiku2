using System;
using System.Globalization;
using System.Windows.Data;

namespace TokikuNew.ValueConverters
{
    public class RadioButtonSwitchValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(bool))
            {
                bool inval = (bool)value;

                if (inval)
                {
                    return parameter;
                }
                else
                {
                    return null;
                }

            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(parameter))
            {
                return true;
            }
            return false;
        }
    }
}
