using System;

namespace Tokiku.ViewModels
{
    public interface IUserViewModel : IBaseViewModel
    {
        DateTime CreateTime { get; set; }
        IUserViewModel CreateUser { get; set; }
        Guid CreateUserId { get; set; }
        bool IsAnonymous { get; set; }
        DateTime LastActivityDate { get; set; }
        string LoweredUserName { get; set; }
        string MobileAlias { get; set; }
        string Password { get; }
        Guid UserId { get; set; }
        string UserName { get; set; }
    }
}