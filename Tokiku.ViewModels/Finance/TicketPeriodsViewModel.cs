using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 所有票期設定清單
    /// </summary>
    public class TicketPeriodsViewModelCollection : BaseViewModelCollection<TicketPeriodsViewModel>
    {
        public TicketPeriodsViewModelCollection()
        {

        }

        public TicketPeriodsViewModelCollection(IEnumerable<TicketPeriodsViewModel> source) : base(source)
        {

        }




        public static TicketPeriodsViewModelCollection Query()
        {
            return Query<TicketPeriodsViewModelCollection, TicketPeriod>("TicketPeriodsManagement", "QueryAll");
            //var result = controller.QueryAll();
            //if (!result.HasError)
            //{
            //    if (result.Result.Any())
            //    {
            //        ClearItems();
            //        foreach (var entity in result.Result)
            //        {
            //            var model = new TicketPeriodsViewModel();

            //            Add(model);
            //        }
            //    }
            //}
        }

        public TicketPeriodsViewModelCollection QueryByManufacturers(Guid MaterialCategoriesId, string BusinessItem, Guid ManufacturersId)
        {
            return Query<TicketPeriodsViewModelCollection, TicketPeriod>("TicketPeriodsManagement", "QueryForSelectBusinessItem", MaterialCategoriesId, BusinessItem, ManufacturersId);
            //var result = await controller.QueryForSelectBusinessItemAsync(MaterialCategoriesId, BusinessItem, ManufacturersId);

            //if (!result.HasError)
            //{
            //    if (result.Result.Any())
            //    {
            //        ClearItems();
            //        foreach (var entity in result.Result)
            //        {
            //            var model = new TicketPeriodsViewModel();

            //            Add(model);
            //        }
            //    }
            //}
        }
    }

    public class TicketPeriodsViewModel : BaseViewModelWithPOCOClass<TicketPeriod>
    {
        public TicketPeriodsViewModel()
        {

        }

        public TicketPeriodsViewModel(TicketPeriod entity) : base(entity)
        {

        }
        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        public new int Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }

        #endregion

        #region Name

        /// <summary>
        /// 票期
        /// </summary>
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }



        #endregion

        #region DayLimit


        public int DayLimit
        {
            get { return CopyofPOCOInstance.DayLimit; }
            set { CopyofPOCOInstance.DayLimit = value; RaisePropertyChanged("DayLimit"); }
        }


        #endregion




        public override string ToString()
        {
            return Name;
        }
    }
}
