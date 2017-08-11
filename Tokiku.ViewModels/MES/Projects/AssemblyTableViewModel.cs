using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class AssemblyTableViewModelCollection : BaseViewModelCollection<AssemblyTableViewModel>
    {
        public AssemblyTableViewModelCollection() : base()
        {
        }

        public AssemblyTableViewModelCollection(IEnumerable<AssemblyTableViewModel> source) : base(source)
        {
        }

        public static AssemblyTableViewModelCollection Query()
        {
            return Query<AssemblyTableViewModelCollection, Orders>("Orders", "QueryAll");
        }

    }

    public class AssemblyTableViewModel : BaseViewModelWithPOCOClass<Orders>
    {
        public AssemblyTableViewModel(Orders entity) : base(entity)
        {

        }
        
        /*/ 圖集
        public int Atlas
        {
            get { return CopyofPOCOInstance.Atlas; }
            set { CopyofPOCOInstance.Atlas = value; RaisePropertyChanged("Atlas"); }
        }
        
        // 組合編號
        public string CombinationNumber
        {
            get { return CopyofPOCOInstance.CombinationNumber; }
            set { CopyofPOCOInstance.CombinationNumber = value; RaisePropertyChanged("CombinationNumber"); }
        }
        
        // 加工編號
        public string ProcessingNumber
        {
            get { return CopyofPOCOInstance.ProcessingNumber; }
            set { CopyofPOCOInstance.ProcessingNumber = value; RaisePropertyChanged("ProcessingNumber"); }
        }
        
        // 擠型編號
        public string CrowdedNumber
        {
            get { return CopyofPOCOInstance.CrowdedNumber; }
            set { CopyofPOCOInstance.CrowdedNumber = value; RaisePropertyChanged("CrowdedNumber"); }
        }
        
        // 裁切長度/規格
        public decimal CutLength
        {
            get { return CopyofPOCOInstance.CutLength; }
            set { CopyofPOCOInstance.CutLength = value; RaisePropertyChanged("CutLength"); }
        }
        
        // 數量
        public int Amount
        {
            get { return CopyofPOCOInstance.Amount; }
            set { CopyofPOCOInstance.Amount = value; RaisePropertyChanged("Amount"); }
        }
        
        // 材料說明
        public string MaterialDescription
        {
            get { return CopyofPOCOInstance.MaterialDescription; }
            set { CopyofPOCOInstance.MaterialDescription = value; RaisePropertyChanged("MaterialDescription"); }
        }
        
        // 總需求量
        public decimal TotalDemand
        {
            get { return CopyofPOCOInstance.TotalDemand; }
            set { CopyofPOCOInstance.TotalDemand = value; RaisePropertyChanged("TotalDemand"); }
        }
        // */
    }
}
