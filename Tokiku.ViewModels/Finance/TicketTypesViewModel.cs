﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
  

    public class TicketTypesViewModel : EntityBaseViewModel<TicketTypes>, ITicketTypesViewModel
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
