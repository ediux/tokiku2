﻿using System;
using System.Globalization;
using System.Windows.Data;
using Tokiku.ViewModels;

namespace TokikuNew.ValueConverters
{
    public class ReadModeToEnabledValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DocumentLifeCircle)
            {
                DocumentLifeCircle DocMode = (DocumentLifeCircle)value;
                if (DocMode == DocumentLifeCircle.Create ||
                    DocMode == DocumentLifeCircle.Update)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if (parameter is DocumentLifeCircle)
                {
                    switch ((DocumentLifeCircle)parameter)
                    {
                        default:
                        case DocumentLifeCircle.Create:
                        case DocumentLifeCircle.Update:
                            return false;
                        case DocumentLifeCircle.Read:
                        case DocumentLifeCircle.Delete:
                        case DocumentLifeCircle.Save:
                            return true;
                    }
                }
            }
            return value;
        }

       
    }
}
