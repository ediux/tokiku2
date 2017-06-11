using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TokikuNew.Controls
{
    /// <summary>
    /// DockBar.xaml 的互動邏輯(工具列控制項)
    /// </summary>
    public partial class DockBar : UserControl
    {
        public DockBar()
        {
            InitializeComponent();
        }



        public bool QueryFunctionButtonEnabled
        {
            get { return (bool)GetValue(QueryFunctionButtonEnabledProperty); }
            set { SetValue(QueryFunctionButtonEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QueryFunctionButtonEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QueryFunctionButtonEnabledProperty =
            DependencyProperty.Register("QueryFunctionButtonEnabled", typeof(bool), typeof(DockBar), new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));



        public DocumentLifeCircle LastState
        {
            get { return (DocumentLifeCircle)GetValue(LastStateProperty); }
            set { SetValue(LastStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastState.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastStateProperty =
            DependencyProperty.Register("LastState", typeof(DocumentLifeCircle), typeof(DockBar), new PropertyMetadata(DocumentLifeCircle.Read));


        /// <summary>
        /// 判定各內容狀態
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected static void DefaultFieldChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (e.Property.PropertyType == typeof(DocumentLifeCircle))
                {
                    DockBar src = (DockBar)source;
                    source.SetValue(LastStateProperty, e.OldValue);
                    ChoiceMode((DocumentLifeCircle)e.NewValue, src);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private static void ChoiceMode(DocumentLifeCircle mode, DockBar src)
        {
            try
            {
                switch (mode)
                {
                    case DocumentLifeCircle.Create:
                        src.btnF1.IsEnabled = false;
                        src.btnF2.IsEnabled = false;
                        src.btnF3.IsEnabled = true;
                        src.btnF11.IsEnabled = true;
                        src.btnF12.IsEnabled = true;
                        src.btnF9.IsEnabled = false;
                        break;
                    case DocumentLifeCircle.Delete:
                        src.btnF1.IsEnabled = true;
                        src.btnF2.IsEnabled = false;
                        src.btnF3.IsEnabled = false;
                        src.btnF11.IsEnabled = false;
                        src.btnF12.IsEnabled = false;
                        break;
                    case DocumentLifeCircle.Read:
                        src.btnF1.IsEnabled = true;
                        src.btnF2.IsEnabled = true;
                        src.btnF3.IsEnabled = false;
                        src.btnF11.IsEnabled = true;
                        src.btnF12.IsEnabled = true;
                        src.btnF9.IsEnabled = false;
                        break;
                    case DocumentLifeCircle.Update:
                        src.btnF1.IsEnabled = true;
                        src.btnF2.IsEnabled = false;
                        src.btnF3.IsEnabled = true;
                        src.btnF11.IsEnabled = false;
                        src.btnF12.IsEnabled = false;
                        src.btnF9.IsEnabled = true;
                        break;
                }

                src.UpdateLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        #region WPF 事件路由

        #region DocumentModeChanged 事件

        public static readonly RoutedEvent DocumentModeChangedEvent =
            EventManager.RegisterRoutedEvent("DocumentModeChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockBar));
        /// <summary>
        /// 新增文件模式變更的路由事件。
        /// </summary>
        public event RoutedEventHandler DocumentModeChanged
        {
            add { AddHandler(DocumentModeChangedEvent, value); }
            remove { RemoveHandler(DocumentModeChangedEvent, value); }
        }
        #endregion

        #region 查詢功能鈕觸發事件
        public static readonly RoutedEvent QueryButtonClickEvent =
   EventManager.RegisterRoutedEvent("QueryButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockBar));

        public event RoutedEventHandler QueryButtonClick
        {
            add { AddHandler(QueryButtonClickEvent, value); }
            remove { RemoveHandler(QueryButtonClickEvent, value); }
        }
        #endregion

        #endregion

        #region 文件模式屬性

        /// <summary>
        /// 取得或設定工具列目前文件編輯模式
        /// </summary>
        public DocumentLifeCircle DocumentMode
        {
            get { return (DocumentLifeCircle)GetValue(DocumentModeProperty); }
            set { SetValue(DocumentModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DocumentMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DocumentModeProperty =
            DependencyProperty.Register("DocumentMode", typeof(DocumentLifeCircle), typeof(DockBar), new PropertyMetadata(DocumentLifeCircle.Read, new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        private void btnF1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DocumentMode = DocumentLifeCircle.Create;
                RaiseEvent(new RoutedEventArgs(DocumentModeChangedEvent, DocumentMode));
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnF2_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DocumentMode = DocumentLifeCircle.Update;
                RaiseEvent(new RoutedEventArgs(DocumentModeChangedEvent, DocumentMode));
                UpdateLayout();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        /// <summary>
        /// 傳回是否能執行系統命令的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                e.CanExecute = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        /// <summary>
        /// 處理當系統命令的執行事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (e.Command == ApplicationCommands.New)
                {
                    //DocumentMode = DocumentLifeCircle.Create;
                    //RaiseEvent(new RoutedEventArgs(DocumentModeChangedEvent, this));
                }

                if (e.Command == ApplicationCommands.Save)
                {
                    //DocumentMode = DocumentLifeCircle.Read;
                    //RaiseEvent(new RoutedEventArgs(DocumentModeChangedEvent, this));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnF3_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DocumentMode = DocumentLifeCircle.Save;
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(DocumentModeChangedEvent, DocumentMode));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnF4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DocumentMode = DocumentLifeCircle.Read;
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(QueryButtonClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnF5_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnF6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnF7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnF8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnF9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                DocumentMode = LastState;
                RaiseEvent(new RoutedEventArgs(DocumentModeChangedEvent, DocumentMode));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnF10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnF11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DocumentMode = DocumentLifeCircle.Update;
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnF12_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DocumentMode = DocumentLifeCircle.Update;
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ChoiceMode(this.DocumentMode, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }


    }
}
