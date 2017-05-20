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
    public class SigningDateToCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime signingDate = (DateTime)value;

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
            return new DateTime(int.Parse(parts[0]) + 1911, DateTime.Today.Month, DateTime.Today.Day);
        }
    }
}
