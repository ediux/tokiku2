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
    public class ProcessingAtlasViewModel : BaseViewModelWithPOCOClass<ProcessingAtlas>
    {


     



        public Guid ProjectContractId
        {
            get { return CopyofPOCOInstance.ProjectContractId; }
            set { CopyofPOCOInstance.ProjectContractId = value;RaisePropertyChanged("ProjectContractId"); }
        }



        public int Order
        {
            get { return CopyofPOCOInstance.Order; }
            set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); }
        }

     


        public int Atlas
        {
            get { return CopyofPOCOInstance.Atlas; }
            set { CopyofPOCOInstance.Atlas = value;
                RaisePropertyChanged("Atlas");
            }
        }

     
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }

    

     

   

     


        public int UpdateTimes
        {
            get { return CopyofPOCOInstance.UpdateTimes; }
            set { CopyofPOCOInstance.UpdateTimes = value;
                RaisePropertyChanged("UpdateTimes");
            }
        }




        public DateTime? LastUpdate
        {
            get { return CopyofPOCOInstance.LastUpdate; }
            set { CopyofPOCOInstance.LastUpdate = value;
                RaisePropertyChanged("LastUpdate");
            }
        }

    
        public DateTime? ConstructionOrderChangeDate
        {
            get { return CopyofPOCOInstance.ConstructionOrderChangeDate; }
            set { CopyofPOCOInstance.ConstructionOrderChangeDate = value;RaisePropertyChanged("ConstructionOrderChangeDate"); }
        }

        public override void Initialized()
        {
            base.Initialized();
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
            UpdateTimes = 0;
            ConstructionOrderChangeDate = default(DateTime);
            LastUpdate = CreateTime;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        ProcessingAtlas data = (ProcessingAtlas)entity;
        //        BindingFromModel(data, this);
              
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}
    }
}
