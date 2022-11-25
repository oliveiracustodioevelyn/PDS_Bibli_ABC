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
    /// Lógica interna para Alugar.xaml
    /// </summary>
    public partial class Alugar : Window
    {
        private Aluguel _aluguel = new Aluguel();
        public Alugar()
        {
            InitializeComponent();
        }

        public Alugar(Aluguel aluguel)
        {
            InitializeComponent();
            Loaded += Alugar_Loaded;
            _aluguel = aluguel;
        }

        private void Alugar_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodLivro.Text = Convert.ToString(_aluguel.Livro);
            txtCodLeitor.Text = Convert.ToString(_aluguel.Leitor);
            txtCodUse.Text = Convert.ToString(_aluguel.Funcionario);
            /*txtTitulo.Text = ;
            txtLeitor.Text = ;
            txtFunc.Text = ;*/
            dtAtual.SelectedDate = _aluguel.DataAluguel;
            dtDevolucao.SelectedDate = _aluguel.DataDevolucao;
            /*txtDescricao.Text = ;*/

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

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            /*_aluguel.Livro = txtCodLivro.Text;
            _aluguel.Leitor =

            _aluguel.DataAluguel = dtAtual.SelectedDate;
            _aluguel.DataDevolucao = dtDevolucao.SelectedDate;
            */

            try
            {
                var dao = new AluguelDAO();

                if (_aluguel.Id > 0)
                {
                    dao.Update(_aluguel);
                    MessageBox.Show("Registro do Aluguel atualizado com sucesso");
                }
                else
                {
                    dao.Insert(_aluguel);

                    MessageBox.Show("Aluguel realizado com Sucesso!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
