using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;
using GalaSoft.MvvmLight;
using Tokiku.DataServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using System.Reflection;
using GalaSoft.MvvmLight.Messaging;

namespace Tokiku.ViewModels
{
    public class ProjectListViewModel : DocumentBaseViewModel, IProjectListViewModel
    {
        public ProjectListViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {
        }

        private ObservableCollection<IProjectListItemViewModel> _ProjectsList;

        public ObservableCollection<IProjectListItemViewModel> ProjectsList
        {
            get => _ProjectsList;
            set
            {
                try
                {
                    _ProjectsList = value;
                    RaisePropertyChanged("ProjectsList");

                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }

        private ICommand _SelectedAndOpenCommand;

        public ICommand SelectedAndOpenCommand
        {
            get => _SelectedAndOpenCommand; set
            {
                try
                {
                    _SelectedAndOpenCommand = value;
                    RaisePropertyChanged("SelectedAndOpenCommand");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }

        public override void CreateNew()
        {
            try
            {
                ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();

                tab.ViewType = Assembly.Load("TokikuNew").GetType("TokikuNew.Views.ClientManageView");
                tab.ContentView = SimpleIoc.Default.GetInstanceWithoutCaching(tab.ViewType);
                tab.Header = "新增客戶";
                tab.SelectedObject = null;
                tab.DataModelType = typeof(IClientViewModel);
                tab.TabControlName = "Workspaces";
                tab.IsNewModel = true;

                var msg = new NotificationMessage<ITabViewModel>(this, tab, "OpenTab");
                Messenger.Default.Send(msg);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }


        }

        protected void RunSelectedAndOpenCommand(object parameter)
        {
            try
            {
                if (parameter is IVendorListItemViewModel)
                {
                    ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();
                    IVendorListItemViewModel selecteditem = (IVendorListItemViewModel)parameter;

                    if (selecteditem != null)
                    {
                        tab.ViewType = Assembly.Load("TokikuNew").GetType("TokikuNew.Views.ClientManageView");
                        tab.ContentView = SimpleIoc.Default.GetInstanceWithoutCaching(tab.ViewType);
                        tab.Header = string.Format("客戶:{0}-{1}", selecteditem.Code, selecteditem.ShortName);
                        tab.SelectedObject = selecteditem;
                        tab.DataModelType = typeof(IClientViewModel);
                        tab.TabControlName = "Workspaces";

                        var msg = new NotificationMessage<ITabViewModel>(this, tab, "OpenTab");
                        Messenger.Default.Send(msg);
                    }

                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }


        }

        public override void Query(object Parameter)
        {
            try
            {
                if (Parameter == null)
                {
                    _ClientsList = new ObservableCollection<IClientListItemViewModel>(
                        _ClientDataService.GetAll().Select(s => new ClientListItemViewModel(s)));
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }


        }
        //private ProjectsController _projects_controller;


        //public ProjectListViewModelCollection(IEnumerable<ProjectListViewModel> source) : base(source)
        //{

        //}

        //public override void Initialized()
        //{
        //    base.Initialized();
        //    //_projects_controller = new ProjectsController();
        //}

        public void Refresh()
        {

        }

        //public ProjectListViewModelCollection Query()
        //{
        //    //return Query<ProjectListViewModelCollection, ProjectListEntity>("Projects", "QueryAll");
        //    //var projectResult = _projects_controller.Query(v => v.Void == false);
        //    //if (!projectResult.HasError)
        //    //{
        //    //    Clear();
        //    //    var result = projectResult.Result
        //    //        .OrderByDescending(s => s.Code)
        //    //        .OrderBy(s => s.State)
        //    //        .Select(s => new ProjectListViewModel()
        //    //        {
        //    //            Code = s.Code,
        //    //            CompletionDate = s.PromissoryNoteManagement.Where(k => k.TicketTypeId == 3 || k.TicketTypeId == 4).OrderByDescending(w => w.OpenDate).FirstOrDefault()?.OpenDate,
        //    //            Id = s.Id,
        //    //            Name = s.Name,
        //    //            ShortName = s.ShortName,
        //    //            StartDate = s.StartDate,
        //    //            State = s.State,
        //    //            WarrantyDate = s.PromissoryNoteManagement.Where(k => k.TicketTypeId == 3 || k.TicketTypeId == 4).OrderByDescending(w => w.RecoveryDate).FirstOrDefault()?.RecoveryDate
        //    //        });

        //    //    foreach (var row in result)
        //    //    {
        //    //        Add(row);
        //    //    }

        //    //}
        //}
        //public ProjectListViewModelCollection QueryByText(string text)
        //{
        //    //return Query<ProjectListViewModelCollection, ProjectListEntity>("Projects", "SearchByText", text);
        //    //var projectResult = _projects_controller.SearchByText(text);
        //    //if (!projectResult.HasError)
        //    //{
        //    //    Clear();
        //    //    var result = projectResult.Result
        //    //        .Where(s => s.Code.Contains(text)
        //    //        || s.Name.Contains(text)
        //    //        || (s.ShortName != null && s.ShortName.Contains(text)))
        //    //        .OrderByDescending(s => s.Code)
        //    //        .OrderBy(s => s.State)
        //    //        .Select(s => new ProjectListViewModel()
        //    //        {
        //    //            Code = s.Code,
        //    //            CompletionDate = s.CompletionDate,
        //    //            Id = s.Id,
        //    //            Name = s.Name,
        //    //            ShortName = s.ShortName,
        //    //            StartDate = s.StartDate,
        //    //            State = s.State,
        //    //            WarrantyDate = s.WarrantyDate
        //    //        });

        //    //    //foreach (var row in result)
        //    //    //{
        //    //    //    Add(row);
        //    //    //}

        //    //}
        //}

    }

}
