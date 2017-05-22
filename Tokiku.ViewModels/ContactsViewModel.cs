using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        private Controllers.ContactController controller;
        #region 公開方法(中介層呼叫)
        public void QueryAll()
        {
            ContractsList = controller.QueryAll();
        }
        /// <summary>
        /// 查詢單一個體的資料實體。
        /// </summary>
        /// <param name="ProjectId"></param>
        public void QueryModel(Guid ProjectId)
        {
            Entity.Contacts result = controller.QuerySingle(ProjectId);
            BindingFromModel(result);
        }

        /// <summary>
        /// 儲存變更
        /// </summary>
        public void SaveModel()
        {
            try
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return;
                }

                if (controller.IsExists(Id))
                {
                    Entity.Contacts result = controller.QuerySingle(Id);
                    CopyToModel(result);
                    controller.Update(result, LoginedUser.UserId);
                }
                else
                {
                    Entity.Contacts newProject = new Entity.Contacts();
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

        public void Delete(Guid ContactsId)
        {
            controller.Delete(ContactsId, LoginedUser.UserId);
        }

        #endregion

        public ContactsViewModel()
        {
            controller = new Controllers.ContactController();
            Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ContactsViewModel), new PropertyMetadata(Guid.NewGuid(),new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 部門
        /// </summary>
        public string Dep
        {
            get { return (string)GetValue(DepProperty); }
            set { SetValue(DepProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dep.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DepProperty =
            DependencyProperty.Register("Dep", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 職稱
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 市內電話
        /// </summary>
        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Phone.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhoneProperty =
            DependencyProperty.Register("Phone", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 分機號碼
        /// </summary>
        public string ExtensionNumber
        {
            get { return (string)GetValue(ExtensionNumberProperty); }
            set { SetValue(ExtensionNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExtensionNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExtensionNumberProperty =
            DependencyProperty.Register("ExtensionNumber", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile
        {
            get { return (string)GetValue(MobileProperty); }
            set { SetValue(MobileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mobile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MobileProperty =
            DependencyProperty.Register("Mobile", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 傳真
        /// </summary>
        public string Fax
        {
            get { return (string)GetValue(FaxProperty); }
            set { SetValue(FaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fax.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FaxProperty =
            DependencyProperty.Register("Fax", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 是否為負責人
        /// </summary>
        public bool IsPrincipal
        {
            get { return (bool)GetValue(IsPrincipalProperty); }
            set { SetValue(IsPrincipalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPrincipal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPrincipalProperty =
            DependencyProperty.Register("IsPrincipal", typeof(bool), typeof(ContactsViewModel), new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 是否停用(刪除)
        /// </summary>
        public bool Void
        {
            get { return (bool)GetValue(VoidProperty); }
            set { SetValue(VoidProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Void.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VoidProperty =
            DependencyProperty.Register("Void", typeof(bool), typeof(ContactsViewModel), new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ContactsViewModel), new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 建立者
        /// </summary>
        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ContactsViewModel), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(DefaultFieldChanged)));



        public string EMail
        {
            get { return (string)GetValue(EMailProperty); }
            set { SetValue(EMailProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EMail.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EMailProperty =
            DependencyProperty.Register("EMail", typeof(string), typeof(ContactsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));



        public bool IsDefault
        {
            get { return (bool)GetValue(IsDefaultProperty); }
            set { SetValue(IsDefaultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDefault.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDefaultProperty =
            DependencyProperty.Register("IsDefault", typeof(bool), typeof(ContactsViewModel), new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));

        public List<Contacts> ContractsList
        {
            get { return (List<Contacts>)GetValue(ContractsListProperty); }
            set { SetValue(ContractsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractsListProperty =
            DependencyProperty.Register("ContactsList", typeof(List<Contacts>), typeof(ContactsViewModel), new PropertyMetadata(default(List<Contacts>), new PropertyChangedCallback(DefaultFieldChanged)));

    }
}
