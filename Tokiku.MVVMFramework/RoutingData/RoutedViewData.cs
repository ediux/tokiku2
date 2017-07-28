using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.MVVM.Commands;

namespace Tokiku.MVVM.Data
{
    public class RoutedViewData : UIElement
    {
        public RoutedViewData()
        {
            RoutedValues = new Dictionary<string, object>();
            RoutingBinding = new Dictionary<string, string>();
            ReplyCommand = new RelayCommand((x) =>
            {

            });
        }
       

        /// <summary>
        /// 路由名稱
        /// </summary>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(RoutedViewData), new PropertyMetadata("Default"));



        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayText", typeof(string), typeof(RoutedViewData), new PropertyMetadata(string.Empty));


        //public string DisplayText { get; set; }
        //public string FormatedDisplay { get; set; }


        public string FormatedDisplay
        {
            get { return (string)GetValue(FormatedDisplayProperty); }
            set { SetValue(FormatedDisplayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormatedDisplay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormatedDisplayProperty =
            DependencyProperty.Register("FormatedDisplay", typeof(string), typeof(RoutedViewData), new PropertyMetadata(string.Empty));



        public object[] FormatedParameters
        {
            get { return (object[])GetValue(FormatedParametersProperty); }
            set { SetValue(FormatedParametersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormatedParameters.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormatedParametersProperty =
            DependencyProperty.Register("FormatedParameters", typeof(object[]), typeof(RoutedViewData), new PropertyMetadata(null));

        /// <summary>
        /// View的型別
        /// </summary>
        public Type ViewType
        {
            get { return (Type)GetValue(ViewTypeProperty); }
            set { SetValue(ViewTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewTypeProperty =
            DependencyProperty.Register("ViewType", typeof(Type), typeof(RoutedViewData), new PropertyMetadata(null));

        /// <summary>
        /// 來源View的型別        
        /// </summary>
        public Type SourceViewType
        {
            get { return (Type)GetValue(SourceViewTypeProperty); }
            set { SetValue(SourceViewTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceViewType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceViewTypeProperty =
            DependencyProperty.Register("SourceViewType", typeof(Type), typeof(RoutedViewData), new PropertyMetadata(null));

        /// <summary>
        /// 來源執行個體參考
        /// </summary>
        public object SourceInstance
        {
            get { return (object)GetValue(SourceInstanceProperty); }
            set { SetValue(SourceInstanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceInstance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceInstanceProperty =
            DependencyProperty.Register("SourceInstance", typeof(object), typeof(RoutedViewData), new PropertyMetadata(null, new PropertyChangedCallback(SourceChange)));

        private static void SourceChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            RoutedViewData r = (RoutedViewData)d;
            if (r != null)
            {
                r.SourceViewType = e.NewValue.GetType();
                return;
            }
        }

        /// <summary>
        /// 資料來源繫結
        /// </summary>
        public object DataContent
        {
            get { return (object)GetValue(DataContentProperty); }
            set { SetValue(DataContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataContentProperty =
            DependencyProperty.Register("DataContent", typeof(object), typeof(RoutedViewData), new PropertyMetadata(null));


        //public Dictionary<string, object> RoutedValues { get; set; }
        //public string AttachedTargetElementName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> RoutingBinding
        {
            get { return (Dictionary<string, string>)GetValue(RoutingBindingProperty); }
            set { SetValue(RoutingBindingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoutingBindingProperty =
            DependencyProperty.Register("RoutingBinding", typeof(Dictionary<string, string>), typeof(RoutedViewData), new PropertyMetadata(default(Dictionary<string, Binding>)));




        public Dictionary<string, object> RoutedValues
        {
            get { return (Dictionary<string, object>)GetValue(RoutedValuesProperty); }
            set { SetValue(RoutedValuesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RoutedValues.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoutedValuesProperty =
            DependencyProperty.Register("RoutedValues", typeof(Dictionary<string, object>), typeof(RoutedViewData), new PropertyMetadata(default(Dictionary<string, object>)));





        /// <summary>
        /// 轉送命令
        /// </summary>
        public ICommand ReplyCommand
        {
            get { return (ICommand)GetValue(ReplyCommandProperty); }
            set { SetValue(ReplyCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReplyCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReplyCommandProperty =
            DependencyProperty.Register("ReplyCommand", typeof(ICommand), typeof(RoutedViewData), new PropertyMetadata(null));



        public string AttachedTargetElementName
        {
            get { return (string)GetValue(AttachedTargetElementNameProperty); }
            set { SetValue(AttachedTargetElementNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AttachedTargetElementName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachedTargetElementNameProperty =
            DependencyProperty.Register("AttachedTargetElementName", typeof(string), typeof(RoutedViewData), new PropertyMetadata(string.Empty));


    }
}
