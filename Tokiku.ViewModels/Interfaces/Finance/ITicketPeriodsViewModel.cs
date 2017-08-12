using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITicketPeriodsViewModel : IEntityBaseViewModel<TicketPeriod>
    {
        int DayLimit { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}