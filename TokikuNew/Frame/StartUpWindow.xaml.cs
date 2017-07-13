using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Tokiku.Controllers;
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
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tblkMessage.Text = "正在登入...";
                tblkMessage.Foreground = new SolidColorBrush(Colors.Black);
                Model.Password = pwdBox.Password;


                var loginedUser = Model.Login();

                if (loginedUser.HasError)
                {
                    tblkMessage.Text = loginedUser.Errors.First();
                    tblkMessage.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (loginedUser != null)
                    {
                        tblkMessage.Text = "登入成功!";


                        var mainwin = App.Navigate<MainWindow, MainViewModel>(new MainViewModel(App.Resolve<ProjectsController>()));


                        mainwin.Closed += Mainwin_Closed;
                        mainwin.Show();

                        tblkMessage.Text = "";
                        tbUserName.Text = "";
                        pwdBox.Password = "";
                        Hide();
                    }
                    else
                    {
                        tblkMessage.Text = "登入失敗!";
                        tblkMessage.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }



        }

        private void Mainwin_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter & (sender as TextBox).AcceptsReturn == false) MoveToNextUIElement(e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        void MoveToNextUIElement(KeyEventArgs e)
        {
            try
            {
                // Creating a FocusNavigationDirection object and setting it to a
                // local field that contains the direction selected.
                FocusNavigationDirection focusDirection = FocusNavigationDirection.Next;

                // MoveFocus takes a TraveralReqest as its argument.
                TraversalRequest request = new TraversalRequest(focusDirection);

                // Gets the element with keyboard focus.
                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

                // Change keyboard focus.
                if (elementWithFocus != null)
                {
                    if (elementWithFocus.MoveFocus(request)) e.Handled = true;
                }
            }
            catch
            {


            }

        }

        private void pwdBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter) { btnLogin_Click(sender, new RoutedEventArgs(e.RoutedEvent)); }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void window_Initialized(object sender, EventArgs e)
        {
            try
            {
                Model = new LoginViewModel(App.Resolve<StartUpWindowController>());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Model.Initialized();
                DataContext = Model;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }
    }
}
