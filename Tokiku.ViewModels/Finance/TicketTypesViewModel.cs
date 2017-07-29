using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TicketTypesViewModelCollection : BaseViewModelCollection<TicketTypesViewModel, TicketTypes>
    {
        public TicketTypesViewModelCollection()
        {

        }

        public TicketTypesViewModelCollection(IEnumerable<TicketTypesViewModel> source) : base(source)
        {

        }

        public override string ControllerName => ManufacturersManageControllerName; 
    }

    public class TicketTypesViewModel : BaseViewModelWithPOCOClass<TicketTypes>
    {
        public TicketTypesViewModel()
        {

        }
        public TicketTypesViewModel(TicketTypes entity) : base(entity)
        {

        }

        public override string ControllerName => ManufacturersManageControllerName;

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
