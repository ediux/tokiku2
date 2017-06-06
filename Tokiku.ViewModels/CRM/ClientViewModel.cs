using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;

namespace Tokiku.ViewModels
{
    public class ClientViewModelCollection : BaseViewModelCollection<ClientViewModel>
    {
        private ClientController client_controller;

        public ClientViewModelCollection()
        {
        }

        public ClientViewModelCollection(IEnumerable<ClientViewModel> source) : base(source)
        {

        }

        public override void Initialized()
        {
            base.Initialized();
            client_controller = new ClientController();
        }
        public override void Query()
        {
            var executed_result = client_controller.QueryAll();

            if (!executed_result.HasError)
            {
                if (executed_result.Result.Any())
                {
                    Clear();
                    foreach (var item in executed_result.Result)
                    {
                        ClientViewModel client = BindingFromModel(item);
                        Add(client);
                    }
                }
            }


        }

        public override void Refresh()
        {
            Query();
        }

        public override void StartUp_Query()
        {
            Query();
        }
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

        public override void StartUp_Query()
        {
            Query();
        }

        public override void Query()
        {

        }

        public override void Refresh()
        {
            Query();
        }
    }
}
