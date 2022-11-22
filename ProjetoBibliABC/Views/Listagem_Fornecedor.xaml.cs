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
    /// Lógica interna para Listagem_Fornecedor.xaml
    /// </summary>
    public partial class Listagem_Fornecedor : Window
    {
        public Listagem_Fornecedor()
        {
            InitializeComponent();
            Loaded += Listagem_Fornecedor_Loaded;
        }

        private void Listagem_Fornecedor_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var dao = new FornecedorDAO();
                List<Fornecedor> listaFornecedor = dao.List();

                dataGridFornecedor.ItemsSource = listaFornecedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelecionado = dataGridFornecedor.SelectedItem as Fornecedor;

            var form = new Cadastro_Fornecedor(fornecedorSelecionado);
            form.ShowDialog();
            CarregarListagem();
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelecionado = dataGridFornecedor.SelectedItem as Fornecedor;

            var resultado = MessageBox.Show($"Deseja realmente remover o Fornecedor '{fornecedorSelecionado.Nome_fantasia}' ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {

                    var dao = new FornecedorDAO();
                    dao.Delete(fornecedorSelecionado);

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
                var dao = new FornecedorDAO();
                List<Fornecedor> listaFornecedor = dao.List();

                dataGridFornecedor.ItemsSource = listaFornecedor;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
