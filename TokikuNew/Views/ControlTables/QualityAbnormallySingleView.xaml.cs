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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var master = (QualityAbnormallyViewModel)((ObjectDataProvider)TryFindResource("QualityAbnormallySource")).Data;
                var slave = (QualityAbnormallyDetailsViewModelCollection)((ObjectDataProvider)TryFindResource("QualityAbnormallyDetailsSource")).Data;

                if (master == null)
                    return;

                master.CreateTime = DateTime.Now;

                if (slave == null)
                {
                    foreach (var detailmodel in slave)
                    {
                        if (detailmodel.Entity.AbnormalQualityId != master.Entity.Id)
                        {
                            detailmodel.Entity.AbnormalQualityId = master.Entity.Id;
                            detailmodel.Entity.AbnormalQuality = master.Entity;
                        }
                    }
                }


                slave.SaveModel();

                if (slave.HasError)
                {
                    MessageBox.Show(string.Join("\n", slave.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    master.Errors = new string[] { };
                    master.HasError = false;
                    return;
                }

                //RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
