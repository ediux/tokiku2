using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ManufacturersViewModel : BaseViewModel
    {
        private Controllers.ManufacturersController controller;
        private Controllers.ContactController controller2;
        #region 公開方法(中介層呼叫)

        /// <summary>
        /// 查詢單一個體的資料實體。
        /// </summary>
        /// <param name="ProjectId"></param>
        public void QueryModel(Guid ProjectId)
        {
            Entity.Manufacturers result = controller.QuerySingle(ProjectId);

            if (result != null)
            {
                Contracts = result.Contacts.ToList();
                BindingFromModel(result);
                DisabledEditor();
            }

        }

        /// <summary>
        /// 儲存變更
        /// </summary>
        public void SaveModel()
        {
            try
            {
                if (controller.IsExists(Id))
                {
                    Entity.Manufacturers result = controller.QuerySingle(Id);
                    CopyToModel(result);
                    controller.Update(result);
                }
                else
                {
                    Entity.Manufacturers newProject = new Entity.Manufacturers();
                    CreateTime = DateTime.Now;
                    CreateUserId = LoginedUser.UserId;
                    CopyToModel(newProject);
                    controller.Add(newProject);
                }
                IsEditorMode = true;
                IsSaved = true;
                IsModify = false;
            }
            catch
            {
                throw;
            }

        }

        public ManufacturersViewModel()
        {
            controller = new Controllers.ManufacturersController();
            controller2 = new Controllers.ContactController();
            Id = Guid.NewGuid();

            var lastitem = controller.QueryAll().OrderByDescending(s => s.Code).FirstOrDefault();
            if (lastitem != null)
            {
                int numif = 0;
                if (int.TryParse(lastitem.Code, out numif))
                {
                    if (numif <= 99)
                    {
                        Code = (numif + 1).ToString();
                        return;
                    }
                    
                }

                Dictionary<int, string> dict = new Dictionary<int, string>();
                dict.Add(0, "0");
                dict.Add(1, "1");
                dict.Add(2, "2");
                dict.Add(3, "3");
                dict.Add(4, "4");
                dict.Add(5, "5");
                dict.Add(6, "6");
                dict.Add(7, "7");
                dict.Add(8, "8");
                dict.Add(9, "9");
                dict.Add(10, "A");
                dict.Add(11, "B");
                dict.Add(12, "C");
                dict.Add(13, "D");
                dict.Add(14, "E");
                dict.Add(15, "F");
                dict.Add(16, "G");
                dict.Add(17, "H");
                dict.Add(18, "I");
                dict.Add(19, "J");
                dict.Add(20, "K");
                dict.Add(21, "L");
                dict.Add(22, "M");
                dict.Add(23, "N");
                dict.Add(24, "O");
                dict.Add(25, "P");
                dict.Add(26, "Q");
                dict.Add(27, "R");
                dict.Add(28, "S");
                dict.Add(29, "T");
                dict.Add(30, "U");
                dict.Add(31, "V");
                dict.Add(32, "W");
                dict.Add(33, "X");
                dict.Add(34, "Y");
                dict.Add(35, "Z");

                string hignchar = lastitem.Code.Substring(0, 1);
                string lowchar = lastitem.Code.Substring(1, 1);

                int lowint = dict.Where(w => w.Value == lowchar).Select(s => s.Key).Single();
                int highint = dict.Where(w => w.Value == hignchar).Select(s => s.Key).Single();

                if (lowint == 35)
                {
                    lowint = 0;
                    highint += 1;
                }
                else
                {
                    lowint += 1;
                }

                Code = dict[highint] + dict[lowint];
            }
            else
            {
                Code = "01";
            }

        }
        #endregion

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public void QueryAll()
        {

        }

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty PrincipalProperty = DependencyProperty.Register("Principal", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty UniformNumbersProperty = DependencyProperty.Register("UniformNumbers", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FaxProperty = DependencyProperty.Register("Fax", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty eMailProperty = DependencyProperty.Register("eMail", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register("Address", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryPhoneProperty = DependencyProperty.Register("FactoryPhone", typeof(string),
            typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryFaxProperty = DependencyProperty.Register("FactoryFax", typeof(string),
         typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryAddressProperty = DependencyProperty.Register("FactoryAddress", typeof(string),
         typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty MainContactPersonIdProperty = DependencyProperty.Register("MainContactPersonId",
            typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty VoidProperty = DependencyProperty.Register("Void",
            typeof(bool), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty IsClientProperty = DependencyProperty.Register("IsClient",
         typeof(bool), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register("CreateTime",
         typeof(DateTime), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserIdProperty = DependencyProperty.Register("CreateUserId",
         typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserProperty = DependencyProperty.Register("CreateUser",
    typeof(UserViewModel), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ProjectsProperty = DependencyProperty.Register("Projects",
   typeof(ICollection<ProjectBaseViewModel>), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public System.Guid Id { get { return (Guid)GetValue(IdProperty); } set { SetValue(IdProperty, value); } }
        public string Code { get { return (string)GetValue(CodeProperty); } set { SetValue(CodeProperty, value); } }
        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); SetValue(ShortNameProperty, value.Substring(0, 4)); } }
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); } }
        public string Principal { get { return (string)GetValue(PrincipalProperty); } set { SetValue(PrincipalProperty, value); } }
        public string UniformNumbers { get { return (string)GetValue(UniformNumbersProperty); } set { SetValue(UniformNumbersProperty, value); } }
        public string Phone { get { return (string)GetValue(PhoneProperty); } set { SetValue(PhoneProperty, value); } }
        public string Fax { get { return (string)GetValue(FaxProperty); } set { SetValue(FaxProperty, value); } }
        public string eMail { get { return (string)GetValue(eMailProperty); } set { SetValue(eMailProperty, value); } }
        public string Address { get { return (string)GetValue(AddressProperty); } set { SetValue(AddressProperty, value); } }
        public string FactoryPhone { get { return (string)GetValue(FactoryPhoneProperty); } set { SetValue(FactoryPhoneProperty, value); } }
        public string FactoryFax { get { return (string)GetValue(FactoryFaxProperty); } set { SetValue(FactoryFaxProperty, value); } }
        public string FactoryAddress { get { return (string)GetValue(FactoryAddressProperty); } set { SetValue(FactoryAddressProperty, value); } }
        public System.Guid MainContactPersonId { get { return (Guid)GetValue(MainContactPersonIdProperty); } set { SetValue(MainContactPersonIdProperty, value); } }
        public string Comment { get { return (string)GetValue(CommentProperty); } set { SetValue(CommentProperty, value); } }
        public bool Void { get { return (bool)GetValue(VoidProperty); } set { SetValue(VoidProperty, value); } }
        public bool IsClient { get { return (bool)GetValue(IsClientProperty); } set { SetValue(IsClientProperty, value); } }
        public System.DateTime CreateTime { get { return (DateTime)GetValue(CreateTimeProperty); } set { SetValue(CreateTimeProperty, value); } }
        public System.Guid CreateUserId { get { return (Guid)GetValue(CreateUserIdProperty); } set { SetValue(CreateUserIdProperty, value); } }


        public virtual UserViewModel CreateUser { get { return (UserViewModel)GetValue(IdProperty); } set { SetValue(IdProperty, value); } }

        //public virtual ICollection<ProjectContract> ProjectContract { get; set; }

        //public virtual ICollection<Materials> Materials { get; set; }

        public virtual ICollection<ProjectBaseViewModel> Projects { get; set; }



        public string AccountingCode
        {
            get { return (string)GetValue(AccountingCodeProperty); }
            set { SetValue(AccountingCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountingCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountingCodeProperty =
            DependencyProperty.Register("AccountingCode", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));



        public string BankName
        {
            get { return (string)GetValue(BankNameProperty); }
            set { SetValue(BankNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankNameProperty =
            DependencyProperty.Register("BankName", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));




        public string BankAccount
        {
            get { return (string)GetValue(BankAccountProperty); }
            set { SetValue(BankAccountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankAccount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankAccountProperty =
            DependencyProperty.Register("BankAccount", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));



        public string BankAccountName
        {
            get { return (string)GetValue(BankAccountNameProperty); }
            set { SetValue(BankAccountNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankAccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankAccountNameProperty =
            DependencyProperty.Register("BankAccountName", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));



        public byte PaymentType
        {
            get { return (byte)GetValue(PaymentTypeProperty); }
            set { SetValue(PaymentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeProperty =
            DependencyProperty.Register("PaymentType", typeof(byte), typeof(ManufacturersViewModel), new PropertyMetadata((byte)0));



        public string CheckNumber
        {
            get { return (string)GetValue(CheckNumberProperty); }
            set { SetValue(CheckNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckNumberProperty =
            DependencyProperty.Register("CheckNumber", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));


        public List<Entity.Contacts> Contracts
        {
            get { return (List<Entity.Contacts>)GetValue(ContractsProperty); }
            set { SetValue(ContractsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contracts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractsProperty =
            DependencyProperty.Register("Contracts", typeof(List<Entity.Contacts>), typeof(ManufacturersViewModel), new PropertyMetadata(default(List<Entity.Contacts>)));



        public List<Entity.Materials> Materials
        {
            get { return (List<Entity.Materials>)GetValue(MaterialsProperty); }
            set { SetValue(MaterialsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Materials.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialsProperty =
            DependencyProperty.Register("Materials", typeof(List<Entity.Materials>), typeof(ManufacturersViewModel), new PropertyMetadata(default(List<Entity.Materials>)));



        public Entity.Contacts SelectedContract
        {
            get { return (Entity.Contacts)GetValue(SelectedContractProperty); }
            set { SetValue(SelectedContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for  SelectedContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedContractProperty =
            DependencyProperty.Register(" SelectedContract", typeof(Entity.Contacts), typeof(ManufacturersViewModel), new PropertyMetadata(default(Entity.Contacts)));


    }
}
