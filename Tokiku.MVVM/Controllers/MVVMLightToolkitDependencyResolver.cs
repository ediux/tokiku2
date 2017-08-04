using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.MVVM
{
    public class MVVMLightToolkitDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
           
            try
            {
                return SimpleIoc.Default.GetService(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return SimpleIoc.Default.GetAllInstances(serviceType);
        }
    }
}