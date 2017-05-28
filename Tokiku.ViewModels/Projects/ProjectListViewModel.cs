using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ProjectListViewModelCollection : ObservableCollection<ProjectListViewModel>, IBaseViewModel
    {
        public ProjectListViewModelCollection() : base()
        {

        }

        public ProjectListViewModelCollection(IEnumerable<ProjectListViewModel> source) : base(source)
        {

        }

        private IEnumerable<string> _Errors;
        public IEnumerable<string> Errors { get => _Errors; set => _Errors = value; }
        private bool _HasError = false;
        public bool HasError { get => _HasError; set => _HasError = value; }

    }
    public class ProjectListViewModel : BaseViewModel
    {
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(Guid), typeof(ProjectListViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(ProjectListViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ProjectListViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName", typeof(string), typeof(ProjectListViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(string), typeof(ProjectListViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); RaisePropertyChanged("Id"); }
        }

        /// <summary>
        /// 專案代碼
        /// </summary>
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); RaisePropertyChanged("Code"); }
        }

        /// <summary>
        /// 專案名稱
        /// </summary>
        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); RaisePropertyChanged("Name"); } }
        /// <summary>
        /// 專案名稱(簡稱)
        /// </summary>
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); RaisePropertyChanged("ShortName"); } }

        /// <summary>
        /// 狀態
        /// </summary>
        public string State { get { return (string)GetValue(StateProperty); } set { SetValue(StateProperty, value); RaisePropertyChanged("State"); } }

        public DateTime? StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); RaisePropertyChanged("StartDate"); }
        }

        // Using a DependencyProperty as the backing store for StartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register("StartDate", typeof(DateTime?), typeof(ProjectListViewModel), new PropertyMetadata(default(DateTime?), new PropertyChangedCallback(DefaultFieldChanged)));



        public DateTime? CompletionDate
        {
            get { return (DateTime)GetValue(CompletionDateProperty); }
            set { SetValue(CompletionDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompletionDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompletionDateProperty =
            DependencyProperty.Register("CompletionDate", typeof(DateTime?), typeof(ProjectListViewModel), new PropertyMetadata(default(DateTime?), new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 保固日期
        /// </summary>
        public DateTime? WarrantyDate
        {
            get { return (DateTime?)GetValue(WarrantyDateProperty); }
            set { SetValue(WarrantyDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyDateProperty =
            DependencyProperty.Register("WarrantyDate", typeof(DateTime?), typeof(ProjectListViewModel), new PropertyMetadata(default(DateTime?)));

        //public System.DateTime StartDate { get; set; }
        //public System.DateTime CompletionDate { get; set; }
    }
}
