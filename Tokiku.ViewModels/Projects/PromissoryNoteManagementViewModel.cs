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
            /*base.Query();
            PromissoryNoteManagementViewModelController ctrl = new PromissoryNoteManagementViewModelController();
            ExecuteResultEntity<ICollection<本票管理Entity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                PromissoryNoteManagementViewModel vm = new PromissoryNoteManagementViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
            // */
        }
    }

    public class PromissoryNoteManagementViewModel : BaseViewModel
    {
        // propdp=>[tab]=>[tab]
        public string 保證票Name
        {
            get { return (string)GetValue(保證票NameProperty); }
            set { SetValue(保證票NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for 保證票Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保證票NameProperty =
            DependencyProperty.Register("保證票Name", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));
        
        public Nullable<int> 保證票Id
        {
            get { return (Nullable<int>)GetValue(保證票IdProperty); }
            set { SetValue(保證票IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for 保證票Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保證票IdProperty =
            DependencyProperty.Register("保證票Id", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(null));
        
        public int 保證票金額
        {
            get { return (int)GetValue(保證票金額Property); }
            set { SetValue(保證票金額Property, value); }
        }

        // Using a DependencyProperty as the backing store for 保證票金額.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保證票金額Property =
            DependencyProperty.Register("保證票金額", typeof(int), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(0));
        
        public Nullable<DateTime> 保證票開立日期
        {
            get { return (Nullable<DateTime>)GetValue(保證票開立日期Property); }
            set { SetValue(保證票開立日期Property, value); }
        }

        // Using a DependencyProperty as the backing store for 保證票開立日期.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保證票開立日期Property =
            DependencyProperty.Register("保證票開立日期", typeof(Nullable<DateTime>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));
        
        public DateTime 保證票取回日期
        {
            get { return (DateTime)GetValue(保證票取回日期Property); }
            set { SetValue(保證票取回日期Property, value); }
        }

        // Using a DependencyProperty as the backing store for 保證票取回日期.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保證票取回日期Property =
            DependencyProperty.Register("保證票取回日期", typeof(Nullable<DateTime>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));
        
        public Nullable<int> 保固票Id
        {
            get { return (Nullable<int>)GetValue(保固票IdProperty); }
            set { SetValue(保固票IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for 保固票Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保固票IdProperty =
            DependencyProperty.Register("保固票Id", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));
        
        public string 保固票Name
        {
            get { return (string)GetValue(保固票NameProperty); }
            set { SetValue(保固票NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for 保固票Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保固票NameProperty =
            DependencyProperty.Register("保固票Name", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));
        
        public Nullable<int> 保固票金額
        {
            get { return (Nullable<int>)GetValue(保固票金額Property); }
            set { SetValue(保固票金額Property, value); }
        }

        // Using a DependencyProperty as the backing store for 保固票金額.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保固票金額Property =
            DependencyProperty.Register("保固票金額", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));
        
        public Nullable<DateTime> 保固票開立日期
        {
            get { return (Nullable<DateTime>)GetValue(保固票開立日期Property); }
            set { SetValue(保固票開立日期Property, value); }
        }

        // Using a DependencyProperty as the backing store for 保固票開立日期.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保固票開立日期Property =
            DependencyProperty.Register("保固票開立日期", typeof(Nullable<DateTime>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));
        
        public Nullable<DateTime> 保固票取回日期
        {
            get { return (Nullable<DateTime>)GetValue(保固票取回日期Property); }
            set { SetValue(保固票取回日期Property, value); }
        }

        // Using a DependencyProperty as the backing store for 保固票取回日期.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 保固票取回日期Property =
            DependencyProperty.Register("保固票取回日期", typeof(Nullable<DateTime>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<DateTime>)));
        
        public Nullable<int> 異動人員Id
        {
            get { return (Nullable<int>)GetValue(異動人員IdProperty); }
            set { SetValue(異動人員IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for 異動人員Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 異動人員IdProperty =
            DependencyProperty.Register("異動人員Id", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));
        
        public string 異動人員Name
        {
            get { return (string)GetValue(異動人員NameProperty); }
            set { SetValue(異動人員NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for 異動人員Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 異動人員NameProperty =
            DependencyProperty.Register("異動人員Name", typeof(string), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(string.Empty));
        
        public Nullable<int> 承攬總價
        {
            get { return (Nullable<int>)GetValue(承攬總價Property); }
            set { SetValue(承攬總價Property, value); }
        }

        // Using a DependencyProperty as the backing store for 承攬總價.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty 承攬總價Property =
            DependencyProperty.Register("承攬總價", typeof(Nullable<int>), typeof(PromissoryNoteManagementViewModel), new PropertyMetadata(default(Nullable<int>)));


    }

}
