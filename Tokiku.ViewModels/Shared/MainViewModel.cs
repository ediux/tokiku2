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

        }

       

        public static readonly DependencyProperty CurrentProjectProperty = DependencyProperty.Register("CurrentProject", typeof(ProjectBaseViewModel), typeof(MainViewModel), new PropertyMetadata(default(ProjectBaseViewModel)));

        public static readonly DependencyProperty LoadedProjectsProperty = DependencyProperty.Register("LoadedProjects", typeof(Collection<ProjectBaseViewModel>), typeof(MainViewModel), new PropertyMetadata(new Collection<ProjectBaseViewModel>()));

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
        /// 取得目前已選取的專案
        /// </summary>
        public Collection<ProjectBaseViewModel> LoadedProjects
        {
            get { return GetValue(LoadedProjectsProperty) as Collection<ProjectBaseViewModel>; }
            set { SetValue(LoadedProjectsProperty, value); }
        }
    }
}
