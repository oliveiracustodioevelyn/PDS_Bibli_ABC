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

                comando.CommandText = "INSERT INTO  Obras VALUES (null, @titulo_obra,  @dataPublicacao_obra, @num_exemplar_obra, @editora_obra, @num_paginas_obra, @autor_obra," +
                    "@genero_obra,@tipo_obra,@edicao_obra, @sinopse_obra, 0, 0, 0, 0);";

                comando.Parameters.AddWithValue("@titulo_obra", livro.TituloObra);
                comando.Parameters.AddWithValue("@dataPublicacao_obra", livro.DataPublicacao);
                comando.Parameters.AddWithValue("@num_exemplar_obra", livro.NumExemplar);
                comando.Parameters.AddWithValue("@editora_obra", livro.EditoraObra);
                comando.Parameters.AddWithValue("@num_paginas_obra", livro.NumPagina);
                comando.Parameters.AddWithValue("@autor_obra", livro.AutorObra);
                comando.Parameters.AddWithValue("@genero_obra", livro.Genero);
                comando.Parameters.AddWithValue("@tipo_obra", livro.Tipo);
                comando.Parameters.AddWithValue("@edicao_obra", livro.EdicaoObra);
                comando.Parameters.AddWithValue("@sinopse_obra", livro.SinopseObra);



                /*CREATE TABLE Obras(
cod_obra int primary key auto_increment,
titulo_obra varchar(100),
dataPublicacao_obra date,
num_exemplar_obra int,
editora_obra varchar(100),
num_paginas_obra int,
autor_obra varchar(100),
genero_obra varchar(100),
tipo_obra varchar(100),
edicao_obra varchar (100),
sinopse_obra varchar(100)
);*/







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

                comando.CommandText = "DELETE FROM Obras  WHERE cod_obra = @id";

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
               "num_paginas_obra = @numPagina, autor_obra = @autor, genero_obra = @genero, tipo_obra = @tipo, edicao_obra = @edicao, sinopse_obra = @sinopse" + " where cod_obra = @id";


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
