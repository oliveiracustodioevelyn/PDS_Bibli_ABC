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
    /// Lógica interna para Listagem_Leitor.xaml
    /// </summary>
    public partial class Listagem_Leitor : Window
    {
        public Listagem_Leitor()
        {
            InitializeComponent();
            Loaded += Listagem_Leitor_Loaded;
        }

        private void Listagem_Leitor_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var dao = new LeitorDAO();
                List<Leitor> listaLeitor = dao.List();

                dataGridLeitor.ItemsSource = listaLeitor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var leitorSelecionado = dataGridLeitor.SelectedItem as Leitor;

            var form = new Cadastro_Leitor(leitorSelecionado);
            form.ShowDialog();
            CarregarListagem();
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var leitorSelecionado = dataGridLeitor.SelectedItem as Leitor;

            var resultado = MessageBox.Show($"Deseja realmente remover o Leitor '{leitorSelecionado.Nome}' ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {

                    var dao = new LeitorDAO();
                    dao.Delete(leitorSelecionado);

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
                var dao = new LeitorDAO();
                List<Leitor> listaLeitor = dao.List();

                dataGridLeitor.ItemsSource = listaLeitor;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
