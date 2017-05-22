using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TokikuNew.Frame
{
    public class ThemeResourceDictionary : ResourceDictionary
    {
    }

    /// <summary>
    /// OptionWindow.xaml 的互動邏輯
    /// </summary>
    public partial class OptionWindow : Window
    {
        public OptionWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CurrentThemeDictionaryProperty =
 DependencyProperty.RegisterAttached("CurrentThemeDictionary", typeof(Uri),
 typeof(OptionWindow),
 new UIPropertyMetadata(null, CurrentThemeDictionaryChanged));

        public static Uri GetCurrentThemeDictionary(DependencyObject obj)
        {
            return (Uri)obj.GetValue(CurrentThemeDictionaryProperty);
        }

        public static void SetCurrentThemeDictionary(DependencyObject obj, Uri value)
        {
            obj.SetValue(CurrentThemeDictionaryProperty, value);
        }

        private static void CurrentThemeDictionaryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is FrameworkElement) // works only on FrameworkElement objects
            {
                ApplyTheme(obj as FrameworkElement, GetCurrentThemeDictionary(obj));
            }
        }

        private static void ApplyTheme(FrameworkElement targetElement, Uri dictionaryUri)
        {
            if (targetElement == null) return;

            try
            {
                ResourceDictionary themeDictionary = null;
                if (dictionaryUri != null)
                {
                    themeDictionary = new ResourceDictionary();
                    themeDictionary.Source = dictionaryUri;

                    // add the new dictionary to the collection of merged dictionaries of the target object
                    //targetElement.Resources.MergedDictionaries.Insert(0, themeDictionary);
                    Application.Current.Resources.MergedDictionaries.Insert(0, themeDictionary);
                }

                // find if the target element already has a theme applied
                List<ResourceDictionary> existingDictionaries =
                    (from dictionary in Application.Current.Resources.MergedDictionaries.OfType<ResourceDictionary>()
                     select dictionary).ToList();

                // remove the existing dictionaries
                foreach (ResourceDictionary thDictionary in existingDictionaries)
                {
                    if (themeDictionary == thDictionary) continue;  // don't remove the newly added dictionary
                    Application.Current.Resources.MergedDictionaries.Remove(thDictionary);
                }
            }
            finally { }
        }

        private void ThemeSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)e.AddedItems[0];
            SetCurrentThemeDictionary(this, new Uri(item.Tag.ToString(),UriKind.Relative));
        }
    }
}
