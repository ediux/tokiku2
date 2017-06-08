using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;

namespace Tokiku.ViewModels
{
    public class TicketPeriodsViewModelCollection : BaseViewModelCollection<TicketPeriodsViewModel>
    {
        private TicketPeriodsManagementController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new TicketPeriodsManagementController();
        }
        public override void Query()
        {
            var result = controller.QueryAll();
            if (!result.HasError)
            {
                if (result.Result.Any())
                {
                    ClearItems();
                    foreach(var entity in result.Result)
                    {
                        var model = new TicketPeriodsViewModel();
                        model.SetModel(entity);
                        Add(model);
                    }
                }
            }
        }
    }

    public class TicketPeriodsViewModel : BaseViewModel
    {

        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(TicketPeriodsViewModel), new PropertyMetadata(1));

        #endregion

        #region Name

        /// <summary>
        /// 票期
        /// </summary>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(TicketPeriodsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region DayLimit


        public int DayLimit
        {
            get { return (int)GetValue(DayLimitProperty); }
            set { SetValue(DayLimitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayLimit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayLimitProperty =
            DependencyProperty.Register("DayLimit", typeof(int), typeof(TicketPeriodsViewModel), new PropertyMetadata(1));

        #endregion

        #region CreateTime


        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(TicketPeriodsViewModel), new PropertyMetadata(DateTime.Now));


        #endregion

        #region CreateUserId


        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(TicketPeriodsViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        public override void SetModel(dynamic entity)
        {
            Entity.TicketPeriod data = (Entity.TicketPeriod)entity;
            BindingFromModel(data, this);
            Status.IsNewInstance = false;
        }
    }
}
