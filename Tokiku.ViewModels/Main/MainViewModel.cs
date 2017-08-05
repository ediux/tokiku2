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
    public class MainViewModel : WithLoginUserBaseViewModel, IMainViewModel
    {
        //private Controllers.ProjectsController _projects_controller;

        //public MainViewModel(Controllers.ProjectsController projects_controller)
        //{
        //    //_projects_controller = projects_controller;

        //    //Status = new DocumentStatusViewModel();
        //    //Projects = new ProjectListViewModelCollection();
        //    //Manufacturers = new ManufacturersViewModelCollection();

        //    //Clients = new ClientViewModelCollection();
        //    //ToolBarButtons = new ToolbarButtonsViewModel();

        //}

        public MainViewModel Query()
        {
            UserViewModel loginUser = QuerySingle<UserViewModel, Users>("System", "GetCurrentLoginUser");
            return new MainViewModel() { LoginedUser = loginUser };
        }
    }
}
