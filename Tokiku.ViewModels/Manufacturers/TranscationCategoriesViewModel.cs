using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TranscationCategoriesViewModelCollection : BaseViewModelCollection<TranscationCategoriesViewModel>
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
                        TranscationCategoriesViewModel model = new TranscationCategoriesViewModel();
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

    public class TranscationCategoriesViewModel : BaseViewModel
    {
        #region Id


        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(TranscationCategoriesViewModel), new PropertyMetadata(0));


        #endregion

        #region Name


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(TranscationCategoriesViewModel), new PropertyMetadata(string.Empty));


        #endregion

        public override void SetModel(dynamic entity)
        {
            try
            {
                TranscationCategories data = (TranscationCategories)entity;
                BindingFromModel(data, this);
            }
            catch (Exception ex)
            {

                setErrortoModel(this, ex);
            }
        }
    }
}
