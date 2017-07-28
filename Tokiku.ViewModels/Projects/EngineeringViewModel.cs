using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class EngineeringViewModelCollection : BaseViewModelCollection<EngineeringViewModel>
    {
        //private Controllers.EngineeringController controller;

        public EngineeringViewModelCollection()
        {
            HasError = false;
        }

        public EngineeringViewModelCollection(IEnumerable<EngineeringViewModel> source) : base(source)
        {

        }

        public Guid ProjectContractId
        {
            get; set;
        }

        //public override void Initialized()
        //{
        //    base.Initialized();
        //    controller = new Controllers.EngineeringController();
        //}

        //public override void Query()
        //{
        //    if (ProjectContractId != null && ProjectContractId != Guid.Empty)
        //    {
        //        var executed_result = controller.QueryAll(ProjectContractId);

        //        if (!executed_result.HasError)
        //        {
        //            ClearItems();
        //            foreach (var row in executed_result.Result)
        //            {
        //                Add(BindingFromModel(row));
        //            }
        //        }
        //    }
        //}      
    }

    public class EngineeringViewModel : BaseViewModelWithPOCOClass<Engineering>
    {
        public EngineeringViewModel()
        {

        }

        public EngineeringViewModel(Engineering entity) : base(entity)
        {

        }



        #region ProjectContractId
        public Guid ProjectContractId
        {
            get { return CopyofPOCOInstance.ProjectContractId; }
            set
            {
                CopyofPOCOInstance.ProjectContractId = value;
                RaisePropertyChanged("ProjectContractId");
            }
        }


        #endregion

        #region ProjectContract
        public ProjectContract ProjectContract
        {
            get { return CopyofPOCOInstance.ProjectContract; }
            set { CopyofPOCOInstance.ProjectContract = value; RaisePropertyChanged("ProjectContract"); }
        }


        #endregion

        #region Code
        public string Code
        {
            get { return CopyofPOCOInstance.Code; }
            set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); }
        }


        #endregion

        #region Name
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set
            {
                CopyofPOCOInstance.Name = value;
                RaisePropertyChanged("Name");
            }
        }


        #endregion

        #region StartDate
        public DateTime StartDate
        {
            get { return CopyofPOCOInstance.StartDate.HasValue ? CopyofPOCOInstance.StartDate.Value : DateTime.Now; }
            set { CopyofPOCOInstance.StartDate = value; RaisePropertyChanged("StartDate"); }
        }


        #endregion

        #region CompletionDate

        public DateTime? CompletionDate
        {
            get { return CopyofPOCOInstance.CompletionDate; }
            set { CopyofPOCOInstance.CompletionDate = value; RaisePropertyChanged("CompletionDate"); }
        }


        #endregion

        #region State
        public byte? State
        {
            get { return CopyofPOCOInstance.State; }
            set { CopyofPOCOInstance.State = value; RaisePropertyChanged("State"); }
        }


        #endregion

        #region Model Command Functions      

        //public override void Query()
        //{
        //    if (ProjectContractId != null && ProjectContractId != Guid.Empty)
        //    {
        //        var executed_result = controller.Query(p => p.Id == Id);

        //        if (!executed_result.HasError)
        //        {
        //            Entity.Engineering data = executed_result.Result.Single();
        //            BindingFromModel(data, this);
        //        }
        //    }

        //}

        //public override void SaveModel()
        //{

        //}
        #endregion









    }
}
