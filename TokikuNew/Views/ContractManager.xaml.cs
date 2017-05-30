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
using Tokiku.Controllers;
using Tokiku.ViewModels;
using TokikuNew.Controls;
using WinForm = System.Windows.Forms;

namespace TokikuNew.Views
{
    /// <summary>
    /// ContractManager.xaml 的互動邏輯
    /// </summary>
    public partial class ContractManager : UserControl
    {
        public ContractManager()
        {
            InitializeComponent();
        }

        private ProjectContractController controller = new ProjectContractController();

        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ContractManager), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion



        public EngineeringViewModel SelectedEngineering
        {
            get { return (EngineeringViewModel)GetValue(SelectedEngineeringProperty); }
            set { SetValue(SelectedEngineeringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedEngineeringProperty =
            DependencyProperty.Register("SelectedEngineering", typeof(int), typeof(ContractManager), new PropertyMetadata(default(EngineeringViewModel)));




        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ContractManager), new PropertyMetadata(default(UserViewModel)));

        public static readonly RoutedEvent SendNewPageRequestEvent = EventManager.RegisterRoutedEvent("SendNewPageRequest", RoutingStrategy.Bubble
        , typeof(RoutedEventHandler), typeof(ContractManager));

        public event RoutedEventHandler SendNewPageRequest
        {
            add { AddHandler(SendNewPageRequestEvent, value); }
            remove { RemoveHandler(SendNewPageRequestEvent, value); }
        }

        #region 分頁關閉事件

        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContractManager));

        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(DockBar_DocumentModeChanged));
        }

        private void EngCaseList_Selected(object sender, RoutedEventArgs e)
        {
            SelectedEngineering = (EngineeringViewModel)e.OriginalSource;
        }

        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {

            try
            {
                e.Handled = true;

                DocumentLifeCircle mode = (DocumentLifeCircle)e.OriginalSource;

                switch (mode)
                {

                    case DocumentLifeCircle.Create:

                        this.DataContext = controller.CreateNew();

                        SelectedEngineering.CreateUserId = LoginedUser.UserId;


                        if (SelectedEngineering.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedEngineering.Errors.ToArray()));
                        }
                        break;
                    case DocumentLifeCircle.Save:
                        ProjectContractViewModel model = (ProjectContractViewModel)DataContext;

                        if (SelectedEngineering.CreateUserId == Guid.Empty)
                        {
                            SelectedEngineering.CreateUserId = LoginedUser.UserId;
                        }

                        if (SelectedEngineering.Compositions.Count > 0)
                        {
                            foreach (CompositionsViewModel com1 in SelectedEngineering.Compositions)
                            {
                                if (com1.CreateUserId == Guid.Empty)
                                {
                                    com1.CreateUserId = LoginedUser.UserId;
                                }
                            }
                        }

                        if (SelectedEngineering.Compositions2.Count > 0)
                        {
                            foreach (CompositionsViewModel com2 in SelectedEngineering.Compositions2)
                            {
                                if (com2.CreateUserId == Guid.Empty)
                                {
                                    com2.CreateUserId = LoginedUser.UserId;
                                }
                            }
                        }

                        controller.SaveModel((ProjectContractViewModel)DataContext);
                        SelectedEngineering.Status.IsModify = false;
                        SelectedEngineering.Status.IsSaved = true;

                        if (SelectedEngineering.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedEngineering.Errors.ToArray()));
                            dockBar.DocumentMode = DocumentLifeCircle.Update;
                        }
                        else
                        {
                            dockBar.DocumentMode = DocumentLifeCircle.Read;
                        }

                        if (SelectedEngineering.Status.IsNewInstance)
                        {
                            RaiseEvent(new RoutedEventArgs(OnPageClosingEvent, this));
                        }
                        break;
                    case DocumentLifeCircle.Update:
                        SelectedEngineering.Status.IsModify = false;
                        SelectedEngineering.Status.IsSaved = false;
                        SelectedEngineering.Status.IsNewInstance = false;
                        break;
                }
                UpdateLayout();
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void CustomDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void CustomDataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
