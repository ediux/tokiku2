using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.ViewModels.Shared;

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



        public SearchBarViewModel SearchBarBinding
        {
            get { return (SearchBarViewModel)GetValue(SearchBarBindingProperty); }
            set { SetValue(SearchBarBindingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchBarBinding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchBarBindingProperty =
            DependencyProperty.Register("SearchBarBinding", typeof(SearchBarViewModel), typeof(SearchBar), new PropertyMetadata(null, new PropertyChangedCallback(ViewModelChange)));


        public static void ViewModelChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender != null && sender is SearchBar)
                {
                    SearchBar source = (SearchBar)sender;

                    SearchBarViewModel ori = (SearchBarViewModel)e.OldValue;
                    SearchBarViewModel current = (SearchBarViewModel)e.NewValue;

                    SearchBarViewModel inside = (SearchBarViewModel)source.TryFindResource("SearchBarSource");

                    if (inside != null)
                    {
                        inside.QueryCommand = current.QueryCommand;
                        inside.RefreshCommand = current.RefreshCommand;
                        inside.ResetCommand = current.ResetCommand;                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    btnQuery.Command.Execute(DataContext);
                }
                else
                {
                    if (e.Key == Key.Escape)
                    {
                        e.Handled = true;
                        tbSearchBar.Text = "";
                        btnQuery.Command.Execute(DataContext);
                        //btnRefresh.Command.Execute(tbSearchBar.Text);

                        //RoutedUICommand ResetQueryCommand = (RoutedUICommand)FindResource("ResetFiliter");

                        //if (ResetQueryCommand != null)
                        //{
                        //    ResetQueryCommand.Execute(tbSearchBar.Text, tbSearchBar);
                        //}
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void Button_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
            Keyboard.Focus((Button)sender);
        }

        private void btnRefresh_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
            Keyboard.Focus((Button)sender);
        }
    }
}
