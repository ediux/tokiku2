using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.ViewModels
{
    public class ManufacturersViewModelCollection : BaseViewModelCollection<ManufacturersViewModel>
    {
        #region 內部變數
        /// <summary>
        /// 廠商管理對應的控制器
        /// </summary>
        private ManufacturersManageController _controller;
        #endregion

        #region 建構式
        /// <summary>
        /// 預設的建構式
        /// </summary>
        public ManufacturersViewModelCollection()
        {

        }

        /// <summary>
        /// 給IoC容器使用的建構式。
        /// </summary>
        /// <param name="Controller">廠商管理商業邏輯層控制器</param>
        public ManufacturersViewModelCollection(ManufacturersManageController Controller)
        {
            _controller = Controller;
        }

        public ManufacturersViewModelCollection(IEnumerable<ManufacturersViewModel> source) : base(source)
        {

        }
        #endregion

        #region 模型命令方法
        public override void Initialized()
        {
            try
            {
                base.Initialized();

                _controller = new ManufacturersManageController();
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public static ManufacturersViewModelCollection Query()
        {
            try
            {
                return Query<ManufacturersViewModelCollection, Manufacturers>("ManufacturersManage", "QueryAll");
                //if (!System.Windows.Threading.Dispatcher.CurrentDispatcher.CheckAccess())
                //{
                //    System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(new Action(Query), System.Windows.Threading.DispatcherPriority.Background);
                //}
                //else
                //{
                //    if (_controller == null)
                //        return;

                //    var queryresult = _controller.QueryAll();

                //    if (!queryresult.HasError)
                //    {
                //        ClearItems();

                //        foreach (var row in queryresult.Result)
                //        {
                //            ManufacturersViewModel model = new ManufacturersViewModel();

                //            //model.SetModel(row);
                //            Add(model);
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                ManufacturersViewModelCollection collection = new ManufacturersViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }

        }

        public void QueryByText(string originalSource)
        {
            try
            {
                var executeresult = _controller.SearchByText(originalSource);

                if (!executeresult.HasError)
                {
                    var objectdataset = executeresult.Result;
                    ClearItems();
                    foreach (var row in objectdataset)
                    {
                        ManufacturersViewModel model = new ManufacturersViewModel();

                        //model.SetModel(row);
                        Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public static ManufacturersViewModelCollection QueryByBusinessItem(Guid MaterialCategoriesId, string BusinessItem)
        {
            try
            {
                return Query<ManufacturersViewModelCollection, Manufacturers>("ManufacturersManage", "GetManufacturersWithBusinessItem", MaterialCategoriesId, BusinessItem);

                //ManufacturersManageController controller = new ManufacturersManageController();
                //var queryresult =  controller.GetManufacturersWithBusinessItemAsync(MaterialCategoriesId, BusinessItem);
                //if (!queryresult.HasError)
                //{
                //    var objectdataset = queryresult.Result;
                //    foreach (var row in objectdataset)
                //    {
                //        ManufacturersViewModel model = new ManufacturersViewModel();

                //        //model.SetModel(row);
                //        Add(model);
                //    }
                //}
            }
            catch (Exception ex)
            {
                ManufacturersViewModelCollection collection = new ManufacturersViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }
        }
        #endregion

    }

    public class ManufacturersViewModel : BaseViewModelWithPOCOClass<Manufacturers>
    {

        #region 內部變數
        private ManufacturersManageController controller;
        #endregion

        #region 建構式
        public ManufacturersViewModel() : base()
        {

        }
        public ManufacturersViewModel(Manufacturers entity) : base(entity)
        {

        }

        public ManufacturersViewModel(ManufacturersManageController Controller) : base()
        {
            controller = Controller;
        }
        #endregion

        #region 屬性

        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        [Display(Name = "編號")]
        public new System.Guid Id { get { return CopyofPOCOInstance.Id; } set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); } }
        #endregion


        public string Code { get { return CopyofPOCOInstance.Code; } set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); } }
        public string Name { get { return CopyofPOCOInstance.Name; } set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }
        public string ShortName { get { return CopyofPOCOInstance.ShortName; } set { CopyofPOCOInstance.ShortName = value; RaisePropertyChanged("ShortName"); } }
        public string Principal { get { return CopyofPOCOInstance.Principal; } set { CopyofPOCOInstance.Principal = value; RaisePropertyChanged("Principal"); } }
        public string UniformNumbers { get { return CopyofPOCOInstance.UniformNumbers; } set { CopyofPOCOInstance.UniformNumbers = value; RaisePropertyChanged("UniformNumbers"); } }
        public string Phone { get { return CopyofPOCOInstance.Phone; } set { CopyofPOCOInstance.Phone = value; RaisePropertyChanged("Phone"); } }
        public string Fax { get { return CopyofPOCOInstance.Fax; } set { CopyofPOCOInstance.Fax = value; RaisePropertyChanged("Fax"); } }
        public string eMail { get { return CopyofPOCOInstance.eMail; } set { CopyofPOCOInstance.eMail = value; RaisePropertyChanged("eMail"); } }
        public string Address { get { return CopyofPOCOInstance.Address; } set { CopyofPOCOInstance.Address = value; RaisePropertyChanged("Address"); } }
        public string FactoryPhone { get { return CopyofPOCOInstance.FactoryPhone; } set { CopyofPOCOInstance.FactoryPhone = value; RaisePropertyChanged("FactoryPhone"); } }
        public string FactoryFax { get { return CopyofPOCOInstance.FactoryFax; } set { CopyofPOCOInstance.FactoryFax = value; RaisePropertyChanged("FactoryFax"); } }
        public string FactoryAddress { get { return CopyofPOCOInstance.FactoryAddress; } set { CopyofPOCOInstance.FactoryAddress = value; RaisePropertyChanged("FactoryAddress"); } }

        public string Comment { get { return CopyofPOCOInstance.Comment; } set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); } }
        public bool Void { get { return CopyofPOCOInstance.Void; } set { CopyofPOCOInstance.Void = value; RaisePropertyChanged("Void"); } }
        public bool IsClient { get { return CopyofPOCOInstance.IsClient; } set { CopyofPOCOInstance.IsClient = value; RaisePropertyChanged("IsClient"); } }
       

        #region MainContactPerson

        /// <summary>
        /// 主要聯絡人
        /// </summary>
        public string MainContactPerson
        {
            get
            {
                var result = CopyofPOCOInstance.Contacts.Select(s => s.IsDefault == true);
                if (result.Any())
                {
                    return result.Single().ToString();
                }
                return string.Empty;
            }
            set
            {
                RaisePropertyChanged("MainContactPerson");
            }
        }


        #endregion



        #region BankName
        /// <summary>
        /// 銀行名稱
        /// </summary>
        public string BankName
        {
            get { return CopyofPOCOInstance.BankName; }
            set { CopyofPOCOInstance.BankName = value; RaisePropertyChanged("BankName"); }
        }

      
        #endregion

        #region BankAccount
        /// <summary>
        /// 銀行帳號
        /// </summary>
        public string BankAccount
        {
            get { return CopyofPOCOInstance.BankAccount; }
            set { CopyofPOCOInstance.BankAccount = value; RaisePropertyChanged("BankAccount"); }
        }

      
        #endregion

        #region BankAccountName
        /// <summary>
        /// 銀行帳號名稱
        /// </summary>
        public string BankAccountName
        {
            get { return CopyofPOCOInstance.BankAccountName; }
            set { BankAccountName = value; RaisePropertyChanged("BankAccountName"); }
        }

      
        #endregion

        #region PaymentType
        /// <summary>
        /// 支付方式
        /// </summary>
        public byte PaymentType
        {
            get { return CopyofPOCOInstance.PaymentType; }
            set { CopyofPOCOInstance.PaymentType = value; RaisePropertyChanged("PaymentType"); }
        }


        #endregion

        //#region 聯絡人清單 Contracts
        ///// <summary>
        ///// 聯絡人清單
        ///// </summary>
        //public ContactsViewModelCollection Contracts
        //{
        //    get
        //    {
        //        var source = new ContactsViewModelCollection();
        //        if (source.Count == 0)
        //        {
        //            source.Query();
        //        }
        //        return source;
        //    }
        //    set { RaisePropertyChanged("Contracts"); }
        //}



        //#endregion

        #region 選擇的聯絡人
        private ContactsViewModel _SelectedContact;
        /// <summary>
        /// 選擇的聯絡人
        /// </summary>
        public ContactsViewModel SelectedContract
        {
            get { return _SelectedContact; }
            set { _SelectedContact = value; RaisePropertyChanged("SelectedContract"); }
        }



        #endregion

        #region ManufacturersBussinessItems 營業項目
        private ManufacturersBussinessItemsViewModelColletion _ManufacturersBussinessItems;
        /// <summary>
        /// 營業項目
        /// </summary>
        public ManufacturersBussinessItemsViewModelColletion ManufacturersBussinessItems
        {
            get
            {
                if (_ManufacturersBussinessItems == null)
                {
                    _ManufacturersBussinessItems = new ManufacturersBussinessItemsViewModelColletion(
                        CopyofPOCOInstance.ManufacturersBussinessItems.Select(s=>
                        new ManufacturersBussinessItemsViewModel(s)));       
                }

                return _ManufacturersBussinessItems;
               
            }
            set { _ManufacturersBussinessItems = value; RaisePropertyChanged("ManufacturersBussinessItems"); }
        }

        #endregion

        #region 行動電話

        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile
        {
            get { return CopyofPOCOInstance.Mobile; }
            set { RaisePropertyChanged("Mobile"); }
        }



        #endregion

        #region 分機

        /// <summary>
        /// 主要聯絡人分機
        /// </summary>
        public string Extension
        {
            get { return string.Empty; }
            set {  }
        }

     


        #endregion

        #region TicketPeriodId

        /// <summary>
        /// 票期Id
        /// </summary>
        public int? TicketPeriodId
        {
            get { return CopyofPOCOInstance.TicketPeriodId; }
            set { CopyofPOCOInstance.TicketPeriodId = value; RaisePropertyChanged("TicketPeriodId"); }
        }



        #endregion

        #region 發票地址

        /// <summary>
        /// 發票地址
        /// </summary>
        public string InvoiceAddress
        {
            get { return CopyofPOCOInstance.InvoiceAddress; }
            set { CopyofPOCOInstance.InvoiceAddress = value; RaisePropertyChanged("InvoiceAddress"); }
        }



        #endregion

        #region 交易紀錄

        private ManufacturersBussinessTranscationsViewModelCollection _TranscationRecords;

        public ManufacturersBussinessTranscationsViewModelCollection TranscationRecords
        {
            get
            {
                if (_TranscationRecords == null)
                {
                    _TranscationRecords = new ManufacturersBussinessTranscationsViewModelCollection();
                }

                return _TranscationRecords;
            }
            set {
                _TranscationRecords = value;
                RaisePropertyChanged("TranscationRecords");
            }
        }

       
        #endregion

        #endregion

        #region 模型命令

        #region 查詢單一個體的檢視資料
        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public void QueryModel(Guid ManufacturersId)
        {
            try
            {
                var exeecuteresult = controller.Query(s => s.Id == ManufacturersId);
                if (!exeecuteresult.HasError)
                {
                    var data = exeecuteresult.Result.Single();
                   
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        public override void Initialized()
        {

            base.Initialized();

            try
            {
                if (controller == null)
                    controller = new ManufacturersManageController();

                Id = Guid.NewGuid();

                var createnewresult = controller.CreateNew();

                if (!createnewresult.HasError)
                {
                    var data = createnewresult.Result;
                    
                }

                //LastUpdateTime = DateTime.Now;
                CreateTime = DateTime.Now;

                //Contracts = new ContactsViewModelCollection();
                ManufacturersBussinessItems = new ManufacturersBussinessItemsViewModelColletion();
                TranscationRecords = new ManufacturersBussinessTranscationsViewModelCollection();
            }
            catch (Exception ex)
            {

                setErrortoModel(this, ex);
            }


        }

        //public  void SaveModel()
        //{
        //    try
        //    {
        //        Manufacturers data = new Manufacturers();
        //        //data.ManufacturersBussinessItems.First().SupplierTranscationItem.First().Projects
        //        var LoginedUser = controller.GetCurrentLoginUser().Result;

        //        if (CreateUserId == Guid.Empty)
        //        {
        //            CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
        //        }

        //        if (CreateTime.Year < 1754)
        //        {
        //            CreateTime = DateTime.Now;
        //        }

        //        CopyToModel(data, this);

        //        if (ManufacturersBussinessItems != null && ManufacturersBussinessItems.Count > 0)
        //        {
        //            data.ManufacturersBussinessItems = new Collection<ManufacturersBussinessItems>();

        //            foreach (var x in ManufacturersBussinessItems)
        //            {
        //                ManufacturersBussinessItems BItems = new ManufacturersBussinessItems();
        //                CopyToModel(BItems, x);
        //                BItems.ManufacturersId = Id;
        //                BItems.Id = Guid.NewGuid();
        //                data.ManufacturersBussinessItems.Add(BItems);
        //            }
        //        }

        //        if (Contracts != null)
        //        {
        //            if (Contracts.Count > 0)
        //            {
        //                data.Contacts = new Collection<Entity.Contacts>();

        //                foreach (var x in Contracts)
        //                {
        //                    if (x.Id == Guid.Empty)
        //                        x.Id = Guid.NewGuid();



        //                    if (x.CreateUserId == Guid.Empty)
        //                    {
        //                        x.CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
        //                    }

        //                    if (x.CreateTime.Year < 1754)
        //                    {
        //                        x.CreateTime = CreateTime;
        //                    }

        //                    Contacts contact = new Contacts();
        //                    CopyToModel(contact, x);                         
        //                    data.Contacts.Add(contact);
        //                }
        //            }
        //        }

        //        var resultsec = controller.CreateOrUpdate(data);

        //        if (resultsec.HasError)
        //        {
        //            Errors = resultsec.Errors;
        //            HasError = resultsec.HasError;
        //            return;
        //        }

        //        Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }

        //}

        public void QueryByName(string Name)
        {
            try
            {
                ManufacturersManageController controller = new ManufacturersManageController();
                var executeresult = controller.Query(p => p.Name == Name);

                if (!executeresult.HasError)
                {
                    if (executeresult.Result.Any())
                    {
                        var data = executeresult.Result.Single();

                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is ManufacturersEnter)
        //        {
        //            ManufacturersEnter data = (ManufacturersEnter)entity;
        //            //BindingFromModel(data, this);
        //            //DoEvents();
        //            Status.IsNewInstance = false;
        //            Status.IsModify = false;
        //            Status.IsSaved = false;
        //        }

        //        if (entity is Manufacturers)
        //        {
        //            Manufacturers data = (Manufacturers)entity;
        //            //BindingFromModel(data, this);
        //            //DoEvents();
        //            Status.IsNewInstance = false;
        //            Status.IsModify = false;
        //            Status.IsSaved = false;
        //        }

        //        //await Dispatcher.InvokeAsync(new Action(QueryDetails), System.Windows.Threading.DispatcherPriority.Background);                
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }

        //}
        public void QueryDetails()
        {
            //Contracts.ManufacturersId = Id;
            //Contracts.Query("", Id, IsClient);

            ManufacturersBussinessItems.QueryAsync(Id);

            TranscationRecords.Query(Id);

        }
        #endregion

    }
}
