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
using System.Windows.Shapes;
using Tokiku.ViewModels;

namespace TokikuNew.Frame
{
    /// <summary>
    /// StartUpWindow.xaml 的互動邏輯
    /// </summary>
    public partial class StartUpWindow : Window
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(LoginViewModel), typeof(StartUpWindow), new PropertyMetadata(default(LoginViewModel)));

        public LoginViewModel Model
        {
            get { return GetValue(ModelProperty) as LoginViewModel; }
            set { SetValue(ModelProperty, value); }
        }

        public StartUpWindow()
        {
            InitializeComponent();
            Model = new LoginViewModel();
            this.DataContext = Model;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            tblkMessage.Text = "正在登入...";
            tblkMessage.Foreground = new SolidColorBrush(Colors.Black);
            Model.Password = pwdBox.Password;

            var loginedUser = Model.Login();
            if (loginedUser != null)
            {
                tblkMessage.Text = "登入成功!";
                MainWindow mainwin = new MainWindow();
                mainwin.Model = new MainViewModel();
                mainwin.Model.LoginedUser = loginedUser;
                mainwin.DataContext = mainwin.Model;
                mainwin.Closed += Mainwin_Closed;
                mainwin.Show();
                tblkMessage.Text = "";
                this.Hide();
            }
            else
            {
                tblkMessage.Text = "登入失敗!";
                tblkMessage.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Mainwin_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
