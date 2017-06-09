using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TokikuNew.Controls
{
    /// <summary>
    /// 用來替換Tab控制項的面板用控制項
    /// </summary>
    public partial class ClosableTab : UserControl
    {
        public ClosableTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 當關閉分頁時引發的事件處理。
        /// </summary>
        /// <remarks>
        /// 引發獨立的自訂路由事件，由外層UI元素進行對應攔截事件訊息。
        /// </remarks>
        private void btnTabClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoutedEventArgs eu = new RoutedEventArgs(ButtonBase.ClickEvent, btnTabClose);
                base.RaiseEvent(eu);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }
    }
}
