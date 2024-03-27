using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using senai_eventos_api.Models;
using senai_eventos_api.Repository;

namespace senai_eventos_api.DAO
{
    public class IngressoDAO
    {
        private MySqlConnection _connection;

        public IngressoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Ingresso> GetAll()
        {
            List<Ingresso> ingressos = new List<Ingresso>();

            string query = "SELECT * FROM bd_eventos_senai1.ingresso";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    Ingresso ingresso = new Ingresso();
                    while(reader.Read())
                    {
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.Valor = reader.GetString("valor");
                        ingresso.Status = reader.GetString("status");
                        ingresso.Tipo = reader.GetString("tipo");
                        ingresso.CodigoQr = reader.GetString("codigo_qr");
                        ingresso.DataUtilizacao = reader.GetDateTime("data_utilizacao");

                        ingressos.Add(ingresso);
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
            return ingressos;
        }

        public Ingresso GetId(int id)
        {
            Ingresso ingresso = new Ingresso();
            string query = $"SELECT * FROM bd_eventos_senai1.ingresso WHERE id_ingresso = {id}";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.Valor = reader.GetString("valor");
                        ingresso.Status = reader.GetString("status");
                        ingresso.Tipo = reader.GetString("tipo");
                        ingresso.CodigoQr = reader.GetString("codigo_qr");
                        ingresso.DataUtilizacao = reader.GetDateTime("data_utilizacao");
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
            return ingresso;
        }

        public void CriarIngresso(Ingresso ingresso)
        {
            string query = "INSERT INTO bd_eventos_senai1.ingresso (valor, status, tipo, codigo_qr, data_utilizacao)" +
                            "VALUES (@Valor, @Status, @Tipo, @CodigoQr, @DataUtilizacao)";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Valor", ingresso.Valor);
                    command.Parameters.AddWithValue("@Status", ingresso.Status);
                    command.Parameters.AddWithValue("@Tipo", ingresso.Tipo);
                    command.Parameters.AddWithValue("@CodigoQr", ingresso.CodigoQr);
                    command.Parameters.AddWithValue("@DataUtilizacao", ingresso.DataUtilizacao);
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

        public void AtualizarIngresso(int id, Ingresso ingresso)
        {
            string query = "UPDATE bd_eventos_senai1.ingresso SET" +
                            "valor=@Valor, " +
                            "status=@Status, " +
                            "tipo=@Tipo ," +
                            "codigo_qr=@CodigoQr ," +
                            "data_utilizacao=@DataUtilizacao ," +
                            "WHERE id_ingresso=@id_ingresso";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Valor", ingresso.Valor);
                    command.Parameters.AddWithValue("@Status", ingresso.Status);
                    command.Parameters.AddWithValue("@Tipo", ingresso.Tipo);
                    command.Parameters.AddWithValue("@CodigoQr", ingresso.CodigoQr);
                    command.Parameters.AddWithValue("@DataUtilizacao", ingresso.DataUtilizacao);
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

        public void DeletarIngresso(int id)
        {
            string query = "DELETE FROM bd_eventos_senai1.ingresso WHERE id_ingresso = @id_ingresso";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_ingresso", id);
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