using System;
using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IManufacturersViewModel : IEntityBaseViewModel<Manufacturers>
    {
        string Address { get; set; }
        string BankAccount { get; set; }
        string BankAccountName { get; set; }
        string BankName { get; set; }
        string Code { get; set; }
        string Comment { get; set; }
        string eMail { get; set; }
        string Extension { get; set; }
        string Fax { get; set; }
        Guid Id { get; set; }
        string InvoiceAddress { get; set; }
        bool IsClient { get; set; }
        string MainContactPerson { get; set; }
        ObservableCollection<IManufacturersBussinessItemsViewModel> ManufacturersBussinessItems { get; set; }
        string Mobile { get; set; }
        string Name { get; set; }
        byte PaymentType { get; set; }
        string Phone { get; set; }
        string Principal { get; set; }
        ContactsViewModel SelectedContract { get; set; }
        string ShortName { get; set; }
        int? TicketPeriodId { get; set; }
        ManufacturersBussinessTranscationsViewModelCollection TranscationRecords { get; set; }
        string UniformNumbers { get; set; }
        bool Void { get; set; }

        void Initialized(object Parameter);
        void QueryByName(string Name);
        void QueryDetails();
        void SaveModel(bool isLast = true);
    }
}