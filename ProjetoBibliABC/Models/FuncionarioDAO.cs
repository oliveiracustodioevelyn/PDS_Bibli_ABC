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

        public List<Funcionario> List()
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


                    funcionario.Id = reader.GetInt32("id_fun");
                    funcionario.Nome = DAOHelper.GetString(reader, "nome_fun");
                    funcionario.CPF = DAOHelper.GetString(reader, "cpf_fun");
                    funcionario.RG = DAOHelper.GetString(reader, "rg_fun");
                    funcionario.Sexo = DAOHelper.GetString(reader, "sexo_fun");
                    funcionario.Telefone1 = DAOHelper.GetString(reader, "telefone1_fun");
                    funcionario.Telefone2 = DAOHelper.GetString(reader, "telefone2_fun");
                    funcionario.DataNascimento = DAOHelper.GetDateTime(reader, "dataNascimento_fun");
                    funcionario.Email = DAOHelper.GetString(reader, "email_fun");
                    funcionario.Senha = DAOHelper.GetString(reader, "senha_fun");
                    funcionario.Rua = DAOHelper.GetString(reader, "rua_fun");
                    funcionario.Bairro = DAOHelper.GetString(reader, "bairro_fun");
                    funcionario.Numero = DAOHelper.GetString(reader, "numero_fun");
                    funcionario.Complemento = DAOHelper.GetString(reader, "complemento_fun");
                    funcionario.Cidade = DAOHelper.GetString(reader, "cidade_fun");
                    funcionario.Estado = DAOHelper.GetString(reader, "estado_fun");


                    lista.Add(funcionario);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
               "nome_fun = @nome,  cpf_fun = @cpf, rg_fun = @rg, sexo_fun = @sexo, telefone1_fun = @telefone1, telefone2_fun = @telefone2, " +
               "dataNascimento_fun = @dataNascimento, email_fun = @email, senha_fun = @senha, rua_fun = @rua, bairo_fun = @bairo, numero_fun = @numero," +
               " complemento_fun = @complemento, cidade_fun = @cidade, estado_fun = @estado" + "where id_fun = @id";

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
