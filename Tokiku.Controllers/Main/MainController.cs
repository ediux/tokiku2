using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class MainController : BaseController
    {
        public MainViewModel Index()
        {
            UserController controller = new UserController();

            try
            {
                MainViewModel main_model = new MainViewModel();
                main_model.LoginedUser = controller.GetCurrentLoginUser();
                return main_model;
            }
            catch (Exception ex)
            {
                MainViewModel error_model = new MainViewModel();
                error_model.Error = ex;
                return error_model;
            }

        }
    }
}
