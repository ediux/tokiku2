using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WinForm = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectManagerView.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectManagerView : UserControl
    {
        
        #region 相依屬性
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(ProjectBaseViewModel), typeof(ProjectManagerView), new PropertyMetadata(default(ProjectBaseViewModel)));

        public ProjectBaseViewModel Model
        {
            get { return GetValue(ModelProperty) as ProjectBaseViewModel; }
            set { SetValue(ModelProperty, value); }
        }
        #endregion

        public ProjectManagerView()
        {
            InitializeComponent();

            Model = new ProjectBaseViewModel();
            this.DataContext = Model;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.SaveModel();
                Model.CanSave = false;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;
                    string msg = "";
                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg += errb.ErrorMessage;
                        }
                    }


                    WinForm.MessageBox.Show(msg, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {

                    WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
                }
            }


        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            Model.IsEditorMode = !Model.IsEditorMode;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Model.DisabledEditor();
            Model.CanSave = false;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F3)
            {
                if (Model.CanSave)
                    btnSave_Click(sender, new RoutedEventArgs(e.RoutedEvent));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
