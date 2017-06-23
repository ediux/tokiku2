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
    /// SupplierForProjects.xaml 的互動邏輯
    /// </summary>
    public partial class SupplierForProjects : UserControl
    {
        public SupplierForProjects()
        {
            InitializeComponent();
        }

        private void CBMaterialCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //
                Guid CBMaterialCategoriesId = ((MaterialCategoriesViewModel)((ComboBox)sender).SelectedItem).Id;
                ManufacturersBussinessItemsViewModelColletion biselect = new ManufacturersBussinessItemsViewModelColletion();
                biselect.QueryWithMaterialCategories(CBMaterialCategoriesId);
                var CBTranscationBusiness = (ComboBox)BussinessItemsGrid.Columns[1].HeaderTemplate.FindName("CBTranscationBusiness", BussinessItemsGrid);
                if (CBTranscationBusiness != null)
                {
                    CBTranscationBusiness.ItemsSource = biselect;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void CBTranscationBusiness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Guid CBMaterialCategoriesId = ((MaterialCategoriesViewModel)CBMaterialCategories.SelectedItem).Id;

                //if (CBTranscationBusiness.SelectedItem != null)
                //{
                //    string TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem).Name;
                //    ManufacturersViewModelCollection ManufacturersSelect = new ManufacturersViewModelCollection();
                //    ManufacturersSelect.QueryByBusinessItem(CBMaterialCategoriesId, TranscationItem);
                //    var CBManufacturerList = (ComboBox)BussinessItemsGrid.Columns[2].HeaderTemplate.FindName("CBManufacturerList", BussinessItemsGrid); CBManufacturerList.ItemsSource = ManufacturersSelect;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);


            }


        }

        private void CBManufacturerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Guid CBMaterialCategoriesId = ((MaterialCategoriesViewModel)CBMaterialCategories.SelectedItem).Id;
                //if (CBTranscationBusiness.SelectedItem != null)
                //{
                //    string TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem).Name;

                //    //if (CBManufacturerList.SelectedItem != null)
                //    //{
                //    //    Guid manuid = ((ManufacturersViewModel)CBManufacturerList.SelectedItem).Id;
                //    //    TicketPeriodsViewModelCollection ManufacturersSelect = new TicketPeriodsViewModelCollection();
                //    //    ManufacturersSelect.QueryByManufacturers(CBMaterialCategoriesId, TranscationItem, manuid);
                //    //    CBTicketPeriods.ItemsSource = ManufacturersSelect;
                //    //}

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void btnAddBI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (string.IsNullOrEmpty(TBPlaceofReceipt.Text))
                {
                    if (MessageBox.Show("請輸入送貨地址!", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    Guid CBMaterialCategoriesId = ((MaterialCategoriesViewModel)CBMaterialCategories.SelectedItem).Id;
                    //if (CBTranscationBusiness.SelectedItem != null)
                    //{
                    //    string TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem).Name;

                    //    //if (CBManufacturerList.SelectedItem != null)
                    //    //{
                    //    //    Guid manuid = ((ManufacturersViewModel)CBManufacturerList.SelectedItem).Id;
                    //    //    int periodsid = ((TicketPeriodsViewModel)CBTicketPeriods.SelectedItem).Id;
                    //    //    ManufacturersBussinessItemsViewModelColletion bicollection = new ManufacturersBussinessItemsViewModelColletion();
                    //    //    bicollection.QueryByBusinessItem(CBMaterialCategoriesId, TranscationItem, manuid, periodsid);
                    //    //    if (bicollection.Count > 0)
                    //    //    {
                    //    //        foreach (var item in bicollection)
                    //    //        {
                    //    //            SuppliersViewModel model = new SuppliersViewModel();
                    //    //            model.SetModel(item);
                    //    //            model.PlaceofReceipt = TBPlaceofReceipt.Text;
                    //    //            //SelectedProject.Suppliers.Add(model);
                    //    //        }
                    //    //    }
                    //    //}
                    //}

                    //CBVandorSelectionForRecvAddress_Loaded(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }
        private Stack<SuppliersViewModel> RemoveItem = new Stack<SuppliersViewModel>();
        private void BussinessItemsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                RemoveItem.Clear();

                if (BussinessItemsGrid.SelectedItems.Count > 0)
                {
                    foreach (var row in BussinessItemsGrid.SelectedItems)
                    {
                        if (row is SuppliersViewModel)
                        {
                            if (!RemoveItem.Contains((SuppliersViewModel)row))
                                RemoveItem.Push((SuppliersViewModel)row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error,
                     MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
