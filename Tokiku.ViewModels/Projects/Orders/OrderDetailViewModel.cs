using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderDetailViewModelCollection : BaseViewModelCollection<OrderDetailViewModel>
    {
        public OrderDetailViewModelCollection()
        {

        }

        public OrderDetailViewModelCollection(IEnumerable<OrderDetailViewModel> source) : base(source)
        {


        }

        public static OrderDetailViewModelCollection Query(Guid ProjectId, Guid ShopFlowId)
        {
            OrderDetailViewModelCollection returnSet = null;
            try
            {
                OrderDetailViewModelCollection QueryResuly
                    = Query<OrderDetailViewModelCollection, Orders>("Orders", "Query", ProjectId, ShopFlowId);


                if (!returnSet.HasError)
                {
                    return returnSet;
                }

                return new OrderDetailViewModelCollection();
            }
            catch (Exception ex)
            {
                if (returnSet == null)
                    returnSet = new OrderDetailViewModelCollection();

                returnSet.Errors = new string[] { ex.Message };
                returnSet.HasError = true;

                return returnSet;
            }
        }

        public static OrderDetailViewModelCollection Query()
        {
            return new OrderDetailViewModelCollection();
        }

    }
    

    public class OrderDetailViewModel : BaseViewModelWithPOCOClass<OrderDetails>
    {
        public OrderDetailViewModel() : base()
        {

        }

        public OrderDetailViewModel(OrderDetails entity) : base(entity)
        {

        }

        // "*東菊編號*"
        public string TokikuId
        {
            get { return CopyofPOCOInstance.RequiredDetails.Code; }
            set
            {
                //反查
                RaisePropertyChanged("TokikuId");
            }
        }



        // "*廠商編號*"
        public string ManufacturersId
        {
            get { return CopyofPOCOInstance.RequiredDetails.Required.Manufacturers.Code; }
            set { RaisePropertyChanged("ManufacturersId"); }
        }



        // "*材質*"
        public string Material
        {
            get { return CopyofPOCOInstance.RequiredDetails.Materials.Name; }
            set { RaisePropertyChanged("Material"); }
        }


        // "*單位重(kg/m)*"
        public decimal UnitWeight
        {
            get { return CopyofPOCOInstance.RequiredDetails.UnitWeight; }
            set {  RaisePropertyChanged("UnitWeight"); }
        }



        // "*訂購長度(mm)*"
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.RequiredDetails.OrderLength; }
            set { CopyofPOCOInstance.RequiredDetails.OrderLength = value; RaisePropertyChanged("OrderLength"); }
        }



        // "[需求數量]"
        public Nullable<int> RequiredQuantity
        {
            get { return CopyofPOCOInstance.RequiredDetails.RequiredQuantity; }
            set {  RaisePropertyChanged("RequiredQuantity"); }
        }



        // "[備品數量]"
        public decimal SparePartsQuantity
        {
            get { return CopyofPOCOInstance.SparePartsNumber; }
            set { CopyofPOCOInstance.SparePartsNumber = value; RaisePropertyChanged("SparePartsQuantity"); }
        }



        // "[下單數量]"
        public decimal PlaceAnOrderQuantity
        {
            get { return CopyofPOCOInstance.OrderQuantity; }
            set { CopyofPOCOInstance.OrderQuantity = value; RaisePropertyChanged("PlaceAnOrderQuantity"); }
        }


        // "[備註]"
        public string Note
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Note"); }
        }

    }
}
