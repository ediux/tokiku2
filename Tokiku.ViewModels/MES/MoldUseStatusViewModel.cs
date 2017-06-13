using System;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MoldUseStatusViewModel : BaseViewModelWithPOCOClass<MoldUseStatus>
    {
        #region Id

        /// <summary>
        /// 模具使用狀況編號        
        /// </summary>
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(MoldUseStatusViewModel), new PropertyMetadata(1));


        #endregion

        #region Name


        /// <summary>
        /// 使用狀況名稱
        /// </summary>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(MoldUseStatusViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region CreateTime


        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(MoldUseStatusViewModel), new PropertyMetadata(DateTime.Now));


        #endregion

        #region CreateUserId


        /// <summary>
        /// 建立人員ID
        /// </summary>
        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(MoldUseStatusViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region CreateUser
        /// <summary>
        /// 建立的使用者
        /// </summary>
        public UserViewModel CreateUser
        {
            get { return (UserViewModel)GetValue(CreateUserProperty); }
            set { SetValue(CreateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserProperty =
            DependencyProperty.Register("CreateUser", typeof(UserViewModel), typeof(MoldUseStatusViewModel), new PropertyMetadata(default(UserViewModel)));

        #endregion
    }
}
