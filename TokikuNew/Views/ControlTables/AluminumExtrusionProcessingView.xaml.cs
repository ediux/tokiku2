﻿using System;
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
using Tokiku.ViewModels;

namespace TokikuNew.Views
{
    /// <summary>
    /// AluminumExtrusionProcessingView.xaml 的互動邏輯
    /// </summary>
    public partial class AluminumExtrusionProcessingView : UserControl
    {
        public AluminumExtrusionProcessingView()
        {
            InitializeComponent();
        }

        private void AluminumExtrusionProcessingView_Loaded(object sender, RoutedEventArgs e)
        {
            ProcessingViewModelCollection ctrl = new ProcessingViewModelCollection();
            CheckGrid.DataContext = ctrl;
            //ProcessingViewModelCollection.Query();
        }

        private void Btn2_PreviewCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }

    }
}
