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
using WPF.Themes;

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

        
        private void ThemeSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Application.Current.ApplyTheme((string)ThemeSelection.SelectedValue);
        
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            ThemeSelection.ItemsSource = ThemeManager.GetThemes();         
            ThemeSelection.SelectedValuePath = "Key";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
