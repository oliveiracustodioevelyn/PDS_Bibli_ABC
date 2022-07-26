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
    /// Lógica interna para Menu_Principal.xaml
    /// </summary>
    public partial class Menu_Principal : Window
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void btCadastrarLivro_Click(object sender, RoutedEventArgs e)
        {
            Cadastro_Livro livro = new Cadastro_Livro();
            livro.ShowDialog();
        }

        private void btCadastrarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            var window = new Cadastro_Fornecedor();
            window.ShowDialog();
        }

        private void btCadastrarLeitor_Click(object sender, RoutedEventArgs e)
        {
            Cadastro_Leitor leitor = new Cadastro_Leitor();
            leitor.ShowDialog();
        }

        private void btDevolucao_Click(object sender, RoutedEventArgs e)
        {
            Devolucao dev = new Devolucao();        
            dev.ShowDialog();
        }

        private void btPendente_Click(object sender, RoutedEventArgs e)
        {
            Livro_Pendentes pend = new Livro_Pendentes();
            pend.ShowDialog();
        }

        private void btAlugar_Click(object sender, RoutedEventArgs e)
        {
            Alugar alu = new Alugar();  
            alu.ShowDialog();
        }

        private void btDevolução_Click(object sender, RoutedEventArgs e)
        {
            Devolucao dev = new Devolucao();
            dev.ShowDialog();
        }

        private void btFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Listagem_Funcionario cad = new Listagem_Funcionario();
            cad.ShowDialog();
        }

        private void btListaLivro_Click(object sender, RoutedEventArgs e)
        {
            Listagem_Avervo ca = new Listagem_Avervo();
                ca.ShowDialog();

        }

        private void btListaLeitor_Click(object sender, RoutedEventArgs e)
        {
            Listagem_Leitor lei = new Listagem_Leitor();
            lei.ShowDialog();
        }

        private void btListaFornecedor_Click(object sender, RoutedEventArgs e)
        {
            Listagem_Fornecedor forn = new Listagem_Fornecedor();
            forn.ShowDialog();
        }

        private void btPerfil_Funcionario_Click(object sender, RoutedEventArgs e)
        {
            Listagem_Funcionario lis = new Listagem_Funcionario();
            lis.ShowDialog();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.ShowDialog();
        }
    }
}
