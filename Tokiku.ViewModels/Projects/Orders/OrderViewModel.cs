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
            CopyofPOCOInstance.Id = Guid.NewGuid();
            _OrderType = new OrderTypesViewModel(CopyofPOCOInstance.OrderTypes);
            _ShippingManufacture = new ManufacturersViewModel();
            this.Entity.ActualDelivery = DateTime.Now;
        }

        public OrderViewModel(Orders entity) : base(entity)
        {
            _OrderType = new OrderTypesViewModel(entity.OrderTypes);
            _ShippingManufacture = new ManufacturersViewModel();
        }


        public int Order { get => CopyofPOCOInstance.Order; set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); } }
        public Guid? OrderTypeId
        {
            get => CopyofPOCOInstance.OrderTypeId; set
            {
                CopyofPOCOInstance.OrderTypeId = value;
                _OrderType = new OrderTypesViewModel(CopyofPOCOInstance.OrderTypes); RaisePropertyChanged("OrderTypeId");
            }
        }

        OrderTypesViewModel _OrderType;

        public OrderTypesViewModel OrderType { get => _OrderType; }
        public string RequiredDep { get => CopyofPOCOInstance.RequiredDep; set { CopyofPOCOInstance.RequiredDep = value; RaisePropertyChanged("RequiredDep"); } }
        public string FormNumber { get => CopyofPOCOInstance.FormNumber; set { CopyofPOCOInstance.FormNumber = value; RaisePropertyChanged("FormNumber"); } }
        public string BatchNumber { get => CopyofPOCOInstance.BatchNumber; set { CopyofPOCOInstance.BatchNumber = value; RaisePropertyChanged("BatchNumber"); } }
        public DateTime ExpectedDelivery
        {
            get
            {
                if (CopyofPOCOInstance.ExpectedDelivery.Year < 1754)
                {
                    CopyofPOCOInstance.ExpectedDelivery = DateTime.Now;
                }
                return CopyofPOCOInstance.ExpectedDelivery;
            }
            set { CopyofPOCOInstance.ExpectedDelivery = value; RaisePropertyChanged("ExpectedDelivery"); }
        }
        public DateTime? ActualDelivery { get => CopyofPOCOInstance.ActualDelivery.HasValue ? CopyofPOCOInstance.ActualDelivery : DateTime.Now; set { CopyofPOCOInstance.ActualDelivery = value; RaisePropertyChanged("ActualDelivery"); } }
        public Guid? MakingUserId { get => CopyofPOCOInstance.MakingUserId ?? Guid.Empty; set { CopyofPOCOInstance.MakingUserId = value; RaisePropertyChanged("MakingUserId"); } }
        public UserViewModel MakingUsers { get => new UserViewModel(CopyofPOCOInstance.MakingUsers); set { RaisePropertyChanged("MakingUsers"); } }

        public DateTime? MakingTime { get => CopyofPOCOInstance.MakingTime ?? DateTime.Now; set { CopyofPOCOInstance.MakingTime = value; RaisePropertyChanged("MakingTime"); } }
        public double? ReservedPercentage { get => CopyofPOCOInstance.ReservedPercentage ?? 0; set { CopyofPOCOInstance.ReservedPercentage = value; RaisePropertyChanged("ReservedPercentage"); } }
        public Guid? ShippingManufactureId { get => CopyofPOCOInstance.ShippingManufactureId ?? Guid.Empty; set { CopyofPOCOInstance.ShippingManufactureId = value; RaisePropertyChanged("ShippingManufactureId"); } }

        private ManufacturersViewModel _ShippingManufacture;
        public ManufacturersViewModel ShippingManufacture { get => _ShippingManufacture; set { _ShippingManufacture = value; CopyofPOCOInstance.Manufacturers = _ShippingManufacture.Entity; RaisePropertyChanged("ShippingManufacture"); } }

        public static OrderViewModel CreateNew(Guid ProjectId)
        {
            try
            {
                return QuerySingle<OrderViewModel, Orders>("Orders", "CreateNew", ProjectId);
            }
            catch (Exception ex)
            {
                OrderViewModel viewmodel = new OrderViewModel();
                setErrortoModel(viewmodel, ex);
                return viewmodel;
            }
        }
    }
}
