namespace Tokiku.ViewModels
{
    public class StateTextViewModel : BaseViewModel
    {
        private byte _Id = 0;
        private string _StateName = string.Empty;            

        /// <summary>
        /// 編號
        /// </summary>
        public byte Id { get { return _Id; } set { _Id = value; RaisePropertyChanged("Id"); } }
        /// <summary>
        /// 狀態文字
        /// </summary>
        public string StateName { get { return _StateName; } set { _StateName = value; RaisePropertyChanged("StateName"); } }
    }
}