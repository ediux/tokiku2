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

namespace TokikuNew.Views
{
    /// <summary>
    /// 本票管理UC.xaml 的互動邏輯
    /// </summary>
    public partial class 本票管理UC : UserControl
    {
        public 本票管理UC()
        {
            InitializeComponent();
        }

        private void BussinessItemsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CBMaterialCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void 本票管理UC_Loaded(object sender, RoutedEventArgs e)
        {
            UC.DataContext = new Tokiku.ViewModels.PromissoryNoteManagementViewModelCollection();
        }
    }
}
