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
using Tokiku.Entity;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// ContractListView.xaml 的互動邏輯
    /// </summary>
    public partial class ContractListView : UserControl
    {
        public ContractListView()
        {
            InitializeComponent();
        }

        #region SelectedProjectId
        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid),
                typeof(ContractListView), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(SelectedProjectIdChange)));

        public static void SelectedProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {

                if (sender is ContractListView)
                {

                    ObjectDataProvider source = (ObjectDataProvider)((ContractListView)sender).TryFindResource("ContractListSource");

                    if (source != null)
                    {
                        source.MethodParameters[0] = e.NewValue;
                        source.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion



        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ContractListView));
        #endregion

        private void userControl_Initialized(object sender, EventArgs e)
        {
            try
            {
                Mode = DocumentLifeCircle.Read;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(DockBar_DocumentModeChanged));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                Mode = (DocumentLifeCircle)e.OriginalSource;

                switch (Mode)
                {

                    case DocumentLifeCircle.Save:
                        var dataset = (ProjectContractViewModelCollection)DataContext;

                        dataset.SaveModel("");

                        if (dataset.HasError)
                        {
                            MessageBox.Show(string.Join("\n", dataset.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                            dataset.Errors = null;
                            break;
                        }

                        Mode = DocumentLifeCircle.Read;

                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void ContractList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ContractList.SelectedItem));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void ContractList_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            try
            {
                e.NewItem = new ProjectContractViewModel();
                ((ProjectContractViewModel)e.NewItem).ProjectId = SelectedProjectId;
                ((ProjectContractViewModel)e.NewItem).Initialized();
                ((ProjectContractViewModel)e.NewItem).Id = Guid.NewGuid();

                ProjectsViewModel CurrentProject = ProjectsViewModel.QuerySingle<ProjectsViewModel, Projects>("ProjectManagerView", "QueryById", SelectedProjectId);

                if (string.IsNullOrEmpty(((ProjectContractViewModel)e.NewItem).ContractNumber))
                {
                    if (CurrentProject != null)
                        ((ProjectContractViewModel)e.NewItem).ContractNumber = CurrentProject.Code;
                }
                ((ProjectContractViewModel)e.NewItem).Name = CurrentProject.Name;
                ((ProjectContractViewModel)e.NewItem).SigningDate = CurrentProject.ProjectSigningDate;

                //if (CurrentProject.ProjectContract.Where(w => w.ContractNumber == ((ProjectContractViewModel)e.NewItem).ContractNumber).Any())
                //{
                //    var lastdata = CurrentProject.ProjectContract
                //        .Where(w => w.ContractNumber.StartsWith(((ProjectContractViewModel)e.NewItem).ContractNumber))
                //        .OrderByDescending(w => w.ContractNumber).FirstOrDefault();

                //    if (lastdata != null)
                //    {
                //        int lastnumber = 0;

                //        if (lastdata.ContractNumber.Length > 7)
                //        {
                //            if (!int.TryParse(lastdata.ContractNumber.Substring(8), out lastnumber))
                //            {
                //                ((ProjectContractViewModel)e.NewItem).ContractNumber = string.Empty;
                //                return;
                //            }
                //        }

                //        lastnumber += 1;
                //        ((ProjectContractViewModel)e.NewItem).ContractNumber = string.Format("{0}-{1}", lastdata.ContractNumber.Substring(0, 7), lastnumber);
                //        return;
                //    }

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnProcessAltas_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ((ProjectContractViewModel)((Button)sender).DataContext).ProcessingAtlas));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            //}
        }

        private void btnEngItem_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ((ProjectContractViewModel)((Button)sender).DataContext).Engineerings));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            //}
        }

        private void ContractList_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ContractList.SelectedItem));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource is ProjectContractViewModel)
                {
                    ProjectContractViewModel disableContract = (ProjectContractViewModel)e.OriginalSource;
                    UpdateLayout();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //鋁擠型材料
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "鋁擠型材料"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
    }
}
