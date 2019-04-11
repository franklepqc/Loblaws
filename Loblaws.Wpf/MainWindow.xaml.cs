﻿using Loblaws.Biz;

namespace Loblaws.Wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(
                new CalculSousTotal(),
                new CalculTaxes(),
                new CalculTotal());
        }
    }
}
