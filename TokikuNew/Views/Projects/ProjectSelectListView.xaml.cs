using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Tokiku.Entity;
using Tokiku.ViewModels;
using WinForm = System.Windows.Forms;
namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectSelectListView.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectSelectListView : UserControl
    {
        private ProjectsController controller = new ProjectsController();

        public ProjectSelectListView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedProjectProperty = DependencyProperty.Register("SelectedProject", typeof(ProjectListViewModel), typeof(ProjectSelectListView));

        public ProjectListViewModel SelectedProject
        {
            get { return (ProjectListViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IsLoaded)
                {
                    ((ProjectListViewModelCollection)DataContext).Query();
                }
                else
                {
                    if (((ProjectListViewModelCollection)DataContext).Count == 0)
                    {
                        ((ProjectListViewModelCollection)DataContext).Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void ProjectList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                SelectedProject = (ProjectListViewModel)e.NewValue;
                RaiseEvent(new RoutedEventArgs(SelectedProjectChangedEvent, SelectedProject));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        public static readonly RoutedEvent SelectedProjectChangedEvent = EventManager.RegisterRoutedEvent(
       "SelectedProjectChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ProjectSelectListView));




        public event RoutedEventHandler SelectedProjectChanged
        {
            add { AddHandler(SelectedProjectChangedEvent, value); }
            remove { RemoveHandler(SelectedProjectChangedEvent, value); }
        }


        // This method raises the Tap event
        protected void RaiseSelectProjectChangedEvent()
        {
            try
            {
                RoutedEventArgs newEventArgs = new RoutedEventArgs(SelectedProjectChangedEvent);
                RaiseEvent(newEventArgs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //搜尋框
                ((ProjectListViewModelCollection)DataContext).QueryByText((string)e.OriginalSource);
                //DataContext = controller.SearchByText((string)e.OriginalSource);
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count > 0)
                {
                    var obj = e.AddedItems[0];
                    RaiseEvent(new RoutedEventArgs(SelectedProjectChangedEvent, obj));
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(Controls.ClosableTabItem.SendNewPageRequestEvent, e.OriginalSource));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void cSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProjectListViewModelCollection)DataContext).Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ProjectList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ProjectList.SelectedItem != null)
                {
                    e.Handled = true;
                    SelectedProject = (ProjectListViewModel)ProjectList.SelectedItem;
                    RaiseEvent(new RoutedEventArgs(SelectedProjectChangedEvent, SelectedProject));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void cSearchBar_RefreshResult(object sender, RoutedEventArgs e)
        {
            try
            {
                //搜尋框
                ((ProjectListViewModelCollection)DataContext).QueryByText((string)e.OriginalSource);
                //DataContext = controller.SearchByText((string)e.OriginalSource);
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
