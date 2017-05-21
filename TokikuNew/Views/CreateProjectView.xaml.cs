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
using WinForm=System.Windows.Forms;
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
    /// CreateProjectView.xaml 的互動邏輯
    /// </summary>
    public partial class CreateProjectView : UserControl
    {
        #region 相依屬性
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(ProjectBaseViewModel), typeof(CreateProjectView), new PropertyMetadata(default(ProjectBaseViewModel)));

        public ProjectBaseViewModel Model
        {
            get { return GetValue(ModelProperty) as ProjectBaseViewModel; }
            set { SetValue(ModelProperty, value); }
        }
        #endregion

        public CreateProjectView()
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
    }
}
