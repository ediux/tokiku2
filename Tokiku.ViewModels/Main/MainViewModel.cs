using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MainViewModel : WithLoginUserBaseViewModel, IBaseViewModelWithLoginedUser
    {
        private Controllers.ProjectsController _projects_controller;

        public MainViewModel(Controllers.ProjectsController projects_controller)
        {
            _projects_controller = projects_controller;

            Status = new DocumentStatusViewModel();
            Projects = new ProjectListViewModelCollection();
            Manufacturers = new ManufacturersViewModelCollection();

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
        public ProjectListViewModelCollection Projects
        {
            get { return (ProjectListViewModelCollection)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); RaisePropertyChanged("Projects"); }
        }

        // Using a DependencyProperty as the backing store for Projects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(ProjectListViewModelCollection), typeof(MainViewModel),
                new PropertyMetadata(default(ProjectListViewModelCollection)));
        #endregion

        #region 廠商列表
        /// <summary>
        /// 廠商列表
        /// </summary>
        public ManufacturersViewModelCollection Manufacturers
        {
            get { return (ManufacturersViewModelCollection)GetValue(ManufacturersProperty); }
            set { SetValue(ManufacturersProperty, value); RaisePropertyChanged("Manufacturers"); }
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersProperty =
            DependencyProperty.Register("Manufacturers", typeof(ManufacturersViewModelCollection), typeof(MainViewModel),
                new PropertyMetadata(default(ManufacturersViewModelCollection)));
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

        public override void Initialized()
        {
            base.Initialized();

            if (_projects_controller == null)
                return;

            Projects = new ProjectListViewModelCollection();
            Manufacturers = new ManufacturersViewModelCollection();
            Clients = new ClientViewModelCollection();

        }

        public override async void Query()
        {
            //非同步讀取資料庫
            await Dispatcher.InvokeAsync(new Action(Projects.Query), System.Windows.Threading.DispatcherPriority.Background);
            await Dispatcher.InvokeAsync(new Action(Manufacturers.Query), System.Windows.Threading.DispatcherPriority.Background);
            await Dispatcher.InvokeAsync(new Action(Clients.Query), System.Windows.Threading.DispatcherPriority.Background);
          
        }
    }
}
