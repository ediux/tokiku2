using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
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
            set
            {
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

        public decimal RequiredQuantity
        {
            get => CopyofPOCOInstance.RequiredQuantity; set
            {
                CopyofPOCOInstance.RequiredQuantity = value;
                RaisePropertyChanged("RequiredQuantity");
            }
        }

        public decimal SparePartsQuantity
        {
            get => CopyofPOCOInstance.SparePartsNumber; set
            {
                CopyofPOCOInstance.SparePartsNumber = value;
                RaisePropertyChanged("SparePartsQuantity");
            }
        }

        public decimal PlaceAnOrderQuantity
        {
            get => CopyofPOCOInstance.OrderQuantity; set
            {
                CopyofPOCOInstance.OrderQuantity = value;
                RaisePropertyChanged("PlaceAnOrderQuantity");
            }
        }

        public string Note
        {
            get => CopyofPOCOInstance.Comment; set
            {
                CopyofPOCOInstance.Comment = value;
                RaisePropertyChanged("Note");
            }
        }
    }
}
