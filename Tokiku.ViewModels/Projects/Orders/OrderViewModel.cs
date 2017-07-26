using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderViewModel : BaseViewModelWithPOCOClass<Orders>
    {

        public OrderViewModel() : base()
        {

        }

        public OrderViewModel(Orders entity) : base(entity)
        {

        }


        public int Order { get => CopyofPOCOInstance.Order; set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); } }
        public Guid? OrderTypeId { get => CopyofPOCOInstance.OrderTypeId; set { } }
        public string RequiredDep { get => CopyofPOCOInstance.RequiredDep; set { } }
        public string FormNumber { get => CopyofPOCOInstance.FormNumber; set { } }
        public string BatchNumber { get => CopyofPOCOInstance.BatchNumber; set { } }
        public DateTime ExpectedDelivery { get => CopyofPOCOInstance.ExpectedDelivery; set { } }
        public DateTime? ActualDelivery { get => CopyofPOCOInstance.ActualDelivery; set { } }
        public Guid? MakingUserId { get => CopyofPOCOInstance.MakingUserId; set { } }
        public UserViewModel MakingUsers { get => new UserViewModel(CopyofPOCOInstance.MakingUsers); set { RaisePropertyChanged("MakingUsers"); } }

        public DateTime? MakingTime { get => CopyofPOCOInstance.MakingTime; set { } }
        public double? ReservedPercentage { get => CopyofPOCOInstance.ReservedPercentage; set { } }
        public Guid? ShippingManufactureId { get => CopyofPOCOInstance.ShippingManufactureId; set { } }


    }
}
