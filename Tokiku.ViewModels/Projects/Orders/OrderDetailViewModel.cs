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
    

    public class OrderDetailViewModel : BaseViewModelWithPOCOClass<AluminumExtrusionOrderEntity>
    {
        public OrderDetailViewModel() : base()
        {

        }

        public OrderDetailViewModel(AluminumExtrusionOrderEntity entity) : base(entity)
        {

        }

        // "*東菊編號*"
        public string TokikuId
        {
            get { return CopyofPOCOInstance.TokikuId; }
            set
            {
                CopyofPOCOInstance.TokikuId = value;
                RaisePropertyChanged("TokikuId");
            }
        }



        // "*廠商編號*"
        public string ManufacturersId
        {
            get { return CopyofPOCOInstance.ManufacturersId; }
            set { CopyofPOCOInstance.ManufacturersId = value; RaisePropertyChanged("ManufacturersId"); }
        }



        // "*材質*"
        public string Material
        {
            get { return CopyofPOCOInstance.Material; }
            set { CopyofPOCOInstance.Material = value; RaisePropertyChanged("Material"); }
        }


        // "*單位重(kg/m)*"
        public Nullable<float> UnitWeight
        {
            get { return CopyofPOCOInstance.UnitWeight; }
            set { CopyofPOCOInstance.UnitWeight = value; RaisePropertyChanged("UnitWeight"); }
        }



        // "*訂購長度(mm)*"
        public Nullable<int> OrderLength
        {
            get { return CopyofPOCOInstance.OrderLength; }
            set { CopyofPOCOInstance.OrderLength = value; RaisePropertyChanged("OrderLength"); }
        }



        // "[需求數量]"
        public Nullable<int> RequiredQuantity
        {
            get { return CopyofPOCOInstance.RequiredQuantity; }
            set { CopyofPOCOInstance.RequiredQuantity = value; RaisePropertyChanged("RequiredQuantity"); }
        }



        // "[備品數量]"
        public Nullable<int> SparePartsQuantity
        {
            get { return (Nullable<int>)CopyofPOCOInstance.SparePartsQuantity; }
            set { CopyofPOCOInstance.SparePartsQuantity = value; RaisePropertyChanged("SparePartsQuantity"); }
        }



        // "[下單數量]"
        public Nullable<int> PlaceAnOrderQuantity
        {
            get { return CopyofPOCOInstance.PlaceAnOrderQuantity; }
            set { CopyofPOCOInstance.PlaceAnOrderQuantity = value; RaisePropertyChanged("PlaceAnOrderQuantity"); }
        }


        // "[備註]"
        public string Note
        {
            get { return CopyofPOCOInstance.Note; }
            set { CopyofPOCOInstance.Note = value; RaisePropertyChanged("Note"); }
        }

    }
}
