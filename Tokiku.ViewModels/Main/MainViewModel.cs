﻿using System;
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
        public MainViewModel(IUserDataService UserDataService) : base(UserDataService)
        {
            _FeaturesTabs = new ObservableCollection<ITabViewModel>();
            _FeaturesTabs.Add(new FixedTabViewModel() { Header = "專案列表" });
            _MainMenus = new ObservableCollection<IMenuItemViewModel>();
            _MainMenus.Add(new MenuItemViewModel() { Header = "主檔 " });

        }
        private ObservableCollection<ITabViewModel> _FeaturesTabs;
        /// <summary>
        /// 分頁功能區塊
        /// </summary>
        public ObservableCollection<ITabViewModel> FeaturesTabs { get => _FeaturesTabs; set { _FeaturesTabs = value; RaisePropertyChanged("FeaturesTabs"); } }

        private ObservableCollection<IMenuItemViewModel> _MainMenus;
        /// <summary>
        /// 主功能列
        /// </summary>
        public ObservableCollection<IMenuItemViewModel> MainMenus { get => _MainMenus; set { _MainMenus = value; } }
    }
}
