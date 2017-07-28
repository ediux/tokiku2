using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tokiku.Controllers;
using Tokiku.ViewModels;

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
                        if (parameter is StatesViewModelCollection)
                        {
                            System.Windows.FrameworkElement frame = new System.Windows.FrameworkElement();

                            StatesViewModelCollection source = (StatesViewModelCollection)frame.FindResource("StatesSource");

                            //if (source.Count == 0)
                            //    source.Query();

                            var result = source.Where(q => q.Id == (byte)value).SingleOrDefault();

                            if (result != null)
                                return result.StateName;
                            else
                                return string.Empty;
                        }
                        else
                        {
                            StateController controller = new StateController();

                            var result = controller.Query(q => q.Id == (byte)value);

                            if (result.Result != null && result.HasError == false)
                                return result.Result.Single().StateName;
                            else
                                return string.Empty;
                        }

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
                    if (parameter is StatesViewModelCollection)
                    {
                        System.Windows.FrameworkElement frame = new System.Windows.FrameworkElement();

                        StatesViewModelCollection source = (StatesViewModelCollection)frame.FindResource("StatesSource");

                        //if (source.Count == 0)
                        //    source.Query();

                        var result = source.Where(q => q.StateName == (string)value).SingleOrDefault();

                        if (result != null)
                            return result.Id;
                    }
                    else
                    {
                        StateController controller = new StateController();

                        var result = controller.Query(q => q.StateName == (string)value);

                        if (result != null)
                            return result.Result.Single().Id;

                    }


                    return default(byte?);
                }

                return value;
            }
            catch
            {
                return default(byte?);
            }
        }
    }
}
