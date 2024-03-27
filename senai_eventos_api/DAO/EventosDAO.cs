using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using senai_eventos_api.Repository;
using senai_eventos_api.Models;
using MySql.Data.MySqlClient;

namespace senai_eventos_api.DAO
{
    public class EventosDAO
    {
        private MySqlConnection _connection;

        public EventosDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Eventos> GetAll()
        {
            List<Eventos> eventos = new List<Eventos>();
            string query = "SELECT * FROM evento";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Eventos evento = new Eventos();
                        evento.IdEvento = reader.GetInt32("id_evento");
                        evento.DataEvento = reader.GetDateTime("data_evento");
                        evento.TotalIngressos = reader.GetInt32("total_ingressos");
                        evento.Descricao = reader.GetString("descricao");
                        eventos.Add(evento);
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro do MySQL: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return eventos;
        }

        public Eventos GetId(int id)
        {
            Eventos evento = new Eventos();

            string query = $"SELECT * FROM evento WHERE id_evento = {id}";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        evento.IdEvento = reader.GetInt32("id_evento");
                        evento.DataEvento = reader.GetDateTime("data_evento");
                        evento.TotalIngressos = reader.GetInt32("total_ingressos");
                        evento.Descricao = reader.GetString("descricao");
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no banco: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return evento;        
        }

        public void CriarEvento(Eventos evento)
        {
            string query = "INSERT INTO evento (data_evento, total_ingressos, descricao) "+
                           "VALUES (@data_evento, @total_ingressos, @descricao)";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@data_evento", evento.DataEvento);
                    command.Parameters.AddWithValue("@total_ingressos", evento.TotalIngressos);
                    command.Parameters.AddWithValue("@descricao", evento.Descricao);
                    command.ExecuteNonQuery();
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no banco: {ex.Message}");
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

        public void AtualizarEvento(int id, Eventos evento)
        {
            string query = "UPDATE evento SET "+ 
                           "data_evento=@data_evento, " +
                           "total_ingressos=@total_ingressos, " +
                           "descricao=@descricao " +
                           "WHERE id_evento=@id_evento";
            
            try
            {
                _connection.Open();
                
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_evento", id);
                    command.Parameters.AddWithValue("@data_evento", evento.DataEvento);
                    command.Parameters.AddWithValue("@total_ingressos", evento.TotalIngressos);
                    command.Parameters.AddWithValue("@descricao", evento.Descricao);
                    command.ExecuteNonQuery();
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no banco: {ex.Message}");
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

        public void DeletarEvento(int id)
        {
            string query = "DELETE FROM evento WHERE id_evento = @id_evento";

            try
            {
                _connection.Open();
                
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_evento", id);
                    command.ExecuteNonQuery();
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no banco: {ex.Message}");
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
    }
}
