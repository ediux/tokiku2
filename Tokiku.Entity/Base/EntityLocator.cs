using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class EntityLocator
    {
        public EntityLocator()
        {
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(new ServiceLocatorProvider(() => SimpleIoc.Default));

            SimpleIoc.Default.Register<AbnormalQuality>();
            SimpleIoc.Default.Register<IUsers2, Users>();
            SimpleIoc.Default.Register<IMembership, Membership>();
            SimpleIoc.Default.Register<IProfile, Profile>();
        }

    }
}
