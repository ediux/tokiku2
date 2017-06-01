using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ProjectsViewModelCollection : ObservableCollection<ProjectsViewModel>, IBaseViewModel
    {
        public ProjectsViewModelCollection()
        {
            HasError = false;
        }

        public ProjectsViewModelCollection(IEnumerable<ProjectsViewModel> source):base(source){

        }

        public IEnumerable<string> Errors { get; set; }
        public bool HasError { get; set; }
    }

    public class ProjectsViewModel : BaseViewModel, IBaseViewModel
    {
        #region 私有變數
        /// <summary>
        /// 專案相關控制器
        /// </summary>         
        #endregion

        #region 相依性屬性宣告

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(Guid), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ProjectSigningDateProperty = DependencyProperty.Register("ProjectSigningDate", typeof(DateTime), typeof(ProjectsViewModel), new PropertyMetadata(DateTime.Today, new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ProjectNameProperty = DependencyProperty.Register("ProjectName", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ClientIdProperty = DependencyProperty.Register("ClientId", typeof(Guid?), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserIdProperty = DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty SiteAddressProperty = DependencyProperty.Register("SiteAddress", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(byte), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty StateTextProperty = DependencyProperty.Register("StateText", typeof(StatesViewModelCollection), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty VoidProperty = DependencyProperty.Register("Void", typeof(bool), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        #region 屬性
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        /// <summary>
        /// 專案代碼
        /// </summary>
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        /// <summary>
        /// 專案名稱
        /// </summary>
        public string ProjectName { get { return (string)GetValue(ProjectNameProperty); } set { SetValue(ProjectNameProperty, value); } }
        /// <summary>
        /// 專案名稱(簡稱)
        /// </summary>
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); } }
        /// <summary>
        /// 工地地址
        /// </summary>
        public string SiteAddress { get { return (string)GetValue(SiteAddressProperty); } set { SetValue(SiteAddressProperty, value); } }
        /// <summary>
        /// 客戶
        /// </summary>
        public System.Guid? ClientId { get { return (Guid?)GetValue(ClientIdProperty); } set { SetValue(ClientIdProperty, value); } }
        /// <summary>
        /// 建立時間
        /// </summary>
        public System.DateTime CreateTime { get { return (DateTime)GetValue(CreateTimeProperty); } set { SetValue(CreateTimeProperty, value); } }
        /// <summary>
        /// 建立者(擁有者)
        /// </summary>
        public System.Guid CreateUserId { get { return (Guid)GetValue(CreateUserIdProperty); } set { SetValue(CreateUserIdProperty, value); } }
        /// <summary>
        /// 工程簽約日期
        /// </summary>
        public DateTime ProjectSigningDate
        {
            get { return (DateTime)GetValue(ProjectSigningDateProperty); }
            set { SetValue(ProjectSigningDateProperty, value); }
        }
        /// <summary>
        /// 備註
        /// </summary>
        public string Comment { get { return (string)GetValue(CommentProperty); } set { SetValue(CommentProperty, value); } }
        /// <summary>
        /// 狀態
        /// </summary>
        public byte State { get { return (byte)GetValue(StateProperty); } set { SetValue(StateProperty, value); } }
        /// <summary>
        /// 是否停用
        /// </summary>
        /// <remarks>
        /// (0: 啟用 1:停用)
        /// </remarks>
        public bool Void { get { return (bool)GetValue(VoidProperty); } set { SetValue(VoidProperty, value); RaisePropertyChanged("Void"); } }

        
        /// <summary>
        /// 狀態資料來源
        /// </summary>
        public StatesViewModelCollection StateText
        {
            get { return (StatesViewModelCollection)GetValue(StateTextProperty); }
            set { SetValue(StateTextProperty, value); RaisePropertyChanged("StateText"); }
        }
        #endregion

        #region Project Contract
        /// <summary>
        /// 專案合約
        /// </summary>
        public ProjectContractViewModelCollection ProjectContract
        {
            get { return (ProjectContractViewModelCollection)GetValue(ProjectContractProperty); }
            set { SetValue(ProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractProperty =
            DependencyProperty.Register("ProjectContract", typeof(ProjectContractViewModelCollection), typeof(ProjectsViewModel
                ), new PropertyMetadata(default(ProjectContractViewModelCollection), new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion


        /// <summary>
        /// 客戶列表
        /// </summary>
        public ClientViewModelCollection Clients
        {
            get { return (ClientViewModelCollection)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clients.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClientsProperty =
            DependencyProperty.Register("Clients", typeof(ClientViewModelCollection), typeof(ProjectsViewModel), new PropertyMetadata(new ClientViewModelCollection()));


    }
}
