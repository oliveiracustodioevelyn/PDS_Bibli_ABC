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

                comando.CommandText = "INSERT INTO Leitor VALUES (null, @nome_lei,  @cpf_lei, @email_lei, @rg_lei, @endereco_lei, @telefone_lei, @dataNascimento_lei, @sexo_lei);";

                comando.Parameters.AddWithValue("@nome_lei", leitor.Nome);
                comando.Parameters.AddWithValue("@cpf_lei", leitor.CPF);
                comando.Parameters.AddWithValue("@email_lei", leitor.Email);
                comando.Parameters.AddWithValue("@rg_lei", leitor.RG);
                comando.Parameters.AddWithValue("@endereco_lei", leitor.Endereco);
                comando.Parameters.AddWithValue("@telefone_lei", leitor.Telefone);
                comando.Parameters.AddWithValue("@dataNascimento_lei", leitor.DataNascimento?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo_lei", leitor.Sexo);

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

        /*public List<Livro> List()
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

                    leitor.Id = reader.GetInt32("id_lei");
                    leitor.Nome = DAOHelper.GetString(reader, "nome_lei");
                    leitor.CPF = DAOHelper.GetString(reader, "cpf_lei");
                    leitor.Email = DAOHelper.GetString(reader, "email_lei");
                    leitor.RG = DAOHelper.GetString(reader, "rg_lei");
                    leitor.Endereco = DAOHelper.GetString(reader, "endereco_lei");
                    leitor.Telefone = DAOHelper.GetString(reader, "telefone_lei");
                    leitor.DataNascimento = DAOHelper.GetDateTime(reader, "dataNascimento_lei");
                    leitor.Sexo = DAOHelper.GetString(reader, "sexo_lei");


                    lista.Add(leitor);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public void Delete(Leitor leitor)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Leitor  WHERE id_lei = @id";

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

                comando.CommandText = "Update Leitor set " +
               "nome_lei = @nome_lei, cpf_lei = @cpf_lei, email_lei = @email_lei, rg_lei = @rg_lei, endereco_lei = @endereco_lei, telefone_lei = @telefone_lei, dataNascimento_lei = @dataNascimento_lei, sexo_lei = @sexo_lei" + " where id_lei = @id";


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
