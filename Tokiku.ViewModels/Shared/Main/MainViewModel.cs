using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MainViewModel : WithLoginUserBaseViewModel, IMainViewModel
    {
        public MainViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {
            
            _FeaturesTabs = new ObservableCollection<ITabViewModel>();
            _FeaturesTabs.Add(new FixedTabViewModel() { Header = "專案列表" ,ContentView = new TokikuNew.Controls.EmptyView()});

          
            var menuroot1 = new MenuItemViewModel() { Header = "主檔 " };

            menuroot1.SubMenus.Add(new MenuItemViewModel() { Header = "廠商列表" });
            menuroot1.SubMenus.Add(new MenuItemViewModel() { Header = "客戶列表" });
            menuroot1.SubMenus.Add(new MenuItemViewModel() { Header = "模具總表" });

            _MainMenus.Add(menuroot1);
            _MainMenus.Add(new MenuItemViewModel() { Header = "報表" });

            var menuroot2 = new MenuItemViewModel() { Header = "帳務" };

            menuroot2.SubMenus.Add(new MenuItemViewModel() { Header = "本票管理" });
            menuroot2.SubMenus.Add(new MenuItemViewModel() { Header = "合約管理" });

            _MainMenus.Add(menuroot2);
            var menuroot3 = new MenuItemViewModel() { Header = "系統管理" };
            menuroot3.SubMenus.Add(new MenuItemViewModel() { Header="選項" });
            menuroot3.SubMenus.Add(new MenuItemViewModel() { Header = "人員管理" });
            menuroot3.SubMenus.Add(new MenuItemViewModel() { Header = "角色管理" });
            menuroot3.SubMenus.Add(new MenuItemViewModel() { Header = "結束程式" });
            _MainMenus.Add(menuroot3);
        }
        private ObservableCollection<ITabViewModel> _FeaturesTabs;
        /// <summary>
        /// 分頁功能區塊
        /// </summary>
        public ObservableCollection<ITabViewModel> FeaturesTabs { get => _FeaturesTabs; set { _FeaturesTabs = value; RaisePropertyChanged("FeaturesTabs"); } }

        private ObservableCollection<IMenuItemViewModel> _MainMenus = new ObservableCollection<IMenuItemViewModel>();
        /// <summary>
        /// 主功能列
        /// </summary>
        public ObservableCollection<IMenuItemViewModel> MainMenus { get => _MainMenus; set { _MainMenus = value; RaisePropertyChanged("MainMenus"); } }
    }
}
