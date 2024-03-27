using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using senai_eventos_api.Models;
using senai_eventos_api.Repository;

namespace senai_eventos_api.DAO
{
    public class LoteDAO
    {
        private MySqlConnection _connection;

        public LoteDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Lote> GetAll()
        {
            List<Lote> lotes = new List<Lote>();

            string query = "SELECT * FROM bd_eventos_senai1.lote";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    Lote lote = new Lote();
                    while(reader.Read())
                    {
                        lote.IdLote = reader.GetInt32("id_lote");
                        lote.ValorUnitario = reader.GetDouble("valor_unitario");
                        lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                        lote.Saldo = reader.GetInt32("saldo");

                        lotes.Add(lote);
                    }
                }
            }
            catch(MySqlException ex)
            {
                //Mapeando os erros de banco
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch(Exception ex)
            {
                //Mapeando os erros geral
                Console.WriteLine($"Erro Descohecido: {ex.Message}");
            }
            finally
            {
                //Fecha a conexão com o banco
                _connection.Close();
            }
            return lotes;
        }

        public Lote GetId(int id)
        {
            Lote lote = new Lote();
            string query = $"SELECT * FROM bd_eventos_senai1.lote WHERE is_lote = {id}";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        lote.IdLote = reader.GetInt32("id_lote");
                        lote.ValorUnitario = reader.GetDouble("valor_unitario");
                        lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                        lote.Saldo = reader.GetInt32("saldo");
                    }
                }
            }
            catch(MySqlException ex)
            {
                //Mapeando os erros de banco
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch(Exception ex)
            {
                //Mapeando os erros geral
                Console.WriteLine($"Erro Descohecido: {ex.Message}");
            }
            finally
            {
                //Fecha a conexão com o banco
                _connection.Close();
            }
            return lote;
        }

        public void CriarLote(Lote lote)
        {
            string query = "INSERT INTO bd_eventos_senai1.lote (valor_unitario, quantidade_total, saldo)" +
                            "VALUES (@ValorUnitario, @QuantidadeTotal, @Saldo)";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@ValorUnitario", lote.ValorUnitario);
                    command.Parameters.AddWithValue("@QuntidadeTotal", lote.QuantidadeTotal);
                    command.Parameters.AddWithValue("@Saldo", lote.Saldo);
                    command.ExecuteNonQuery();
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AtualizarLote(int id, Lote lote)
        {
            string query = "UPDATE bd_eventos_senai1.lote SET" +
                            "valor_unitario=@ValorUnitario, " +
                            "quantidade_total=@QuantidadeTotal, " +
                            "saldo=@Saldo ," +
                            "WHERE id_lote=@id_lote";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@ValorUnitario", lote.ValorUnitario);
                    command.Parameters.AddWithValue("@QuntidadeTotal", lote.QuantidadeTotal);
                    command.Parameters.AddWithValue("@Saldo", lote.Saldo);
                    command.ExecuteNonQuery();
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletarLote(int id)
        {
            string query = "DELETE FROM bd_eventos_senai1.lote WHERE id_lote = @id_lote";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_lote", id);
                    command.ExecuteNonQuery();
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}