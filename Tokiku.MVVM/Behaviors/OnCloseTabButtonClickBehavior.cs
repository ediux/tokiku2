using GalaSoft.MvvmLight.Messaging;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Tokiku.ViewModels;

namespace Tokiku.MVVM.Behaviors
{
    /// <summary>
    /// 可關閉分頁按鈕行為物件
    /// </summary>
    public class OnCloseTabButtonClickBehavior : Behavior<Button>
    {
        //log4net
        static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 控制項通訊通道名稱
        /// </summary>
        public string ControlsChannelName
        {
            get { return (string)GetValue(ControlsChannelNameProperty); }
            set { SetValue(ControlsChannelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControllChannelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlsChannelNameProperty =
            DependencyProperty.Register("ControlsChannelName", typeof(string), typeof(OnCloseTabButtonClickBehavior), new PropertyMetadata(string.Empty));


        /// <summary>
        /// 標題內容
        /// </summary>
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseTabViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(OnCloseTabButtonClickBehavior), new PropertyMetadata(string.Empty));


        protected override void OnAttached()
        {
            try
            {
                AssociatedObject.Click += AssociatedObject_Click;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.DataContext is ITabViewModel)
            {
                ITabViewModel tabcontext = (ITabViewModel)AssociatedObject.DataContext;

                Type ViewType = tabcontext.ViewType;

                List<PropertyInfo> PropNames = ViewType.GetProperties()
                    .Where(w => w.PropertyType.GetInterfaces().Any(a => a.Name == "IDocumentBaseViewModel"))
                    .Select(s => s).ToList();

                bool isContinue = false;
                foreach (var prop in PropNames)
                {
                    var obj = prop.GetValue(tabcontext.ContentView);
                    var isSaved_Prop = prop.GetValue(tabcontext.ContentView).GetType().GetProperty("IsSaved");
                    bool IsSaved = (bool)isSaved_Prop.GetValue(obj);

                    if (IsSaved == false)
                    {
                        if (MessageBox.Show("您尚未儲存!要繼續嗎?\n如果按「是」，所做的變更將不會儲存!") == MessageBoxResult.Yes)
                        {
                            Messenger.Default.Send(tabcontext, "TabItem_Close_View");
                            break;
                        }
                        else
                        {
                            isContinue = true;
                        }

                    }
                }

                if (isContinue)
                    return;

                //傳送訊息給分頁控制項
                NotificationMessage<ITabViewModel> NotifyToClosingTabMessage = new NotificationMessage<ITabViewModel>(AssociatedObject, tabcontext, "CloseTab");
                Messenger.Default.Send(NotifyToClosingTabMessage);
                // Messenger.Default.Send(tabcontext, (!string.IsNullOrEmpty(ControlsChannelName))?ControlsChannelName: "TabItem_Close_View");
            }
        }

        protected override void OnDetaching()
        {
            try
            {
                AssociatedObject.Click -= AssociatedObject_Click;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

           
        }
    }
}
