using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProjectListViewModelCollection : BaseViewModelCollection<ProjectListViewModel>
    {
        //private ProjectsController _projects_controller;

        public ProjectListViewModelCollection() : base()
        {

        }

        public ProjectListViewModelCollection(IEnumerable<ProjectListViewModel> source) : base(source)
        {

        }

        public override void Initialized()
        {
            base.Initialized();
            //_projects_controller = new ProjectsController();
        }

        public void Refresh()
        {

        }

        public ProjectListViewModelCollection Query()
        {
            return Query<ProjectListViewModelCollection, ProjectListEntity>("Projects", "QueryAll");
            //var projectResult = _projects_controller.Query(v => v.Void == false);
            //if (!projectResult.HasError)
            //{
            //    Clear();
            //    var result = projectResult.Result
            //        .OrderByDescending(s => s.Code)
            //        .OrderBy(s => s.State)
            //        .Select(s => new ProjectListViewModel()
            //        {
            //            Code = s.Code,
            //            CompletionDate = s.PromissoryNoteManagement.Where(k => k.TicketTypeId == 3 || k.TicketTypeId == 4).OrderByDescending(w => w.OpenDate).FirstOrDefault()?.OpenDate,
            //            Id = s.Id,
            //            Name = s.Name,
            //            ShortName = s.ShortName,
            //            StartDate = s.StartDate,
            //            State = s.State,
            //            WarrantyDate = s.PromissoryNoteManagement.Where(k => k.TicketTypeId == 3 || k.TicketTypeId == 4).OrderByDescending(w => w.RecoveryDate).FirstOrDefault()?.RecoveryDate
            //        });

            //    foreach (var row in result)
            //    {
            //        Add(row);
            //    }

            //}
        }
        public ProjectListViewModelCollection QueryByText(string text)
        {
            return Query<ProjectListViewModelCollection, ProjectListEntity>("Projects", "SearchByText", text);
            //var projectResult = _projects_controller.SearchByText(text);
            //if (!projectResult.HasError)
            //{
            //    Clear();
            //    var result = projectResult.Result
            //        .Where(s => s.Code.Contains(text)
            //        || s.Name.Contains(text)
            //        || (s.ShortName != null && s.ShortName.Contains(text)))
            //        .OrderByDescending(s => s.Code)
            //        .OrderBy(s => s.State)
            //        .Select(s => new ProjectListViewModel()
            //        {
            //            Code = s.Code,
            //            CompletionDate = s.CompletionDate,
            //            Id = s.Id,
            //            Name = s.Name,
            //            ShortName = s.ShortName,
            //            StartDate = s.StartDate,
            //            State = s.State,
            //            WarrantyDate = s.WarrantyDate
            //        });

            //    //foreach (var row in result)
            //    //{
            //    //    Add(row);
            //    //}

            //}
        }

    }
    public class ProjectListViewModel : BaseViewModelWithPOCOClass<ProjectListEntity>
    {
        public ProjectListViewModel()
        {

        }

        public ProjectListViewModel(ProjectListEntity entity):base(entity)
        {

        }
        //private ProjectsController _projects_controller;


     
        ///// <summary>
        ///// 編號
        ///// </summary>
        //public Guid Id
        //{
        //    get { return (Guid)GetValue(IdProperty); }
        //    set { SetValue(IdProperty, value); RaisePropertyChanged("Id"); }
        //}

        /// <summary>
        /// 專案代碼
        /// </summary>
        public string Code
        {
            get { return CopyofPOCOInstance.Code; }
            set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); }
        }

        /// <summary>
        /// 專案名稱
        /// </summary>
        public string Name { get { return CopyofPOCOInstance.Name; } set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("ProjectName"); } }
        /// <summary>
        /// 專案名稱(簡稱)
        /// </summary>
        public string ShortName { get { return CopyofPOCOInstance.ShortName; } set { CopyofPOCOInstance.ShortName = value;  RaisePropertyChanged("ShortName"); } }

        /// <summary>
        /// 狀態
        /// </summary>
        public byte State { get { return CopyofPOCOInstance.State; } set { CopyofPOCOInstance.State = value; RaisePropertyChanged("State"); } }

        public DateTime? StartDate
        {
            get { return CopyofPOCOInstance.StartDate; }
            set { CopyofPOCOInstance.StartDate = value; RaisePropertyChanged("StartDate"); }
        }

     


        public DateTime? CompletionDate
        {
            get { return CopyofPOCOInstance.CompletionDate; }
            set { CopyofPOCOInstance.CompletionDate = value; RaisePropertyChanged("CompletionDate"); }
        }

        /// <summary>
        /// 保固日期
        /// </summary>
        public DateTime? WarrantyDate
        {
            get { return CopyofPOCOInstance.WarrantyDate; }
            set { CopyofPOCOInstance.WarrantyDate = value;
                RaisePropertyChanged("WarrantyDate");
            }
        }

     
        //public System.DateTime StartDate { get; set; }
        //public System.DateTime CompletionDate { get; set; }
        public override void Initialized()
        {
            base.Initialized();
            
        }

        //public override void Query()
        //{
        //    if (Id == Guid.Empty)
        //        return;

        //    var result = _projects_controller.QuerySingle(Id);

        //    if (!result.HasError)
        //    {
        //        BindingFromModel(result.Result, this);
               

        //        if (CompletionDate.HasValue == false)
        //        {
        //            CompletionDate = DateTime.Today;
        //        }
        //    }
        //    else
        //    {
        //        Errors = result.Errors;
        //        HasError = result.HasError;
        //    }
        //}
    }
}
