using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjetoBibliABC.DataBase;
using ProjetoBibliABC.Helper;

namespace ProjetoBibliABC.Models
{
    internal class FuncionarioDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();


                comando.CommandText = "INSERT INTO Curso VALUES (null, @nome_fun,  @cpf_fun, @rg_fun, @endereco_fun, @telefone_fun, @dataNascimento_fun, @sexo_fun, @turno_fun, @email_fun, @senha_fun);";

                comando.Parameters.AddWithValue("@nome_fun", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf_fun", funcionario.CPF);
                comando.Parameters.AddWithValue("@rg_fun", funcionario.RG);
                comando.Parameters.AddWithValue("@endereco_fun", funcionario.Endereco);
                comando.Parameters.AddWithValue("@telefone_fun", funcionario.Telefone);
                comando.Parameters.AddWithValue("@dataNascimento_fun", funcionario.DataNascimento);
                comando.Parameters.AddWithValue("@sexo_fun", funcionario.Sexo);
                comando.Parameters.AddWithValue("@turno_fun", funcionario.Turno);
                comando.Parameters.AddWithValue("@email_fun", funcionario.Email);
                comando.Parameters.AddWithValue("@senha_fun", funcionario.Senha);


                /*
                 public int Id { get; set; }
                 public string Nome { get; set; }
                 public string CPF { get; set; }
                 public string RG { get; set; }
                 public string Endereco { get; set; }
                 public string Telefone { get; set; }
                 public DateTime? DataNascimento { get; set; }
                 public string Sexo { get; set; }
                 public string Turno { get; set; }
                 public string Email { get; set; }
                 public string Senha { get; set; }
                 */

                /*
                CREATE TABLE Funcionario(
                id_fun int primary key auto_increment,
                nome_fun varchar(100),
                cpf_fun varchar(100),
                rg_fun varchar(100),
                endereco_fun varchar(100),
                telefone_fun varchar(100),
                dataNascimento_fun date,
                sexo_fun varchar(100),
                turno_fun varchar(100),
                email_fun varchar(100), 
                senha_fun varchar(100)
                */


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public List<Funcionario> List()
        {
            try
            {
                var lista = new List<Funcionario>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Obras";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new Funcionario();


                    livro.Id = reader.GetInt32("id_obra");
                    livro.TituloObra = DAOHelper.GetString(reader, "titulo_obra");
                    livro.AutorObra = DAOHelper.GetString(reader, "autor_obra");
                    livro.DataPublicacao = DAOHelper.GetDateTime(reader, "dataPublicacao_obra");
                   
                    livro.EdicaoObra = DAOHelper.GetString(reader, "edicao_obra");
                    livro.SinopseObra = DAOHelper.GetString(reader, "sinopse_obra");

                    funcionario.Id = reader.GetInt32("id_obra");
                    funcionario.TituloObra = DAOHelper.GetString(reader, "titulo_obra");
                    funcionario.AutorObra = DAOHelper.GetString(reader, "autor_obra");
                    funcionario.DataPublicacao = DAOHelper.GetDateTime(reader, "dataPublicacao_obra");
                    funcionario.LocalizacaoObra = DAOHelper.GetString(reader, "localizacao_obra");
                    funcionario.EdicaoObra = DAOHelper.GetString(reader, "edicao_obra");
                    funcionario.SinopseObra = DAOHelper.GetString(reader, "sinopse_obra");



                    lista.Add(funcionario);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public void Delete(Funcionario funcionario)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Obras  WHERE id_obra = @id";

                comando.Parameters.AddWithValue("@id", funcionario.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Curso set " +
               "titulo_obra = @titulo, autor_obra = @autor, dataPublicacao_obra = @data, localizacao_obra = @localizacao, edicao_obra = @edicao, sinopse_obra = @sinopse" + " where id_cur = @id";


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
