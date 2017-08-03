using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IUserViewModel : IEntityBaseViewModel<Users>
    {
        bool IsAnonymous { get; set; }
        DateTime LastActivityDate { get; set; }
        string LoweredUserName { get; set; }
        string MobileAlias { get; set; }
        string Password { get; }
        Guid UserId { get; set; }
        string UserName { get; set; }
    }
}