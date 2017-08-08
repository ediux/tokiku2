using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
     //<DataGridTextColumn Header = "廠商代號" Binding="{Binding Code}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "名稱(全名)" Binding="{Binding Path=Name}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "名稱(簡稱)" Binding="{Binding ShortName}" Width="auto"  HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "主要聯絡人" Binding="{Binding MainContactPerson}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "公司電話" Binding="{Binding Phone}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "公司傳真" Binding="{Binding Fax}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "電子郵件" Binding="{Binding EMail}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "公司地址" Binding="{Binding Address}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "負責人" Binding="{Binding Principal}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
     //           <DataGridTextColumn Header = "統一編號" Binding="{Binding UniformNumbers}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />

     //           <DataGridTextColumn Header = "狀態" Binding="{Binding Void, Converter={StaticResource Void2TextValueConvterver}}" Width="auto" HeaderStyle="{StaticResource HeaderStyleCenter}" />
    public class VendorListItemViewModel : EntityBaseViewModel<Manufacturers>, IVendorListItemViewModel
    {
        public VendorListItemViewModel(Manufacturers entity):base(entity)
        {

        }

        public string Code { get { return CopyofPOCOInstance.Code; } set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); } }
        public string Name { get { return CopyofPOCOInstance.Name; } set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }
        public string ShortName { get { return CopyofPOCOInstance.ShortName; } set { CopyofPOCOInstance.ShortName = value; RaisePropertyChanged("ShortName"); } }
        public string Principal { get { return CopyofPOCOInstance.Principal; } set { CopyofPOCOInstance.Principal = value; RaisePropertyChanged("Principal"); } }
        public string Phone { get { return CopyofPOCOInstance.Phone; } set { CopyofPOCOInstance.Phone = value; RaisePropertyChanged("Phone"); } }
        public string Fax { get { return CopyofPOCOInstance.Fax; } set { CopyofPOCOInstance.Fax = value; RaisePropertyChanged("Fax"); } }
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
            set { CopyofPOCOInstance.eMail = value; RaisePropertyChanged("eMail"); }
        }
        public string Address { get { return CopyofPOCOInstance.Address; } set { CopyofPOCOInstance.Address = value; RaisePropertyChanged("Address"); } }
        public string UniformNumbers { get { return CopyofPOCOInstance.UniformNumbers; } set { CopyofPOCOInstance.UniformNumbers = value; RaisePropertyChanged("UniformNumbers"); } }
        public bool Void { get { return CopyofPOCOInstance.Void; } set { CopyofPOCOInstance.Void = value; RaisePropertyChanged("Void"); } }
        public string VoidStateText { get; set; }
        #region MainContactPerson

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
    }
}
