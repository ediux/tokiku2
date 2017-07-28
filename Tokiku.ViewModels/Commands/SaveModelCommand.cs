using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.ViewModels;

namespace Tokiku.ViewModels
{
    public class SaveModelCommand : DelegateCommand
    {
      
        public SaveModelCommand():base(SaveOrUpdate)
        {

        }

        public SaveModelCommand(Action<object> execute):base(execute)
        {

        }

        private static void SaveOrUpdate(object parameter)
        {
            try
            {
                
                if(parameter!=null && parameter is ObjectDataProvider)
                {
                    ObjectDataProvider provider = (ObjectDataProvider)parameter;

                    if (provider != null)
                    {
                        IBaseViewModel viewmodel = (IBaseViewModel)provider.Data;
                        viewmodel.SaveCommand.Execute(parameter);
                        viewmodel.SaveModel();                        
                    }        
                }

                //if (parameter != null && (parameter is IBaseViewModel || parameter is ISingleBaseViewModel))
                //{
                //    Type refectionType = parameter.GetType();

                //    IBaseViewModel model = (IBaseViewModel)parameter;

                //    if (refectionType != null)
                //    {
                //        var method = refectionType.GetMethod("OnBeforeSave", new Type[] { typeof(object) });

                //        if (method != null)
                //        {
                //            method.Invoke(parameter, new object[] { parameter });
                //        }

                //        model.SaveModel();

                //        if (model.HasError)
                //        {
                //            MessageBox.Show(string.Join("\n", model.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                //            model.Errors = null;
                //            return;
                //        }

                //        if (parameter is ISingleBaseViewModel)
                //        {
                //            ISingleBaseViewModel singleview = (ISingleBaseViewModel)model;
                //            singleview.Status.IsModify = false;
                //            singleview.Status.IsSaved = true;
                //            singleview.Status.IsNewInstance = false;
                //        }

                //    }

                //}
                //ProjectsViewModel SelectedProject = (ProjectsViewModel)((ObjectDataProvider)).Data;
                ////SelectedProject.Errors = new string[] { };
                //Mode = (DocumentLifeCircle)e.OriginalSource;
                //switch (Mode)
                //{

                //    case DocumentLifeCircle.Create:

                //        if (SelectedProject.Status.IsNewInstance == false)
                //        {
                //            RoutedUICommand command = (RoutedUICommand)TryFindResource("OpenNewTabItem");
                //            RoutedViewResult viewparam = (RoutedViewResult)TryFindResource("OpenNewProjectView");
                //            if (command != null)
                //            {
                //                command.Execute(viewparam, this);
                //            }
                //            //RaiseEvent(new RoutedEventArgs(NewDocumentPageEvent, this));
                //            break;
                //        }

                //        SelectedProject = new ProjectsViewModel();

                //        SelectedProject.Initialized();
                //        SelectedProject.CreateUserId = LoginedUser.UserId;

                //        SelectedProject.Status.IsModify = false;
                //        SelectedProject.Status.IsSaved = false;
                //        SelectedProject.Status.IsNewInstance = true;

                //        break;
                //    case DocumentLifeCircle.Save:

                //        //if (SelectedBIGuid != null && SelectedBIGuid != Guid.Empty)
                //        //{
                //        //    var recvdata = SelectedProject.Suppliers.Where(w => w.Id == SelectedBIGuid).Single();
                //        //    //recvdata.SiteContactPerson = TBSiteContactPerson.Text;
                //        //    //recvdata.SiteContactPersonPhone = TBSiteContactPersonPhone.Text;
                //        //}

                //        if (SelectedProject.CreateUserId == Guid.Empty)
                //            SelectedProject.CreateUserId = LoginedUser.UserId;

                //        if (SelectedClient != null)
                //            SelectedProject.ClientId = SelectedClient.Id;

                //        SelectedProject.SaveModel("ProjectManagerView");

                //        if (SelectedProject.HasError)
                //        {
                //            MessageBox.Show(string.Join("\n", SelectedProject.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                //            SelectedProject.Errors = null;
                //            //Mode = dockBar.LastState;
                //            break;
                //        }

                //        if (SelectedProject.Status.IsNewInstance)
                //        {
                //            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));
                //        }

                //        Mode = DocumentLifeCircle.Read;

                //        ((ObjectDataProvider)TryFindResource("ProjectSource")).Refresh();

                //        SelectedProject.Status.IsModify = false;
                //        SelectedProject.Status.IsSaved = true;
                //        SelectedProject.Status.IsNewInstance = false;


                //        break;
                //    case DocumentLifeCircle.Update:
                //        SelectedProject.Status.IsModify = false;
                //        SelectedProject.Status.IsSaved = false;
                //        SelectedProject.Status.IsNewInstance = false;
                //        break;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
