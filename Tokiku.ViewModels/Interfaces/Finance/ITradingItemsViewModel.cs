using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITradingItemsViewModel : IEntityBaseViewModel<TradingItems>
    {
        DateTime CreateTime { get; set; }
        IUserViewModel CreateUser { get; set; }
        Guid CreateUserId { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
    }
}