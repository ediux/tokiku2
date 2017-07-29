﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class ClientViewModelCollection : BaseViewModelCollection<ClientViewModel, Manufacturers>
    {
        //private ClientController client_controller;

        public ClientViewModelCollection()
        {
        }

        public ClientViewModelCollection(IEnumerable<ClientViewModel> source) : base(source)
        {
        }

        //public static ClientViewModelCollection Query()
        //{
        //    try
        //    {
        //        return QueryByText("");            
        //    }
        //    catch (Exception ex)
        //    {
        //        ClientViewModelCollection coll = new ClientViewModelCollection();

        //        setErrortoModel(coll, ex);
        //    }

        //}
        public static ClientViewModelCollection QueryAll()
        {
            try
            {
                return BaseViewModel.Query<ClientViewModelCollection, ClientViewModel, Manufacturers>("Client", "QueryAll");
            }
            catch (Exception ex)
            {
                ClientViewModelCollection coll = new ClientViewModelCollection();
                coll.setErrortoModel(ex);
                return coll;
            }

        }
        public static ClientViewModelCollection QueryByText(string originalSource)
        {
            try
            {
                return Query<ClientViewModelCollection>("Client", "QueryByText", originalSource);

            }
            catch (Exception ex)
            {
                ClientViewModelCollection coll = new ClientViewModelCollection();
                coll.setErrortoModel(ex);
                return coll;
            }

        }
    }

    public class ClientViewModel : ManufacturersViewModel
    {
        private ClientController controller = new ClientController();

        public ClientViewModel() : base()
        {

        }

        public ClientViewModel(Manufacturers entity) : base(entity)
        {

        }

        public ClientViewModel(Guid ProjectId) : base()
        {

            QueryCondition_ProjectId = ProjectId;
        }



        private Guid QueryCondition_ProjectId;

        //public override void SaveModel()
        //{
        //    try
        //    {
        //        if (Status.IsNewInstance)
        //        {
        //            Id = Guid.NewGuid();
        //        }

        //        if (Status.IsNewInstance)
        //        {
        //            CreateTime = DateTime.Now;
        //        }

        //        var LoginedUser = controller.GetCurrentLoginUser().Result;

        //        if (CreateUserId == Guid.Empty)
        //        {
        //            CreateUserId = LoginedUser.UserId;
        //        }

        //        IsClient = true;

        //        Entity.Manufacturers data = new Entity.Manufacturers();

        //        CopyToModel(data, this);

        //        if (Contracts != null)
        //        {
        //            if (Contracts.Count > 0)
        //            {
        //                data.Contacts = new Collection<Entity.Contacts>();

        //                foreach (var x in Contracts)
        //                {
        //                    if (x.Status.IsNewInstance)
        //                    {
        //                        x.CreateTime = CreateTime;
        //                        x.CreateUserId = LoginedUser.UserId;
        //                    }

        //                    Entity.Contacts contact = new Entity.Contacts();
        //                    CopyToModel(contact, x);
        //                    data.Contacts.Add(contact);
        //                }
        //            }
        //        }

        //        var executeResult = controller.CreateOrUpdate(data);

        //        if (!executeResult.HasError)
        //        {
        //            Refresh();
        //        }
        //        else
        //        {
        //            Errors = executeResult.Errors;
        //            HasError = executeResult.HasError;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}

        public override void Initialized()
        {
            try
            {
#if DEBUG
                Debug.WriteLine("ClientViewModel initialized.");
#endif
                base.Initialized();

                IsClient = true;

                // ClientForProjects = new ProjectsViewModelCollection();
                //Contracts = new ContactsViewModelCollection();

                var createnewresult = controller.CreateNew();

                if (!createnewresult.HasError)
                {
                    var data = createnewresult.Result;
                    //BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                this.setErrortoModel(ex);
            }

        }

        public new static ClientViewModel Query(Guid Manuid)
        {


            try
            {
                return QuerySingle<ClientViewModel, Manufacturers>("Client", "QuerySingle", Manuid);

                //if (Id != Guid.Empty)
                //{
                //    ClientController clientclient = new ClientController();
                //    var exexuteresult = clientclient.Query();
                //    if (!exexuteresult.HasError)
                //    {
                //        var item = exexuteresult.Result.Single();

                //        BindingFromModel(item, this);
                //        Phone = item.Phone;
                //        ClientForProjects.QueryByClient(Id);
                //        Contracts.ManufacturersId = Id;
                //        Contracts.Query();
                //    }
                //}

            }
            catch (Exception ex)
            {
                ClientViewModel viewmodel = new ClientViewModel(Manuid);
                viewmodel.setErrortoModel(ex);
                return viewmodel;
            }

        }

        //public override void Refresh()
        //{
        //    Query();
        //}

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is Manufacturers)
        //        {
        //            Manufacturers data = (Manufacturers)entity;
        //            BindingFromModel(data, this);
        //            DoEvents();
        //            Status.IsNewInstance = false;
        //            Status.IsModify = false;
        //            Status.IsSaved = false;
        //        }

        //        if (entity is ManufacturersEnter)
        //        {
        //            ManufacturersEnter data = (ManufacturersEnter)entity;
        //            BindingFromModel(data, this);
        //            DoEvents();
        //            Status.IsNewInstance = false;
        //            Status.IsModify = false;
        //            Status.IsSaved = false;
        //        }

        //        //await Dispatcher.InvokeAsync(new Action(QueryDetails), System.Windows.Threading.DispatcherPriority.Background);
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}
    }
}
