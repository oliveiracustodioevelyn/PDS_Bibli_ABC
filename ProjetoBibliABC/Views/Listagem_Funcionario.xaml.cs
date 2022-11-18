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
    /// Lógica interna para Listagem_Funcionario.xaml
    /// </summary>
    public partial class Listagem_Funcionario : Window
    {
        public Listagem_Funcionario()
        {
            InitializeComponent();
            Loaded += Listagem_Funcionario_Loaded;
        }

        private void Listagem_Funcionario_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var dao = new FuncionarioDAO();
                List<Funcionario> listaFuncionario = dao.List();

                dataGridFuncionario.ItemsSource = listaFuncionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
           /* var funcionarioSelecionado = dataGridFuncionario.SelectedItem as Funcionario;

            var form = new Cadastro_Fornecedor(funcionarioSelecionado);
            form.ShowDialog();
            CarregarListagem();*/
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelecionado = dataGridFuncionario.SelectedItem as Funcionario;

            var resultado = MessageBox.Show($"Deseja realmente remover o Funcionário '{funcionarioSelecionado.Nome}' ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {

                    var dao = new FuncionarioDAO();
                    dao.Delete(funcionarioSelecionado);

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
                var dao = new FuncionarioDAO();
                List<Funcionario> listaFuncionario = dao.List();

                dataGridFuncionario.ItemsSource = listaFuncionario;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
