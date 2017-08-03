using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class RepositoryLocator
    {
        public RepositoryLocator()
        {
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IUnitOfWork>())
                SimpleIoc.Default.Register<IUnitOfWork, EFUnitOfWork>(true);

            Type tDefprovider = SimpleIoc.Default.GetType();

            var IsRegisteredMethod = tDefprovider.GetMethod("IsRegistered", BindingFlags.CreateInstance | BindingFlags.Public);
            var RegisterMethod = tDefprovider.GetMethod("Register", BindingFlags.CreateInstance | BindingFlags.Public);

            Assembly currentAsm = Assembly.GetExecutingAssembly();

            var types = currentAsm.GetTypes().Where(w => w.IsInterface == false
            && w.IsClass == true
            && (w.BaseType.IsInterface == true && w.BaseType.Name.EndsWith("Repository"))
            && w.Name.EndsWith("Repository"));

            foreach (var reg_type in types)
            {
                var rtinvoker_isRegister = IsRegisteredMethod.MakeGenericMethod(reg_type.BaseType);
                var rtinvoker_Register = RegisterMethod.MakeGenericMethod(reg_type.BaseType, reg_type);
                if (!(bool)rtinvoker_isRegister.Invoke(SimpleIoc.Default, new object[] { }))
                {
                    rtinvoker_Register.Invoke(SimpleIoc.Default, new object[] { });
                }
            }


            //if (!SimpleIoc.Default.IsRegistered<IAbnormalQualityDetailsRepository>())
            //    SimpleIoc.Default.Register<IAbnormalQualityDetailsRepository, AbnormalQualityDetailsRepository>();

            //if (!SimpleIoc.Default.IsRegistered<IAbnormalQualityRepository>())
            //    SimpleIoc.Default.Register<IAbnormalQualityRepository, AbnormalQualityRepository>();

            //if (!SimpleIoc.Default.IsRegistered<IAccessLogRepository>())
            //    SimpleIoc.Default.Register<IAccessLogRepository, AccessLogRepository>();

            //if (!SimpleIoc.Default.IsRegistered<IBOMRepository>())
            //    SimpleIoc.Default.Register<IBOMRepository, BOMRepository>();

            //if (!SimpleIoc.Default.IsRegistered<IConstructionAtlasRepository>())
            //    SimpleIoc.Default.Register<IConstructionAtlasRepository, ConstructionAtlasRepository>();

            //if (!SimpleIoc.Default.IsRegistered<IContactsRepository>())
            //    SimpleIoc.Default.Register<IContactsRepository, ContactsRepository>();

            //if (!SimpleIoc.Default.IsRegistered<IControlTableDetailsRepository>())
            //    SimpleIoc.Default.Register<IControlTableDetailsRepository, ControlTableDetailsRepository>();

            //if (!SimpleIoc.Default.IsRegistered<IControlTablesRepository>())
            //    SimpleIoc.Default.Register<IControlTablesRepository, ControlTablesRepository>();
        }

        public IAbnormalQualityDetailsRepository AbnormalQualityDetails
        {
            get => SimpleIoc.Default.GetInstance<IAbnormalQualityDetailsRepository>();
        }

        public IAbnormalQualityRepository AbnormalQuality { get => SimpleIoc.Default.GetInstance<IAbnormalQualityRepository>(); }
    }
}
