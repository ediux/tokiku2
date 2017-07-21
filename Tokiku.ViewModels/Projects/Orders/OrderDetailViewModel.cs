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
    public class OrderViewModel : BaseViewModelWithPOCOClass<OrderDetails>
    {

        public OrderViewModel() : base()
        {

        }

        public OrderViewModel(OrderDetails entity) : base(entity)
        {

        }

        /// <summary>
        /// 專案識別碼
        /// </summary>
        public Guid? ProjectId
        {
            get => CopyofPOCOInstance.RequiredDetails.Required.ProjectId; 
        }

        /// <summary>
        /// 訂單編號
        /// </summary>
        [Key]
        public new Guid Id
        {
            get => CopyofPOCOInstance.Id; set
            {
                CopyofPOCOInstance.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        /// <summary>
        /// 訂單表頭編號
        /// </summary>
        
        public Guid? OrderId
        {
            get => CopyofPOCOInstance.OrderId;
            set
            {
                var ordermaster = ExecuteAction<Orders>("Orders", "QuerySingle", value);

                if (ordermaster != null)
                {
                    CopyofPOCOInstance.Orders = ordermaster;
                    CopyofPOCOInstance.OrderId = ordermaster.Id;
                   
                }
                else
                {
                    throw new Exception("找不到訂單表頭!");
                }
                
                RaisePropertyChanged("OrderId");
            }
        }

        /// <summary>
        /// 需求單細項對應Id
        /// </summary>
        public Guid? RequiredDetailsId
        {
            get => CopyofPOCOInstance.RequiredDetailsId; set
            {
                var refdata = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetail",
                   value);

                if (refdata != null)
                {
                    CopyofPOCOInstance.RequiredDetails = refdata;
                    CopyofPOCOInstance.RequiredDetailsId = refdata.Id;

                    RaisePropertyChanged("RequiredDetailsId");
                }
                else
                {
                    throw new Exception("找不到東菊編號!");
                }
            }
        }

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get => CopyofPOCOInstance.RequiredDetails.Code; set
            {
                var refdata = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByCode",
                    ProjectId,
                    RequiredDetailsId,
                    value);

                if (refdata != null)
                {
                    CopyofPOCOInstance.RequiredDetails = refdata;
                    CopyofPOCOInstance.RequiredDetailsId = refdata.Id;

                    RaisePropertyChanged("Code");
                }
                else
                {
                    throw new Exception("找不到東菊編號!");
                }
            }
        }

        /// <summary>
        /// 廠商編號
        /// </summary>
        public string FactoryNumber
        {
            get => CopyofPOCOInstance?.RequiredDetails?.FactoryNumber; set
            {
                var refdata = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByFactoryNumber",
                   ProjectId,
                   RequiredDetailsId,
                   value);

                if (refdata != null)
                {
                    CopyofPOCOInstance.RequiredDetails = refdata;
                    CopyofPOCOInstance.RequiredDetailsId = refdata.Id;

                    RaisePropertyChanged("FactoryNumber");
                }
                else
                {
                    throw new Exception("找不到廠商編號!");
                }

            }
        }


        /// <summary>
        /// 材質
        /// </summary>
        public string Material
        {
            get => CopyofPOCOInstance?.RequiredDetails?.Materials?.Name; set
            {
                var refdata = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByMaterial",
                   ProjectId,
                   RequiredDetailsId,
                   value);
 
                if (refdata != null)
                {
                    CopyofPOCOInstance.RequiredDetails = refdata;
                    CopyofPOCOInstance.RequiredDetailsId = refdata.Id;

                    RaisePropertyChanged("Material");
                }
                else
                {
                    throw new Exception("無法對應資料!");
                }
            }
        }

        /// <summary>
        /// 單位重量
        /// </summary>
        public decimal? UnitWeight
        {
            get => CopyofPOCOInstance?.RequiredDetails?.UnitWeight; set
            {
                var refdata = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByUnitWeight",
                  ProjectId,
                  RequiredDetailsId,
                  value);

                if (refdata != null)
                {
                    CopyofPOCOInstance.RequiredDetails = refdata;
                    CopyofPOCOInstance.RequiredDetailsId = refdata.Id;

                    RaisePropertyChanged("UnitWeight");
                }
                else
                {
                    throw new Exception("無法對應資料!");
                }
            }
        }

        /// <summary>
        /// 訂購長度
        /// </summary>
        public decimal? OrderLength
        {
            get => CopyofPOCOInstance?.RequiredDetails?.OrderLength;
            set {
                var refdata = ExecuteAction<RequiredDetails>("Required", "QuerySingleDetailByOrderLength",
                 ProjectId,
                 RequiredDetailsId,
                 value);

                if (refdata != null)
                {
                    CopyofPOCOInstance.RequiredDetails = refdata;
                    CopyofPOCOInstance.RequiredDetailsId = refdata.Id;

                    RaisePropertyChanged("OrderLength");
                }
                else
                {
                    throw new Exception("無法對應資料!");
                }
            }
        }

        public decimal RequiredQuantity { get => CopyofPOCOInstance.RequiredQuantity; set {
                CopyofPOCOInstance.RequiredQuantity = value;
                RaisePropertyChanged("RequiredQuantity");
            } }

        public decimal SparePartsQuantity { get => CopyofPOCOInstance.SparePartsNumber; set {
                CopyofPOCOInstance.SparePartsNumber = value;
                RaisePropertyChanged("SparePartsQuantity");
            } }

        public decimal PlaceAnOrderQuantity { get => CopyofPOCOInstance.OrderQuantity; set
            {
                CopyofPOCOInstance.OrderQuantity = value;
                RaisePropertyChanged("PlaceAnOrderQuantity");
            }
        }

        public string Note { get => CopyofPOCOInstance.Comment; set
            {
                CopyofPOCOInstance.Comment = value;
                RaisePropertyChanged("Note");
            }
        }
        private ICommand _SaveCommand = new RoutedCommand();

        /// <summary>
        /// 儲存命令
        /// </summary>
        public ICommand SaveCommand
        {
            get => _SaveCommand;
            set => _SaveCommand = value;
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
