﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TokikuNew.Controls
{
    /// <summary>
    /// 擴充的分頁控制項，實作可關閉的分頁功能。
    /// </summary>
    public class ClosableTabItem : TabItem
    {
        public ClosableTabItem()
        {
            try
            {
                //攔截按鈕的上升事件
                AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Headerobj_OnPageClosing));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void Headerobj_OnPageClosing(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource is Button)
                {
                    Button btn = (Button)e.OriginalSource;

                    if (btn.Name == "btnTabClose")
                    {
                        e.Handled = true;
                        RaiseEvent(new RoutedEventArgs(OnPageClosingEvent, this));  //停止關閉按鈕事件上升，並建立真正的分頁關閉上升事件觸發
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        /// <summary>
        /// 關閉分頁的路由事件。
        /// </summary>
        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClosableTabItem));

        /// <summary>
        /// 指派或移除處理關閉分頁的事件處理器。
        /// </summary>
        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }

        public static readonly RoutedEvent SendNewPageRequestEvent = EventManager.RegisterRoutedEvent("SendNewPageRequest", RoutingStrategy.Bubble
          , typeof(RoutedEventHandler), typeof(ClosableTabItem));

        public event RoutedEventHandler SendNewPageRequest
        {
            add { AddHandler(SendNewPageRequestEvent, value); }
            remove { RemoveHandler(SendNewPageRequestEvent, value); }
        }
    }
}
