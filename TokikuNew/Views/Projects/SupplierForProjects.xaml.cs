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
    /// SupplierForProjects.xaml 的互動邏輯
    /// </summary>
    public partial class SupplierForProjects : UserControl
    {
        public SupplierForProjects()
        {
            InitializeComponent();
        }



        public ManufacturersBussinessItemsViewModelColletion BussinessItemsByCategories
        {
            get { return (ManufacturersBussinessItemsViewModelColletion)GetValue(BussinessItemsByCategoriesProperty); }
            set { SetValue(BussinessItemsByCategoriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BussinessItemsByCategories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BussinessItemsByCategoriesProperty =
            DependencyProperty.Register("BussinessItemsByCategories", typeof(ManufacturersBussinessItemsViewModelColletion), typeof(SupplierForProjects), new PropertyMetadata(default(ManufacturersBussinessItemsViewModelColletion)));




        public ManufacturersViewModelCollection ManufacturerListByBussinessItems
        {
            get { return (ManufacturersViewModelCollection)GetValue(ManufacturerListByBussinessItemsProperty); }
            set { SetValue(ManufacturerListByBussinessItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufacturerListByBussinessItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturerListByBussinessItemsProperty =
            DependencyProperty.Register("ManufacturerListByBussinessItems", typeof(ManufacturersViewModelCollection), typeof(SupplierForProjects), new PropertyMetadata(default(ManufacturersViewModelCollection)));




        public Guid CBMaterialCategoriesId
        {
            get { return (Guid)GetValue(CBMaterialCategoriesIdProperty); }
            set { SetValue(CBMaterialCategoriesIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CBMaterialCategoriesId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CBMaterialCategoriesIdProperty =
            DependencyProperty.Register("CBMaterialCategoriesId", typeof(Guid), typeof(SupplierForProjects), new PropertyMetadata(Guid.Empty));




        public TicketPeriodsViewModelCollection TicketPeriodsByManufacturers
        {
            get { return (TicketPeriodsViewModelCollection)GetValue(TicketPeriodsByManufacturersProperty); }
            set { SetValue(TicketPeriodsByManufacturersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketPeriodsByManufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketPeriodsByManufacturersProperty =
            DependencyProperty.Register("TicketPeriodsByManufacturers", typeof(TicketPeriodsViewModelCollection), typeof(SupplierForProjects), new PropertyMetadata(default(TicketPeriodsViewModelCollection)));


        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(SupplierForProjects));
        #endregion

        private void CBMaterialCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //

                CBMaterialCategoriesId = ((MaterialCategoriesViewModel)((ComboBox)sender).SelectedItem).Id;
                BussinessItemsByCategories = new ManufacturersBussinessItemsViewModelColletion();
                BussinessItemsByCategories.QueryWithMaterialCategories(CBMaterialCategoriesId);
                //var CBTranscationBusiness = (ComboBox)((DataGridTemplateColumn)BussinessItemsGrid.Columns[1]).CellTemplate.FindName("CBTranscationBusiness", BussinessItemsGrid);
                //if (CBTranscationBusiness != null)
                //{
                //    CBTranscationBusiness.ItemsSource = biselect;
                //}


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
                ComboBox CBTranscationBusiness = (ComboBox)sender;

                if (CBTranscationBusiness != null && CBTranscationBusiness.SelectedItem != null)
                {
                    string TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem).Name;
                    ManufacturerListByBussinessItems = new ManufacturersViewModelCollection();
                    ManufacturerListByBussinessItems.QueryByBusinessItem(CBMaterialCategoriesId, TranscationItem);
                }
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

                ComboBox CBTranscationBusiness = (ComboBox)sender;

                if (CBTranscationBusiness != null && CBTranscationBusiness.SelectedItem != null)
                {
                    string TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem).Name;

                    //if (CBManufacturerList.SelectedItem != null)
                    //{
                    //    Guid manuid = ((ManufacturersViewModel)CBManufacturerList.SelectedItem).Id;
                    //    TicketPeriodsViewModelCollection ManufacturersSelect = new TicketPeriodsViewModelCollection();
                    //    ManufacturersSelect.QueryByManufacturers(CBMaterialCategoriesId, TranscationItem, manuid);
                    //    CBTicketPeriods.ItemsSource = ManufacturersSelect;
                    //}

                }
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

                //if (string.IsNullOrEmpty(TBPlaceofReceipt.Text))
                //{
                //    if (MessageBox.Show("請輸入送貨地址!", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                //    {
                //        return;
                //    }
                //}
                //else
                //{
                //    DataGridTemplateColumn cell = ((DataGridTemplateColumn)BussinessItemsGrid.Columns[0]);
                //    if (cell != null)
                //    {
                //        ComboBox CBMaterialCategories = (ComboBox)cell.CellTemplate.FindName("CBMaterialCategories", BussinessItemsGrid);

                //        if (CBMaterialCategories != null)
                //        {
                //            Guid CBMaterialCategoriesId = ((MaterialCategoriesViewModel)CBMaterialCategories.SelectedItem).Id;
                //        }
                //    }

                //    //if (CBTranscationBusiness.SelectedItem != null)
                //    //{
                //    //    string TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem).Name;

                //    //    //if (CBManufacturerList.SelectedItem != null)
                //    //    //{
                //    //    //    Guid manuid = ((ManufacturersViewModel)CBManufacturerList.SelectedItem).Id;
                //    //    //    int periodsid = ((TicketPeriodsViewModel)CBTicketPeriods.SelectedItem).Id;
                //    //    //    ManufacturersBussinessItemsViewModelColletion bicollection = new ManufacturersBussinessItemsViewModelColletion();
                //    //    //    bicollection.QueryByBusinessItem(CBMaterialCategoriesId, TranscationItem, manuid, periodsid);
                //    //    //    if (bicollection.Count > 0)
                //    //    //    {
                //    //    //        foreach (var item in bicollection)
                //    //    //        {
                //    //    //            SuppliersViewModel model = new SuppliersViewModel();
                //    //    //            model.SetModel(item);
                //    //    //            model.PlaceofReceipt = TBPlaceofReceipt.Text;
                //    //    //            //SelectedProject.Suppliers.Add(model);
                //    //    //        }
                //    //    //    }
                //    //    //}
                //    //}

                //    //CBVandorSelectionForRecvAddress_Loaded(sender, e);
                //}
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
            try
            {
                Button btn = (Button)sender;
                SuppliersViewModel data = (SuppliersViewModel)btn.DataContext;
                ((SuppliersViewModelCollection)DataContext).Remove(data);
                ((SuppliersViewModelCollection)DataContext).SaveModel();
                ((SuppliersViewModelCollection)DataContext).Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(DockBar_DocumentModeChanged));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                Mode = (DocumentLifeCircle)e.OriginalSource;

                switch (Mode)
                {
                  
                    case DocumentLifeCircle.Save:
                        var dataset = (SuppliersViewModelCollection)DataContext;

                        dataset.SaveModel();

                        if (dataset.HasError)
                        {
                            MessageBox.Show(string.Join("\n", dataset.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                            dataset.Errors = null;
                            //Mode = dockBar.LastState;
                            break;
                        }

                        Mode = DocumentLifeCircle.Read;

                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void userControl_Initialized(object sender, EventArgs e)
        {
            try
            {
                Mode = DocumentLifeCircle.Read;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
    }
}
