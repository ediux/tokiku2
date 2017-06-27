using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class StatesViewModelCollection : BaseViewModelCollection<StatesViewModel>
    {
        private Controllers.StateController controller;

        public StatesViewModelCollection()
        {

        }

        public StatesViewModelCollection(IEnumerable<StatesViewModel> source) : base(source)
        {

        }

        public override void Initialized()
        {
            base.Initialized();
            controller = new Controllers.StateController();
            Query();
        }

        public async override void Query()
        {
            var result = await controller.GetStateListAsync();

            if (!result.HasError)
            {
                if (result.Result.Any())
                {
                    ClearItems();
                    foreach (var item in result.Result)
                    {
                        StatesViewModel model = new StatesViewModel();
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
    public class StatesViewModel : BaseViewModel
    {


        public byte Id
        {
            get { return (byte)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(byte), typeof(StatesViewModel), new PropertyMetadata((byte)0));



        public string StateName
        {
            get { return (string)GetValue(StateNameProperty); }
            set { SetValue(StateNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StateName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateNameProperty =
            DependencyProperty.Register("StateName", typeof(string), typeof(StatesViewModel), new PropertyMetadata(string.Empty));

        public override void SetModel(dynamic entity)
        {
            try
            {
                States data = (States)entity;
                BindingFromModel(data, this);
            }
            catch (Exception ex)
            {

                setErrortoModel(this, ex);
            }
        }

        public override string ToString()
        {
            return this.StateName;
        }
    }
}
