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
using System.Windows.Shapes;

namespace ProjetoBibliABC.Views
{
    /// <summary>
    /// Lógica interna para Alugar.xaml
    /// </summary>
    public partial class Alugar : Window
    {
        public Alugar()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Menu_Principal menu = new Menu_Principal();
            menu.ShowDialog();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtCodLeitor.Clear();
        }
    }
}
