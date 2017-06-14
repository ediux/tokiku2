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
    /// ProcessingAtlasView.xaml 的互動邏輯
    /// </summary>
    public partial class ProcessingAtlasView : UserControl
    {
        public ProcessingAtlasView()
        {
            InitializeComponent();
        }



        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ProcessingAtlasView), new PropertyMetadata(default(UserViewModel)));




        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ProcessingAtlasView), new PropertyMetadata(DocumentLifeCircle.Read));


        /// <summary>
        /// 目前處理的合約
        /// </summary>
        public ProjectContractViewModel CurrentProjectContract
        {
            get { return (ProjectContractViewModel)GetValue(CurrentProjectContractProperty); }
            set { SetValue(CurrentProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentProjectContractProperty =
            DependencyProperty.Register("CurrentProjectContract", typeof(ProjectContractViewModel), typeof(ProcessingAtlasView), new PropertyMetadata(default(ProjectContractViewModel)));

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void com2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void com2_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            try
            {
                var model = new ProcessingAtlasViewModel();
                model.Id = Guid.NewGuid();
                model.ProjectContractId = (CurrentProjectContract?.Id).HasValue ? (CurrentProjectContract?.Id).Value : Guid.Empty;
                e.NewItem = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }

        }

        private void com2_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }
    }
}
