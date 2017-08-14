using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IClientViewModel : IDocumentBaseViewModel<Manufacturers>
    {
        string Address { get; set; }
        string BankAccount { get; set; }
        string BankAccountName { get; set; }
        string BankName { get; set; }
        string Code { get; set; }
        string Comment { get; set; }
        IContactListViewModel ContactsList { get; set; }
        string eMail { get; set; }
        string Extension { get; set; }
        string Fax { get; set; }
        string InvoiceAddress { get; set; }
        bool IsClient { get; set; }
        bool IsSameForAddress { get; set; }
        string MainContactPerson { get; set; }
        string Mobile { get; set; }
        string Name { get; set; }
        byte PaymentType { get; set; }
        string Phone { get; set; }
        string Principal { get; set; }
        string ShortName { get; set; }
        int? TicketPeriodId { get; set; }
        string UniformNumbers { get; set; }
        bool Void { get; set; }
    }
}