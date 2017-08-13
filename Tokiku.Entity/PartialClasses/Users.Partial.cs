using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public interface IUsers2 : IUsers
    {

        Profile Profile { get; set; }
        ICollection<Roles> Roles { get; set; }

        ICollection<Materials> Materials { get; set; }
        ICollection<Molds> Molds { get; set; }
        ICollection<ProjectContract> ProjectContract { get; set; }
        ICollection<ProjectItemCost> ProjectItemCost { get; set; }
        ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
        ICollection<BOM> BOM { get; set; }
        ICollection<OrderDetails> OrderDetails { get; set; }
        ICollection<Orders> OrdersByCreateUser { get; set; }
        ICollection<Orders> OrdersByMakingUser { get; set; }
        ICollection<PickList> PickList { get; set; }
        ICollection<PickList> PickList_MakingUser { get; set; }
        ICollection<Receive> Receipts_CreateUser { get; set; }
        ICollection<Receive> Receipts_MakingUser { get; set; }
        ICollection<Invoices> Invoices_CreateUser { get; set; }
        ICollection<Invoices> Invoices_InvoiceUser { get; set; }
        ICollection<MaterialEstimation> MaterialEstimation { get; set; }
        ICollection<Required> Required { get; set; }
        ICollection<Required> Required1 { get; set; }
        ICollection<ShopFlowDetail> ShopFlowDetail { get; set; }
        ICollection<Returns> Returns_CreateUser { get; set; }
        ICollection<Returns> Returns_MakingUser { get; set; }
        ICollection<AbnormalQuality> AbnormalQuality_MakingUser { get; set; }
        ICollection<AbnormalQuality> AbnormalQuality_CreateUser { get; set; }
    }

    public partial class Users : IUsers2
    {
        IMembership IUsers.Membership { get => Membership; set => Membership = (Membership)value; }
    }
}
