using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class RoutedViewResult : UIElement
    {
        public RoutedViewResult()
        {
            RoutedValues = new Dictionary<string, object>();
            RoutingBinding = new Dictionary<string, string>();
            ReplyCommand = new RelayCommand((x) => {

            });
        }

        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayText", typeof(string), typeof(RoutedViewResult), new PropertyMetadata(string.Empty));


        //public string DisplayText { get; set; }
        //public string FormatedDisplay { get; set; }


        public string FormatedDisplay
        {
            get { return (string)GetValue(FormatedDisplayProperty); }
            set { SetValue(FormatedDisplayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormatedDisplay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormatedDisplayProperty =
            DependencyProperty.Register("FormatedDisplay", typeof(string), typeof(RoutedViewResult), new PropertyMetadata(string.Empty));



        public object[] FormatedParameters
        {
            get { return (object[])GetValue(FormatedParametersProperty); }
            set { SetValue(FormatedParametersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormatedParameters.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormatedParametersProperty =
            DependencyProperty.Register("FormatedParameters", typeof(object[]), typeof(RoutedViewResult), new PropertyMetadata(null));


        //public object[] FormatedParameters { get; set; }

        public Type ViewType { get; set; }

        public Type SourceViewType { get; set; }

        public object SourceInstance
        {
            get { return (object)GetValue(SourceInstanceProperty); }
            set { SetValue(SourceInstanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceInstance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceInstanceProperty =
            DependencyProperty.Register("SourceInstance", typeof(object), typeof(RoutedViewResult), new PropertyMetadata(null, new PropertyChangedCallback(SourceChange)));

        private static void SourceChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            RoutedViewResult r = (RoutedViewResult)d;
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
            DependencyProperty.Register("DataContent", typeof(object), typeof(RoutedViewResult), new PropertyMetadata(null));


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
            DependencyProperty.Register("RoutingBinding", typeof(Dictionary<string, string>), typeof(RoutedViewResult), new PropertyMetadata(default(Dictionary<string, Binding>)));




        public Dictionary<string, object> RoutedValues
        {
            get { return (Dictionary<string, object>)GetValue(RoutedValuesProperty); }
            set { SetValue(RoutedValuesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RoutedValues.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoutedValuesProperty =
            DependencyProperty.Register("RoutedValues", typeof(Dictionary<string, object>), typeof(RoutedViewResult), new PropertyMetadata(default(Dictionary<string, object>)));





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
            DependencyProperty.Register("ReplyCommand", typeof(ICommand), typeof(RoutedViewResult), new PropertyMetadata(null));



        public string AttachedTargetElementName
        {
            get { return (string)GetValue(AttachedTargetElementNameProperty); }
            set { SetValue(AttachedTargetElementNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AttachedTargetElementName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachedTargetElementNameProperty =
            DependencyProperty.Register("AttachedTargetElementName", typeof(string), typeof(RoutedViewResult), new PropertyMetadata(string.Empty));


    }
}
