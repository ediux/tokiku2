using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ProjectContractViewModelCollection : ObservableCollection<ProjectContractViewModel>
    {

    }

    public class ProjectContractViewModel : WithOutBaseViewModel, IBaseViewModel
    {


        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); RaisePropertyChanged("Id"); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ProjectContractViewModel), new PropertyMetadata(Guid.NewGuid(), new PropertyChangedCallback(DefaultFieldChanged)));



        public Guid? ProjectId
        {
            get { return (Guid?)GetValue(ProjectIdProperty); }
            set { SetValue(ProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectIdProperty =
            DependencyProperty.Register("ProjectId", typeof(Guid?), typeof(ProjectContractViewModel), new PropertyMetadata(default(Guid?), new PropertyChangedCallback(DefaultFieldChanged)));




        //public Nullable<System.Guid> ProjectId { get; set; }
        //public System.Guid ContractorId { get; set; }
        //public System.DateTime SigningDate { get; set; }
        //public string ContractNumber { get; set; }
        //public System.DateTime StartDate { get; set; }
        //public System.DateTime CompletionDate { get; set; }
        //public Nullable<float> ContractAmount { get; set; }
        //public Nullable<float> AmountDue { get; set; }
        //public Nullable<float> PrepaymentGuaranteeAmount { get; set; }
        //public Nullable<System.DateTime> OpenDate { get; set; }
        //public byte PaymentType { get; set; }
        //public System.DateTime CreateTime { get; set; }
        //public System.Guid CreateUserId { get; set; }

     
        //public virtual ICollection<EngineeringViewModel> Engineering { get; set; }
        //public virtual ProjectBaseViewModel Projects { get; set; }
        //public virtual UserViewModel CreateUser { get; set; }
        
        //public virtual ICollection<PromissoryNoteManagementViewModel> PromissoryNoteManagement { get; set; }
    }
}
