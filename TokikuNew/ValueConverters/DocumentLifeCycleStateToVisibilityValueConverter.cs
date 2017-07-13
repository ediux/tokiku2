using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Tokiku.ViewModels;

namespace TokikuNew.ValueConverters
{
    public class DocumentLifeCycleStateToVisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                if (value is DocumentLifeCircle)
                {
                    switch ((DocumentLifeCircle)value)
                    {
                        case DocumentLifeCircle.Create:
                        case DocumentLifeCircle.Update:
                        default:
                            return Visibility.Visible;
                        case DocumentLifeCircle.Delete:
                        case DocumentLifeCircle.Read:
                        case DocumentLifeCircle.Save:
                            return Visibility.Hidden;
                    }

                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(DocumentLifeCircle))
            {
                if (value is Visibility)
                {
                    switch ((Visibility)value)
                    {
                        case Visibility.Collapsed:
                        case Visibility.Hidden:
                            return DocumentLifeCircle.Read;
                        default:
                            return DocumentLifeCircle.Update;
                    }
                }
            }

            return value;
        }
    }
}
