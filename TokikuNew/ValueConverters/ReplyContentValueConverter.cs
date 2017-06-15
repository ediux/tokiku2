using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TokikuNew.ValueConverters
{
    public class ReplyContentValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if(value is int)
                {
                    switch ((int)value)
                    {
                        case 1:
                            return "存查";
                        case 2:
                            return "同意";
                        case 3:
                            return "修正後同意";
                        case 4:
                            return "修正後送審";
                        case 5:
                            return "退件重新送審";
                        case 6:
                            return "其他:輸入文字";
                    }
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
            throw new NotImplementedException();
        }
    }
}
