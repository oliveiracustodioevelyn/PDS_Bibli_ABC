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


                comando.CommandText = "INSERT INTO Funcionario VALUES (null, @nome,  @cpf, @rg, @sexo, @telefone1, " +
                    "@telefone2, @dataNascimento, @email, @senha, @rua, @bairro, @numero, @complemento, @cidade, @estado);";

                
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@telefone1", funcionario.Telefone1);
                comando.Parameters.AddWithValue("@telefone2", funcionario.Telefone2);
                comando.Parameters.AddWithValue("@dataNascimento", funcionario.DataNascimento?.ToString("yyyy-MM-dd"));
                
                //comando.Parameters.AddWithValue("@turno_fun", funcionario.Turno);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@senha", funcionario.Senha);
                comando.Parameters.AddWithValue("@rua", funcionario.Rua);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@numero", funcionario.Numero);
                comando.Parameters.AddWithValue("@complemento", funcionario.Complemento);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);




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

                comando.CommandText = "SELECT * FROM Funcionario";

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

                comando.CommandText = "DELETE FROM Funcionario  WHERE id_fun = @id";

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

                comando.CommandText = "Update Funcionario set " +
               "nome_fun = @nome,  cpf_fun = @cpf, rg_fun = @rg, sexo_fun = @sexo, telefone1_fun = @telefone1, telefone2_fun = @telefone2, dataNascimento_fun = @dataNascimento, email_fun = @email, senha_fun = @senha, rua_fun = @rua, bairo_fun = @bairo, numero_fun = @numero, complemento_fun = @complemento, cidade_fun = @cidade, estado_fun = @estado" + "where id_fun = @id";

                comando.Parameters.AddWithValue("@id", funcionario.Id);
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@telefone1", funcionario.Telefone1);
                comando.Parameters.AddWithValue("@telefone2", funcionario.Telefone2);
                comando.Parameters.AddWithValue("@dataNascimento", funcionario.DataNascimento?.ToString("yyyy-MM-dd"));

                //comando.Parameters.AddWithValue("@turno_fun", funcionario.Turno);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@senha", funcionario.Senha);
                comando.Parameters.AddWithValue("@rua", funcionario.Rua);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@numero", funcionario.Numero);
                comando.Parameters.AddWithValue("@complemento", funcionario.Complemento);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);

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
