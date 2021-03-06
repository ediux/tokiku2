﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tokiku.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using GalaSoft.MvvmLight.Ioc;
    
    public partial class TokikuEntities : DbContext
    {
    	[PreferredConstructor]
        public TokikuEntities()
            : base("name=TokikuEntities")
        {
    		StartUp();
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<AccessLog> AccessLog { get; set; }
        public virtual DbSet<WorkShops> WorkShops { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Engineering> Engineering { get; set; }
        public virtual DbSet<MaterialCategories> MaterialCategories { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Molds> Molds { get; set; }
        public virtual DbSet<MoldUseStatus> MoldUseStatus { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<ProjectContract> ProjectContract { get; set; }
        public virtual DbSet<ProjectItemCost> ProjectItemCost { get; set; }
        public virtual DbSet<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
        public virtual DbSet<ShopFlow> ShopFlow { get; set; }
        public virtual DbSet<TicketTypes> TicketTypes { get; set; }
        public virtual DbSet<TicketPeriod> TicketPeriod { get; set; }
        public virtual DbSet<View_BussinessItemsList> View_BussinessItemsList { get; set; }
        public virtual DbSet<View_ManufacturersBussinessTranscations> View_ManufacturersBussinessTranscations { get; set; }
        public virtual DbSet<TranscationCategories> TranscationCategories { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<MoldsInProjects> MoldsInProjects { get; set; }
        public virtual DbSet<ConstructionAtlas> ConstructionAtlas { get; set; }
        public virtual DbSet<ProcessingAtlas> ProcessingAtlas { get; set; }
        public virtual DbSet<ManufacturersBussinessItems> ManufacturersBussinessItems { get; set; }
        public virtual DbSet<BOM> BOM { get; set; }
        public virtual DbSet<SupplierTranscationItem> SupplierTranscationItem { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderMaterialValuation> OrderMaterialValuation { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderTypes> OrderTypes { get; set; }
        public virtual DbSet<PickList> PickList { get; set; }
        public virtual DbSet<PickListDetails> PickListDetails { get; set; }
        public virtual DbSet<ReceiveDetails> ReceiptDetails { get; set; }
        public virtual DbSet<Receive> Receipts { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceDetails_Material> InvoiceDetails_Material { get; set; }
        public virtual DbSet<InvoiceDetails_Miscellaneous> InvoiceDetails_Miscellaneous { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<MaterialEstimation> MaterialEstimation { get; set; }
        public virtual DbSet<OrderMiscellaneous> OrderMiscellaneous { get; set; }
        public virtual DbSet<Required> Required { get; set; }
        public virtual DbSet<ControlTableDetails> ControlTableDetails { get; set; }
        public virtual DbSet<RequiredDetails> RequiredDetails { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<ShopFlowDetail> ShopFlowDetail { get; set; }
        public virtual DbSet<ShopFlowHistory> ShopFlowHistory { get; set; }
        public virtual DbSet<ControlTables> ControlTables { get; set; }
        public virtual DbSet<ManufacturersFactories> ManufacturersFactories { get; set; }
        public virtual DbSet<OrderControlTableDetails> OrderControlTableDetails { get; set; }
        public virtual DbSet<View_OrderMaterialValuation> View_OrderMaterialValuation { get; set; }
        public virtual DbSet<View_Orders> View_Orders { get; set; }
        public virtual DbSet<View_PickList> View_PickList { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<View_RequiredForms> View_RequiredForms { get; set; }
        public virtual DbSet<ReturnDetails> ReturnDetails { get; set; }
        public virtual DbSet<Returns> Returns { get; set; }
        public virtual DbSet<EncodingRecords> EncodingRecords { get; set; }
        public virtual DbSet<View_OrderControlTable> View_OrderControlTable { get; set; }
        public virtual DbSet<View_Shipping> View_Shipping { get; set; }
        public virtual DbSet<AbnormalQuality> AbnormalQuality { get; set; }
        public virtual DbSet<AbnormalQualityDetails> AbnormalQualityDetails { get; set; }
        public virtual DbSet<View_ShippingList> View_ShippingList { get; set; }
        public virtual DbSet<View_RequiredControlTable> View_RequiredControlTable { get; set; }
        public virtual DbSet<TradingItems> TradingItems { get; set; }
        public virtual DbSet<View_ObtainMaterial> View_ObtainMaterial { get; set; }
    
        [DbFunction("TokikuEntities", "SplitString")]
        public virtual IQueryable<SplitString_Result> SplitString(string splitStr, string splitChar)
        {
            var splitStrParameter = splitStr != null ?
                new ObjectParameter("SplitStr", splitStr) :
                new ObjectParameter("SplitStr", typeof(string));
    
            var splitCharParameter = splitChar != null ?
                new ObjectParameter("SplitChar", splitChar) :
                new ObjectParameter("SplitChar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<SplitString_Result>("[TokikuEntities].[SplitString](@SplitStr, @SplitChar)", splitStrParameter, splitCharParameter);
        }
    }
}
