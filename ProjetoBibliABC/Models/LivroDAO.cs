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
    internal class LivroDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Livro livro)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Curso VALUES (null, @titulo_obra,  @autor_obra, @dataPublicacao_obra, @localizacao_obra, @edicao_obra, @sinopse_obra);";

                comando.Parameters.AddWithValue("@titulo_obra", livro.TituloObra);
                comando.Parameters.AddWithValue("@autor_obra", livro.AutorObra);
                comando.Parameters.AddWithValue("@dataPublicacao_obra", livro.DataPublicacao);
                comando.Parameters.AddWithValue("@localizacao_obra", livro.LocalizacaoObra);
                comando.Parameters.AddWithValue("@edicao_obra", livro.EdicaoObra);
                comando.Parameters.AddWithValue("@sinopse_obra", livro.SinopseObra);

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

        public List<Livro>List ()
        {
            try
            {
                var lista = new List<Livro>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Obras";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var livro = new Livro();

                    livro.Id = reader.GetInt32("id_obra");
                    livro.TituloObra = DAOHelper.GetString(reader, "titulo_obra");
                    livro.AutorObra = DAOHelper.GetString(reader, "autor_obra");
                    livro.DataPublicacao = DAOHelper.GetDateTime(reader, "dataPublicacao_obra");
                    livro.LocalizacaoObra = DAOHelper.GetString(reader, "localizacao_obra");
                    livro.EdicaoObra = DAOHelper.GetString(reader, "edicao_obra");
                    livro.SinopseObra = DAOHelper.GetString(reader, "sinopse_obra");
                   

                    lista.Add(livro);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Livro livro)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Obras  WHERE id_obra = @id";

                comando.Parameters.AddWithValue("@id",livro.Id);

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

        public void Update(Livro livro)
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
