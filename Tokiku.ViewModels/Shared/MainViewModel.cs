using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class MainViewModel : WithLoginUserBaseViewModel, IBaseViewModelWithLoginedUser
    {
        public MainViewModel()
        {
            Status = new DocumentStatusViewModel();
            Projects = new ObservableCollection<ProjectListViewModel>();
            Manufacturers = new ObservableCollection<ManufacturersViewModel>();
            Clients = new ClientViewModelCollection();
            ToolBarButtons = new ToolbarButtonsViewModel();
        }

        #region 目前選定的專案
        public static readonly DependencyProperty CurrentProjectProperty =
                   DependencyProperty.Register("CurrentProject", typeof(ProjectsViewModel), typeof(MainViewModel),
                       new PropertyMetadata(default(ProjectsViewModel)));

        /// <summary>
        /// 目前選定的專案
        /// </summary>
        public ProjectsViewModel CurrentProject
        {
            get
            {
                return GetValue(CurrentProjectProperty) as ProjectsViewModel;
            }

            set
            {
                SetValue(CurrentProjectProperty, value);
                RaisePropertyChanged("CurrentProject");
            }
        }
        #endregion

        #region 專案列表

        /// <summary>
        /// 專案列表
        /// </summary>
        public ObservableCollection<ProjectListViewModel> Projects
        {
            get { return (ObservableCollection<ProjectListViewModel>)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); RaisePropertyChanged("Projects"); }
        }

        // Using a DependencyProperty as the backing store for Projects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(ObservableCollection<ProjectListViewModel>), typeof(MainViewModel),
                new PropertyMetadata(default(ObservableCollection<ProjectListViewModel>)));
        #endregion

        #region 廠商列表
        /// <summary>
        /// 廠商列表
        /// </summary>
        public ObservableCollection<ManufacturersViewModel> Manufacturers
        {
            get { return (ObservableCollection<ManufacturersViewModel>)GetValue(ManufacturersProperty); }
            set { SetValue(ManufacturersProperty, value); RaisePropertyChanged("Manufacturers"); }
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersProperty =
            DependencyProperty.Register("Manufacturers", typeof(ObservableCollection<ManufacturersViewModel>), typeof(MainViewModel),
                new PropertyMetadata(default(ObservableCollection<ManufacturersViewModel>)));
        #endregion

        #region 客戶列表

        /// <summary>
        /// 客戶列表
        /// </summary>
        public ClientViewModelCollection Clients
        {
            get { return (ClientViewModelCollection)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clients.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClientsProperty =
            DependencyProperty.Register("Clients", typeof(ClientViewModelCollection), typeof(MainViewModel), new PropertyMetadata(default(ObservableCollection<ClientViewModel>)));



        #endregion

        #region 工具列狀態
        /// <summary>
        /// 工具列按鈕狀態
        /// </summary>
        public ToolbarButtonsViewModel ToolBarButtons
        {
            get { return (ToolbarButtonsViewModel)GetValue(ToolBarButtonsProperty); }
            set { SetValue(ToolBarButtonsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolBarButtons.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolBarButtonsProperty =
            DependencyProperty.Register("ToolBarButtons", typeof(ToolbarButtonsViewModel), typeof(MainViewModel), new PropertyMetadata(default(ToolbarButtonsViewModel))); 
        #endregion

    }
}
