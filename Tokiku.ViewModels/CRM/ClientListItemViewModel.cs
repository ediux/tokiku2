using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.ViewModels
{
       //<DataGridTextColumn Header = "客戶代號" Width="auto" Binding="{Binding Code}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "名稱(全名)" Width="auto" Binding="{Binding Name}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "名稱(簡稱)" Width="auto" Binding="{Binding ShortName}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "主要聯絡人" Width="auto" Binding="{Binding MainContactPerson}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "公司電話" Width="auto" Binding="{Binding Phone}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "公司傳真" Width="auto" Binding="{Binding Fax}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "電子郵件" Width="auto" Binding="{Binding EMail}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "公司地址" Width="auto" Binding="{Binding Address}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "負責人" Width="auto" Binding="{Binding Principal}" HeaderStyle="{StaticResource HeaderStyleCenter}" />
       //         <DataGridTextColumn Header = "統一編號" Width="auto" Binding="{Binding UniformNumbers}" HeaderStyle="{StaticResource HeaderStyleCenter}" />

    public class ClientListItemViewModel : EntityBaseViewModel<Manufacturers>, IClientListItemViewModel
    {
        public ClientListItemViewModel()
        {
        }

        [PreferredConstructor]
        public ClientListItemViewModel(Manufacturers entity) : base(entity)
        {
        }

        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        [Display(Name = "編號")]
        public Guid Id { get { return CopyofPOCOInstance.Id; } set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); } }
        #endregion

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string Code { get { return CopyofPOCOInstance.Code; } set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); } }

        /// <summary>
        /// 客戶名稱(全名)
        /// </summary>
        public string Name { get { return CopyofPOCOInstance.Name; } set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }

        /// <summary>
        /// 客戶簡稱
        /// </summary>
        public string ShortName { get { return CopyofPOCOInstance.ShortName; } set { CopyofPOCOInstance.ShortName = value; RaisePropertyChanged("ShortName"); } }
        
        #region 主要聯絡人

        /// <summary>
        /// 主要聯絡人
        /// </summary>
        public string MainContactPerson
        {
            get
            {
                var result = CopyofPOCOInstance.Contacts.Where(s => s.IsDefault == true);
                if (result.Any())
                {
                    return result.Single().Name;
                }
                return string.Empty;
            }
            set
            {
                RaisePropertyChanged("MainContactPerson");
            }
        }


        #endregion

        /// <summary>
        /// 公司電話
        /// </summary>
        public string Phone { get { return CopyofPOCOInstance.Phone; } set { CopyofPOCOInstance.Phone = value; RaisePropertyChanged("Phone"); } }
        
        /// <summary>
        /// 公司傳真
        /// </summary>
        public string Fax { get { return CopyofPOCOInstance.Fax; } set { CopyofPOCOInstance.Fax = value; RaisePropertyChanged("Fax"); } }

        /// <summary>
        /// 預設聯絡人電子郵件地址
        /// </summary>
        public string eMail
        {
            get
            {
                var result = CopyofPOCOInstance.Contacts.Where(s => s.IsDefault == true);
                if (result.Any())
                {
                    return result.Single().EMail;
                }
                return CopyofPOCOInstance.eMail;
            }
            set {  RaisePropertyChanged("eMail"); }
        }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get { return CopyofPOCOInstance.Address; } set { CopyofPOCOInstance.Address = value; RaisePropertyChanged("Address"); } }

        /// <summary>
        /// 負責人
        /// </summary>
        public string Principal { get { return CopyofPOCOInstance.Principal; } set { CopyofPOCOInstance.Principal = value; RaisePropertyChanged("Principal"); } }
        
        /// <summary>
        /// 統一編號
        /// </summary>
        public string UniformNumbers { get { return CopyofPOCOInstance.UniformNumbers; } set { CopyofPOCOInstance.UniformNumbers = value; RaisePropertyChanged("UniformNumbers"); } }
    }
}
