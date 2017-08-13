using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TradingItemsViewModel : EntityBaseViewModel<TradingItems>, ITradingItemsViewModel
    {
        private ICoreDataService CoreDataService;
        private IUserDataService UserDataService;

        [PreferredConstructor]
        public TradingItemsViewModel(TradingItems entity) : base(entity)
        {
            CoreDataService = DefaultLocator.Current.CoreDataService;
            UserDataService = CoreDataService;
        }

        public Guid Id { get => CopyofPOCOInstance.Id; set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); } }
        public string Name { get => CopyofPOCOInstance.Name; set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }
        public DateTime CreateTime { get => CopyofPOCOInstance.CreateTime; set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); } }
        public Guid CreateUserId { get => CopyofPOCOInstance.CreateUserId; set { CopyofPOCOInstance.CreateUserId = value; RaisePropertyChanged("CreateUserId"); } }
        public IUserViewModel CreateUser { get {
                var user = UserDataService.GetSingle(s => s.UserId == CopyofPOCOInstance.CreateUserId);
                return new UserViewModel((Users)user);
            } set {
                CopyofPOCOInstance.CreateUserId = value.Entity.UserId;
                RaisePropertyChanged("CreateUser");
            } }
    }
}