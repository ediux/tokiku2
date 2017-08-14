using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IClientListItemViewModel : IEntityBaseViewModel<Manufacturers>
    {
        string Address { get; set; }
        string Code { get; set; }
        string eMail { get; set; }
        string Fax { get; set; }
        Guid Id { get; set; }
        string MainContactPerson { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Principal { get; set; }
        string ShortName { get; set; }
        string UniformNumbers { get; set; }
    }
}