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
    public class OrderDetailViewModelCollection : BaseViewModelCollection<OrderDetailViewModel, OrderDetails>
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
                    = Query<OrderDetailViewModelCollection>("Orders", "Query", ProjectId, ShopFlowId);


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
            get { return CopyofPOCOInstance?.RequiredDetails?.Code; }
            set
            {
                var found = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByCode", value);

                if (found != null)
                {
                    CopyofPOCOInstance.RequiredDetails = found;
                    CopyofPOCOInstance.RequiredDetailsId = found.Id;                    
                }
                else
                {
                    throw new Exception("找不到需求單項目");
                    //反查
                }

                RaisePropertyChanged("TokikuId");
                RaisePropertyChanged("ManufacturersId");
                RaisePropertyChanged("Material");
                RaisePropertyChanged("UnitWeight");
                RaisePropertyChanged("OrderLength");
            }
        }



        // "*廠商編號*"
        public string ManufacturersId
        {
            get { return CopyofPOCOInstance?.RequiredDetails?.FactoryNumber; }
            set
            {
                var found = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByFactoryNumber", TokikuId, value);

                if (found != null)
                {
                    CopyofPOCOInstance.RequiredDetails = found;
                    CopyofPOCOInstance.RequiredDetailsId = found.Id;
                    //反查
                    RaisePropertyChanged("TokikuId");
                    RaisePropertyChanged("ManufacturersId");
                    RaisePropertyChanged("Material");
                    RaisePropertyChanged("UnitWeight");
                    RaisePropertyChanged("OrderLength");
                }
                else
                {
                    throw new Exception("找不到需求單項目");
                }


            }
        }



        // "*材質*"
        public string Material
        {
            get { return CopyofPOCOInstance?.RequiredDetails?.Materials?.Name; }
            set
            {

                var found = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByMaterial", TokikuId, ManufacturersId, value);

                if (found != null)
                {
                    CopyofPOCOInstance.RequiredDetails = found;
                    CopyofPOCOInstance.RequiredDetailsId = found.Id;
                    //反查
                    RaisePropertyChanged("TokikuId");
                    RaisePropertyChanged("ManufacturersId");
                    RaisePropertyChanged("Material");
                    RaisePropertyChanged("UnitWeight");
                    RaisePropertyChanged("OrderLength");
                }
                else
                {
                    throw new Exception("找不到需求單項目");
                }

            }
        }


        // "*單位重(kg/m)*"
        public decimal? UnitWeight
        {
            get { return CopyofPOCOInstance?.RequiredDetails?.UnitWeight; }
            set
            {

            }
        }



        // "*訂購長度(mm)*"
        public int? OrderLength
        {
            get { return CopyofPOCOInstance?.RequiredDetails?.OrderLength; }
            set
            {          
            }
        }



        // "[需求數量]"
        public decimal RequiredQuantity
        {
            get { return CopyofPOCOInstance.RequiredQuantity; }
            set
            {
                CopyofPOCOInstance.RequiredQuantity = value;
                RaisePropertyChanged("RequiredQuantity");
            }
        }



        /// <summary>
        /// 備品數量
        /// </summary>
        public decimal SparePartsQuantity
        {
            get { return CopyofPOCOInstance.SparePartsNumber; }
            set { CopyofPOCOInstance.SparePartsNumber = value; RaisePropertyChanged("SparePartsQuantity"); }
        }



 
        /// <summary>
        /// 下單數量
        /// </summary>
        public decimal PlaceAnOrderQuantity
        {
            get { return CopyofPOCOInstance.OrderQuantity; }
            set { CopyofPOCOInstance.OrderQuantity = value; RaisePropertyChanged("PlaceAnOrderQuantity"); }
        }


        /// <summary>
        /// 備註
        /// </summary>
        public string Note
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Note"); }
        }

        
        
    }
}
