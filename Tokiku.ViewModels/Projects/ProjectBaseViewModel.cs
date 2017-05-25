using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ProjectBaseViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        #region 私有變數
        /// <summary>
        /// 專案相關控制器
        /// </summary>         
        #endregion

        #region 相依性屬性宣告

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(Guid), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ProjectSigningDateProperty = DependencyProperty.Register("ProjectSigningDate", typeof(DateTime), typeof(ProjectBaseViewModel), new PropertyMetadata(DateTime.Today, new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ClientIdProperty = DependencyProperty.Register("ClientId", typeof(Guid), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserIdProperty = DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty SiteAddressProperty = DependencyProperty.Register("SiteAddress", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(byte), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty StateTextProperty = DependencyProperty.Register("StateText", typeof(ObservableCollection<StatesViewModel>), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty VoidProperty = DependencyProperty.Register("Void", typeof(bool), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

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
        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); } }
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
        public System.Guid ClientId { get { return (Guid)GetValue(ClientIdProperty); } set { SetValue(ClientIdProperty, value); } }
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
        public bool Void { get { return (bool)GetValue(VoidProperty); } set { SetValue(VoidProperty, value); } }

        /// <summary>
        /// 狀態資料來源
        /// </summary>
        public ObservableCollection<StatesViewModel> StateText
        {
            get { return (ObservableCollection<StatesViewModel>)GetValue(StateTextProperty); }
            set { SetValue(StateTextProperty, value); }
        } 
        #endregion
    }
}
