using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturerFactoryViewModel : EntityBaseViewModel<ManufacturersFactories>, IManufacturerFactoryViewModel
    {
        public ManufacturerFactoryViewModel()
        {
            
        }

        public ManufacturerFactoryViewModel(ManufacturersFactories entity) : base(entity)
        {

        }

        /// <summary>
        /// 工廠名稱
        /// </summary>
        public string Name { get => CopyofPOCOInstance.Name; set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }

        /// <summary>
        /// 工廠電話
        /// </summary>
        public string Phone { get => CopyofPOCOInstance.FactoryPhone; set { CopyofPOCOInstance.FactoryPhone = value; RaisePropertyChanged("Phone"); } }

        /// <summary>
        /// 工廠地址
        /// </summary>
        public string Address
        {
            get => CopyofPOCOInstance.FactoryAddress;
            set
            {
                CopyofPOCOInstance.FactoryAddress = value;
                RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// 工廠傳真
        /// </summary>
        public string Fax
        {
            get => CopyofPOCOInstance.FactoryFax;
            set
            {
                CopyofPOCOInstance.FactoryFax = value;
                RaisePropertyChanged("Fax");
            }
        }
    }
}
