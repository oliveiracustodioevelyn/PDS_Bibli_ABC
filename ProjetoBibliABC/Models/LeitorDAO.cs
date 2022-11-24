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
    internal class LeitorDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Leitor leitor)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Leitor VALUES (null, @nome,  @cpf, @rg, @email, @telefone," +
                    " @dataNascimento, @sexo, @rua, @bairro, @numero, @cep, @complemento, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nome", leitor.Nome);
                comando.Parameters.AddWithValue("@cpf", leitor.CPF);
                comando.Parameters.AddWithValue("@rg", leitor.RG);
                comando.Parameters.AddWithValue("@email", leitor.Email);
                comando.Parameters.AddWithValue("@telefone", leitor.Telefone);
                comando.Parameters.AddWithValue("@dataNascimento", leitor.DataNascimento?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", leitor.Sexo);
                
                comando.Parameters.AddWithValue("@rua", leitor.Rua);
                comando.Parameters.AddWithValue("@bairro", leitor.Bairro);
                comando.Parameters.AddWithValue("@numero", leitor.Numero);
                comando.Parameters.AddWithValue("@cep", leitor.Cep);
                comando.Parameters.AddWithValue("@complemento", leitor.Complemento);
                comando.Parameters.AddWithValue("@cidade", leitor.Cidade);
                comando.Parameters.AddWithValue("@estado", leitor.Estado);

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

        public List<Leitor> List()
        {
            try
            {
                var lista = new List<Leitor>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Leitor";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var leitor = new Leitor();

                    leitor.Id = reader.GetInt32("cod_lei");
                    leitor.Nome = DAOHelper.GetString(reader, "nome_lei");
                    leitor.CPF = DAOHelper.GetString(reader, "cpf_lei");
                    leitor.RG = DAOHelper.GetString(reader, "rg_lei");
                    leitor.Email = DAOHelper.GetString(reader, "email_lei");
                    
                    leitor.Telefone = DAOHelper.GetString(reader, "telefone_lei");
                    leitor.DataNascimento = DAOHelper.GetDateTime(reader, "dataNascimento_lei");
                    leitor.Sexo = DAOHelper.GetString(reader, "sexo_lei");
                    leitor.Rua = DAOHelper.GetString(reader, "rua_lei");
                    leitor.Bairro = DAOHelper.GetString(reader, "bairro_lei");
                    leitor.Numero = DAOHelper.GetString(reader, "numero_lei");
                    leitor.Cep = DAOHelper.GetString(reader, "cep_lei");
                    leitor.Complemento = DAOHelper.GetString(reader, "complemento_lei");
                    leitor.Cidade = DAOHelper.GetString(reader, "cidade_lei");
                    leitor.Estado = DAOHelper.GetString(reader, "estado_lei");

                    lista.Add(leitor);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Leitor leitor)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Leitor WHERE cod_lei = @id";

                comando.Parameters.AddWithValue("@id", leitor.Id);

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

        public void Update(Leitor leitor)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Leitor set nome_lei = @nome, cpf_lei = @cpf, rg_lei = @rg, email_lei = @email, telefone_lei = @telefone," +
                    " dataNascimento_lei = @dataNascimento, sexo_lei = @sexo, rua_lei = @rua, bairro_lei = @bairro, numero_lei = @numero, cep_lei = @cep," +
                    " complemento_lei = @complemento, cidade_lei = @cidade, estado_lei = @estado WHERE (cod_lei = @id)";

                comando.Parameters.AddWithValue("@id", leitor.Id);
                comando.Parameters.AddWithValue("@nome", leitor.Nome);
                comando.Parameters.AddWithValue("@cpf", leitor.CPF);
                comando.Parameters.AddWithValue("@rg", leitor.RG);
                comando.Parameters.AddWithValue("@email", leitor.Email);
                comando.Parameters.AddWithValue("@telefone", leitor.Telefone);
                comando.Parameters.AddWithValue("@dataNascimento", leitor.DataNascimento?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", leitor.Sexo);

                comando.Parameters.AddWithValue("@rua", leitor.Rua);
                comando.Parameters.AddWithValue("@bairro", leitor.Bairro);
                comando.Parameters.AddWithValue("@numero", leitor.Numero);
                comando.Parameters.AddWithValue("@cep", leitor.Cep);
                comando.Parameters.AddWithValue("@complemento", leitor.Complemento);
                comando.Parameters.AddWithValue("@cidade", leitor.Cidade);
                comando.Parameters.AddWithValue("@estado", leitor.Estado);

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
