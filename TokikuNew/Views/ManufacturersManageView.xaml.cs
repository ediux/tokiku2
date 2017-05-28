﻿using System;
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
using Tokiku.ViewModels;
using WinForm = System.Windows.Forms;

namespace TokikuNew.Views
{
    /// <summary>
    /// ManufacturersManageView.xaml 的互動邏輯
    /// </summary>
    public partial class ManufacturersManageView : UserControl
    {
        private ManufacturersController controller=new ManufacturersController();

        public ManufacturersManageView()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ManufacturersManageView));

        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }

        public ManufacturersViewModel Model
        {
            get { return (ManufacturersViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(ManufacturersViewModel), typeof(ManufacturersManageView), new PropertyMetadata(default(ManufacturersViewModel)));

        private void btnF1_Click(object sender, RoutedEventArgs e)
        {
            Model = new ManufacturersViewModel();            
            Model.Status.IsNewInstance = true;
            DataContext = Model;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            Model.Status.IsModify = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.SaveModel(Model);
                Model.Status.IsSaved = true;                
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

        private void ContractList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnContractSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMtSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddMTList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MTList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {        
            Binding modelBinding = new Binding();
            modelBinding.Source = this.DataContext;
            SetBinding(ModelProperty, modelBinding);
        }

        private void ContractList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbName.Text.Length > 0)
            {
                if (tbName.Text.Length >= 4)
                {
                    tbShortName.Text = tbName.Text.Substring(0, Math.Min(4, tbName.Text.Length));
                }
                else
                {
                    tbShortName.Text = tbName.Text;
                }
            }
            else
            {
                tbShortName.Text = string.Empty;
            }
        }
    }
}
