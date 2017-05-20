using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LoginedUser = new Users()
            {
                UserId = Guid.Empty,
                UserName = "root",
                LoweredUserName = "root",
                IsAnonymous = false,
            };
        }

        public static readonly DependencyProperty LoginedUserProperty = DependencyProperty.Register("LoginedUser", typeof(Users), typeof(MainViewModel), new PropertyMetadata(DependencyProperty.UnsetValue));

        public static readonly DependencyProperty CurrentProjectProperty = DependencyProperty.Register("CurrentProject", typeof(ProjectBaseViewModel), typeof(MainViewModel), new PropertyMetadata(DependencyProperty.UnsetValue));

        public static readonly DependencyProperty LoadedProjectsProperty = DependencyProperty.Register("LoadedProjects", typeof(Collection<ProjectBaseViewModel>), typeof(MainViewModel), new PropertyMetadata(DependencyProperty.UnsetValue));

        /// <summary>
        /// 目前選定的專案
        /// </summary>
        public ProjectBaseViewModel CurrentProject
        {
            get
            {
                return GetValue(CurrentProjectProperty) as ProjectBaseViewModel;
            }

            set
            {
                SetValue(CurrentProjectProperty, value);
                RaisePropertyChanged("CurrentProject");
            }
        }

        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public Users LoginedUser
        {
            get { return GetValue(LoginedUserProperty) as Users; }
            set
            {
                SetValue(LoginedUserProperty, value);
                RaisePropertyChanged("LoginedUser");
            }
        }

        /// <summary>
        /// 取得目前已選取的專案
        /// </summary>
        public Collection<ProjectBaseViewModel> LoadedProjects
        {
            get { return GetValue(LoadedProjectsProperty) as Collection<ProjectBaseViewModel>; }
            set { SetValue(LoadedProjectsProperty, value); }
        }
    }
}
