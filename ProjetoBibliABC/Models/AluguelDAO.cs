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
    internal class AluguelDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Aluguel aluguel)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Aluguel VALUES (null, @dataAluguel, " +
                    "@dataDevolucao, @idFuncionario, @idLeitor, @idObra);";

                comando.Parameters.AddWithValue("@dataAluguel", aluguel.DataAluguel);
                comando.Parameters.AddWithValue("@dataDevolucao", aluguel.DataDevolucao);
                comando.Parameters.AddWithValue("@idFuncionario", aluguel.Funcionario);
                comando.Parameters.AddWithValue("@idLeitor", aluguel.Leitor);
                comando.Parameters.AddWithValue("@idObra", aluguel.Livro);
                



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

        public List<Aluguel> List()
        {
            try
            {
                var lista = new List<Aluguel>();
                var comando = _conn.Query();

                comando.CommandText = "select " +
                    "cod_obra as 'Codigo do Livro', " +
                    "titulo_obra as 'Titulo do Livro', " +
                    "id_fun as 'Codigo Funcionario', " +
                    "nome_fun as 'Nome do Funcionario', " +
                    "cod_lei as 'Codigo do Leitor', " +
                    "nome_lei as 'Nome do Leitor', " +
                    "id_alu as 'Codigo do Aluguel' " +
                    "from " +
                    "Obras, Funcionario, Leitor, Aluguel " +
                    "where (Aluguel.id_fun_fk = Funcionario.id_fun) and (Leitor.cod_lei = Aluguel.cod_lei_fk) and (Aluguel.cod_obra_fk = Obras.cod_obra); ";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var aluguel = new Aluguel();

                    aluguel.Id = reader.GetInt32("id_alu ");
                    aluguel.DataAluguel = DAOHelper.GetDateTime(reader, "dataAluguel_alu");
                    aluguel.DataDevolucao = DAOHelper.GetDateTime(reader, "dataDevolucao_alu");
                    //aluguel.Funcionario = reader.GetInt32("id_fun_fk");
                    //aluguel.Leitor = reader.GetInt32("cod_lei_fk");
                    //aluguel.Livro = reader.GetInt32("cod_obra_fk");

                    lista.Add(aluguel);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Aluguel aluguel)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Aluguel WHERE cod_edi  = @id";

                comando.Parameters.AddWithValue("@id", aluguel.Id);

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

        public void Update(Aluguel aluguel)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Aluguel SET dataAluguel_alu = @dataAluguel, dataDevolucao_alu = @dataDevolucao," +
                    " id_fun_fk = @idFuncionario, cod_lei_fk = @idLeitor, cod_obra_fk = @idObra  WHERE (id_alu = @id)";

                comando.Parameters.AddWithValue("@id", aluguel.Id);
                comando.Parameters.AddWithValue("@dataAluguel", aluguel.DataAluguel);
                comando.Parameters.AddWithValue("@dataDevolucao", aluguel.DataDevolucao);
                comando.Parameters.AddWithValue("@idFuncionario", aluguel.Funcionario);
                comando.Parameters.AddWithValue("@idLeitor", aluguel.Leitor);
                comando.Parameters.AddWithValue("@idObra", aluguel.Livro);


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
