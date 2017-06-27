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

        public override void Query()
        {
            PromissoryNoteManagementViewModelController ctrl = new PromissoryNoteManagementViewModelController();
            ExecuteResultEntity<ICollection<PromissoryNoteManagementEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                PromissoryNoteManagementViewModel vm = new PromissoryNoteManagementViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }
    }

    public class PromissoryNoteManagementViewModel : BaseViewModel
    {
        // 工程代號
        public string ContractNumber
        {
            get { return (string)GetValue(ContractNumberProperty); }
            set { SetValue(ContractNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContractNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractNumberProperty =
            DependencyProperty.Register("ContractNumber", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));


        // 專案名稱
        public string ProjectName
        {
            get { return (string)GetValue(ProjectNameProperty); }
            set { SetValue(ProjectNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectNameProperty =
            DependencyProperty.Register("ProjectName", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));


        // 本票代號
        public Nullable<int> PromissoryId
        {
            get { return (Nullable<int>)GetValue(PromissoryIdProperty); }
            set { SetValue(PromissoryIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PromissoryId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromissoryIdProperty =
            DependencyProperty.Register("PromissoryId", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));


        // 本票名稱
        public string PromissoryName
        {
            get { return (string)GetValue(PromissoryNameProperty); }
            set { SetValue(PromissoryNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PromissoryName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromissoryNameProperty =
            DependencyProperty.Register("PromissoryName", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));


        // 本票票據金額
        public Nullable<int> PromissoryAmount
        {
            get { return (Nullable<int>)GetValue(PromissoryAmountProperty); }
            set { SetValue(PromissoryAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PromissoryAmount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromissoryAmountProperty =
            DependencyProperty.Register("PromissoryAmount", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));


        // 本票開立日期
        public DateTime PromissoryOpenDate
        {
            get { return (DateTime)GetValue(PromissoryOpenDateProperty); }
            set { SetValue(PromissoryOpenDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PromissoryOpenDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromissoryOpenDateProperty =
            DependencyProperty.Register("PromissoryOpenDate", typeof(DateTime), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));


        // 本票取回日期
        public DateTime PromissoryRecoveryDate
        {
            get { return (DateTime)GetValue(PromissoryRecoveryDateProperty); }
            set { SetValue(PromissoryRecoveryDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PromissoryRecoveryDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromissoryRecoveryDateProperty =
            DependencyProperty.Register("PromissoryRecoveryDate", typeof(DateTime), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));


        // 保固票代號
        public Nullable<int> WarrantyId
        {
            get { return (Nullable<int>)GetValue(WarrantyIdProperty); }
            set { SetValue(WarrantyIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyIdProperty =
            DependencyProperty.Register("WarrantyId", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));


        // 保固票名稱
        public string WarrantyName
        {
            get { return (string)GetValue(WarrantyNameProperty); }
            set { SetValue(WarrantyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyNameProperty =
            DependencyProperty.Register("WarrantyName", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));


        // 保固票票據金額
        public Nullable<int> WarrantyAmount
        {
            get { return (Nullable<int>)GetValue(WarrantyAmountProperty); }
            set { SetValue(WarrantyAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyAmount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyAmountProperty =
            DependencyProperty.Register("WarrantyAmount", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));


        // 保固票開立日期
        public DateTime WarrantyOpenDate
        {
            get { return (DateTime)GetValue(WarrantyOpenDateProperty); }
            set { SetValue(WarrantyOpenDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyOpenDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyOpenDateProperty =
            DependencyProperty.Register("WarrantyOpenDate", typeof(DateTime), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));


        // 保固票取回日期
        public DateTime WarrantyRecoveryDate
        {
            get { return (DateTime)GetValue(WarrantyRecoveryDateProperty); }
            set { SetValue(WarrantyRecoveryDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyRecoveryDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyRecoveryDateProperty =
            DependencyProperty.Register("WarrantyRecoveryDate", typeof(DateTime), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));


        // 異動人員代號
        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(Guid.Empty));


        // 異動人員
        public string CreateUser
        {
            get { return (string)GetValue(CreateUserProperty); }
            set { SetValue(CreateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserProperty =
            DependencyProperty.Register("CreateUser", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));


        // 異動時間
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));

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
