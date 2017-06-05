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
            Manufacturers = new ObservableCollection<ManufacturersViewModel>();
            Clients = new ClientViewModelCollection();
            ToolBarButtons = new ToolbarButtonsViewModel();
            StartUp_Query();
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

        public override void StartUp_Query()
        {
            LoginedUser = BindingFromModel<UserViewModel, Users>(_projects_controller.GetCurrentLoginUser().Result);
            var projectResult = _projects_controller.Query(v => v.Void == false);

            if (!projectResult.HasError)
            {
                Projects = new ProjectListViewModelCollection(projectResult.Result
                    .Select(s => BindingFromModel<ProjectListViewModel, Projects>(s)));
            }
            //((MainViewModel)DataContext).Manufacturers = mc.QueryAll();
            //((MainViewModel)DataContext).Clients = clientcontroller.QueryAll();
        }

        public override void Refresh()
        {
            //重新整理檢視模型
            //((MainViewModel)DataContext).Projects = controller.QueryAll();
            //((MainViewModel)DataContext).Manufacturers = mc.QueryAll();
            //((MainViewModel)DataContext).Clients = clientcontroller.QueryAll();
        }
    }
}
