using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;
using System.Linq;
using Tokiku.DataServices;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 聯絡人清單控制項檢視模型
    /// </summary>
    public class ContactListViewModel : DocumentBaseViewModel, IContactListViewModel
    {
        private ICoreDataService _UserDataService;

        [PreferredConstructor]
        public ContactListViewModel(ICoreDataService UserDataService) : base(UserDataService)
        {
            try
            {
                _UserDataService = UserDataService;
                //_ContractsList = new ObservableCollection<IContactsViewModel>(((IContactsDataService)_UserDataService).GetAll()
                //    .Select(s => new ContactsViewModel(s)));
                QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
                ModeChangedCommand = new RelayCommand<DocumentLifeCircle>(RunModeChanged);
                SaveCommand = new RelayCommand<Manufacturers>(RunSave);
                SetDefaultCommand = new RelayCommand<RoutedEventArgs>(RunSetDefaultCommand);
                _Mode = DocumentLifeCircle.Read;
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }
        public override void CreateNew()
        {
            ContractsList = new ObservableCollection<IContactsViewModel>();
        }

        protected virtual void RunQuery(Manufacturers Parameter)
        {
            if (Parameter != null)
            {
                ContractsList = new ObservableCollection<IContactsViewModel>(
                    Parameter.Contacts.Select(s => new ContactsViewModel(s)));
            }
            else
            {
                ContractsList = new ObservableCollection<IContactsViewModel>();
            }
        }
        protected override void RunModeChanged(DocumentLifeCircle Mode)
        {
            base.RunModeChanged(Mode);

            if (_ContractsList == null)
                QueryCommand.Execute(null);
        }

        protected virtual void RunSave(Manufacturers Parameter)
        {
            try
            {
                if (Parameter.Contacts.Count > 0)
                {
                    if (Parameter.Contacts == null)
                    {
                        Parameter.Contacts = new Collection<Contacts>();
                    }

                    foreach (var x in ContractsList)
                    {
                        Contacts contact = x.Entity;

                        if (Parameter.Contacts.Any(a => a.Id == x.Id))
                        {
                            var data = Parameter.Contacts.Single(s => s.Id == x.Id);

                            var props = data.GetType().GetProperties();

                            foreach (var auto_p in props)
                            {
                                var ori_val = auto_p.GetValue(data);
                                var current_val = auto_p.GetValue(contact);

                                if (ori_val != null && !ori_val.Equals(current_val))
                                {
                                    auto_p.SetValue(data, current_val);
                                }
                                else
                                {
                                    if (ori_val == null && current_val != null)
                                        auto_p.SetValue(data, current_val);

                                    if (ori_val != null && current_val == null)
                                        auto_p.SetValue(data, null);
                                }
                            }
                            //if (data.Comment != x.Comment)
                            //    data.Comment = x.Comment;

                            //if (data.Dep != x.Dep)
                            //    data.Dep = x.Dep;

                            //if (data.EMail != x.EMail)
                            //    data.EMail = x.EMail;

                            //if (data.ExtensionNumber != x.ExtensionNumber)
                            //    data.ExtensionNumber = x.ExtensionNumber;

                            //if (data.Fax != x.Fax)
                            //    data.Fax = x.Fax;

                            //if (data.IsDefault != x.IsDefault)
                            //    data.IsDefault = x.IsDefault;

                            //if (data.IsPrincipal != x.IsPrincipal)
                            //    data.IsPrincipal = x.IsPrincipal;

                            //if (data.Mobile != x.Mobile)
                            //    data.Mobile = x.Mobile;
                        }
                        else
                            Parameter.Contacts.Add(contact);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }


        private ObservableCollection<IContactsViewModel> _ContractsList;

        /// <summary>
        /// 取得或設定指定廠商或客戶的聯絡人清單
        /// </summary>
        public ObservableCollection<IContactsViewModel> ContractsList
        {
            get => _ContractsList; set
            {
                try
                {
                    _ContractsList = value;
                    RaisePropertyChanged("ContractsList");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }

            }
        }

        private ICommand _SetDefaultCommand;

        public ICommand SetDefaultCommand
        {
            get => _SetDefaultCommand; set
            {
                try
                {
                    _SetDefaultCommand = value;
                    RaisePropertyChanged("SetDefaultCommand");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }

        protected void RunSetDefaultCommand(RoutedEventArgs EventArgs)
        {
            //    DataGridCell cell = (DataGridCell)sender;
            CheckBox cb = (CheckBox)EventArgs.Source;
            //ContactsViewModel currentrow = (ContactsViewModel)cell.DataContext;

            //    if (ContractList.DataContext is ContactsViewModelCollection)
            //    {
            //        var founddefuts = ((ContactsViewModelCollection)ContractList.DataContext)
            //            .Where(w => w.IsDefault == true && w.Id != currentrow.Id);

            //        if (founddefuts.Any())
            //        {
            //            if (founddefuts.Count() > 0)
            //            {
            //                foreach (var fix in founddefuts)
            //                {
            //                    fix.IsDefault = false;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (ContractList.DataContext is ManufacturersViewModel)
            //        {
            //            //      var founddefuts = ((ManufacturersViewModel)ContractList.DataContext).Contracts
            //            //.Where(w => w.IsDefault == true);

            //            //      if (founddefuts.Any())
            //            //      {
            //            //          if (founddefuts.Count() > 0)
            //            //          {
            //            //              foreach (var fix in founddefuts)
            //            //              {
            //            //                  fix.IsDefault = false;
            //            //              }
            //            //          }
            //            //      }
            //        }
            //        else
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }

            //    if (currentrow.IsDefault == false)
            //    {
            //        currentrow.IsDefault = true;
            //        RaiseEvent(new RoutedEventArgs(DefaultContactChangedEvent, currentrow));
            //    }
        }

    }
}