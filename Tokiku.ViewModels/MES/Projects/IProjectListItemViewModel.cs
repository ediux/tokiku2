using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IProjectListItemViewModel : IEntityBaseViewModel<Projects>
    {
        /// <summary>
        /// 專案系統識別碼
        /// </summary>
        Guid Id { get; set; }
        string Code { get; set; }
        DateTime? CompletionDate { get; set; }
        string Name { get; set; }
        string ShortName { get; set; }
        DateTime StartDate { get; set; }
        byte State { get; set; }
        DateTime? WarrantyDate { get; set; }
    }
}