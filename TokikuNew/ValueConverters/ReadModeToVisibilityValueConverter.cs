using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Tokiku.ViewModels;

namespace TokikuNew.ValueConverters
{
    public class ReadModeToVisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (value is DocumentLifeCircle)
                    {
                        if (targetType == typeof(Visibility))
                        {
                            DocumentLifeCircle document_mode = (DocumentLifeCircle)value;
                            switch (document_mode)
                            {
                                case DocumentLifeCircle.Delete:
                                case DocumentLifeCircle.Read:
                                    return Visibility.Hidden;
                                case DocumentLifeCircle.Create:
                                case DocumentLifeCircle.Save:
                                case DocumentLifeCircle.Update:
                                    return Visibility.Visible;
                            }
                        }
                    }
                }

                return value;
            }
            catch
            {
                if (targetType == typeof(string))
                {
                    return "#Error";
                }
                return value;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (value is Visibility)
                    {
                        if (targetType == typeof(DocumentLifeCircle))
                        {
                            if (parameter is string)
                            {
                                Visibility document_visibility = (Visibility)value;
                                string backmode = ((string)parameter).ToLowerInvariant();
                                switch (backmode)
                                {
                                    case "read":
                                        return DocumentLifeCircle.Read;
                                    case "create":
                                        return DocumentLifeCircle.Create;
                                    case "delete":
                                        return DocumentLifeCircle.Delete;
                                    case "save":
                                        return DocumentLifeCircle.Save;
                                    case "update":
                                        return DocumentLifeCircle.Update;
                                }

                            }

                            if (parameter is DocumentLifeCircle)
                            {
                                return (DocumentLifeCircle)parameter;
                            }

                        }
                    }
                }

                throw new NotSupportedException();
            }
            catch
            {
                if (targetType == typeof(string))
                {
                    return "#Error";
                }
                return value;
            }
        }
    }
}
