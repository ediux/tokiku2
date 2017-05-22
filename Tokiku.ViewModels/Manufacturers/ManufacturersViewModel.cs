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
        #region 公開方法(中介層呼叫)

        /// <summary>
        /// 查詢單一個體的資料實體。
        /// </summary>
        /// <param name="ProjectId"></param>
        public void QueryModel(Guid ProjectId)
        {
            Entity.Manufacturers result = controller.QuerySingle(ProjectId);
            BindingFromModel(result);
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
            Id = Guid.NewGuid();
        }
        #endregion

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty PrincipalNameProperty = DependencyProperty.Register("PrincipalName", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

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

        public static readonly DependencyProperty PrincipalProperty = DependencyProperty.Register("Principal",
         typeof(ContactsViewModel), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty MainContactPersonProperty = DependencyProperty.Register("MainContactPerson",
         typeof(ContactsViewModel), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserProperty = DependencyProperty.Register("CreateUser",
    typeof(UserViewModel), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ProjectsProperty = DependencyProperty.Register("Projects",
   typeof(ICollection<ProjectBaseViewModel>), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public System.Guid Id { get { return (Guid)GetValue(IdProperty); } set { SetValue(IdProperty, value); } }
        public string Code { get { return (string)GetValue(CodeProperty); } set { SetValue(CodeProperty, value); } }
        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); } }
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); } }
        public string PrincipalName { get { return (string)GetValue(PrincipalNameProperty); } set { SetValue(PrincipalNameProperty, value); } }
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

        public virtual ContactsViewModel Principal { get { return (ContactsViewModel)GetValue(PrincipalProperty); } set { SetValue(PrincipalProperty, value); } }
        public virtual ContactsViewModel MainContactPerson { get { return (ContactsViewModel)GetValue(MainContactPersonProperty); } set { SetValue(MainContactPersonProperty, value); } }
        public virtual UserViewModel CreateUser { get { return (UserViewModel)GetValue(IdProperty); } set { SetValue(IdProperty, value); } }
     
        //public virtual ICollection<ProjectContract> ProjectContract { get; set; }
       
        //public virtual ICollection<Materials> Materials { get; set; }
       
        public virtual ICollection<ProjectBaseViewModel> Projects { get; set; }
    }
}
