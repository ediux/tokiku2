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
            //_projects_controller = projects_controller;

            //Status = new DocumentStatusViewModel();
            //Projects = new ProjectListViewModelCollection();
            //Manufacturers = new ManufacturersViewModelCollection();

            //Clients = new ClientViewModelCollection();
            //ToolBarButtons = new ToolbarButtonsViewModel();

        }

        public override void ReplyFrom(object source)
        {
            if (source is RoutedViewResult)
            {

            }
        }

        #region 目前選定的專案
        private ProjectsViewModel _CurrentProject;

        /// <summary>
        /// 目前選定的專案
        /// </summary>
        public ProjectsViewModel CurrentProject
        {
            get
            {
                return _CurrentProject;
            }

            set
            {
                _CurrentProject = value;
                RaisePropertyChanged("CurrentProject");
            }
        }
        #endregion

        #region 專案列表
        private ProjectListViewModelCollection _Projects;
        /// <summary>
        /// 專案列表
        /// </summary>
        public ProjectListViewModelCollection Projects
        {
            get { return _Projects; }
            set { _Projects = value; RaisePropertyChanged("Projects"); }
        }


        #endregion

        #region 廠商列表
        private ManufacturersViewModelCollection _Manufacturers;
        /// <summary>
        /// 廠商列表
        /// </summary>
        public ManufacturersViewModelCollection Manufacturers
        {
            get { return _Manufacturers; }
            set { _Manufacturers = value; RaisePropertyChanged("Manufacturers"); }
        }


        #endregion

        #region 客戶列表
        private ClientViewModelCollection _Clients;
        /// <summary>
        /// 客戶列表
        /// </summary>
        public ClientViewModelCollection Clients
        {
            get { return _Clients; }
            set { _Clients = value; RaisePropertyChanged("Clients"); }
        }




        #endregion

        #region 工具列狀態
        private ToolbarButtonsViewModel _ToolBarButtons;
        /// <summary>
        /// 工具列按鈕狀態
        /// </summary>
        public ToolbarButtonsViewModel ToolBarButtons
        {
            get { return _ToolBarButtons; }
            set { _ToolBarButtons = value; RaisePropertyChanged("ToolBarButtons"); }
        }


        #endregion

        public override void Initialized(object Parameter)
        {
            base.Initialized(Parameter);

            if (_projects_controller == null)
                return;

            Projects = new ProjectListViewModelCollection();
            Manufacturers = new ManufacturersViewModelCollection();
            Clients = new ClientViewModelCollection();

        }

        public void Query()
        {
            //非同步讀取資料庫
            _Projects = ProjectListViewModelCollection.Query<ProjectListViewModelCollection, Projects>("", "");
            //await Dispatcher.InvokeAsync(new Action(Projects.Query), System.Windows.Threading.DispatcherPriority.Background);
            //await Dispatcher.InvokeAsync(new Action(Manufacturers.Query), System.Windows.Threading.DispatcherPriority.Background);
            //await Dispatcher.InvokeAsync(new Action(Clients.Query), System.Windows.Threading.DispatcherPriority.Background);

        }
    }
}
