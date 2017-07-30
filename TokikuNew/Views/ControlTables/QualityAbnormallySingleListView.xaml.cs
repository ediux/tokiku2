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

namespace TokikuNew.Views
{
    /// <summary>
    /// QualityAbnormallySingleListView.xaml 的互動邏輯
    /// </summary>
    public partial class QualityAbnormallySingleListView : UserControl
    {
        public QualityAbnormallySingleListView()
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
            DependencyProperty.Register("SelectedProjectId",
                typeof(Guid), typeof(QualityAbnormallySingleListView), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(ProjectIdChange)));


        public static void ProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is QualityAbnormallySingleListView)
                {
                    QualityAbnormallySingleListView currentview = (QualityAbnormallySingleListView)sender;

                    ObjectDataProvider provider = (ObjectDataProvider)currentview.TryFindResource("QualityAbnormallySingleListSource");

                    if (provider != null)
                    {
                        provider.MethodParameters[0] = e.NewValue;
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
    }
}
