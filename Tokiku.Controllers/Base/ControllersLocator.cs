using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Tokiku.Controllers.Base
{
    public class ControllersLocator
    {
        public ControllersLocator()
        {
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(new ServiceLocatorProvider(() => SimpleIoc.Default));

            SimpleIoc.Default.Register<IContactPersonManageController, ContractManagementController>();
        }

        public IContactPersonManageController ContactPersonManage {
            get => SimpleIoc.Default.GetInstance<IContactPersonManageController>();
        }


    }
}
