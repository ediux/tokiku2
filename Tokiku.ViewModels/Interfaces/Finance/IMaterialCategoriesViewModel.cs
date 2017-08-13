using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IMaterialCategoriesViewModel : IEntityBaseViewModel<MaterialCategories>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime CreateTime { get; set; }
        Guid CreateUserId { get; set; }
        IUserViewModel CreateUser { get; set; }
    }
}