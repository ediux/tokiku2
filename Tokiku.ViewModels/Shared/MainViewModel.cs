using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class MainViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        public MainViewModel()
        {
        }

        public static readonly DependencyProperty CurrentProjectProperty = DependencyProperty.Register("CurrentProject", typeof(ProjectBaseViewModel), typeof(MainViewModel), new PropertyMetadata(default(ProjectBaseViewModel), new PropertyChangedCallback(DefaultFieldChanged)));

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

        public ObservableCollection<ProjectListViewModel> Projects
        {
            get { return (ObservableCollection<ProjectListViewModel>)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); RaisePropertyChanged("Projects"); }
        }

        // Using a DependencyProperty as the backing store for Projects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(ObservableCollection<ProjectListViewModel>), typeof(MainViewModel), new PropertyMetadata(default(ObservableCollection<ProjectListViewModel>),
                new PropertyChangedCallback(DefaultFieldChanged)));



        public ObservableCollection<ManufacturersViewModel> Manufacturers
        {
            get { return (ObservableCollection<ManufacturersViewModel>)GetValue(ManufacturersProperty); }
            set { SetValue(ManufacturersProperty, value); RaisePropertyChanged("Manufacturers"); }
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersProperty =
            DependencyProperty.Register("Manufacturers", typeof(ObservableCollection<ManufacturersViewModel>), typeof(MainViewModel), new PropertyMetadata(default(ObservableCollection<ManufacturersViewModel>),
                new PropertyChangedCallback(DefaultFieldChanged)));

       

    }
}
