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
    /// MiscellaneousView.xaml 的互動邏輯
    /// </summary>
    public partial class MiscellaneousView : UserControl
    {
        public MiscellaneousView()
        {
            InitializeComponent();
            
        }

        #region SelectedProject
        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid), typeof(MiscellaneousView), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(ProjectIdChange)));

        public static void ProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is MiscellaneousView)
                {

                    ObjectDataProvider source = (ObjectDataProvider)((MiscellaneousView)sender).TryFindResource("OrderMiscellaneousSource");

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

        private void MiscellaneousView_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                //AluminumExtrusionOrderMiscellaneousViewModelCollection coll = new AluminumExtrusionOrderMiscellaneousViewModelCollection();
                //雜項DG.DataContext = coll;
                //coll.Query();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
