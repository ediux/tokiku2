﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class CompositionTypesViewModelCollection : ObservableCollection<CompositionTypesViewModel>, IBaseViewModel
    {
        public CompositionTypesViewModelCollection()
        {

        }
        public CompositionTypesViewModelCollection(IEnumerable<CompositionTypesViewModel> source) : base(source)
        {

        }

        public IEnumerable<string> Errors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool HasError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class CompositionTypesViewModel : BaseViewModel
    {


        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(CompositionTypesViewModel ), new PropertyMetadata(0));




        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(CompositionTypesViewModel), new PropertyMetadata(string.Empty));

    }
}