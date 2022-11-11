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
      
            txtNome.Text = _leitor.Nome;
            txtCpf.Text = _leitor.CPF;
            txtRg.Text = _leitor.RG;
            txtEmail.Text = _leitor.Email;
            txtTelefone.Text = _leitor.Telefone;
            dtNasc.SelectedDate = _leitor.DataNascimento;
            txtSexo.Text = _leitor.Sexo;
            txtRua.Text = _leitor.Rua;
            txtBairro.Text = _leitor.Bairro;
            txtNumero.Text = _leitor.Numero;
            txtComplemento.Text = _leitor.Complemento;
            txtCidade.Text = _leitor.Cidade;
            txtEstado.Text = _leitor.Estado;
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
        
            _leitor.Nome = txtNome.Text;
            _leitor.CPF = txtCpf.Text;
            _leitor.RG = txtRg.Text;
            _leitor.Email = txtEmail.Text;
            _leitor.Telefone = txtTelefone.Text;
            _leitor.DataNascimento = dtNasc.SelectedDate;
            _leitor.Sexo = txtSexo.Text;

            _leitor.Rua = txtRua.Text;
            _leitor.Bairro = txtBairro.Text;
            _leitor.Numero = txtNumero.Text;
            _leitor.Cep = txtCep.Text;
            _leitor.Complemento = txtComplemento.Text;
            _leitor.Cidade = txtCidade.Text;
            _leitor.Estado = txtEstado.Text;


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
