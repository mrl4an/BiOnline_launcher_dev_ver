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

namespace BiOnline_launcher_dev_ver
{
    /// <summary>
    /// Логика взаимодействия для CirilicError.xaml
    /// </summary>
    public partial class CirilicError : Page
    {
        public CirilicError(string ErrorText)
        {
            
            InitializeComponent();
            ErrorDesc.Content = ErrorText;
        }
        private void closeGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           w682372 w682372 = new w682372();
            w682372.Show();
        }
    }
}
