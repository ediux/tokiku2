using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturersViewModelCollection : BaseViewModelCollection<ManufacturersViewModel>
    {
        private ManufacturersManageController _controller;

        public ManufacturersViewModelCollection()
        {
            HasError = false;
        }

        public ManufacturersViewModelCollection(IEnumerable<ManufacturersViewModel> source) : base(source)
        {

        }

        public ManufacturersManageController Controller
        {
            get { return _controller; }
            set
            {
                _controller = value;
            }
        }

        public override void Initialized()
        {
            if (_controller == null)
                _controller = new ManufacturersManageController();

            base.Initialized();
        }

        public override void Query()
        {
            if (_controller == null)
                return;

            var queryresult = _controller.QueryAll();

            if (!queryresult.HasError)
            {
                Clear();

                foreach (var row in queryresult.Result)
                {
                    Add(BindingFromModel(row));
                }
            }
        }

        public override void Refresh()
        {
            Query();
        }

        public override void StartUp_Query()
        {
            Query();
        }
    }

    public class ManufacturersViewModel : BaseViewModel, IBaseViewModel
    {
        private Controllers.ManufacturersManageController controller = new ManufacturersManageController();
        public ManufacturersViewModel()
        {

        }

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id",
            typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(Guid.NewGuid(), new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty PrincipalProperty = DependencyProperty.Register("Principal",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty UniformNumbersProperty = DependencyProperty.Register("UniformNumbers",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FaxProperty = DependencyProperty.Register("Fax",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty eMailProperty = DependencyProperty.Register("eMail",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register("Address",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryPhoneProperty = DependencyProperty.Register("FactoryPhone", typeof(string),
            typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryFaxProperty = DependencyProperty.Register("FactoryFax", typeof(string),
         typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryAddressProperty = DependencyProperty.Register("FactoryAddress", typeof(string),
         typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty MainContactPersonIdProperty = DependencyProperty.Register("MainContactPersonId",
            typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty VoidProperty = DependencyProperty.Register("Void",
            typeof(bool), typeof(ManufacturersViewModel), new PropertyMetadata(false));

        public static readonly DependencyProperty IsClientProperty = DependencyProperty.Register("IsClient",
         typeof(bool), typeof(ManufacturersViewModel), new PropertyMetadata(false));

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register("CreateTime",
         typeof(DateTime), typeof(ManufacturersViewModel), new PropertyMetadata(DateTime.Now));

        public static readonly DependencyProperty CreateUserIdProperty = DependencyProperty.Register("CreateUserId",
         typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserProperty = DependencyProperty.Register("CreateUser",
    typeof(UserViewModel), typeof(ManufacturersViewModel), new PropertyMetadata(default(UserViewModel)));

        public static readonly DependencyProperty ProjectsProperty = DependencyProperty.Register("Projects",
   typeof(ProjectsViewModelCollection), typeof(ManufacturersViewModel),
   new PropertyMetadata(default(ProjectsViewModelCollection), new PropertyChangedCallback(DefaultFieldChanged)));

        [Display(Name = "編號")]
        public System.Guid Id { get { return (Guid)GetValue(IdProperty); } set { SetValue(IdProperty, value); RaisePropertyChanged("Id"); } }
        public string Code { get { return (string)GetValue(CodeProperty); } set { SetValue(CodeProperty, value); RaisePropertyChanged("Code"); } }
        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); RaisePropertyChanged("Name"); } }
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); RaisePropertyChanged("ShortName"); } }
        public string Principal { get { return (string)GetValue(PrincipalProperty); } set { SetValue(PrincipalProperty, value); RaisePropertyChanged("Principal"); } }
        public string UniformNumbers { get { return (string)GetValue(UniformNumbersProperty); } set { SetValue(UniformNumbersProperty, value); RaisePropertyChanged("UniformNumbers"); } }
        public string Phone { get { return (string)GetValue(PhoneProperty); } set { SetValue(PhoneProperty, value); RaisePropertyChanged("Phone"); } }
        public string Fax { get { return (string)GetValue(FaxProperty); } set { SetValue(FaxProperty, value); RaisePropertyChanged("Fax"); } }
        public string eMail { get { return (string)GetValue(eMailProperty); } set { SetValue(eMailProperty, value); RaisePropertyChanged("eMail"); } }
        public string Address { get { return (string)GetValue(AddressProperty); } set { SetValue(AddressProperty, value); RaisePropertyChanged("Address"); } }
        public string FactoryPhone { get { return (string)GetValue(FactoryPhoneProperty); } set { SetValue(FactoryPhoneProperty, value); RaisePropertyChanged("FactoryPhone"); } }
        public string FactoryFax { get { return (string)GetValue(FactoryFaxProperty); } set { SetValue(FactoryFaxProperty, value); RaisePropertyChanged("FactoryFax"); } }
        public string FactoryAddress { get { return (string)GetValue(FactoryAddressProperty); } set { SetValue(FactoryAddressProperty, value); RaisePropertyChanged("FactoryAddress"); } }
        public System.Guid MainContactPersonId { get { return (Guid)GetValue(MainContactPersonIdProperty); } set { SetValue(MainContactPersonIdProperty, value); RaisePropertyChanged("MainContactPersonId"); } }
        public string Comment { get { return (string)GetValue(CommentProperty); } set { SetValue(CommentProperty, value); RaisePropertyChanged("Comment"); } }
        public bool Void { get { return (bool)GetValue(VoidProperty); } set { SetValue(VoidProperty, value); RaisePropertyChanged("Void"); } }
        public bool IsClient { get { return (bool)GetValue(IsClientProperty); } set { SetValue(IsClientProperty, value); RaisePropertyChanged("IsClient"); } }
        public System.DateTime CreateTime { get { return (DateTime)GetValue(CreateTimeProperty); } set { SetValue(CreateTimeProperty, value); RaisePropertyChanged("CreateTime"); } }
        public System.Guid CreateUserId { get { return (Guid)GetValue(CreateUserIdProperty); } set { SetValue(CreateUserIdProperty, value); RaisePropertyChanged("CreateUserId"); } }
        public virtual UserViewModel CreateUser { get { return (UserViewModel)GetValue(CreateUserProperty); } set { SetValue(CreateUserProperty, value); RaisePropertyChanged("CreateUser"); } }

        //public virtual ICollection<ProjectContract> ProjectContract { get; set; }

        //public virtual ICollection<Materials> Materials { get; set; }

        public virtual ProjectsViewModelCollection Projects
        {
            get
            {
                return (ProjectsViewModelCollection)GetValue(ProjectsProperty);
            }
            set
            {
                SetValue(ProjectsProperty, value);
                RaisePropertyChanged("Projects");
            }
        }



        public string AccountingCode
        {
            get { return (string)GetValue(AccountingCodeProperty); }
            set { SetValue(AccountingCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountingCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountingCodeProperty =
            DependencyProperty.Register("AccountingCode", typeof(string),
                typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));



        public string BankName
        {
            get { return (string)GetValue(BankNameProperty); }
            set { SetValue(BankNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankNameProperty =
            DependencyProperty.Register("BankName", typeof(string), typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public string BankAccount
        {
            get { return (string)GetValue(BankAccountProperty); }
            set { SetValue(BankAccountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankAccount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankAccountProperty =
            DependencyProperty.Register("BankAccount", typeof(string), typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));



        public string BankAccountName
        {
            get { return (string)GetValue(BankAccountNameProperty); }
            set { SetValue(BankAccountNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankAccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankAccountNameProperty =
            DependencyProperty.Register("BankAccountName", typeof(string), typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));



        public byte PaymentType
        {
            get { return (byte)GetValue(PaymentTypeProperty); }
            set { SetValue(PaymentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeProperty =
            DependencyProperty.Register("PaymentType", typeof(byte), typeof(ManufacturersViewModel),
                new PropertyMetadata((byte)0, new PropertyChangedCallback(DefaultFieldChanged)));




        public ObservableCollection<PaymentTypeViewModel> PaymentTypes
        {
            get { return (ObservableCollection<PaymentTypeViewModel>)GetValue(PaymentTypesProperty); }
            set { SetValue(PaymentTypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypesProperty =
            DependencyProperty.Register("PaymentTypes", typeof(ObservableCollection<PaymentTypeViewModel>),
                typeof(ManufacturersViewModel),
                new PropertyMetadata(default(ObservableCollection<PaymentTypeViewModel>),
                    new PropertyChangedCallback(DefaultFieldChanged)));



        public string CheckNumber
        {
            get { return (string)GetValue(CheckNumberProperty); }
            set { SetValue(CheckNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckNumberProperty =
            DependencyProperty.Register("CheckNumber", typeof(string),
                typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));


        public ContactsViewModelCollection Contracts
        {
            get { return (ContactsViewModelCollection)GetValue(ContractsProperty); }
            set { SetValue(ContractsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contracts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractsProperty =
            DependencyProperty.Register("Contracts", typeof(ContactsViewModelCollection),
                typeof(ManufacturersViewModel),
                new PropertyMetadata(default(ObservableCollection<ContactsViewModel>),
                    new PropertyChangedCallback(DefaultFieldChanged)));



        public MaterialsViewModelCollection Materials
        {
            get { return (MaterialsViewModelCollection)GetValue(MaterialsProperty); }
            set { SetValue(MaterialsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Materials.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialsProperty =
            DependencyProperty.Register("Materials", typeof(MaterialsViewModelCollection),
                typeof(ManufacturersViewModel),
                new PropertyMetadata(default(ObservableCollection<MaterialsViewModel>), new PropertyChangedCallback(DefaultFieldChanged)));



        public ContactsViewModel SelectedContract
        {
            get { return (ContactsViewModel)GetValue(SelectedContractProperty); }
            set { SetValue(SelectedContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for  SelectedContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedContractProperty =
            DependencyProperty.Register(" SelectedContract",
                typeof(ContactsViewModel), typeof(ManufacturersViewModel),
                new PropertyMetadata(default(ContactsViewModel),
                    new PropertyChangedCallback(DefaultFieldChanged)));




        public EngineeringViewModelCollection Engineerings
        {
            get { return (EngineeringViewModelCollection)GetValue(EngineeringsProperty); }
            set { SetValue(EngineeringsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Engineerings.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EngineeringsProperty =
            DependencyProperty.Register("Engineerings",
                typeof(EngineeringViewModelCollection),
                typeof(ManufacturersViewModel),
                new PropertyMetadata(default(EngineeringViewModelCollection),
                    new PropertyChangedCallback(DefaultFieldChanged)));

        public bool IsDefault
        {
            get { return (bool)GetValue(IsDefaultProperty); }
            set { SetValue(IsDefaultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDefault.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDefaultProperty =
            DependencyProperty.Register("IsDefault", typeof(bool), typeof(ManufacturersViewModel),
                new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public void QueryModel(Guid ManufacturersId)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

        }

        public override void Initialized()
        {
            base.Initialized();
            Projects = new ProjectsViewModelCollection();
        }

        public override void SaveModel()
        {
            Manufacturers data = new Manufacturers();

            if (CreateUserId == Guid.Empty)
            {
                CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
            }

            CopyToModel(data, this);

            if (Contracts != null)
            {
                if (Contracts.Count > 0)
                {
                    foreach (ContactsViewModel model in Contracts)
                    {

                        model.Id = Guid.NewGuid();

                        if (model.CreateUserId == Guid.Empty)
                        {
                            model.CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
                        }
                    }
                }
            }

            if (Materials == null)
                Materials = new MaterialsViewModelCollection();

            if (Engineerings != null)
            {
                foreach (EngineeringViewModel model in Engineerings)
                {
                    if (model != null)
                    {
                        model.SaveModel();
                    }
                }
            }

            var result = controller.CreateOrUpdate(data);

            if (result.HasError)
            {
                Errors = result.Errors;
                HasError = result.HasError;
            }

            Refresh();
        }
    }
}
