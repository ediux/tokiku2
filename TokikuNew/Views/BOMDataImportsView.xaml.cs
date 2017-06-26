using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// BOMDataImportsView.xaml 的互動邏輯
    /// </summary>
    public partial class BOMDataImportsView : UserControl
    {
        public BOMDataImportsView()
        {
            InitializeComponent();
        }

        #region 登入的使用者
        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(BOMDataImportsView), new PropertyMetadata(default(UserViewModel)));

        /// <summary>
        /// 登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }
        #endregion


        /// <summary>
        /// 目前的專案
        /// </summary>
        public ProjectsViewModel CurrentProject
        {
            get { return (ProjectsViewModel)GetValue(CurrentProjectProperty); }
            set { SetValue(CurrentProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentProjectProperty =
            DependencyProperty.Register("CurrentProject", typeof(ProjectsViewModel), typeof(BOMDataImportsView), new PropertyMetadata(default(ProjectsViewModel)));



        public BOMViewModelCollection BOMImports
        {
            get { return (BOMViewModelCollection)GetValue(BOMImportsProperty); }
            set { SetValue(BOMImportsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BOMImportsProperty =
            DependencyProperty.Register("BOMImports", typeof(BOMViewModelCollection), typeof(BOMDataImportsView), new PropertyMetadata(default(BOMViewModelCollection)));


        private void SearchBox_ResetSearch(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BaseViewModel.BindToDataGridView<BOMViewModel, BOMViewModelCollection>(BOMImports, BOMGrid);
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            BOMImports = new BOMViewModelCollection();

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            //GrapeCity.Windows.SpreadSheet.UI.GcSpreadSheet sheet = new GrapeCity.Windows.SpreadSheet.UI.GcSpreadSheet();

            //Microsoft.Win32.OpenFileDialog opendialog = new Microsoft.Win32.OpenFileDialog();
            //var dialogresult = opendialog.ShowDialog();
            //if (dialogresult.HasValue && dialogresult.Value)
            //{
            //    sheet.OpenExcel(opendialog.FileName);
            //    //BaseViewModel.BindToGCSheet<BOMViewModel, BOMViewModelCollection>(BOMImports, sheet);

            //    if (sheet.Sheets.Count > 0)
            //    {
            //        Type MType = typeof(BOMViewModel);

            //        var Props = MType.GetProperties()
            //            .Select(w => new
            //            {
            //                DisplayMapping = (DisplayAttribute)w.GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault(),
            //                Name = w.Name,

            //            }).ToArray();

            //        for (int row = 1; row < sheet.ActiveSheet.Rows.Count; row++)
            //        {
            //            BOMViewModel model = new BOMViewModel();

            //            foreach (var prop in Props)
            //            {
            //                if (prop.DisplayMapping == null)
            //                    continue;

            //                for (int c = 0; c < sheet.ActiveSheet.Columns.Count; c++)
            //                {
            //                    if (prop.DisplayMapping.Order == c)
            //                    {
            //                        var value = sheet.ActiveSheet.GetText(row, c);

            //                        if (string.IsNullOrEmpty(value))
            //                            continue;

            //                        Type FT = model.GetType();
            //                        var datafield = FT.GetProperty(prop.Name);
            //                        datafield.SetValue(model, Convert.ChangeType(value, datafield.PropertyType));

            //                    }
            //                }

            //            }

            //            BOMImports.Add(model);
            //        }

            //        BOMImports.SaveModel();

            //        if (BOMImports.HasError)
            //        {
            //            MessageBox.Show(string.Join("\n", BOMImports.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            //        }
            //    }
            //}


        }
    }
}
