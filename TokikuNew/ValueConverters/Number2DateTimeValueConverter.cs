using System;
using System.Globalization;
using System.Windows.Data;

namespace TokikuNew.ValueConverters
{
    public class Number2DateTimeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if(value is byte  )
                {
                    DateTime time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, (int)value);
                    return time;
                }

                if (value is short)
                {
                    DateTime time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, (int)value);
                    return time;
                }
                if (value is int)
                {
                    DateTime time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, (int)value);
                    return time;
                }

                return value;
            }
            catch 
            {

                return DateTime.Today;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {
                if(value is DateTime)
                {
                    if (targetType == typeof(byte))
                        return (byte)((DateTime)value).Day;

                    if (targetType == typeof(short))
                        return (short)((DateTime)value).Day;

                    if (targetType == typeof(int))
                        return (int)((DateTime)value).Day;
                }

                return value;
            }
            catch 
            {

                return 0;
            }
        }
    }
}
