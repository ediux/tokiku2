using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
   
    public class TicketPeriodsViewModel : EntityBaseViewModel<TicketPeriod>, ITicketPeriodsViewModel
    {
        public TicketPeriodsViewModel()
        {

        }

        [PreferredConstructor]
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
