using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class AccessLogViewModel : BaseViewModelWithPOCOClass<AccessLog>
    {
        [Key]
        public long Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }

        public string DataTableName
        {
            get { return CopyofPOCOInstance.DataTableName; }
            set { CopyofPOCOInstance.DataTableName = value; RaisePropertyChanged("DataTableName"); }
        }


        /// <summary>
        /// 異動人員帳號
        /// </summary>
        public string UserName
        {
            get
            {
                var executeresult = SystemController.GetUserById(CopyofPOCOInstance.UserId);

                if (!executeresult.HasError)
                {
                    return executeresult.Result.UserName;
                }

                return string.Empty;
            }
            set
            {
                SystemController sysCtr = new SystemController();
                var executeresult = sysCtr.GetUser(value);
                if (!executeresult.HasError)
                {
                    CopyofPOCOInstance.UserId = executeresult.Result.UserId;
                }
            }
        }


        /// <summary>
        /// 存取時間
        /// </summary>
        [Column("CreateTime")]
        public DateTime UpdateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("UpdateTime"); }
        }




        /// <summary>
        /// 存取動作
        /// </summary>
        public string Action
        {
            get
            {
                string actionname = "";

                switch ((ActionCodes)CopyofPOCOInstance.ActionCode)
                {
                    case ActionCodes.Read:
                        actionname = "讀取資料";
                        break;
                    case ActionCodes.Create:
                        actionname = "建立資料";
                        break;
                    case ActionCodes.Update:
                        actionname = "更新資料";
                        break;
                    case ActionCodes.Delete:
                        actionname = "刪除資料";
                        break;
                    case ActionCodes.ConstructionOrderChange:
                        actionname = "施工圖集變更";
                        break;
                    default:
                        actionname = "其他";
                        break;
                }
                return actionname;
            }
            set
            {
                switch (value)
                {
                    case "讀取資料":
                        CopyofPOCOInstance.ActionCode = 0;
                        break;
                    case "建立資料":
                        CopyofPOCOInstance.ActionCode = 1;
                        break;
                    case "更新資料":
                        CopyofPOCOInstance.ActionCode = 2;
                        break;
                    case "刪除資料":
                        CopyofPOCOInstance.ActionCode = 4;
                        break;
                    case "施工圖集變更":
                        CopyofPOCOInstance.ActionCode = 8;
                        break;
                    case "其他":
                    default:
                        CopyofPOCOInstance.ActionCode = 1;
                        break;

                }
                RaisePropertyChanged("Action");
            }
        }




        /// <summary>
        /// 紀錄說明(變更原因說明)
        /// </summary>
        [Column("Reason")]
        public string Description
        {
            get { return CopyofPOCOInstance.Reason; }
            set { CopyofPOCOInstance.Reason = value; RaisePropertyChanged("Description"); }
        }




        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is AccessLog)
                {
                    CopyofPOCOInstance = (AccessLog)entity;
                    BindingFromModel(CopyofPOCOInstance);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                throw;
            }
        }


    }
}
