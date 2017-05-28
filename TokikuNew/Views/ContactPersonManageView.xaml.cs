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
        private ContactController controller = new ContactController();

        public ContactPersonManageView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 是否和客戶端聯絡人
        /// </summary>
        public bool IsClient
        {
            get { return (bool)GetValue(IsClientProperty); }
            set { SetValue(IsClientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsClientProperty =
            DependencyProperty.Register("IsClient", typeof(bool), typeof(ContactPersonManageView), new PropertyMetadata(false));

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

            Model.ContractsList = controller.QueryAll();
            DataContext = Model;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.SaveModel(Model);
                if (Model.HasError)
                {
                    WinForm.MessageBox.Show(string.Join(",", Model.Errors), "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
                }
                Model = new ContactsViewModel();
                Model.Status.IsSaved = true;
                Model.ContractsList = controller.QueryAll();


            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnPageClosingEvent));
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var obj = e.AddedItems[0];
                if (obj is Contacts)
                {
                    Model = controller.Query(x => x.Id == ((Contacts)obj).Id);
                }
            }

            Model.Status.IsNewInstance = false;
        }

        private void btnF1_Click(object sender, RoutedEventArgs e)
        {
            Model = new ContactsViewModel();
            Model.ContractsList = controller.QueryAll();
            Model.Status.IsNewInstance = true;
            DataContext = Model;
        }
    }
}
