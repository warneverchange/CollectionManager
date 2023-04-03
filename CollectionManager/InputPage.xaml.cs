﻿using CollectionManager.core.entities;
using CollectionManager.viewmodel;
using CollectionManager.viewmodel.input_page_view_model;
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
using System.Windows.Shapes;

namespace CollectionManager
{
    /// <summary>
    /// Логика взаимодействия для InputPage.xaml
    /// </summary>
    public partial class InputPage : Window
    {
        public InputPage()
        {
            InitializeComponent();
            DataContext = new InputPageViewModel(
                new WorkerViewModel(new Worker("", "", "")),
                this);
        }
    }
}
