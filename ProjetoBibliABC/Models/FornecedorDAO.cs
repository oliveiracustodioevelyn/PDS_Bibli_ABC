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
                    "@email, @rua, @bairro, @numero, @cep, @complemento, @cidade, @estado);";

                comando.Parameters.AddWithValue("@razao_social", fornecedor.Razao_social);
                comando.Parameters.AddWithValue("@nome_fantasia", fornecedor.Nome_fantasia);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@telefone1", fornecedor.Telefone1);
                comando.Parameters.AddWithValue("@telefone2", fornecedor.Telefone2);
                comando.Parameters.AddWithValue("@representante", fornecedor.Representante);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
               
                comando.Parameters.AddWithValue("@rua", fornecedor.Rua);
                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@numero", fornecedor.Numero);
                comando.Parameters.AddWithValue("@cep", fornecedor.Cep);
                comando.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                comando.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@estado", fornecedor.Estado);



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

        public List<Fornecedor> List ()
        {
            try
            {
                var lista = new List<Fornecedor>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Editora";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var fornecedor = new Fornecedor();

                    fornecedor.Id = reader.GetInt32("cod_edi");
                    fornecedor.Razao_social = DAOHelper.GetString(reader, "razaoSocial_edi");
                    fornecedor.Nome_fantasia = DAOHelper.GetString(reader, "nomeFantasia_edi");
                    fornecedor.Cnpj = DAOHelper.GetString(reader, "cnpj_edi");
                    fornecedor.Telefone1 = DAOHelper.GetString(reader, "telefone1_edi");
                    fornecedor.Telefone2 = DAOHelper.GetString(reader, "telefone2_edi");
                    fornecedor.Representante = DAOHelper.GetString(reader, "representante_edi");
                    fornecedor.Email = DAOHelper.GetString(reader, "email_edi");
                    fornecedor.Rua = DAOHelper.GetString(reader, "rua_edi");
                    fornecedor.Bairro = DAOHelper.GetString(reader, "bairro_edi");
                    fornecedor.Numero = DAOHelper.GetString(reader, "numero_edi");
                    fornecedor.Cep = DAOHelper.GetString(reader, "cep_edi");
                    fornecedor.Complemento = DAOHelper.GetString(reader, "complemento_edi");
                    fornecedor.Cidade = DAOHelper.GetString(reader, "cidade_edi");
                    fornecedor.Estado = DAOHelper.GetString(reader, "estado_edi");

                    lista.Add(fornecedor);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Fornecedor fornecedor)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Editora  WHERE cod_edi  = @id";

                comando.Parameters.AddWithValue("@id", fornecedor.Id);

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

                comando.CommandText = "Update  Editora set " +
               "razaoSocial_edi = @razao_social, nomeFantasia_edi = @nome_fantasia, cnpj_edi = @cnpj, telefone1_edi = @telefone1," +
               "telefone2_edi = @telefone2, representante_edi = @representante, email_edi = @email, rua_edi = @rua, bairro_edi = @bairro, " +
               "numero_edi = @numero, cep_edi  = @cep, complemento_edi = @complemento, cidade_edi = @cidade, estado_edi = @estado," + " where cod_edi  = @id";

                comando.Parameters.AddWithValue("@id", fornecedor.Id);
                comando.Parameters.AddWithValue("@razao_social", fornecedor.Razao_social);
                comando.Parameters.AddWithValue("@nome_fantasia", fornecedor.Nome_fantasia);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@telefone1", fornecedor.Telefone1);
                comando.Parameters.AddWithValue("@telefone2", fornecedor.Telefone2);
                comando.Parameters.AddWithValue("@representante", fornecedor.Representante);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);

                comando.Parameters.AddWithValue("@rua", fornecedor.Rua);
                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@numero", fornecedor.Numero);
                comando.Parameters.AddWithValue("@cep", fornecedor.Cep);
                comando.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                comando.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@estado", fornecedor.Estado);

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
