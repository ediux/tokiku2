﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ClientViewModelCollection : ObservableCollection<ClientViewModel>, IBaseViewModel
    {
        public ClientViewModelCollection()
        {
            HasError = false;
        }

        public ClientViewModelCollection(IEnumerable<ClientViewModel> source) : base(source)
        {

        }

        public IEnumerable<string> Errors { get; set; }
        public bool HasError { get; set; }

    }
    public class ClientViewModel : ManufacturersViewModel
    {

        public ClientViewModel() : base()
        {

        }

        public ClientViewModel(Guid ProjectId) : base()
        {
            QueryCondition_ProjectId = ProjectId;
        }

        private Guid QueryCondition_ProjectId;

        public ProjectContractViewModelCollection ProjectContract
        {
            get { return (ProjectContractViewModelCollection)GetValue(ProjectContractProperty); }
            set { SetValue(ProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractProperty =
            DependencyProperty.Register("ProjectContract", typeof(ProjectContractViewModelCollection), typeof(ClientViewModel), new PropertyMetadata(default(ProjectContractViewModelCollection)));

        public override void Initialized()
        {
            IsClient = true;
            base.Initialized();
        }

       

        public override void Query()
        {
            base.Query();
        }
    }
}
