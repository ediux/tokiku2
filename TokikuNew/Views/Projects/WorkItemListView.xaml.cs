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


        private EngineeringController controller = new EngineeringController();

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



        public ProjectContractViewModel CurrentProjectContract
        {
            get { return (ProjectContractViewModel)GetValue(CurrentProjectContractProperty); }
            set { SetValue(CurrentProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentProjectContractProperty =
            DependencyProperty.Register("CurrentProjectContract", typeof(ProjectContractViewModel), typeof(ContractManager), new PropertyMetadata(default(ProjectContractViewModel)));



        public EngineeringViewModel SelectedEngineering
        {
            get { return (EngineeringViewModel)GetValue(SelectedEngineeringProperty); }
            set { SetValue(SelectedEngineeringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedEngineeringProperty =
            DependencyProperty.Register("SelectedEngineering", typeof(EngineeringViewModel), typeof(ContractManager), new PropertyMetadata(default(EngineeringViewModel)));


        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ContractManager), new PropertyMetadata(default(UserViewModel)));





        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(DockBar_DocumentModeChanged));
            Binding datasourceing = new Binding();
            datasourceing.Source = this.DataContext;

            SetBinding(CurrentProjectContractProperty, datasourceing);
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

                Mode = (DocumentLifeCircle)e.OriginalSource;

                switch (Mode)
                {

                    case DocumentLifeCircle.Create:
                        EngineeringViewModelCollection model1 = (EngineeringViewModelCollection)DataContext;
                        SelectedEngineering.Initialized(null);
                        SelectedEngineering.CreateUserId = LoginedUser.UserId;
                        model1.Add(SelectedEngineering);

                        if (SelectedEngineering.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedEngineering.Errors.ToArray()));
                        }
                        break;
                    case DocumentLifeCircle.Save:
                        EngineeringViewModelCollection model = (EngineeringViewModelCollection)DataContext;

                        if (model != null)
                        {
                            if (SelectedEngineering != null)
                            {

                                if (SelectedEngineering.CreateUserId == Guid.Empty)
                                {
                                    SelectedEngineering.CreateUserId = LoginedUser.UserId;
                                }

                            }
                        }

                      

                        model.SaveModel("");

                        if (SelectedEngineering != null && SelectedEngineering.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedEngineering.Errors.ToArray()));
                            SelectedEngineering.Errors = null;
                            Mode = DocumentLifeCircle.Update;
                            break;
                        }

                        if (SelectedEngineering != null && SelectedEngineering.Status.IsNewInstance)
                        {
                            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this.Parent));
                            SelectedEngineering.Status.IsModify = false;
                            SelectedEngineering.Status.IsSaved = true;
                        }

                        Mode = DocumentLifeCircle.Read;
                    
                        break;
                    case DocumentLifeCircle.Update:
                        EngineeringViewModelCollection model3 = (EngineeringViewModelCollection)DataContext;
                    
                        break;
                }
                //Mode = dockBar.DocumentMode;
                UpdateLayout();
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        //private void CustomDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{

        //}

        //private void CustomDataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        //{

        //}

        private void EngCaseList_Selected(object sender, MouseButtonEventArgs e)
        {
            //選擇合約項目
            SelectedEngineering = (EngineeringViewModel)EngCaseList.SelectedItem;

            if (SelectedEngineering != null)
            {
                //SelectedEngineering = controller.Query(q => q.Id == SelectedEngineering.Id);
                //SelectedEngineering.Refresh();

                if (SelectedEngineering != null)
                {
                    //com1.ItemsSource = SelectedEngineering.Compositions;
                    //com2.ItemsSource = SelectedEngineering.Compositions2;
                }
            }

        }
    }
}
