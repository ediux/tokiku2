using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using Tokiku.DataServices;

namespace Tokiku.ViewModels
{
    public class MainViewModel : WithLoginUserBaseViewModel, IMainViewModel
    {
        public MainViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {

            _FeaturesTabs = new ObservableCollection<ITabViewModel>();
         


            var menuroot1 = new MenuItemViewModel() { Header = "主檔 " };
            var assembly = Assembly.Load("TokikuNew");

            _FeaturesTabs.Add(new FixedTabViewModel()
            {
                Header = "專案列表",
                ContentView = null 
            });

            menuroot1.MenuItems.Add(new MenuItemViewModel()
            {
                Header = "廠商列表",
                TabControlName = "Workspaces",
                ViewType = assembly.GetType("TokikuNew.Views.VendorListView"),
                DataModelType = typeof(IVendorListViewModel)
            });
            menuroot1.MenuItems.Add(new MenuItemViewModel()
            {
                Header = "客戶列表",
                TabControlName = "Workspaces",
                ViewType = assembly.GetType("TokikuNew.Views.ClientListView"),
                DataModelType = typeof(IClientListViewModel)
            });

            menuroot1.MenuItems.Add(new MenuItemViewModel() { Header = "模具總表", TabControlName = "Workspaces" });

            _MainMenus.Add(menuroot1);
            _MainMenus.Add(new MenuItemViewModel() { Header = "報表" });

            var menuroot2 = new MenuItemViewModel() { Header = "帳務" };

            menuroot2.MenuItems.Add(new MenuItemViewModel() { Header = "本票管理", TabControlName = "Workspaces" });
            menuroot2.MenuItems.Add(new MenuItemViewModel() { Header = "合約管理", TabControlName = "Workspaces" });

            _MainMenus.Add(menuroot2);
            var menuroot3 = new MenuItemViewModel() { Header = "系統管理" };
            menuroot3.MenuItems.Add(new MenuItemViewModel() { Header = "選項", TabControlName = "Workspaces" });
            menuroot3.MenuItems.Add(new MenuItemViewModel() { Header = "人員管理", TabControlName = "Workspaces" });
            menuroot3.MenuItems.Add(new MenuItemViewModel() { Header = "角色管理", TabControlName = "Workspaces" });
            menuroot3.MenuItems.Add(new MenuItemViewModel()
            {
                Header = "結束程式",
                ClickCommand = new RelayCommand<IMenuItemViewModel>((x) =>
                {
                    try
                    {
                        DefaultLocator.Current.CoreDataService.Logout();
                        Application.Current.Shutdown();
                    }
                    catch (Exception ex)
                    {
                        setErrortoModel(this, ex);
                    }

                })
            });
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
