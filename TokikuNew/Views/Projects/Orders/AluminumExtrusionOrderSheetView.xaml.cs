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
    /// AluminumExtrusionOrderSheetView.xaml 的互動邏輯
    /// </summary>
    public partial class AluminumExtrusionOrderSheetView : UserControl
    {
        public AluminumExtrusionOrderSheetView()
        {
            InitializeComponent();
        }

        #region Document Mode

        /// <summary>
        /// 目前載入的文件所處的模式
        /// </summary>
        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(AluminumExtrusionOrderSheetView), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        #region 登入的使用者
        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(AluminumExtrusionOrderSheetView), new PropertyMetadata(default(UserViewModel)));

        /// <summary>
        /// 登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }
        #endregion
    }
}
