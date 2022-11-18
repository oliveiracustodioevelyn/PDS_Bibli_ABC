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
    /// Lógica interna para Listagem_Avervo.xaml
    /// </summary>
    public partial class Listagem_Avervo : Window
    {
        public Listagem_Avervo()
        {
            InitializeComponent();
            Loaded += Listagem_Avervo_Loaded;

        }

        private void Listagem_Avervo_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var dao = new LivroDAO();
                List<Livro> listaLivro = dao.List();

                dataGridAcervo.ItemsSource = listaLivro;
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
       
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            /*var livroSelecionado = dataGridAcervo.SelectedItem as Livro;

            var form = new Cadastro_Livro(livroSelecionado);
            form.ShowDialog();
            CarregarListagem();*/
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dataGridAcervo.SelectedItem as Livro;

            var resultado = MessageBox.Show($"Deseja realmente remover o livro '{escolaSelecionada.TituloObra}' ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {

                    var dao = new LivroDAO();
                    dao.Delete(escolaSelecionada);

                    MessageBox.Show("O registro foi Removido com sucesso!");
                    CarregarListagem();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new LivroDAO();
                List<Livro> listaEscolas = dao.List();

                dataGridAcervo.ItemsSource = listaEscolas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
