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
    /// RecvMaterialListView.xaml 的互動邏輯
    /// </summary>
    public partial class RecvMaterialListView : UserControl
    {
        public RecvMaterialListView()
        {
            InitializeComponent();
        }


        #region SelectedProjectId
        /// <summary>
        /// 目前已選擇的專案ID
        /// </summary>
        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid), typeof(RecvMaterialView), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(ProjectIdChange)));



        public static void ProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is RecvMaterialView)
                {
                    RecvMaterialView currentview = (RecvMaterialView)sender;

                    ObjectDataProvider provider = (ObjectDataProvider)currentview.TryFindResource("RecvMaterialSource");

                    if (provider != null)
                    {
                        provider.MethodParameters[0] = currentview.SelectedRecvId;
                        provider.MethodParameters[1] = e.NewValue;

                        provider.Refresh();
                    }

                 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion



        private void RecvMaterialListView_Loaded(object sender, RoutedEventArgs e)
        {
            //ObjectDataProvider collection =(ObjectDataProvider) FindResource("RecvMaterialSource");

            //if (collection != null)
            //{
            //    CheckGrid.ItemsSource = (RecvMaterialViewModelCollection) collection.Data;
            //}
            //RecvMaterialListViewModelCollection ctrl = new RecvMaterialListViewModelCollection();
            //CheckGrid.DataContext = ctrl;
            //ctrl.Query();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "開啟收料單"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

    }
}
