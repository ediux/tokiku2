using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IMaterialCategoriesViewModel : IDocumentBaseViewModel<MaterialCategories>
    {       
        string Name { get; set; }
    }
}