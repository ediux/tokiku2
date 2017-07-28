using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// ControlTableView.xaml 的互動邏輯
    /// </summary>
    public partial class ControlTableView : UserControl
    {
        public ControlTableView()
        {
            InitializeComponent();
        }

        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ControlTableView), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        #region 指出目前顯示的單據類型名稱


        public string FormName
        {
            get { return (string)GetValue(FormNameProperty); }
            set { SetValue(FormNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormNameProperty =
            DependencyProperty.Register("FormName", typeof(string), typeof(ControlTableView), new PropertyMetadata(string.Empty));



        #endregion



        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid), typeof(ControlTableView),
                new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(ProjectShortNameChange)));




        public static void ProjectShortNameChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is ControlTableView)
                {
                    ControlTableView currentview = (ControlTableView)sender;

                    ObjectDataProvider controltableprovider = (ObjectDataProvider)currentview.TryFindResource("ControlTableListSource");

                    if (controltableprovider != null)
                    {
                        controltableprovider.MethodName = "Query";
                        controltableprovider.MethodParameters[0] = e.NewValue;
                        controltableprovider.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {


            //RoutedViewResult routing = (RoutedViewResult)TryFindResource("OpenOrderView");
            //routing.RoutedValues["SelectedProject"] = SelectedProject;
            //ControlTableViewModelCollection ctrl = new ControlTableViewModelCollection();
            //dg.DataContext = ctrl;
            //ControlTableViewModelCollection.Query(select);

            //for (int i = 0; i < dg.Columns.Count; i++)
            //{
            //    dg.Columns[i].Visibility = Visibility.Visible;
            //}

            if (!string.IsNullOrEmpty(FormName))
            {
                //switch (FormName)
                //{
                //    case "鋁擠型材料":
                //        dg.Columns[1].Visibility = Visibility.Collapsed;
                //        dg.Columns[2].Visibility = Visibility.Collapsed;
                //        dg.Columns[4].Visibility = Visibility.Collapsed;
                //        dg.Columns[7].Visibility = Visibility.Visible;
                //        break;

                //    default:
                //        dg.Columns[1].Visibility = Visibility.Visible;
                //        dg.Columns[2].Visibility = Visibility.Visible;
                //        dg.Columns[4].Visibility = Visibility.Visible;
                //        dg.Columns[5].Visibility = Visibility.Collapsed;
                //        dg.Columns[6].Visibility = Visibility.Collapsed;
                //        dg.Columns[7].Visibility = Visibility.Collapsed;
                //        dg.Columns[8].Visibility = Visibility.Collapsed;
                //        dg.Columns[9].Visibility = Visibility.Collapsed;
                //        dg.Columns[11].Visibility = Visibility.Collapsed;
                //        dg.Columns[12].Visibility = Visibility.Collapsed;
                //        dg.Columns[13].Visibility = Visibility.Collapsed;
                //        dg.Columns[14].Visibility = Visibility.Collapsed;
                //        dg.Columns[15].Visibility = Visibility.Collapsed;
                //        dg.Columns[16].Visibility = Visibility.Collapsed;
                //        break;

                //}
            }
        }

        private void Button_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }

        private void QueryCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;

            ObjectDataProvider source = (ObjectDataProvider)FindResource("ControlTableListSource");

            if (source != null)
            {
                RequiredControlTableViewModelCollection list = (RequiredControlTableViewModelCollection)source.Data;
                e.CanExecute = true;
                return;
            }

            e.CanExecute = false;

        }

        private void QueryCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ObjectDataProvider source = (ObjectDataProvider)FindResource("ControlTableListSource");

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
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
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

                ObjectDataProvider source = (ObjectDataProvider)FindResource("ControlTableListSource");

                if (source != null)
                {
                    source.MethodName = "Query";
                    source.Refresh();
                }
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

                ObjectDataProvider source = (ObjectDataProvider)FindResource("ControlTableListSource");

                if (source != null)
                {
                    source.MethodName = "QueryByText";
                    source.MethodParameters[0] = e.Parameter;
                    source.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }

    //public class ColumnVisibilityConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        var vis = Visibility.Hidden;
    //        if (value.ToString().Equals("鋁擠型需求"))
    //        {
    //            vis = Visibility.Visible;
    //        }
    //        return vis;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //}

}
