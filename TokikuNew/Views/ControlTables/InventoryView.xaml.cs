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
    /// InventoryView.xaml 的互動邏輯
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
        }
        
        private void InventoryView_Loaded(object sender, RoutedEventArgs e)
        {
            InventoryViewModelCollection ctrl = new InventoryViewModelCollection();
            CheckGrid.DataContext = ctrl;
            InventoryViewModelCollection.Query();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
