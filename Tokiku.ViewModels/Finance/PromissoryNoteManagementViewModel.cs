using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.ViewModels
{
    public class PromissoryNoteManagementViewModelCollection : BaseViewModelCollection<PromissoryNoteManagementViewModel>
    {
        public PromissoryNoteManagementViewModelCollection()
        {
            HasError = false;
        }

        public PromissoryNoteManagementViewModelCollection(IEnumerable<PromissoryNoteManagementViewModel> source) : base(source)
        {


        }

        //public override void Query()
        //{
        //    PromissoryNoteManagementViewModelController ctrl = new PromissoryNoteManagementViewModelController();
        //    ExecuteResultEntity<ICollection<PromissoryNoteManagementEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        PromissoryNoteManagementViewModel vm = new PromissoryNoteManagementViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}
    }

    public class PromissoryNoteManagementViewModel : BaseViewModelWithPOCOClass<PromissoryNoteManagementEntity>
    {
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is PromissoryNoteManagementEntity)
        //        {
        //            PromissoryNoteManagementEntity data = (PromissoryNoteManagementEntity)entity;
        //            BindingFromModel(data, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //        throw;
        //    }
        //}


        // 工程代號
        public string ContractNumber
        {
            get { return CopyofPOCOInstance.ContractNumber; }
            set { CopyofPOCOInstance.ContractNumber = value; RaisePropertyChanged("ContractNumber"); }
        }


        // 專案名稱
        public string ProjectName
        {
            get { return CopyofPOCOInstance.ProjectName; }
            set { CopyofPOCOInstance.ProjectName = value; RaisePropertyChanged("ProjectName"); }
        }


        // 本票代號
        public Nullable<byte> PromissoryId
        {
            get { return CopyofPOCOInstance.PromissoryId; }
            set { CopyofPOCOInstance.PromissoryId = value; RaisePropertyChanged("PromissoryId"); }
        }


        // 本票名稱
        public string PromissoryName
        {
            get { return CopyofPOCOInstance.PromissoryName; }
            set { CopyofPOCOInstance.PromissoryName = value; RaisePropertyChanged("PromissoryName"); }
        }



        // 本票票據金額
        public Nullable<float> PromissoryAmount
        {
            get { return CopyofPOCOInstance.PromissoryAmount; }
            set { CopyofPOCOInstance.PromissoryAmount = value; RaisePropertyChanged("PromissoryAmount"); }
        }


        // 本票開立日期
        public string PromissoryOpenDate
        {
            get { return CopyofPOCOInstance.PromissoryOpenDate; }
            set { CopyofPOCOInstance.PromissoryOpenDate = value; RaisePropertyChanged("PromissoryOpenDate"); }
        }



        // 本票取回日期
        public string PromissoryRecoveryDate
        {
            get { return CopyofPOCOInstance.PromissoryRecoveryDate; }
            set { CopyofPOCOInstance.PromissoryRecoveryDate = value; RaisePropertyChanged("PromissoryRecoveryDate"); }
        }



        // 保固票代號
        public Nullable<byte> WarrantyId
        {
            get { return CopyofPOCOInstance.WarrantyId; }
            set { CopyofPOCOInstance.WarrantyId = value; RaisePropertyChanged("WarrantyId"); }
        }



        // 保固票名稱
        public string WarrantyName
        {
            get { return CopyofPOCOInstance.WarrantyName; }
            set { CopyofPOCOInstance.WarrantyName=value; RaisePropertyChanged("WarrantyName"); }
        }



        // 保固票票據金額
        public Nullable<float> WarrantyAmount
        {
            get { return CopyofPOCOInstance.WarrantyAmount; }
            set { CopyofPOCOInstance.WarrantyAmount = value; RaisePropertyChanged("WarrantyAmount"); }
        }


        // 保固票開立日期
        public string WarrantyOpenDate
        {
            get { return CopyofPOCOInstance.WarrantyOpenDate; }
            set { CopyofPOCOInstance.WarrantyOpenDate = value; RaisePropertyChanged("WarrantyOpenDate"); }
        }



        // 保固票取回日期
        public string WarrantyRecoveryDate
        {
            get { return CopyofPOCOInstance.WarrantyRecoveryDate; }
            set { CopyofPOCOInstance.WarrantyRecoveryDate = value; RaisePropertyChanged("WarrantyRecoveryDate"); }
        }



       

        /*/ 承攬總價
        public Nullable<int> 承攬總價
        {
            get { return (Nullable<int>)GetValue(承攬總價Property); }
            set { SetValue(承攬總價Property, value); }
        }

        // Using a DependencyProperty as the backing store for 承攬總價.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 承攬總價Property =
            DependencyProperty.Register("承攬總價", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));
        // */
    }

}
