using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Tokiku.ViewModels;

namespace TokikuNew.Helpers
{
    public class OnUserControlPassDataObjectBehavior : Behavior<UserControl>
    {
        public string DataChannelName
        {
            get { return (string)GetValue(DataChannelNameProperty); }
            set { SetValue(DataChannelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChannelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataChannelNameProperty =
            DependencyProperty.Register("DataChannelName", typeof(string), typeof(OnUserControlPassDataObjectBehavior), new PropertyMetadata(string.Empty));



        public Type DataObjectType
        {
            get { return (Type)GetValue(DataObjectTypeProperty); }
            set { SetValue(DataObjectTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataObjectType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataObjectTypeProperty =
            DependencyProperty.Register("DataObjectType", typeof(Type), typeof(OnUserControlPassDataObjectBehavior), new PropertyMetadata(null));



        protected override void OnAttached()
        {
            AssociatedObject.Initialized += AssociatedObject_Initialized;
        }

        private void AssociatedObject_Initialized(object sender, EventArgs e)
        {
            Messenger.Default.Register<object>(AssociatedObject, DataChannelName, RecviceFromOthers);
        }

        private void RecviceFromOthers(object model)
        {
            if (model?.GetType() == DataObjectType)
            {
                AssociatedObject.DataContext = model;
            }
            else
            {
                var currentModel = SimpleIoc.Default.GetInstanceWithoutCaching(DataObjectType);

                var entity_p = model.GetType().GetProperty("Entity");

                if (entity_p != null)
                {
                    var modelvalue = entity_p.GetValue(model);
                    var methid_set = currentModel.GetType().GetMethod("SetEntity");

                    if (methid_set != null)
                    {
                        methid_set.Invoke(currentModel, new object[] { modelvalue });
                    }
                }

                AssociatedObject.DataContext = currentModel;
                AssociatedObject.UpdateLayout();
              
            }
        }

        protected override void OnDetaching()
        {
            Messenger.Default.Unregister<object>(AssociatedObject, DataChannelName, RecviceFromOthers);
            AssociatedObject.Initialized -= AssociatedObject_Initialized;
        }
    }
}
