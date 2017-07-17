using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
namespace Tokiku.ViewModels
{
    public class RequiredDetailViewModel : BaseViewModelWithPOCOClass<RequiredDetails>
    {
        public RequiredDetailViewModel()
        {

        }
        public RequiredDetailViewModel(RequiredDetails entity) : base(entity)
        {

        }

        public static RequiredDetailViewModel Query(Guid RequiredDetailId)
        {
            try
            {
                return QuerySingle<RequiredDetailViewModel, RequiredDetails>("Required", "QuerySingleDetailItem", RequiredDetailId);
            }
            catch (Exception ex)
            {
                RequiredDetailViewModel model = new RequiredDetailViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }

        /// <summary>
        /// 項次
        /// </summary>
        public int Order
        {
            get => CopyofPOCOInstance.Order;
            set
            {
                CopyofPOCOInstance.Order = value;
                RaisePropertyChanged("Order");
            }
        }

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get => CopyofPOCOInstance.Code;
            set
            {
                CopyofPOCOInstance.Code = value;
                RaisePropertyChanged("Code");
            }
        }

        /// <summary>
        /// 廠商編號(大同編號)
        /// </summary>
        public string FactoryNumber
        {
            get => CopyofPOCOInstance.FactoryNumber;
            set
            {
                CopyofPOCOInstance.FactoryNumber = value;

                RaisePropertyChanged("FactoryNumber");
            }
        }

        /// <summary>
        /// 材質
        /// </summary>
        public string Material
        {
            get => CopyofPOCOInstance?.Materials?.Name;
            set
            {
                try
                {
                    var foundmateial = ExecuteAction<Materials>("MaterialManagement", "QueryByName", value);

                    if (foundmateial != null)
                    {
                        CopyofPOCOInstance.Materials = foundmateial;
                        CopyofPOCOInstance.MaterialsId = foundmateial.Id;
                    }
                    else
                    {
                        CopyofPOCOInstance.Materials = new Materials();
                        CopyofPOCOInstance.Materials.Id = Guid.NewGuid();
                        CopyofPOCOInstance.MaterialsId = CopyofPOCOInstance.Materials.Id;
                        CopyofPOCOInstance.Materials.ManufacturersId = CopyofPOCOInstance.Materials.ManufacturersId = Guid.Empty;
                        CopyofPOCOInstance.Materials.Name = value;
                        CopyofPOCOInstance.Materials.UnitPrice = 0;
                        CopyofPOCOInstance.Materials.CreateTime = DateTime.Now;
                        
                    }

                    RaisePropertyChanged("Material");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }                
            }
        }

        /// <summary>
        /// 單位重量
        /// </summary>
        public decimal UnitWeight
        {
            get => CopyofPOCOInstance.UnitWeight;
            set
            {
                CopyofPOCOInstance.UnitWeight = value;
                RaisePropertyChanged("UnitWeight");
            }
        }

        /// <summary>
        /// 訂購長度
        /// </summary>
        public int? OrderLenth
        {
            get => CopyofPOCOInstance.OrderLength;
            set
            {
                CopyofPOCOInstance.OrderLength = value;
                RaisePropertyChanged("OrderLenth");
            }
        }

        /// <summary>
        /// 需求數量
        /// </summary>
        public int RequiredQuantity
        {
            get => CopyofPOCOInstance.RequiredQuantity;
            set
            {
                CopyofPOCOInstance.RequiredQuantity = value;
                RaisePropertyChanged("RequiredQuantity");
            }
        }
    }
}
