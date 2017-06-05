using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class ProjectListEntity
    {
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// 專案代碼
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 專案名稱
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 專案名稱(簡稱)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string State { get; set; }

        public DateTime? StartDate
        {
            get;
            set;
        }

        public DateTime? CompletionDate
        {
            get;
            set;
        }

        /// <summary>
        /// 保固日期
        /// </summary>
        public DateTime? WarrantyDate
        {
            get;
            set;
        }

      

    }
}
