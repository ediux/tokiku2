using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITicketTypesViewModel : IEntityBaseViewModel<TicketTypes>
    {
        byte Id { get; set; }
        string Name { get; set; }
    }
}