using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tokiku.Controllers;

namespace TokikuNew.ValueConverters
{
    public class StatesCodeToTextValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (value.GetType() == typeof(byte))
                    {
                        StateController controller = new StateController();

                        var result = controller.Query(q => q.Id == (byte)value);

                        if (result != null)
                            return result.StateName;
                        else
                            return string.Empty;
                    }
                }


                return value;
            }
            catch
            {
                return "#Error";

            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value.GetType() == typeof(string))
                {
                    StateController controller = new StateController();

                    var result = controller.Query(q => q.StateName == (string)value);

                    if (result != null)
                        return result.Id;

                    return (byte)0;
                }

                return value;
            }
            catch
            {
                return (byte)0;
            }
        }
    }
}
