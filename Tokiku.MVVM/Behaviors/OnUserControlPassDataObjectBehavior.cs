using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using Tokiku.ViewModels;

namespace Tokiku.MVVM.Behaviors
{
    public class OnUserControlPassDataObjectBehavior : Behavior<UserControl>
    {

        #region DataChannelName 的附加屬性
        public static string GetDataChannelName(DependencyObject obj)
        {
            return (string)obj.GetValue(DataChannelNameProperty);
        }

        public static void SetDataChannelName(DependencyObject obj, string value)
        {
            obj.SetValue(DataChannelNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for DataChannelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataChannelNameProperty =
            DependencyProperty.RegisterAttached("DataChannelName", typeof(string), typeof(OnUserControlPassDataObjectBehavior), new PropertyMetadata(string.Empty));
        #endregion

        #region DataObjectType 的附加屬性


        public static Type GetDataObjectType(DependencyObject obj)
        {
            return (Type)obj.GetValue(DataObjectTypeProperty);
        }

        public static void SetDataObjectType(DependencyObject obj, Type value)
        {
            obj.SetValue(DataObjectTypeProperty, value);
        }

        // Using a DependencyProperty as the backing store for DataObjectType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataObjectTypeProperty =
            DependencyProperty.RegisterAttached("DataObjectType", typeof(Type), typeof(OnUserControlPassDataObjectBehavior), new PropertyMetadata(null));


        #endregion

        protected override void OnAttached()
        {
            Messenger.Default.Register<NotificationMessage<IBaseViewModel>>(AssociatedObject, RecviceFromOthers);

        }

        //private void AssociatedObject_Initialized(object sender, EventArgs e)
        //{
        //    //Messenger.Default.Register<object>(AssociatedObject, GetDataChannelName(AssociatedObject), RecviceFromOthers);

        //}

        private void RecviceFromOthers(NotificationMessage<IBaseViewModel> model)
        {
            if (model.Target.Equals(AssociatedObject))
            {
                try
                {
                    AssociatedObject.DataContext = Activator.CreateInstance(GetDataObjectType(AssociatedObject));
                    var v = AssociatedObject.DataContext;
                    var t = v.GetType();

                    var command_p = t.GetProperty("QueryCommand");
                    var m_i = command_p.PropertyType?.GetMethod("Execute");
                    m_i?.Invoke(command_p.GetValue(v), new object[] { model.Content });





                }
                catch
                {

                    throw;
                }
                //if (AssociatedObject.DataContext is IDocumentBaseViewModel)
                //{
                //    IDocumentBaseViewModel baseobj = (IDocumentBaseViewModel)AssociatedObject.DataContext;
                //    baseobj.QueryCommand.Execute(model.Content);
                //}

            }

            AssociatedObject.UpdateLayout();
            //Type _DataObjectType = GetDataObjectType(AssociatedObject);

            //if (model?.GetType() == _DataObjectType)
            //{
            //    Messenger.Default.Send(model);
            //    AssociatedObject.DataContext = model;
            //}
            //else
            //{
            //    var currentModel = SimpleIoc.Default.GetInstanceWithoutCaching(_DataObjectType);

            //    Type SourceType = model.GetType();

            //    var entity_p = SourceType?.GetProperty("Entity");

            //    if (entity_p != null)
            //    {
            //        var modelvalue = entity_p.GetValue(model);

            //        if (currentModel is IDocumentBaseViewModel)
            //        {
            //            //使用命令
            //            IDocumentBaseViewModel basetypeobj = (IDocumentBaseViewModel)currentModel;
            //            basetypeobj.QueryCommand?.Execute(modelvalue);
            //        }
            //        else
            //        {
            //            var querycommand_prop = _DataObjectType.GetProperty("QueryCommand", typeof(ICommand));

            //            if (querycommand_prop != null)
            //            {
            //                ICommand instance_querycommand = (ICommand)querycommand_prop.GetValue(currentModel);
            //                instance_querycommand?.Execute(modelvalue);
            //            }
            //            else
            //            {
            //                var methid_set = currentModel.GetType().GetMethod("SetEntity");

            //                if (methid_set != null)
            //                {
            //                    methid_set.Invoke(currentModel, new object[] { modelvalue });
            //                }
            //            }

            //        }

            //    }

            //    AssociatedObject.DataContext = currentModel;
            //    AssociatedObject.UpdateLayout();

            //}
        }

        protected override void OnDetaching()
        {
            Messenger.Default.Unregister<NotificationMessage<IBaseViewModel>>(AssociatedObject, RecviceFromOthers);
            //AssociatedObject.Initialized -= AssociatedObject_Initialized;
        }
    }
}
