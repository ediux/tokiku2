using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.Controllers;
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
                    //((ProjectListViewModelCollection)DataContext).Query();
                }
                else
                {
                    if (((ProjectListViewModelCollection)DataContext).Count == 0)
                    {
                        //((ProjectListViewModelCollection)DataContext).Refresh();
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




        private void ProjectList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (ProjectList.SelectedItem != null)
                {
                    SelectedProject = (ProjectListViewModel)ProjectList.SelectedItem;
                }

                //OpenNewTabItem command = (OpenNewTabItem)TryFindResource("OpenNewTabItem");

                //if (command != null)
                //{                    
                //    var routedvalue = new RoutedViewResult()
                //    {
                //        FormatedDisplay = "專案:{0}-{1}",
                //        FormatedParameters = new object[] { SelectedProject.Code, SelectedProject.ShortName },
                //        ViewType = typeof(ProjectViewer),
                //        SourceViewType = typeof(ProjectSelectListView),
                //        RoutedValues = new Dictionary<string, object>()
                //    };
                //    routedvalue.RoutedValues.Add("SelectedProjectId", SelectedProject.Id);
                //    command.Execute(routedvalue);
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void QueryCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.Handled = true;

            e.CanExecute = true;

        }

        private void QueryCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ObjectDataProvider source = (ObjectDataProvider)FindResource("ProjoectListSource");

                if (source != null)
                {

                    source.MethodName = "QueryByText";
                    source.MethodParameters.Clear();
                    source.MethodParameters.Add(e.Parameter);
                    source.Refresh();
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ResetFiliterCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;

        }

        private void ResetFiliterCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ObjectDataProvider source = (ObjectDataProvider)FindResource("ProjoectListSource");

                if (source != null)
                {

                    source.MethodName = "Query";
                    source.MethodParameters.Clear();
                    source.Refresh();
                }
                //((ProjectListViewModelCollection)DataContext).Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void RefreshQueryCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }

        private void RefreshQueryCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ObjectDataProvider source = (ObjectDataProvider)FindResource("ProjoectListSource");

                if (source != null)
                {

                    source.MethodName = "QueryByText";
                    source.MethodParameters.Clear();
                    source.MethodParameters.Add(e.Parameter);
                    source.Refresh();
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnNew_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }
    }
}
