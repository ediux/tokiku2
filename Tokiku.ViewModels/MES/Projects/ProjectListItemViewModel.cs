using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProjectListItemViewModel : EntityBaseViewModel<Projects>, IProjectListItemViewModel
    {
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
        public string ShortName { get { return CopyofPOCOInstance.ShortName; } set { CopyofPOCOInstance.ShortName = value; RaisePropertyChanged("ShortName"); } }

        /// <summary>
        /// 狀態
        /// </summary>
        public byte State { get { return CopyofPOCOInstance.State; } set { CopyofPOCOInstance.State = value; RaisePropertyChanged("State"); } }

        /// <summary>
        /// 起造日期
        /// </summary>
        public DateTime StartDate
        {
            get { return CopyofPOCOInstance.StartDate; }
            set { CopyofPOCOInstance.StartDate = value; RaisePropertyChanged("StartDate"); }
        }



        /// <summary>
        /// 完工日期
        /// </summary>
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
            get { return null; }
            set
            {

                RaisePropertyChanged("WarrantyDate");
            }
        }

        public Guid Id
        {
            get => CopyofPOCOInstance.Id; set
            {
                try
                {
                    CopyofPOCOInstance.Id = value;
                    RaisePropertyChanged("Id");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }
    }
}
