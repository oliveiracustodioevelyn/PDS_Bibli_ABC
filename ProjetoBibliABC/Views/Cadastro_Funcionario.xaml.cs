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
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Cadastro_Funcionario : Window
    {
        private Funcionario _funcionario = new Funcionario();
        public Cadastro_Funcionario()
        {
            InitializeComponent();
            Loaded += Cadastro_Funcionario_Loaded;
        }
        public Cadastro_Funcionario(Funcionario funcionario)
        {
            InitializeComponent();
            Loaded += Cadastro_Funcionario_Loaded;
            _funcionario = funcionario;
        }

        private void Cadastro_Funcionario_Loaded(object sender, RoutedEventArgs e)
        {

            txtNome.Text = _funcionario.Nome;
            txtCPF.Text = _funcionario.CPF;
            txtRG.Text = _funcionario.RG;
            txtSexo.Text = _funcionario.Sexo;
            txtTelefone1.Text = _funcionario.Telefone1;
            txtTelefone2.Text = _funcionario.Telefone2;
            dtNasc.SelectedDate = _funcionario.DataNascimento;
            
            //txtTurno.Text = _funcionario.Turno;
            txtEmail.Text = _funcionario.Email;
            txtSenha.Text = _funcionario.Senha;
            txtRua.Text = _funcionario.Rua;
            txtBairro.Text = _funcionario.Bairro;
            txtNumero.Text = _funcionario.Numero;
            txtComplemento.Text = _funcionario.Complemento;
            txtCidade.Text = _funcionario.Cidade;
            txtEstado.Text = _funcionario.Estado;
        }

        /*public Cadastro_Leitor()
        {
            InitializeComponent();
        }*/

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Menu_Principal menu = new Menu_Principal();
            menu.ShowDialog();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            _funcionario.Nome = txtNome.Text;
            _funcionario.CPF = txtCPF.Text;
            _funcionario.RG = txtRG.Text;
            _funcionario.Sexo = txtSexo.Text;
            _funcionario.Telefone1 = txtTelefone1.Text;
            _funcionario.Telefone2 = txtTelefone2.Text;
            _funcionario.DataNascimento = dtNasc.SelectedDate;
            
            //_funcionario.Turno = txtTurno.Text;
            _funcionario.Email = txtEmail.Text;
            _funcionario.Senha = txtSenha.Text;
            _funcionario.Rua = txtRua.Text;
            _funcionario.Bairro = txtBairro.Text;
            _funcionario.Numero = txtNumero.Text;
            _funcionario.Complemento = txtComplemento.Text;
            _funcionario.Cidade = txtCidade.Text;
            _funcionario.Estado = txtEstado.Text;


            try
            {
                var dao = new FuncionarioDAO();

                if (_funcionario.Id > 0)
                {
                    dao.Update(_funcionario);
                    MessageBox.Show("Registro de leitor atualizado com sucesso");
                }
                else
                {
                    dao.Insert(_funcionario);

                    MessageBox.Show("Cadastrado realizado com Sucesso!!");
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
