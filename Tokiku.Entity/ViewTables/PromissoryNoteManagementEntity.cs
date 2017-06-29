using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    /// <summary>
    /// 本票管理Entity
    /// </summary>
    public class PromissoryNoteManagementEntity
    {
        // 工程代號
        public string ContractNumber { get; set; }
        // 專案名稱
        public string ProjectName { get; set; }
        // 本票代號
        public Nullable<byte> PromissoryId { get; set; }
        // 本票名稱
        public string PromissoryName { get; set; }
        // 本票票據金額
        public Nullable<float> PromissoryAmount { get; set; }
        // 本票開立日期
        public string PromissoryOpenDate { get; set; }
        // 本票取回日期
        public string PromissoryRecoveryDate { get; set; }
        // 保固票代號
        public Nullable<byte> WarrantyId { get; set; }
        // 保固票名稱
        public string WarrantyName { get; set; }
        // 保固票票據金額
        public Nullable<float> WarrantyAmount { get; set; }
        // 保固票開立日期
        public string WarrantyOpenDate { get; set; }
        // 保固票取回日期
        public string WarrantyRecoveryDate { get; set; }
        // 異動人員代號
        public Nullable<Guid> CreateUserId { get; set; }
        // 異動人員
        public string CreateUser { get; set; }
        // 異動時間
        public string CreateTime { get; set; }

    }
}
