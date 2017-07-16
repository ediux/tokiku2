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
using Tokiku.Entity;
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

        #region SelectedProjectId
        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid),
                typeof(SupplierForProjects), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(SelectedProjectIdChange)));

        public static void SelectedProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {

                if (sender is SupplierForProjects)
                {

                    ObjectDataProvider source = (ObjectDataProvider)((SupplierForProjects)sender).TryFindResource("SupplierSource");

                    if (source != null)
                    {
                        source.MethodParameters[0] = e.NewValue;
                        source.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion

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




        public ManufacturersViewModelCollection NextStop
        {
            get { return (ManufacturersViewModelCollection)GetValue(NextStopProperty); }
            set { SetValue(NextStopProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NextStop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NextStopProperty =
            DependencyProperty.Register("NextStop", typeof(ManufacturersViewModelCollection), typeof(SupplierForProjects), new PropertyMetadata(default(ManufacturersViewModelCollection)));



        public Guid CBMaterialCategoriesId
        {
            get { return (Guid)GetValue(CBMaterialCategoriesIdProperty); }
            set { SetValue(CBMaterialCategoriesIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CBMaterialCategoriesId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CBMaterialCategoriesIdProperty =
            DependencyProperty.Register("CBMaterialCategoriesId", typeof(Guid), typeof(SupplierForProjects), new PropertyMetadata(Guid.Empty));




        public Guid ManufactureId
        {
            get { return (Guid)GetValue(ManufactureIdProperty); }
            set { SetValue(ManufactureIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufactureId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufactureIdProperty =
            DependencyProperty.Register("ManufactureId", typeof(Guid), typeof(SupplierForProjects), new PropertyMetadata(Guid.Empty));




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

        private ManufacturersBussinessItemsViewModel TranscationItem;

        private void CBMaterialCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //

                CBMaterialCategoriesId = ((MaterialCategoriesViewModel)((ComboBox)sender).SelectedItem).Id;

                BussinessItemsByCategories = ManufacturersBussinessItemsViewModelColletion.QueryWithMaterialCategories(CBMaterialCategoriesId);
                SuppliersViewModel model = (SuppliersViewModel)BussinessItemsGrid.SelectedItem;

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
                    TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem);

                    if (BussinessItemsGrid.SelectedItem != null)
                    {
                        SuppliersViewModel model = (SuppliersViewModel)BussinessItemsGrid.SelectedItem;
                        model.ManufacturersBussinessItems = TranscationItem.Entity;
                        model.MaterialCategories = model.ManufacturersBussinessItems.MaterialCategories.Name;
                        model.Name = model.ManufacturersBussinessItems.Name;
                        model.ManufacturersBussinessItemsId = model.ManufacturersBussinessItems.Id;
                        model.ManufacturersName = model.ManufacturersBussinessItems.Manufacturers.Name;
                        model.TicketPeriod = model.ManufacturersBussinessItems.TicketPeriod.Name;


                        //model.Name = TranscationItem.Name;
                        //model.Id = TranscationItem.Id;
                    }


                    ManufacturerListByBussinessItems = ManufacturersViewModelCollection.QueryByBusinessItem(CBMaterialCategoriesId, TranscationItem.Name);
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
                    ManufactureId = ((ManufacturersViewModel)CBTranscationBusiness.SelectedItem).Id;

                    if (BussinessItemsGrid.SelectedItem != null)
                    {
                        SuppliersViewModel model = (SuppliersViewModel)BussinessItemsGrid.SelectedItem;
                        model.ManufacturersName = ((ManufacturersViewModel)CBTranscationBusiness.SelectedItem).Name;
                    }

                    TicketPeriodsByManufacturers = TicketPeriodsViewModelCollection.QueryByManufacturers(CBMaterialCategoriesId, TranscationItem.Name, ManufactureId);
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

                var dataset = ((ObjectDataProvider)TryFindResource("SupplierSource")).Data as SuppliersViewModelCollection;

                if (dataset != null)
                {
                    dataset.Remove(data);
                }
                //((SuppliersViewModelCollection)DataContext).Remove(data);
                ////((SuppliersViewModelCollection)DataContext).SaveModel();
                ////((SuppliersViewModelCollection)DataContext).Refresh();
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
                NextStop = ManufacturersViewModelCollection.QueryForCombox();
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

                        var dataset = ((ObjectDataProvider)TryFindResource("SupplierSource")).Data as SuppliersViewModelCollection;

                        if (dataset != null)
                        {
                            if (dataset.Any())
                            {
                                foreach (var item in dataset)
                                {
                                    item.ProjectId = SelectedProjectId;
                                }
                            }

                            dataset.SaveModel("Suppliers");

                            if (dataset.HasError)
                            {
                                MessageBox.Show(string.Join("\n", dataset.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                                dataset.Errors = null;
                                //Mode = dockBar.LastState;
                                break;
                            }

                        }

                        Mode = DocumentLifeCircle.Read;
                        //dataset.Refresh();

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
                NextStop = new ManufacturersViewModelCollection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void CBTicketPeriods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                ComboBox CBTicketPeriods = (ComboBox)sender;

                if (CBTicketPeriods != null && CBTicketPeriods.SelectedItem != null)
                {
                    var item = ((TicketPeriodsViewModel)CBTicketPeriods.SelectedItem);

                    if (BussinessItemsGrid.SelectedItem != null)
                    {
                        SuppliersViewModel model = (SuppliersViewModel)BussinessItemsGrid.SelectedItem;
                        //model.TicketPeriod = item.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void BussinessItemsGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            try
            {
                e.NewItem = new SuppliersViewModel(new SupplierTranscationItem() { Id = Guid.NewGuid() });
                ((SuppliersViewModel)e.NewItem).Initialized();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void DDLNextStop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox DDLNextStop = (ComboBox)sender;

                if (DDLNextStop != null && DDLNextStop.SelectedItem != null)
                {
                    if (BussinessItemsGrid.SelectedItem != null)
                    {
                        SuppliersViewModel model = (SuppliersViewModel)BussinessItemsGrid.SelectedItem;
                        model.NextManufacturers = ((ManufacturersViewModel)DDLNextStop.SelectedItem).Entity;
                        //model.TicketPeriod = item.Name;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
    }
}
