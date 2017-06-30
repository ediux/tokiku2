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
    /// ProcessingAtlasView.xaml 的互動邏輯
    /// </summary>
    public partial class ProcessingAtlasView : UserControl
    {
        public ProcessingAtlasView()
        {
            InitializeComponent();
        }



        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ProcessingAtlasView), new PropertyMetadata(default(UserViewModel)));




        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ProcessingAtlasView), new PropertyMetadata(DocumentLifeCircle.Read));


        /// <summary>
        /// 目前處理的合約
        /// </summary>
        public ProjectContractViewModel CurrentProjectContract
        {
            get { return (ProjectContractViewModel)GetValue(CurrentProjectContractProperty); }
            set { SetValue(CurrentProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentProjectContractProperty =
            DependencyProperty.Register("CurrentProjectContract", typeof(ProjectContractViewModel), typeof(ProcessingAtlasView), new PropertyMetadata(default(ProjectContractViewModel)));



        private void com2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void com2_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            try
            {

                var model = new ProcessingAtlasViewModel();
                model.Id = Guid.NewGuid();
                model.Order = ((ProcessingAtlasViewModelCollection)com2.ItemsSource).Max(p => p.Order) + 1;
                model.ProjectContractId = (CurrentProjectContract?.Id).HasValue ? (CurrentProjectContract?.Id).Value : Guid.Empty;
                model.ConstructionOrderChangeDate = new DateTime(1900, 1, 1);
                e.NewItem = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void com2_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //var s = (ProcessingAtlasViewModelCollection)com2.ItemsSource;
            //s = new ProcessingAtlasViewModelCollection(s.OrderBy(p => p.Order).ToList());
        }

        private void MI_Projects_Order_1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = "鋁擠型訂製單";
                addWorkarea = new ClosableTabItem() { Header = Header };


                bool isExisted = false;

                //foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
                //{
                //    if (item.Header.Equals(addWorkarea.Header))
                //    {
                //        isExisted = true;
                //        addWorkarea = item;
                //        break;
                //    }
                //}

                //if (!isExisted)
                //{
                //    var vm = new AluminumExtrusionOrderSheetView() { Margin = new Thickness(0) };

                //    addWorkarea.Content = vm;
                //    addWorkarea.Margin = new Thickness(0);

                //    Binding LoginedUserBinding = new Binding();
                //    LoginedUserBinding.Source = LoginedUser;

                //    vm.SetBinding(AluminumExtrusionOrderSheetView.LoginedUserProperty, LoginedUserBinding);

                //    InnerWorkspaces.Items.Add(addWorkarea);
                //    InnerWorkspaces.SelectedItem = addWorkarea;

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_Projects_Order_2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = "鋁擠型請款單";
                addWorkarea = new ClosableTabItem() { Header = Header };

                bool isExisted = false;

                //foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
                //{
                //    if (item.Header.Equals(addWorkarea.Header))
                //    {
                //        isExisted = true;
                //        addWorkarea = item;
                //        break;
                //    }
                //}

                //if (!isExisted)
                //{
                //    var vm = new InvoiceView() { Margin = new Thickness(0) };

                //    addWorkarea.Content = vm;
                //    addWorkarea.Margin = new Thickness(0);

                //    //Binding LoginedUserBinding = new Binding();
                //    //LoginedUserBinding.Source = LoginedUser;

                //    //vm.SetBinding(AluminumExtrusionOrderSheetView.LoginedUserProperty, LoginedUserBinding);

                //    InnerWorkspaces.Items.Add(addWorkarea);
                //    InnerWorkspaces.SelectedItem = addWorkarea;

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_Projects_Order_3_Click(object sender, RoutedEventArgs e)
        {
            //RecvMaterialView
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = "鋁擠型收料單";

                addWorkarea = new ClosableTabItem() { Header = Header };

                bool isExisted = false;

                //foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
                //{
                //    if (item.Header.Equals(addWorkarea.Header))
                //    {
                //        isExisted = true;
                //        addWorkarea = item;
                //        break;
                //    }
                //}

                //if (!isExisted)
                //{

                //    var vm = new RecvMaterialView() { Margin = new Thickness(0) };

                //    addWorkarea.Content = vm;
                //    addWorkarea.Margin = new Thickness(0);

                //    //Binding LoginedUserBinding = new Binding();
                //    //LoginedUserBinding.Source = LoginedUser;

                //    //vm.SetBinding(AluminumExtrusionOrderSheetView.LoginedUserProperty, LoginedUserBinding);

                //    InnerWorkspaces.Items.Add(addWorkarea);
                //    InnerWorkspaces.SelectedItem = addWorkarea;

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_Projects_BOMImports_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = "用料需求資料匯入";
                addWorkarea = new ClosableTabItem() { Header = Header };

                bool isExisted = false;

                //foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
                //{
                //    if (item.Header.Equals(addWorkarea.Header))
                //    {
                //        isExisted = true;
                //        addWorkarea = item;
                //        break;
                //    }
                //}

                //if (!isExisted)
                //{
                //    var vm = new BOMDataImportsView() { Margin = new Thickness(0) };


                //    addWorkarea.Content = vm;
                //    addWorkarea.Margin = new Thickness(0);

                //    Binding LoginedUserBinding = new Binding();
                //    LoginedUserBinding.Source = LoginedUser;

                //    vm.SetBinding(BOMDataImportsView.LoginedUserProperty, LoginedUserBinding);

                //    vm.CurrentProject = (ProjectsViewModel)DataContext;
                //    InnerWorkspaces.Items.Add(addWorkarea);
                //    InnerWorkspaces.SelectedItem = addWorkarea;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_Projects_BOMQuery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAluminumExtrusion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, new ControlTableView()));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void BtnGlass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "玻璃管控表"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void BtnAluminumPlate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnIronPieces_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOthers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
