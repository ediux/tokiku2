using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    [MetadataType(typeof(ManufacturersMetaDataInfo))]
    public partial class Manufacturers
    {

    }

    public partial class ManufacturersMetaDataInfo
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "客戶名稱/廠商名稱為必要項。")]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string UniformNumbers { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "輸入的格式不符電話號碼格式!")]
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string eMail { get; set; }
        public string Address { get; set; }
        public string FactoryPhone { get; set; }
        public string FactoryFax { get; set; }
        public string FactoryAddress { get; set; }
        public string Comment { get; set; }
        public bool Void { get; set; }
        public bool IsClient { get; set; }
        public string ContractNumber { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public string AccountingCode { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountName { get; set; }
        public string CheckNumber { get; set; }
        public Nullable<float> ContractAmount { get; set; }
        public Nullable<float> AmountDue { get; set; }
        public Nullable<float> PrepaymentGuaranteeAmount { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        public byte PaymentType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public string Principal { get; set; }
        public string MainContactPerson { get; set; }

        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual PaymentTypes PaymentTypes { get; set; }
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
    }
}
