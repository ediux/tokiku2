using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProcessingAtlasViewModelCollection : BaseViewModelCollection<ProcessingAtlasViewModel>
    {
        public ProcessingAtlasViewModelCollection()
        {
        }

        public ProcessingAtlasViewModelCollection(IEnumerable<ProcessingAtlasViewModel> source) : base(source)
        {
        }

        public static ProcessingAtlasViewModelCollection Query()
        {
            return Query<ProcessingAtlasViewModelCollection, ProcessingAtlas>("ProcessingAtlas", "QueryAll");
        }
    }
    public class ProcessingAtlasViewModel : BaseViewModelWithPOCOClass<ProcessingAtlas>
    {
        public ProcessingAtlasViewModel()
        {
        }
        public ProcessingAtlasViewModel(ProcessingAtlas entity) : base(entity)
        {
        }

        // ID
        public Guid ProjectContractId
        {
            get { return CopyofPOCOInstance.ProjectContractId; }
            set { CopyofPOCOInstance.ProjectContractId = value; RaisePropertyChanged("ProjectContractId"); }
        }
        // 順序
        public int Order
        {
            get { return CopyofPOCOInstance.Order; }
            set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); }
        }
        // 合約編號
        public string ContractNumber
        {
            get { return CopyofPOCOInstance.ProjectContract.ContractNumber; }
            set { CopyofPOCOInstance.ProjectContract.ContractNumber = value;RaisePropertyChanged("ContractNumber"); }
        }
        // 圖集
        public int Atlas
        {
            get { return CopyofPOCOInstance.Atlas; }
            set { CopyofPOCOInstance.Atlas = value;
                RaisePropertyChanged("Atlas");
            }
        }
        // 圖集名稱
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }
        // 更新次數
        public int UpdateTimes
        {
            get { return CopyofPOCOInstance.UpdateTimes; }
            set { CopyofPOCOInstance.UpdateTimes = value;
                RaisePropertyChanged("UpdateTimes");
            }
        }
        // 最新日期
        public DateTime? LastUpdate
        {
            get { return CopyofPOCOInstance.LastUpdate; }
            set { CopyofPOCOInstance.LastUpdate = value;
                RaisePropertyChanged("LastUpdate");
            }
        }
        // 施工順序異動日期
        public DateTime? ConstructionOrderChangeDate
        {
            get { return CopyofPOCOInstance.ConstructionOrderChangeDate; }
            set { CopyofPOCOInstance.ConstructionOrderChangeDate = value;RaisePropertyChanged("ConstructionOrderChangeDate"); }
        }

        public override void Initialized(object Parameter)
        {
            base.Initialized(Parameter);
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
            UpdateTimes = 0;
            ConstructionOrderChangeDate = default(DateTime);
            LastUpdate = CreateTime;
        }
        
    }
}
