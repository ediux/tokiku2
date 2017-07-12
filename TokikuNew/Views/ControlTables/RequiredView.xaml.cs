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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// RequiredView.xaml 的互動邏輯
    /// </summary>
    public partial class RequiredView : UserControl
    {
        public RequiredView()
        {
            InitializeComponent();
        }

        private void RequiredView_Loaded(object sender, RoutedEventArgs e)
        {
            RequiredViewModelCollection ctrl = new RequiredViewModelCollection();
            CheckGrid.DataContext = ctrl;
            ctrl.Query();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生需求單"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
