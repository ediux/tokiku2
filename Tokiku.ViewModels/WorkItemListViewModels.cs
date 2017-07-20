using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class WorkItemListCollection : BaseViewModelCollection<WorkItemListViewModels>
    {
        public WorkItemListCollection()
        {
        }

        public WorkItemListCollection(IEnumerable<WorkItemListViewModels> source) : base(source)
        {
        }

        public static WorkItemListCollection Query()
        {
            return Query<WorkItemListCollection, Engineering>("Engineering", "QueryAll");
        }
    }

    public class WorkItemListViewModels : BaseViewModelWithPOCOClass<Engineering>
    {
        public WorkItemListViewModels(Engineering entity) : base(entity)
        {
        }

        // 合約編號
        public string ContractNumber
        {
            get { return CopyofPOCOInstance.ProjectContract.ContractNumber; }
            set { CopyofPOCOInstance.ProjectContract.ContractNumber = value; RaisePropertyChanged("ContractNumber"); }
        }

        // 工程名稱
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }

        // 單位
        public string Unit
        {
            get { return CopyofPOCOInstance.Unit; }
            set { CopyofPOCOInstance.Unit = value; RaisePropertyChanged("Unit"); }
        }

    }
}
