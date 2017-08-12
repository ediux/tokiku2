using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TradingItemsViewModel : EntityBaseViewModel<TradingItems>, ITradingItemsViewModel
    {
        [PreferredConstructor]
        public TradingItemsViewModel(TradingItems entity) : base(entity)
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid CreateUserId { get; set; }
        public IUserViewModel CreateUser { get; set; }
    }
}