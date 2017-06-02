using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tokiku.ViewModels;
using TokikuNew.Controls;
using System.Windows.Automation.Peers;

namespace TokikuNew
{
    public class ERPDocumentViewerControlBase : System.Windows.Controls.UserControl
    {
        public ERPDocumentViewerControlBase() : base()
        {

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
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ERPDocumentViewerControlBase), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        #region 登入的使用者
        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ERPDocumentViewerControlBase), new PropertyMetadata(default(UserViewModel)));

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
