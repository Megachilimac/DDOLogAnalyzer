﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using DDOLogAnalyzer.Helpers;
using Microsoft.Win32;

namespace DDOLogAnalyzer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }





    }
}
