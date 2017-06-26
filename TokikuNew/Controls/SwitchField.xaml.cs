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

namespace TokikuNew.Controls
{
    /// <summary>
    /// SwitchField.xaml 的互動邏輯
    /// </summary>
    public partial class SwitchField : UserControl
    {
        public SwitchField()
        {
            InitializeComponent();
        }

        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(SwitchField));
        #endregion

        #region SwitchTo


        public SwitchFieldMode SwitchTo
        {
            get { return (SwitchFieldMode)GetValue(SwitchToProperty); }
            set { SetValue(SwitchToProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SwitchTo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SwitchToProperty =
            DependencyProperty.Register("SwitchTo", typeof(SwitchFieldMode), typeof(SwitchField), new PropertyMetadata(SwitchFieldMode.TextBox));


        #endregion
    }
}
