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
using ProjetoBibliABC.Models;

namespace ProjetoBibliABC.Views
{
    /// <summary>
    /// Lógica interna para Cadastro_Livro.xaml
    /// </summary>
    public partial class Cadastro_Livro : Window
    {
        private Livro _livro = new Livro();

        public Cadastro_Livro()
        {
            InitializeComponent();
            CbEditora.Items.Add("1");
            CbEditora.Items.Add("2");
        }

        private void Cadastro_Livro_Loaded(object sender, RoutedEventArgs e)
        {
            txtAutor.Text = _livro.AutorObra;
            txtEdicao.Text = _livro.EdicaoObra;
            txtSinopse.Text = _livro.SinopseObra;
            txtTitulo.Text = _livro.TituloObra;
           
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btMenuInicial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCadastrarLivro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCadastrarFornecedor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCadastrarLeitor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btDevolucao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _livro.SinopseObra = txtSinopse.Text;
            _livro.AutorObra = txtAutor.Text;
            _livro.EdicaoObra = txtEdicao.Text;
            _livro.TituloObra = txtTitulo.Text;


            try
            {
                var dao = new LivroDAO();

                if (_livro.Id > 0)
                {
                    dao.Update(_livro);
                    MessageBox.Show("Registro de curso atualizado com sucesso");
                }
                else
                {
                    dao.Insert(_livro);

                    MessageBox.Show("Registro de escola cadastrado com sucesso.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
