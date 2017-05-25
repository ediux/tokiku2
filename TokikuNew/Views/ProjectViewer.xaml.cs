using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tokiku.Controllers;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectViewer.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectViewer : UserControl
    {
        private ProjectsController controller = new ProjectsController();

        #region 相依屬性
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(ProjectBaseViewModel), typeof(ProjectViewer), new PropertyMetadata(default(ProjectBaseViewModel)));

        public ProjectBaseViewModel Model
        {
            get { return GetValue(ModelProperty) as ProjectBaseViewModel; }
            set { SetValue(ModelProperty, value); }
        }
        #endregion

        public ProjectViewer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //註冊一個處理分頁關閉的事件處理器
            AddHandler(ClosableTabItem.OnPageClosingEvent, new RoutedEventHandler(ProjectViewer_OnPageClosing));
            //this.DataContext = Model;
            //projectmgr.Model = Model;
            //projectmgr.DataContext = Model;
           

        }

        private void ProjectViewer_OnPageClosing(object sender, RoutedEventArgs e)
        {
            
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (tbName.Text.Trim().Length > 0)
            //{
            //    tbShortName.Text = tbName.Text.Substring(0, Math.Min(4, tbName.Text.Length));
            //} 
        }
    }
}
