using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Reflection;

namespace Tokiku.Controllers
{
    public class ControllersLocator
    {
        public ControllersLocator()
        {
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(new ServiceLocatorProvider(() => SimpleIoc.Default));

            Type tDefprovider = SimpleIoc.Default.GetType();

            var IsRegisteredMethod = tDefprovider.GetMethod("IsRegistered", BindingFlags.CreateInstance | BindingFlags.Public);
            var RegisterMethod = tDefprovider.GetMethod("Register", BindingFlags.CreateInstance | BindingFlags.Public);

            Assembly currentAsm = Assembly.GetExecutingAssembly();

            var types = currentAsm.GetTypes().Where(w => w.IsInterface == false
            && w.IsClass == true
            && ((w.BaseType.IsInterface == true && w.BaseType.Name.EndsWith("Controller"))
            || w.Name.EndsWith("Controller")));

            foreach (var reg_type in types)
            {
                var rtinvoker_isRegister = IsRegisteredMethod.MakeGenericMethod(reg_type.BaseType);
                var rtinvoker_Register = RegisterMethod.MakeGenericMethod(reg_type.BaseType, reg_type);
                if (!(bool)rtinvoker_isRegister.Invoke(SimpleIoc.Default, new object[] { }))
                {
                    rtinvoker_Register.Invoke(SimpleIoc.Default, new object[] { });
                }
            }

            //SimpleIoc.Default.Register<IContactPersonManageController, ContractManagementController>();
            //SimpleIoc.Default.Register<IControlTableController, ControlTableController>();
            //SimpleIoc.Default.Register<IInventoryController, InventoryController>();

        }

        public IContactPersonManageController ContactPersonManage {
            get => SimpleIoc.Default.GetInstance<IContactPersonManageController>();
        }


    }
}
