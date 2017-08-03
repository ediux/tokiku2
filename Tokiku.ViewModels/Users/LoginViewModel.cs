using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class LoginViewModel : BaseViewModelWithPOCOClass<Users>, ILoginViewModel
    {

        //private StartUpWindowController _controller = null;
        [System.ComponentModel.Composition.ImportingConstructor]
        public LoginViewModel()
        {
            RelayCommand = new LoginCommand(new Action<object>(Login));
            //_controller = controller;
        }

        //public LoginViewModel(Users entity) : base(entity)
        //{
        //    RelayCommand = new LoginCommand(new Action<object>(Login));

        //}
        //public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(LoginViewModel), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string UserName { get { return CopyofPOCOInstance.UserName ?? string.Empty; } set { CopyofPOCOInstance.UserName = value; RaisePropertyChanged("UserName"); } }

        //public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(LoginViewModel), new PropertyMetadata(string.Empty));
        public override string SaveModelController { get => "StartUpWindow"; set { } }
        /// <summary>
        /// 登入密碼
        /// </summary>
        public string Password { get {
                try
                {
                    return CopyofPOCOInstance?.Membership?.Password ?? string.Empty;

                }
                catch 
                {
                    return string.Empty;
                }
            } set { if (CopyofPOCOInstance.Membership == null) { CopyofPOCOInstance.Membership = new Membership(); } CopyofPOCOInstance.Membership.Password = value; RaisePropertyChanged("Password"); } }


        public void Login(object Parameter)
        {
            try
            {
                var reult = ExecuteAction<Users>("StartUpWindow", "Login", UserName, Password);

                if (reult != null)
                {
                    LoginCommand Login = (LoginCommand)RelayCommand;
                    RedirectCommand Redirect = new RedirectCommand();
                    //Redirect.SourceInstance = Login.SourceInstance;
                    Redirect.Execute(Parameter);
                    //((Window)Redirect.SourceInstance).Close();
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                RaisePropertyChanged("Errors");
            }

            //_controller.Login(UserName, Password);

            //if (!reult.HasError)
            //{
            //    UserViewModel model = new UserViewModel(reult.Result);
            //    return model;
            //}
            //else
            //{
            //    return new UserViewModel()
            //    {
            //        Errors = reult.Errors,
            //        HasError = reult.HasError
            //    };
            //}

        }
    }
}
