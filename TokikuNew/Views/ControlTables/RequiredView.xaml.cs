using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// RequiredView.xaml 的互動邏輯
    /// </summary>
    public partial class RequiredView : UserControl
    {
        public RequiredView()
        {
            InitializeComponent();
        }



        public string ProjectShortName
        {
            get { return (string)GetValue(ProjectShortNameProperty); }
            set { SetValue(ProjectShortNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectShortName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectShortNameProperty =
            DependencyProperty.Register("ProjectShortName", typeof(string), typeof(RequiredView),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(ProjectShortNameChange)));

        public static void ProjectShortNameChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is RequiredView)
                {

                    ObjectDataProvider source = (ObjectDataProvider)((RequiredView)sender).TryFindResource("RequiredSource");

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

        private void RequiredView_Loaded(object sender, RoutedEventArgs e)
        {
            //RequiredViewModelCollection ctrl = new RequiredViewModelCollection();
            //CheckGrid.DataContext = ctrl;
            //RequiredViewModelCollection.Query();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生需求單"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RequiredViewModel master = (RequiredViewModel)((ObjectDataProvider)TryFindResource("RequiredSource")).Data;
                RequiredDetailViewModelCollection details = (RequiredDetailViewModelCollection)((ObjectDataProvider)TryFindResource("RequiredDetailSource")).Data;

                if (details.Count > 0)
                {
                    master.Entity.RequiredDetails = new Collection<RequiredDetails>();

                    foreach (var item in details)
                    {
                        item.Entity.Required = master.Entity;
                        item.Entity.RequiredId = master.Id;
                        if (item.Entity.Id == Guid.Empty)
                            item.Entity.Id = Guid.NewGuid();

                        if (item.Entity.Materials.ManufacturersId == Guid.Empty)
                        {
                            item.Entity.Materials.ManufacturersId = master.Entity.Manufacturers.Id;
                        }
                        if(item.Entity.Materials.CreateUserId == Guid.Empty)
                        {
                            item.Entity.Materials.CreateUserId = master.CreateUserId;
                        }
                        master.Entity.RequiredDetails.Add(item.Entity);
                    }
                }

                master.SaveModel("Required");
                if (master.HasError)
                {
                    MessageBox.Show(string.Join("\n", master.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
                //var provider = (ObjectDataProvider)TryFindResource("RequiredSource");
                //provider.MethodName = "Query";
                //provider.MethodParameters.Clear();
                //provider.MethodParameters.Add(master.Id);
                //provider.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
