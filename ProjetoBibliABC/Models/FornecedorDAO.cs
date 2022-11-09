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
    internal class FornecedorDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Editora VALUES (null, @razao_social, " +
                    "@nome_fantasia, @cnpj, @telefone1, @telefone2, @representante," +
                    "@email, @rua, @bairo, @numero, @cep, @complemento, @cidade, @estado);";

                comando.Parameters.AddWithValue("@razao_social", fornecedor.Razao_social);
                comando.Parameters.AddWithValue("@nome_fantasia", fornecedor.Nome_fantasia);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                /*comando.Parameters.AddWithValue("@telefone1", fornecedor.Telefone1);
                comando.Parameters.AddWithValue("@telefone2", fornecedor.Telefone2);
                comando.Parameters.AddWithValue("@representante", fornecedor.Representante);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
               
                comando.Parameters.AddWithValue("@rua", fornecedor.Rua);
                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@numero", fornecedor.Numero);
                comando.Parameters.AddWithValue("@cep", fornecedor.Cep);
                comando.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                comando.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@estado", fornecedor.Estado);*/



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

        /*public List<Livro>List ()
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
        }*/

        public void Delete(Livro livro)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Obras  WHERE cod_obra = @id";

                comando.Parameters.AddWithValue("@id", livro.Id);

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

        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update  fornecedor set " +
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
