namespace WPF.Themes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    public static class ThemeManager
    {
        private static Dictionary<string, Uri> _Themes;

        public static ResourceDictionary GetThemeResourceDictionary(string theme)
        {
            if (theme != null)
            {
                //Assembly assembly = Assembly.LoadFrom("WPF.Themes.dll");
                //string packUri = String.Format(@"/WPF.Themes;component/{0}/Theme.xaml", theme);
                //return Application.LoadComponent(new Uri(packUri, UriKind.Relative)) as ResourceDictionary;
                return new ResourceDictionary() { Source = _Themes[theme] };
            }
            return null;
        }

        public static Dictionary<string, Uri> GetThemes()
        {
            if (_Themes == null)
            {
                _Themes = new Dictionary<string, Uri>();

                _Themes.Add("BureauBlack", new Uri("/Themes/BureauBlack.xaml", UriKind.Relative));
                _Themes.Add("BureauBlue", new Uri("/Themes/BureauBlue.xaml", UriKind.Relative));
                _Themes.Add("ExpressionDark", new Uri("/Themes/ExpressionDark.xaml", UriKind.Relative));
                _Themes.Add("ExpressionLight", new Uri("/Themes/ExpressionLight.xaml", UriKind.Relative));
                _Themes.Add("ShinyBlue", new Uri("/Themes/ShinyBlue.xaml", UriKind.Relative));
                _Themes.Add("ShinyRed", new Uri("/Themes/ShinyRed.xaml", UriKind.Relative));
                _Themes.Add("WhistlerBlue", new Uri("/Themes/ShinyRed.xaml", UriKind.Relative));
                //_Themes.Add("ExpressionDark", new Uri("/WPF.Themes;component/ExpressionDark/Theme.xaml", UriKind.Relative));
                //new string[] {
                //    "ExpressionDark", "ExpressionLight", 
                ////"RainierOrange", "RainierPurple", "RainierRadialBlue", 
                //"ShinyBlue", "ShinyRed", 
                ////"ShinyDarkTeal", "ShinyDarkGreen", "ShinyDarkPurple",
                //"DavesGlossyControls",
                //"WhistlerBlue",
                //"BureauBlack", "BureauBlue",
                //"BubbleCreme",
                //"TwilightBlue",
                //"UXMusingsRed", "UXMusingsGreen", 
                ////"UXMusingsRoughRed", "UXMusingsRoughGreen", 
                //"UXMusingsBubblyBlue"
                //});
            }

            return _Themes;
        }

        public static void ApplyTheme(this Application app, string theme)
        {
            ResourceDictionary dictionary = GetThemeResourceDictionary(theme);

            if (dictionary != null)
            {
                app.Resources.MergedDictionaries.Clear();
                app.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/Global.xaml", UriKind.Relative) });
                app.Resources.MergedDictionaries.Add(dictionary);
                app.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/SystemStrings.xaml", UriKind.Relative) });
                app.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/MyTheme.xaml", UriKind.Relative) });
            }
        }

        public static void ApplyTheme(this ContentControl control, string theme)
        {
            ResourceDictionary dictionary = GetThemeResourceDictionary(theme);

            if (dictionary != null)
            {
                control.Resources.MergedDictionaries.Clear();
                control.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        #region Theme

        /// <summary>
        /// Theme Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.RegisterAttached("Theme", typeof(string), typeof(ThemeManager),
                new FrameworkPropertyMetadata((string)string.Empty,
                    new PropertyChangedCallback(OnThemeChanged)));

        /// <summary>
        /// Gets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static string GetTheme(DependencyObject d)
        {
            return (string)d.GetValue(ThemeProperty);
        }

        /// <summary>
        /// Sets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetTheme(DependencyObject d, string value)
        {
            d.SetValue(ThemeProperty, value);
        }

        /// <summary>
        /// Handles changes to the Theme property.
        /// </summary>
        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string theme = e.NewValue as string;
            if (theme == string.Empty)
                return;

            ContentControl control = d as ContentControl;
            if (control != null)
            {
                control.ApplyTheme(theme);
            }
        }

        #endregion



    }
}
