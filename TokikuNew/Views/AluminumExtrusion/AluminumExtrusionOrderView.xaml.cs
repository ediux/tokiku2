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
    /// AluminumExtrusionOrderView.xaml 的互動邏輯
    /// </summary>
    public partial class AluminumExtrusionOrderView : UserControl
    {
        public AluminumExtrusionOrderView()
        {
            InitializeComponent();
            
        }

        #region SelectedProject
        public ProjectsViewModel SelectedProject
        {
            get { return (ProjectsViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(ProjectsViewModel), typeof(AluminumExtrusionOrderView), new PropertyMetadata(default(ProjectsViewModel)));

        #endregion



        public Guid FormDetailId
        {
            get { return (Guid)GetValue(FormDetailIdProperty); }
            set { SetValue(FormDetailIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormDetailId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormDetailIdProperty =
            DependencyProperty.Register("FormDetailId", typeof(Guid), typeof(AluminumExtrusionOrderView), new PropertyMetadata(Guid.NewGuid()));


        private void AluminumExtrusionOrderView_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                //AluminumExtrusionOrderViewModelCollection coll = (AluminumExtrusionOrderViewModelCollection)FindResource("AluminumExtrusionOrderSource");
                //if (coll != null)
                //{
                //    coll = AluminumExtrusionOrderViewModelCollection.Query(SelectedProject.Id, FormDetailId);
                //}
                //AluminumExtrusionOrderViewModelCollection coll = new AluminumExtrusionOrderViewModelCollection();
                //鋁擠型訂製單DG.DataContext = coll;
                //coll.Query();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
