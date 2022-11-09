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
           
        }

        private void Cadastro_Livro_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = Convert.ToString(_livro.Id); 
            txtTitulo.Text = _livro.TituloObra;
            dtPublicacao.Text = Convert.ToString(_livro.DataPublicacao);
            txtExemplar.Text = Convert.ToString(_livro.NumExemplar);
            CbEditora.Text = Convert.ToString(_livro.EditoraObra);
            txtNumPag.Text = Convert.ToString(_livro.NumPagina);
            txtAutor.Text = _livro.AutorObra;
            txtGenero.Text = Convert.ToString(_livro.Genero);
            txtTipo.Text = Convert.ToString(_livro.Tipo);
            txtEdicao.Text = _livro.EdicaoObra;
            txtSinopse.Text = _livro.SinopseObra;



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
            _livro.NumExemplar = Convert.ToInt32(txtExemplar.Text);
            _livro.NumPagina = Convert.ToInt32(txtNumPag.Text);
            _livro.EditoraObra = Convert.ToString(CbEditora);
            _livro.Genero = txtGenero.Text;
            _livro.Tipo = txtTipo.Text;
            _livro.DataPublicacao = dtPublicacao.SelectedDate;

            /*CREATE TABLE Obras(
            cod_obra int primary key auto_increment,
            titulo_obra varchar(100),
            dataPublicacao_obra date,
            num_exemplar_obra int,
            editora_obra varchar(100),
            num_paginas_obra int,
            autor_obra varchar(100),
            genero_obra varchar(100),
            tipo_obra varchar(100),
            edicao_obra varchar (100),
            sinopse_obra varchar(100)
            );*/


            try
            {
                var dao = new LivroDAO();

                if (_livro.Id > 0)
                {
                    dao.Update(_livro);
                    MessageBox.Show("Registro do livro atualizado com sucesso");
                }
                else
                {
                    dao.Insert(_livro);

                    MessageBox.Show("errrrrrrrrrrrrrrrrrrrrrrrrrrrrrrooooo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
