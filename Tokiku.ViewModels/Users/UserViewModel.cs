using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class UserViewModel : DocumentBaseViewModel<Users>, IUserViewModel
    {
        public UserViewModel()
        {
            Status = new DocumentStatusViewModel();
        }

        public UserViewModel(Users entity) : base(entity)
        {

        }

        public Guid UserId
        {
            get { return CopyofPOCOInstance.UserId; }
            set { RaisePropertyChanged("UserId"); }
        }

        public string UserName
        {
            get { return CopyofPOCOInstance.UserName; }
            set { CopyofPOCOInstance.UserName = value; RaisePropertyChanged("UserName"); }
        }

        public string LoweredUserName
        {
            get { return CopyofPOCOInstance.LoweredUserName; }
            set { CopyofPOCOInstance.LoweredUserName = value; RaisePropertyChanged("LoweredUserName"); }
        }

        public string MobileAlias
        {
            get { return CopyofPOCOInstance.MobileAlias; }
            set { CopyofPOCOInstance.MobileAlias = value; RaisePropertyChanged("MobileAlias"); }
        }

        public bool IsAnonymous
        {
            get { return CopyofPOCOInstance.IsAnonymous; }
            set { CopyofPOCOInstance.IsAnonymous = value; RaisePropertyChanged("IsAnonymous"); }
        }

        public DateTime LastActivityDate
        {
            get { return CopyofPOCOInstance.LastActivityDate; }
            set { CopyofPOCOInstance.LastActivityDate = value; RaisePropertyChanged(""); }
        }

        public string Password
        {
            get { return CopyofPOCOInstance.Membership.Password; }
        }

        public override IUserViewModel CreateUser { get => null; set { } }
        public override DateTime CreateTime { get => DateTime.Now; set {  } }
        public override Guid CreateUserId { get => Guid.Empty; set { } }

        public override void CreateNew()
        {
            IsAnonymous = true;
            CopyofPOCOInstance = new Users();
            CopyofPOCOInstance.LastActivityDate = new DateTime(1754, 1, 1);
            CopyofPOCOInstance.LoweredUserName = Environment.UserName.ToLowerInvariant();
            CopyofPOCOInstance.UserName = Environment.UserName;
            CopyofPOCOInstance.UserId = Guid.NewGuid();
        }

        //public override void Initialized(object Parameter)
        //{
        //    base.Initialized(Parameter);

        //}
    }
}
