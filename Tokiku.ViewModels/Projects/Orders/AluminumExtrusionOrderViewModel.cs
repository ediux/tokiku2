using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class AluminumExtrusionOrderViewModelCollection : BaseViewModelCollection<AluminumExtrusionOrderViewModel>
    {
        public AluminumExtrusionOrderViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderViewModelCollection(IEnumerable<AluminumExtrusionOrderViewModel> source) : base(source)
        {


        }

        public static AluminumExtrusionOrderViewModelCollection Query(Guid ProjectId, Guid FormDetailId)
        {
            AluminumExtrusionOrderViewModelCollection returnSet = null;
            try
            {
                AluminumExtrusionOrderController ctrl = new AluminumExtrusionOrderController();

                ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>> ere = ctrl.Query(ProjectId, FormDetailId);
                if (!ere.HasError)
                {
                    returnSet = new AluminumExtrusionOrderViewModelCollection(ere.Result.ToList()
                        .ConvertAll(c => new AluminumExtrusionOrderViewModel(c)));
                }

                return new AluminumExtrusionOrderViewModelCollection();
            }
            catch (Exception ex)
            {
                if (returnSet == null)
                    returnSet = new AluminumExtrusionOrderViewModelCollection();

                returnSet.Errors = new string[] { ex.Message };
                returnSet.HasError = true;

                return returnSet;
            }
        }

        public static AluminumExtrusionOrderViewModelCollection Query()
        {
            return Query<AluminumExtrusionOrderViewModelCollection, Orders>("", "");
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
        /// 訂單編號
        /// </summary>
        public new Guid Id
        {
            get => (CopyofPOCOInstance.Orders ?? CopyofPOCOInstance.Orders).Id; set
            {
                var ordermaster = ExecuteAction<Orders>("Orders", "QuerySingle", value);

                if (ordermaster != null)
                {
                    CopyofPOCOInstance.Orders = ordermaster;
                    CopyofPOCOInstance.OrderId = ordermaster.Id;
                    RaisePropertyChanged("Id");
                }
                else
                {
                    throw new Exception("找不到訂單表頭!");
                }
            }
        }

        /// <summary>
        /// 訂單細項編號
        /// </summary>
        public Guid DetailId
        {
            get => CopyofPOCOInstance.Id;
            set
            {

                CopyofPOCOInstance.Id = value;
                RaisePropertyChanged("DetailId");
            }
        }

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get => CopyofPOCOInstance.RequiredDetails.Code; set
            {
                var refdata = ExecuteAction<RequiredDetails>("Requires", "QuerySingleByCode", value);
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
        public string FactoryNumber { get => CopyofPOCOInstance?.RequiredDetails?.FactoryNumber; set {
                var refdata = ExecuteAction<RequiredDetails>("Requires", "QuerySingleByFactoryNumber", CopyofPOCOInstance.RequiredDetailsId, value);
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
            } }


        /// <summary>
        /// 材質
        /// </summary>
        public string Material { get => CopyofPOCOInstance?.RequiredDetails?.Materials?.Name; set {
                var refdata = ExecuteAction<RequiredDetails>("Requires", "QuerySingleByFactoryNumber", CopyofPOCOInstance.RequiredDetailsId, value);
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
            } }

        /// <summary>
        /// 單位重量
        /// </summary>
        public decimal? UnitWeight { get=>CopyofPOCOInstance?.RequiredDetails?.UnitWeight; set {

            } }

        /// <summary>
        /// 訂購長度
        /// </summary>
        public decimal? OrderLength { get => CopyofPOCOInstance?.RequiredDetails?.OrderLength;
            set {  }
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

    public class AluminumExtrusionOrderViewModel : BaseViewModelWithPOCOClass<AluminumExtrusionOrderEntity>
    {
        public AluminumExtrusionOrderViewModel() : base()
        {

        }

        public AluminumExtrusionOrderViewModel(AluminumExtrusionOrderEntity entity) : base(entity)
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
