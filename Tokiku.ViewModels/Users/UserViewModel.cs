using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class UserViewModel : BaseViewModel,IBaseViewModel
    {
        public UserViewModel()
        {
            Status = new DocumentStatusViewModel();
        }
        public Guid UserId
        {
            get { return (Guid )GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserIdProperty =
            DependencyProperty.Register("UserId", typeof(Guid ), typeof(UserViewModel), new PropertyMetadata(Guid.NewGuid(),new PropertyChangedCallback(DefaultFieldChanged)));



        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(UserViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        public string LoweredUserName
        {
            get { return (string)GetValue(LoweredUserNameProperty); }
            set { SetValue(LoweredUserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoweredUserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoweredUserNameProperty =
            DependencyProperty.Register("LoweredUserName", typeof(string), typeof(UserViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));




        public string MobileAlias
        {
            get { return (string)GetValue(MobileAliasProperty); }
            set { SetValue(MobileAliasProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MobileAlias.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MobileAliasProperty =
            DependencyProperty.Register("MobileAlias", typeof(string), typeof(UserViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));



        public bool IsAnonymous
        {
            get { return (bool)GetValue(IsAnonymousProperty); }
            set { SetValue(IsAnonymousProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAnonymous.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAnonymousProperty =
            DependencyProperty.Register("IsAnonymous", typeof(bool), typeof(UserViewModel), new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));




        public DateTime LastActivityDate
        {
            get { return (DateTime)GetValue(LastActivityDateProperty); }
            set { SetValue(LastActivityDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastActivityDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastActivityDateProperty =
            DependencyProperty.Register("LastActivityDate", typeof(DateTime), typeof(UserViewModel), new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(DefaultFieldChanged)));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(UserViewModel), new PropertyMetadata(string.Empty));


    }
}
