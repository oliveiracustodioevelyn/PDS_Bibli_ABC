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
    /// Lógica interna para Cadastro_Fornecedor.xaml
    /// </summary>
    public partial class Cadastro_Fornecedor : Window
    {
        private Fornecedor _fornecedor = new Fornecedor();
        public Cadastro_Fornecedor()
        {
            InitializeComponent();
            Loaded += Cadastro_Fornecedor_Loaded;
        }

        private void Cadastro_Fornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = Convert.ToString(_fornecedor.Id);
            txtRazaoSoc.Text = _fornecedor.Razao_social;
            txtNomeFant.Text = _fornecedor.Nome_fantasia;
            txtCnpj.Text = _fornecedor.Cnpj;
            txtTelefone1.Text = _fornecedor.Telefone1;
            txtTelefone2.Text = _fornecedor.Telefone2;
            txtRepresentante.Text = _fornecedor.Representante;
            txtEmail.Text = _fornecedor.Email;
            txtRua.Text = _fornecedor.Rua;
            txtBairro.Text = _fornecedor.Bairro;
            txtNumero.Text = _fornecedor.Numero;
            txtCep.Text = _fornecedor.Cep;
            txtComplemento.Text = _fornecedor.Complemento;
            txtCidade.Text = _fornecedor.Cidade;
            txtEstado.Text = _fornecedor.Estado;

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _fornecedor.Razao_social = txtRazaoSoc.Text;
            _fornecedor.Nome_fantasia = txtNomeFant.Text;
            _fornecedor.Cnpj = txtCnpj.Text;
            _fornecedor.Telefone1 = txtTelefone1.Text;
            _fornecedor.Telefone2 = txtTelefone2.Text;
            _fornecedor.Representante = txtRepresentante.Text;
            _fornecedor.Email = txtEmail.Text;
            _fornecedor.Rua = txtRua.Text;
            _fornecedor.Bairro = txtBairro.Text;
            _fornecedor.Numero = txtNumero.Text;
            _fornecedor.Complemento = txtComplemento.Text;
            _fornecedor.Cidade = txtCidade.Text;
            _fornecedor.Estado = txtEstado.Text;


            try
            {
                var dao = new FornecedorDAO();

                if (_fornecedor.Id > 0)
                {
                    dao.Update(_fornecedor);
                    MessageBox.Show("Registro do livro atualizado com sucesso");
                }
                else
                {
                    dao.Insert(_fornecedor);

                    MessageBox.Show("errrrrrrrrrrrrrrrrrrrrrrrrrrrrrrooooo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
