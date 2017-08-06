using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ShippingDetailsController : ControllerBase
    {
        public ActionResult QueryAll()
        {
            return View(SimpleIoc.Default.GetInstance<IMainViewModel>());
        }
        //public ExecuteResultEntity<ICollection<View_Shipping>> QueryAll()
        //{
        //    try
        //    {
        //        //var repo = this.GetRepository<IView_ShippingRepository, View_Shipping>();
        //        //return ExecuteResultEntity<ICollection<View_Shipping>>.CreateResultEntity(
        //        //    new Collection<View_Shipping>(repo.All().ToList()));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExecuteResultEntity<ICollection<View_Shipping>>.CreateErrorResultEntity(ex);
        //    }
        //}
    }
}
