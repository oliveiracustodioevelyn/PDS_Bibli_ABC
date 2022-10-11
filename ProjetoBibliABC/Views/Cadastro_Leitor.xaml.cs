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
using MySql.Data.MySqlClient;
using ProjetoBibliABC.Models;
using ProjetoBibliABC.Views;

namespace ProjetoBibliABC.Views
{
    /// <summary>
    /// Lógica interna para Cadastro_Leitor.xaml
    /// </summary>
    public partial class Cadastro_Leitor : Window
    {
        private Leitor _leitor = new Leitor();
        public Cadastro_Leitor()
        {
            InitializeComponent();
            Loaded += Cadastro_Leitor_Loaded;
        }
        //public Cadastro_Leitor(Leitor leitor)
        //{
        //    InitializeComponent();
        //    Loaded += Cadastro_Leitor_Loaded;
        //    _leitor = leitor;
        //}

        private void Cadastro_Leitor_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodAce.Text = Convert.ToString(_leitor.Id);
            txtNomeCompleto.Text = _leitor.Nome;
            txtCPF.Text = _leitor.CPF;
            txtRG.Text = _leitor.RG;
            txtEmail.Text = _leitor.Email;
            txtTelefone.Text = _leitor.Telefone;
            dtDataNasc.SelectedDate = _leitor.DataNascimento;
            //txtRua.Text = _leitor.Endereco;
        }

        /*public Cadastro_Leitor()
        {
            InitializeComponent();
        }*/

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _leitor.Id = Convert.ToInt32(txtCodAce.Text);
            _leitor.Nome = txtNomeCompleto.Text;
            _leitor.CPF = txtCPF.Text;
            _leitor.RG = txtRG.Text;
            _leitor.Email = txtEmail.Text;
            _leitor.Telefone = txtTelefone.Text;
            _leitor.DataNascimento = dtDataNasc.SelectedDate;
            //_leitor.Endereco = txtRua.Text;

            try
            {
                var dao = new LeitorDAO();

                if (_leitor.Id > 0)
                {
                    dao.Update(_leitor);
                    MessageBox.Show("Registro de leitor atualizado com sucesso");
                }
                else
                {
                    dao.Insert(_leitor);

                    MessageBox.Show("Registro de leitor cadastrado com sucesso.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
