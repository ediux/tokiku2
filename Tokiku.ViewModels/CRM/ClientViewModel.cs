using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            try
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
                            if (item.Contacts.Any())
                            {
                                client.Contracts = new ContactsViewModelCollection();

                                foreach (var row in item.Contacts)
                                {
                                    ContactsViewModel contract = new ContactsViewModel();
                                    BindingFromModel(row, contract);
                                    client.Contracts.Add(contract);
                                }
                            }
                            client.ClientForProjects.QueryByClient(item.Id);
                            Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public void QueryByText(string originalSource)
        {
            try
            {
                var executeresult = client_controller.SearchByText(originalSource);
                if (!executeresult.HasError)
                {
                    var objectdataset = executeresult.Result;
                    ClearItems();
                    foreach (var row in objectdataset)
                    {
                        ClientViewModel model = new ClientViewModel();
                        model.SetModel(row);
                        Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }
    }

    public class ClientViewModel : ManufacturersViewModel
    {
        private ClientController controller = new ClientController();

        public ClientViewModel() : base()
        {

        }

        public ClientViewModel(Guid ProjectId) : base()
        {
            QueryCondition_ProjectId = ProjectId;
        }

        #region ClientForProjects
        /// <summary>
        /// 專案清單
        /// </summary>
        public virtual ProjectsViewModelCollection ClientForProjects
        {
            get
            {
                return (ProjectsViewModelCollection)GetValue(ClientForProjectsProperty);
            }
            set
            {
                SetValue(ClientForProjectsProperty, value);
                RaisePropertyChanged("Projects");
            }
        }

        public static readonly DependencyProperty ClientForProjectsProperty = DependencyProperty.Register("ClientForProjects",
  typeof(ProjectsViewModelCollection), typeof(ClientViewModel),
  new PropertyMetadata(default(ProjectsViewModelCollection),
      new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        private Guid QueryCondition_ProjectId;

        public override void SaveModel()
        {
            try
            {
                if (Status.IsNewInstance)
                {
                    Id = Guid.NewGuid();
                }

                if (Status.IsNewInstance)
                {
                    CreateTime = DateTime.Now;
                }

                var LoginedUser = controller.GetCurrentLoginUser().Result;

                if (CreateUserId == Guid.Empty)
                {
                    CreateUserId = LoginedUser.UserId;
                }

                IsClient = true;

                Entity.Manufacturers data = new Entity.Manufacturers();

                CopyToModel(data, this);

                if (Contracts != null)
                {
                    if (Contracts.Count > 0)
                    {
                        data.Contacts = new Collection<Entity.Contacts>();

                        Parallel.ForEach(Contracts, (x) =>
                        {
                            x.Initialized();

                            lock (this)
                            {
                                x.CreateTime = CreateTime;
                            }


                            if (x.CreateUserId == Guid.Empty)
                            {
                                lock (LoginedUser)
                                {
                                    x.CreateUserId = LoginedUser.UserId;
                                }

                            }

                            Entity.Contacts contact = null;

                            CopyToModel(contact, x);

                            lock (data)
                            {
                                data.Contacts.Add(contact);
                            }
                        });
                    }
                }

                var executeResult = controller.CreateOrUpdate(data);

                if (!executeResult.HasError)
                {
                    Refresh();
                }
                else
                {
                    Errors = executeResult.Errors;
                    HasError = executeResult.HasError;
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public override void Initialized()
        {
            try
            {
#if DEBUG
                Debug.WriteLine("ClientViewModel initialized.");
#endif
                base.Initialized();

                IsClient = true;

                ClientForProjects = new ProjectsViewModelCollection();
                Contracts = new ContactsViewModelCollection();

                var createnewresult = controller.CreateNew();

                if (!createnewresult.HasError)
                {
                    var data = createnewresult.Result;
                    BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public override void Query()
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    ClientController clientclient = new ClientController();
                    var exexuteresult = clientclient.Query(q => q.Id == Id);
                    if (!exexuteresult.HasError)
                    {
                        var item = exexuteresult.Result.Single();

                        BindingFromModel(item, this);
                        ClientForProjects.QueryByClient(Id);
                        Contracts.ManufacturersId = Id;
                        Contracts.Query();
                    }
                }

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public override void Refresh()
        {
            Query();
        }
    }
}
