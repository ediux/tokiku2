using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TicketTypesViewModelCollection : BaseViewModelCollection<TicketTypesViewModel>
    {
        private Controllers.ManufacturersManageController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new Controllers.ManufacturersManageController();
            Query();
        }

        public async override void Query()
        {
            var result = await controller.GetTranscationCategoriesListAsync();

            if (!result.HasError)
            {
                if (result.Result.Any())
                {
                    ClearItems();
                    foreach (var item in result.Result)
                    {
                        TicketTypesViewModel model = new TicketTypesViewModel();
                        model.SetModel(item);
                        Add(model);
                    }
                }
            }
            else
            {
                Errors = result.Errors;
                HasError = result.HasError;
            }
        }
    }

    public class TicketTypesViewModel : BaseViewModel
    {
        #region Id


        public byte Id
        {
            get { return (byte)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(byte), typeof(TicketTypesViewModel), new PropertyMetadata((byte)0));


        #endregion

        #region Name


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(TicketTypesViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region CreateTime


        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(TicketTypesViewModel), new PropertyMetadata(DateTime.Now));


        #endregion

        #region CreateUserId


        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(TicketTypesViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        public override void SetModel(dynamic entity)
        {
            try
            {
                TicketTypes data = (TicketTypes)entity;
                BindingFromModel(data, this);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
