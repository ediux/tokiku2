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



        public ProjectsViewModel CurrentProject
        {
            get { return (ProjectsViewModel)GetValue(CurrentProjectProperty); }
            set { SetValue(CurrentProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentProjectProperty =
            DependencyProperty.Register("CurrentProject", typeof(ProjectsViewModel), typeof(SupplierForProjects), new PropertyMetadata(default(ProjectsViewModel)));



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

        #region SelectedProject
        public ProjectsViewModel SelectedProject
        {
            get { return (ProjectsViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(ProjectsViewModel), typeof(SupplierForProjects), new PropertyMetadata(default(ProjectsViewModel)));

        #endregion



        private ManufacturersBussinessItemsViewModel TranscationItem;

        private void CBMaterialCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //

                CBMaterialCategoriesId = ((MaterialCategoriesViewModel)((ComboBox)sender).SelectedItem).Id;
                if (BussinessItemsGrid.SelectedItem != null)
                {
                    SuppliersViewModel model = (SuppliersViewModel)BussinessItemsGrid.SelectedItem;
                    //model.MaterialCategories = ((MaterialCategoriesViewModel)((ComboBox)sender).SelectedItem).Name;
                }
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
                    TranscationItem = ((ManufacturersBussinessItemsViewModel)CBTranscationBusiness.SelectedItem);

                    if (BussinessItemsGrid.SelectedItem != null)
                    {
                        SuppliersViewModel model = (SuppliersViewModel)BussinessItemsGrid.SelectedItem;
                        //model.Name = TranscationItem.Name;
                        model.Id = TranscationItem.Id;
                    }

                 
                    ManufacturerListByBussinessItems = new ManufacturersViewModelCollection();
                    ManufacturerListByBussinessItems.QueryByBusinessItem(CBMaterialCategoriesId, TranscationItem.Name);
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

                    TicketPeriodsByManufacturers = new TicketPeriodsViewModelCollection();
                    TicketPeriodsByManufacturers.QueryByManufacturers(CBMaterialCategoriesId, TranscationItem.Name, ManufactureId);
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
                ((SuppliersViewModelCollection)DataContext).Remove(data);
                //((SuppliersViewModelCollection)DataContext).SaveModel();
                //((SuppliersViewModelCollection)DataContext).Refresh();
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
                //NextStop.Query();

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
                        if (dataset.Any())
                        {
                            foreach (var item in dataset)
                            {
                                item.ProjectId = CurrentProject.Id;

                            }
                        }
                        //dataset.SaveModel();

                        if (dataset.HasError)
                        {
                            MessageBox.Show(string.Join("\n", dataset.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                            dataset.Errors = null;
                            //Mode = dockBar.LastState;
                            break;
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
    }
}
