using System;
using System.Windows;
using System.Windows.Controls;
using Tokiku.ViewModels;

namespace TokikuNew.Controls
{
    /// <summary>
    /// SearchBar.xaml 的互動邏輯
    /// </summary>
    public partial class SearchBar : UserControl
    {
        public SearchBar()
        {
            InitializeComponent();
        }

        public string Prefix
        {
            get { return (string)GetValue(PrefixProperty); }
            set { SetValue(PrefixProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Prefix.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrefixProperty =
            DependencyProperty.Register("Prefix", typeof(string), typeof(SearchBar), new PropertyMetadata(string.Empty,new PropertyChangedCallback(PrefixChange)));


        public static void PrefixChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ViewModelLocator.Current.SearchBarViewModel.Prefix = (string)e.NewValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

    }
}
