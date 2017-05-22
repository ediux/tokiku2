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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.ViewModels;
using WinForm = System.Windows.Forms;
namespace TokikuNew.Views
{
    /// <summary>
    /// ContactPersonManageView.xaml 的互動邏輯
    /// </summary>
    public partial class ContactPersonManageView : UserControl
    {
        private ContactController controller;

        public ContactPersonManageView()
        {
            InitializeComponent();
        }

        public ContactsViewModel Model
        {
            get { return (ContactsViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(ContactsViewModel), typeof(ContactPersonManageView), new PropertyMetadata(default(ContactsViewModel)));

        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContactPersonManageView));

        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            controller = new ContactController();

            if (Model == null)
                Model = new ContactsViewModel();

            Model.QueryAll();
            Model.EnableEditor();
            DataContext = Model;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            Model.IsEditorMode = !Model.IsEditorMode;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.SaveModel();
                Model.CanSave = false;
                Model.QueryAll();
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Model.DisabledEditor();
            Model.CanSave = false;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnPageClosingEvent));
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var obj = e.AddedItems[0];
                Model.QueryModel(((Contacts)obj).Id);                
            }

            Model.IsNew = false;
        }

        private void btnF1_Click(object sender, RoutedEventArgs e)
        {
            Model = new ContactsViewModel();
            Model.QueryAll();
            Model.IsNew = true;
            DataContext = Model;
        }
    }
}
