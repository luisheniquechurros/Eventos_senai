using System;
using System.Collections.Generic;
using senai_eventos_api.Repository;
using senai_eventos_api.Models;
using MySql.Data.MySqlClient;
using static senai_eventos_api.Models.Pedidos;
namespace senai_eventos_api.DAO
{
    public class PedidoDAO
    {
        private MySqlConnection _connection;

        public PedidoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Pedido> GetAll()
        {
            List<Pedido> pedidos = new List<Pedido>();
            string query = "SELECT * FROM pedido";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Pedido pedido = new Pedido(); 
                        pedido.IdPedido = reader.GetInt32("id_pedido");
                        pedido.Data = reader.GetDateTime("data");
                        pedido.Total = reader.GetInt32("total");
                        pedido.Quantidade = reader.GetInt32("quantidade");
                        pedido.FormaPagamento = reader.GetString("forma_pegamento");
                        pedido.Status = reader.GetInt32("status");
                        pedido.ValidacaoId = reader.GetInt32("validacao_id_usuario");
                        pedido.UsuarioId = reader.GetInt32("usuario_id_usuario");
                        pedidos.Add(pedido); 
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro do MySql: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return pedidos;
        }

        public Pedido GetId(int id)
        {
            Pedido pedidos = new Pedido();

            string query = $"SELECT * FROM usuario WHERE id_pedido = {id}";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        pedidos.IdPedido = reader.GetInt32("id_pedido");
                        pedidos.Data = reader.GetDateTime("data");
                        pedidos.Total = reader.GetInt32("total");
                        pedidos.Quantidade = reader.GetInt32("quantidade");
                        pedidos.FormaPagamento = reader.GetString("forma_pagamento");
                        pedidos.Status = reader.GetInt32("status");
                        pedidos.ValidacaoId = reader.GetInt32("validacao_id_usuario");
                        pedidos.UsuarioId = reader.GetInt32("usuario_id_usuario");
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

            return pedidos;        
        }

        public void CriarPedido(Pedido pedidos)
        {
            string query = "INSERT INTO pedido (data, total, quantidade, forma_pagamento, status, validacao_id_usuario, usuario_id_usuario)"+
                            "VALUE (@data, @total, @quantidade, @forma_pagamento, @status, @validacao_id_usuario, @usuario_id_usuario)";

            
            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@data", pedidos.Data);
                    command.Parameters.AddWithValue("@total", pedidos.Total);
                    command.Parameters.AddWithValue("@quantidade", pedidos.Quantidade);
                    command.Parameters.AddWithValue("@forma_pagamento", pedidos.FormaPagamento);
                    command.Parameters.AddWithValue("@status", pedidos.Status);
                    command.Parameters.AddWithValue("@validacao_id_usuario", pedidos.ValidacaoId);
                    command.Parameters.AddWithValue("@usuario_id_usuario", pedidos.UsuarioId);
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

        public void AtualizarPedido(int id, Pedido pedidos)
        {
            string query = "UPDATE pedidos SET "+ 
                            "data=@data, " +
                            "total=@total, " +
                            "quantidade=@quantidade, " +
                            "forma_pagamento=@forma_pagamento, " +
                            "status=@status, " + 
                            "validacao_id_usuario=@validacao_id_usuario, " +
                            "usuario_id_usuario=@usuario_id_usuario " + 
                            "WHERE id_pedido=@id_pedido";
            
            try
            {
                _connection.Open();
                
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_pedido", id);
                    command.Parameters.AddWithValue("@data", pedidos.Data);
                    command.Parameters.AddWithValue("@total", pedidos.Total);
                    command.Parameters.AddWithValue("@quantidade", pedidos.Quantidade);
                    command.Parameters.AddWithValue("@forma_pagamento", pedidos.FormaPagamento);
                    command.Parameters.AddWithValue("@status", pedidos.Status);
                    command.Parameters.AddWithValue("@validacao_id_usuario", pedidos.ValidacaoId);
                    command.Parameters.AddWithValue("@usuario_id_usuario", pedidos.UsuarioId);
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

        public void DeletarPedido(int id)
        {
            string query = "DELETE FROM pedido WHERE IdPedido = @id_pedido";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_pedido", id);
                    command.ExecuteNonQuery();
                }
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
