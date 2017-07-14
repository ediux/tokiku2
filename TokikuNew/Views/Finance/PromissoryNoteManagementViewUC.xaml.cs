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
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// 本票管理UC.xaml 的互動邏輯
    /// </summary>
    public partial class PromissoryNoteManagementUC : UserControl
    {
        public PromissoryNoteManagementUC()
        {
            InitializeComponent();
        }

        private void BussinessItemsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CBMaterialCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PromissoryNoteManagementViewUC_Loaded(object sender, RoutedEventArgs e)
        {
            PromissoryNoteManagementViewModelCollection ctrl = new PromissoryNoteManagementViewModelCollection();
            CheckGrid.DataContext = ctrl;
            PromissoryNoteManagementViewModelCollection.Query();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContractManagement_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
