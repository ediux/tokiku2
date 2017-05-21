using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Tokiku.Controllers;

namespace TokikuNew.ValueConverters
{
    public class SigningDateToCodeConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.GetType() != typeof(string))
            {
                return value;
            }

            DateTime signingDate;

            if(DateTime.TryParse((string)value,out signingDate) == false)
            {
                return value;
            }

            if (parameter.GetType() == typeof(DatePicker))
            {
                DatePicker dp = (DatePicker)parameter;
                signingDate = DateTime.Parse(dp.Text);
            }

                      
            //換成中華民國年
            var TWY = (signingDate.Year - 1911).ToString();

            ProjectsController controller = new ProjectsController();

            string nextSN = controller.GetNextProjectSerialNumber(TWY);

            return string.Format("{0}-{1}", TWY, nextSN);
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DatePicker dp = (DatePicker)parameter;

            DateTime signingDate = DateTime.Parse(dp.Text);

            //換成中華民國年
            var TWY = signingDate.Year - 1911;

            ProjectsController controller = new ProjectsController();

            string nextSN = controller.GetNextProjectSerialNumber(TWY.ToString());

            return string.Format("{0}-{1}", TWY, nextSN);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string code = (string)value;
            string[] parts = code.Split('-');
            parameter= new DateTime(int.Parse(parts[0]) + 1911, DateTime.Today.Month, DateTime.Today.Day);
            return value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
