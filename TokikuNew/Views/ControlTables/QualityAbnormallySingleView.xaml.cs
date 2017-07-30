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
    /// QualityAbnormallySingleView.xaml 的互動邏輯
    /// </summary>
    public partial class QualityAbnormallySingleView : UserControl
    {
        public QualityAbnormallySingleView()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

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
                typeof(Guid), typeof(QualityAbnormallySingleView), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(ProjectIdChange)));

        private static AbnormalQuality _masterEntity;

        public static void ProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is QualityAbnormallySingleView)
                {
                    QualityAbnormallySingleView currentview = (QualityAbnormallySingleView)sender;

                    ObjectDataProvider provider = (ObjectDataProvider)currentview.TryFindResource("QualityAbnormallySource");

                    if (provider != null)
                    {
                        provider.MethodParameters[0] = e.NewValue;
                        provider.MethodParameters[1] = currentview.SelectedQualityAbnormallyId;

                        provider.Refresh();
                    }

                    ObjectDataProvider provider2 = (ObjectDataProvider)currentview.TryFindResource("QualityAbnormallyDetailsSource");

                    if (provider2 != null)
                    {
                        provider2.MethodParameters[0] = ((QualityAbnormallyViewModel)provider.Data).Id;
                        provider2.Refresh();
                    }

                    _masterEntity = ((QualityAbnormallyViewModel)provider.Data).Entity;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion



        public Guid SelectedQualityAbnormallyId
        {
            get { return (Guid)GetValue(SelectedQualityAbnormallyIdProperty); }
            set { SetValue(SelectedQualityAbnormallyIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QualityAbnormallyId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedQualityAbnormallyIdProperty =
            DependencyProperty.Register("SelectedQualityAbnormallyId", typeof(Guid), typeof(QualityAbnormallySingleView), new PropertyMetadata(Guid.Empty));



        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var master = (QualityAbnormallyViewModel)((ObjectDataProvider)TryFindResource("QualityAbnormallySource")).Data;
                var slave = (QualityAbnormallyDetailsViewModelCollection)((ObjectDataProvider)TryFindResource("QualityAbnormallyDetailsSource")).Data;

                if (master == null)
                    return;

                master.CreateTime = DateTime.Now;

                if (slave != null)
                {
                    foreach (var detailmodel in slave)
                    {
                        if (detailmodel.Entity.AbnormalQualityId != master.Entity.Id)
                        {
                            detailmodel.Entity.AbnormalQualityId = master.Entity.Id;
                            detailmodel.Entity.AbnormalQuality = master.Entity;
                            master.Entity.AbnormalQualityDetails.Add(detailmodel.Entity);
                        }
                    }
                }

                if (MessageBox.Show("確定要建立品質異常單?", "建立前確認", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    master.SaveModel();

                    if (master.HasError)
                    {
                        MessageBox.Show(string.Join("\n", slave.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        master.Errors = new string[] { };
                        master.HasError = false;
                        return;
                    }
                }
                else
                {  
                    RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));

                }


              


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
