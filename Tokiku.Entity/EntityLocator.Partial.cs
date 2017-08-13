using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public partial class EntityLocator
    {
        partial void ExtraRegister()
        {
            if (!SimpleIoc.Default.IsRegistered<Tokiku.MVVM.Entities.IUnitOfWork>())
                SimpleIoc.Default.Register<Tokiku.MVVM.Entities.IUnitOfWork, EFUnitOfWork>(true);
        }
    }
}
