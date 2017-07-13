using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    btnQuery.Command.Execute(tbSearchBar.Text);                    
                }
                else
                {
                    if (e.Key == Key.Escape)
                    {
                        e.Handled = true;
                        tbSearchBar.Text = "";
                        //btnRefresh.Command.Execute(tbSearchBar.Text);

                        RoutedUICommand ResetQueryCommand = (RoutedUICommand)FindResource("ResetFiliter");

                        if (ResetQueryCommand != null)
                        {
                            ResetQueryCommand.Execute(tbSearchBar.Text, tbSearchBar);
                        }
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
