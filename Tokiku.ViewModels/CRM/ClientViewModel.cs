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
                        if (item.Contacts.Any())
                        {
                            client.Contracts = new ContactsViewModelCollection();
                            
                            foreach(var row in item.Contacts)
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

        public void QueryByText(string originalSource)
        {
            var executeresult = client_controller.SearchByText(originalSource);
            if (!executeresult.HasError)
            {
                var objectdataset = executeresult.Result;
                ClearItems();
                foreach (var row in objectdataset)
                {
                    Add(BindingFromModel(row));
                }
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
  new PropertyMetadata(default(ProjectsViewModelCollection), new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        #region 行動電話

        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile
        {
            get { return (string)GetValue(MobileProperty); }
            set { SetValue(MobileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mobile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MobileProperty =
            DependencyProperty.Register("Mobile", typeof(string), typeof(ClientViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region 分機


        public string Extension
        {
            get { return (string)GetValue(ExtensionProperty); }
            set { SetValue(ExtensionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Extension.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExtensionProperty =
            DependencyProperty.Register("Extension", typeof(string), typeof(ClientViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region MainContactPerson


        public string MainContactPerson
        {
            get { return (string)GetValue(MainContactPersonProperty); }
            set { SetValue(MainContactPersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainContactPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainContactPersonProperty =
            DependencyProperty.Register("MainContactPerson", typeof(string), typeof(ClientViewModel), new PropertyMetadata(string.Empty));
        #endregion
        private Guid QueryCondition_ProjectId;

        public override void SaveModel()
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

                    Parallel.ForEach(Contracts, (x) => {
                        x.Id = Guid.NewGuid();
                        x.CreateTime = CreateTime;

                        if (x.CreateUserId == Guid.Empty)
                        {
                            lock (LoginedUser)
                            {
                                x.CreateUserId = LoginedUser.UserId;
                            }
                           
                        }

                        Entity.Contacts contact = new Entity.Contacts();
                        CopyToModel(contact, x);
                        lock (data)
                        {
                            data.Contacts.Add(contact);
                        }                      
                    });

                    //foreach (ContactsViewModel model in Contracts)
                    //{
                    //    model.Id = Guid.NewGuid();
                    //    model.CreateTime = CreateTime;
                    //    if (model.CreateUserId == Guid.Empty)
                    //    {
                    //        model.CreateUserId = LoginedUser.UserId;
                    //    }

                    //    Entity.Contacts contact = new Entity.Contacts();
                    //    CopyToModel(contact, model);
                    //    data.Contacts.Add(contact);
                    //}
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

        public override void Initialized()
        {
            IsClient = true;
            base.Initialized();
            ClientForProjects = new ProjectsViewModelCollection();
            Contracts = new ContactsViewModelCollection();

            var createnewresult = controller.CreateNew();

            if (!createnewresult.HasError)
            {
                var data = createnewresult.Result;
                BindingFromModel(data, this);
            }
        }

        public override void StartUp_Query()
        {
            Query();
        }

        public override void Query()
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

        public override void Refresh()
        {
            Query();
        }
    }
}
