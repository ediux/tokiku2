using System;

namespace Tokiku.Entity
{
    public interface IMembership
    {
        string Comment { get; set; }
        DateTime CreateDate { get; set; }
        string Email { get; set; }
        int FailedPasswordAnswerAttemptCount { get; set; }
        DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }
        int FailedPasswordAttemptCount { get; set; }
        DateTime FailedPasswordAttemptWindowStart { get; set; }
        bool IsApproved { get; set; }
        bool IsLockedOut { get; set; }
        DateTime LastLockoutDate { get; set; }
        DateTime LastLoginDate { get; set; }
        DateTime LastPasswordChangedDate { get; set; }
        string LoweredEmail { get; set; }
        string MobilePIN { get; set; }
        string Password { get; set; }
        string PasswordAnswer { get; set; }
        int PasswordFormat { get; set; }
        string PasswordQuestion { get; set; }
        string PasswordSalt { get; set; }
        Guid UserId { get; set; }    
    }
}