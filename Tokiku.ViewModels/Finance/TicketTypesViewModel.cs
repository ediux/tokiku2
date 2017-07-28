using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TicketTypesViewModelCollection : BaseViewModelCollection<TicketTypesViewModel>
    {
        private Controllers.ManufacturersManageController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new Controllers.ManufacturersManageController();
            Query();
        }

        public static TicketTypesViewModelCollection Query()
        {
            return Query<TicketTypesViewModelCollection, TicketTypes>("ManufacturersManage", "GetTranscationCategoriesList");
            //var result = await controller.GetTranscationCategoriesListAsync();

            //if (!result.HasError)
            //{
            //    if (result.Result.Any())
            //    {
            //        ClearItems();
            //        foreach (var item in result.Result)
            //        {
            //            TicketTypesViewModel model = new TicketTypesViewModel();
            //            model.SetModel(item);
            //            Add(model);
            //        }
            //    }
            //}
            //else
            //{
            //    Errors = result.Errors;
            //    HasError = result.HasError;
            //}
        }
    }

    public class TicketTypesViewModel : BaseViewModelWithPOCOClass<TicketTypes>
    {
        public TicketTypesViewModel()
        {

        }
        public TicketTypesViewModel(TicketTypes entity) : base(entity)
        {

        }
        #region Id


        public new byte Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }

        #endregion

        #region Name


        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }

    

        #endregion

       

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        TicketTypes data = (TicketTypes)entity;
        //        BindingFromModel(data, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}
        public override string ToString()
        {
            return Name;
        }
    }
}
