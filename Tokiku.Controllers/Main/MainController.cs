using System;
using System.Windows;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class MainController : BaseController
    {
        ProjectsController pc;
        ManufacturersController mc;
        ClientController clientcontroller;

        public MainController(ProjectsController _pc,ManufacturersController _mc, ClientController _cc)
        {
            pc = _pc;
            mc = _mc;
            clientcontroller = _cc;
        }

        public MainViewModel Index()
        {
            try
            {
                MainViewModel main_model = new MainViewModel();

                main_model.LoginedUser = GetCurrentLoginUser();
                main_model.Projects = pc.QueryAll();
                main_model.Manufacturers = mc.QueryAll();
                main_model.Clients = clientcontroller.QueryAll();


                if (!main_model.HasError)
                    return main_model;
                else
                {
                    setErrortoModel(main_model, "");
                    return main_model;
                }
            }
            catch (Exception ex)
            {
                MainViewModel model = new MainViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }

        public void Index(Window frame)
        {
            UserController controller = new UserController();
            ProjectsController pc = new ProjectsController();
            ManufacturersController mc = new ManufacturersController();
            ClientController clientcontroller = new ClientController();
            try
            {
                MainViewModel main_model = new MainViewModel();

                main_model.LoginedUser = GetCurrentLoginUser();
                main_model.Projects = pc.QueryAll();
                main_model.Manufacturers = mc.QueryAll();
                main_model.Clients = clientcontroller.QueryAll();

                frame.DataContext = main_model;
                if (!main_model.HasError)
                    frame.Show();
                else
                    MessageBox.Show(string.Join(",", main_model.Errors));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
