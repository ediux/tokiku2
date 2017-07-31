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
    /// SystemUserSelector.xaml 的互動邏輯
    /// </summary>
    public partial class SystemUserSelector : UserControl
    {
        public SystemUserSelector()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 已選定的使用者
        /// </summary>
        public Guid SelectedUserId
        {
            get { return (Guid)GetValue(SelectedUserIdProperty); }
            set { SetValue(SelectedUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedUserIdProperty =
            DependencyProperty.Register("SelectedUserId", typeof(Guid), typeof(SystemUserSelector), new PropertyMetadata(Guid.Empty));


    }
}
