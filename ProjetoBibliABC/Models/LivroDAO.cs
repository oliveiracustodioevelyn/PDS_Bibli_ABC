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

                comando.CommandText = "INSERT INTO  Obras VALUES (null, @titulo,  @dataPublicacao, " +
                    "@num_exemplar, @editora, @num_paginas, @autor," +
                    "@genero, @tipo, @edicao, @sinopse);";

                comando.Parameters.AddWithValue("@titulo", livro.TituloObra);
                comando.Parameters.AddWithValue("@dataPublicacao", livro.DataPublicacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@num_exemplar", livro.NumExemplar);
                comando.Parameters.AddWithValue("@editora", livro.EditoraObra);
                comando.Parameters.AddWithValue("@num_paginas", livro.NumPagina);
                comando.Parameters.AddWithValue("@autor", livro.AutorObra);
                comando.Parameters.AddWithValue("@genero", livro.Genero);
                comando.Parameters.AddWithValue("@tipo", livro.Tipo);
                comando.Parameters.AddWithValue("@edicao", livro.EdicaoObra);
                comando.Parameters.AddWithValue("@sinopse", livro.SinopseObra);

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

                    livro.Id = reader.GetInt32("cod_obra");
                    livro.TituloObra = DAOHelper.GetString(reader, "titulo_obra");
                    livro.DataPublicacao = DAOHelper.GetDateTime(reader, "dataPublicacao_obra");
                    livro.NumExemplar = reader.GetInt32("num_exemplar_obra");
                    livro.EditoraObra = DAOHelper.GetString(reader, "editora_obra");
                    livro.NumPagina = reader.GetInt32("num_paginas_obra");
                    livro.AutorObra = DAOHelper.GetString(reader, "autor_obra");
                    livro.Genero = DAOHelper.GetString(reader,"genero_obra");
                    livro.Tipo = DAOHelper.GetString(reader, "tipo_obra");
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

                comando.CommandText = "DELETE FROM Obras WHERE cod_obra = @id";

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

                comando.CommandText = "Update  Obras set " +
               "titulo_obra = @titulo, dataPublicacao_obra = @data, num_exemplar_obra = @numExemplar, editora_obra = @editora," +
               "num_paginas_obra = @numPagina, autor_obra = @autor, genero_obra = @genero, tipo_obra = @tipo, " +
               "edicao_obra = @edicao, sinopse_obra = @sinopse" + " where cod_obra = @id";

                comando.Parameters.AddWithValue("@id", livro.Id);
                comando.Parameters.AddWithValue("@titulo", livro.TituloObra);
                comando.Parameters.AddWithValue("@dataPublicacao", livro.DataPublicacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@num_exemplar", livro.NumExemplar);
                comando.Parameters.AddWithValue("@editora", livro.EditoraObra);
                comando.Parameters.AddWithValue("@num_paginas", livro.NumPagina);
                comando.Parameters.AddWithValue("@autor", livro.AutorObra);
                comando.Parameters.AddWithValue("@genero", livro.Genero);
                comando.Parameters.AddWithValue("@tipo", livro.Tipo);
                comando.Parameters.AddWithValue("@edicao", livro.EdicaoObra);
                comando.Parameters.AddWithValue("@sinopse", livro.SinopseObra);

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
