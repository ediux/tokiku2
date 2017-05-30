using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class MainController
    {
        public void Index(Window frame)
        {
            UserController controller = new UserController();
            ProjectsController pc = new ProjectsController();
            ManufacturersController mc = new ManufacturersController();
            ClientController clientcontroller = new ClientController();
            try
            {
                MainViewModel main_model = new MainViewModel();

                main_model.LoginedUser = controller.GetCurrentLoginUser();
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
