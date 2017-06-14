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
    /// ConstructionAtlasView.xaml 的互動邏輯
    /// </summary>
    public partial class ConstructionAtlasView : UserControl
    {
        public ConstructionAtlasView()
        {
            InitializeComponent();
        }


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
            DependencyProperty.Register("CurrentProjectContract", typeof(ProjectContractViewModel), typeof(ConstructionAtlasView), new PropertyMetadata(default(ProjectContractViewModel)));



        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ConstructionAtlasView), new PropertyMetadata(default(UserViewModel)));


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ConstructionAtlasView), new PropertyMetadata(DocumentLifeCircle.Read));


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConstructionAtlasEditorDialog dialog = new ConstructionAtlasEditorDialog();
                var dmodel = new ConstructionAtlasViewModel();
                if (CurrentProjectContract != null)
                {
                    dmodel.ProjectContractId = CurrentProjectContract.Id;
                }
                dialog.DataContext = dmodel;
                var result = dialog.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    ConstructionAtlasViewModel model = (ConstructionAtlasViewModel)dialog.DataContext;

                    if (LoginedUser != null)
                        model.CreateUserId = LoginedUser.UserId;

                    ((ConstructionAtlasViewModelCollection)DataContext).Add(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AltasGrid.SelectedItems.Count > 0)
                {
                    foreach (ConstructionAtlasViewModel item in AltasGrid.SelectedItems)
                    {
                        ((ConstructionAtlasViewModelCollection)DataContext).Remove(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
