using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.Entity
{
    public partial class EFRepository<T>
    {
        public EFRepository()
        {
            UnitOfWork = SimpleIoc.Default.GetInstance<IUnitOfWork>();
        }
    }
}
