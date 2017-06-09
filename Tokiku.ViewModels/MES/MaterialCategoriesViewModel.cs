﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesViewModelCollection : BaseViewModelCollection<MaterialCategoriesViewModel>
    {
        private ManufacturersManageController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new ManufacturersManageController();
            Query();
        }

        public async override void Query()
        {
            var result = await controller.GetMaterialCategoriesListAsync();
            if (!result.HasError)
            {
                if (result.Result.Any())
                {
                    ClearItems();
                    foreach(var item in result.Result)
                    {
                        MaterialCategoriesViewModel model = new MaterialCategoriesViewModel();
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

    public class MaterialCategoriesViewModel : BaseViewModel
    {
        #region Id


        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(MaterialCategoriesViewModel), new PropertyMetadata(Guid.NewGuid()));


        #endregion

        #region Name


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(MaterialCategoriesViewModel), new PropertyMetadata(string.Empty));


        #endregion

        

        public override void SetModel(dynamic entity)
        {
            var data = (MaterialCategories)entity;
            if (data != null)
            {
                BindingFromModel(data, this);
            }
        }
    }
}
