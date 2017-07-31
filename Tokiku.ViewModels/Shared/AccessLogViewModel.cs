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
        public AccessLogViewModel()
        {
            _SaveModelController = "AccessLog";
        }

        public AccessLogViewModel(AccessLog entity) : base(entity)
        {
            _SaveModelController = "AccessLog";
        }

        /// <summary>
        /// 紀錄ID
        /// </summary>
        [Key]
        public new long Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }

        /// <summary>
        /// 關聯的資料表
        /// </summary>
        public string DataTableName
        {
            get { return CopyofPOCOInstance.DataTableName; }
            set { CopyofPOCOInstance.DataTableName = value; RaisePropertyChanged("DataTableName"); }
        }

        /// <summary>
        /// 異動資料識別碼
        /// </summary>
        public string DataId
        {
            get => CopyofPOCOInstance.DataId; set
            {
                CopyofPOCOInstance.DataId = value;
                RaisePropertyChanged("DataId");
            }
        }

        /// <summary>
        /// 異動人員帳號
        /// </summary>
        public string UserName
        {
            get
            {
                //var executeresult = SystemController.GetUserById(CopyofPOCOInstance.UserId);
                var executeresult = ExecuteAction<Users>("System", "GetUserById", CopyofPOCOInstance.UserId);

                if (executeresult != null)
                {
                    return executeresult.UserName;
                }

                return string.Empty;
            }
            set
            {
                //SystemController sysCtr = new SystemController();
                var executeresult = ExecuteAction<Users>("System", "GetUserByUserName", value);

                if (executeresult != null)
                {
                    CopyofPOCOInstance.UserId = executeresult.UserId;
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

    }
}
