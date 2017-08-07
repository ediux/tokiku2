using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    public interface IMainViewModel : IBaseViewModelWithLoginedUser
    {
        /// <summary>
        /// 主功能表
        /// </summary>
        ObservableCollection<IMenuItemViewModel> MainMenus { get; set; }
        /// <summary>
        /// 功能區分頁
        /// </summary>
        ObservableCollection<ITabViewModel> FeaturesTabs { get; set; }

    }
}