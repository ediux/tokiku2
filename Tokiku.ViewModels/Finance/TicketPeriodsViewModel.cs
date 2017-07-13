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
        private TicketPeriodsManagementController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new TicketPeriodsManagementController();
            Query();
        }

        public  void Query()
        {
            var result = controller.QueryAll();
            if (!result.HasError)
            {
                if (result.Result.Any())
                {
                    ClearItems();
                    foreach (var entity in result.Result)
                    {
                        var model = new TicketPeriodsViewModel();
                       
                        Add(model);
                    }
                }
            }
        }

        public async void QueryByManufacturers(Guid MaterialCategoriesId, string BusinessItem, Guid ManufacturersId)
        {
            var result = await controller.QueryForSelectBusinessItemAsync(MaterialCategoriesId, BusinessItem, ManufacturersId);

            if (!result.HasError)
            {
                if (result.Result.Any())
                {
                    ClearItems();
                    foreach (var entity in result.Result)
                    {
                        var model = new TicketPeriodsViewModel();

                        Add(model);
                    }
                }
            }
        }
    }

    public class TicketPeriodsViewModel : BaseViewModelWithPOCOClass<TicketPeriod>
    {

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
