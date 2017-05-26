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

namespace TokikuNew.Controls
{
    /// <summary>
    /// DockBar.xaml 的互動邏輯
    /// </summary>
    public partial class DockBar : UserControl
    {
        public DockBar()
        {
            InitializeComponent();
        }

        #region 上升事件
        
        /// <summary>
        /// 新增功能按鈕的路由事件。
        /// </summary>
        public static readonly RoutedEvent NewRequestClickEvent = 
            EventManager.RegisterRoutedEvent("NewRequestClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockBar));

        public event RoutedEventHandler NewRequestClick
        {
            add { AddHandler(NewRequestClickEvent, value); }
            remove { RemoveHandler(NewRequestClickEvent, value); }
        }
        #endregion

        /// <summary>
        /// 指出是否可以被編輯
        /// </summary>
        public bool CanEdit
        {
            get { return (bool)GetValue(CanEditProperty); }
            set { SetValue(CanEditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(DockBar), new PropertyMetadata(true));

        private void btnF1_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RaiseEvent(new RoutedEventArgs(NewRequestClickEvent, sender));
        }

        private void btnF2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           
        }

        private void btnF3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            var temp = sender;
        }
    }
}
