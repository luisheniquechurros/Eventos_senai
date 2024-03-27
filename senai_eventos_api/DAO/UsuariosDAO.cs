using System;
using System.Collections.Generic;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MySql.Data.MySqlClient;
using senai_eventos_api.Repository;

namespace senai_eventos_api.DAO
{
    public class UsuariosDAO
    {
        private MySqlConnection _connection;

        public UsuariosDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }


        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM usuario";

            
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = reader.GetInt32("id_usuario");
                        usuario.NomeCompleto = reader.GetString("nome_completo");
                        usuario.Email = reader.GetString("email");
                        usuario.Senha = reader.GetInt32("senha");
                        usuario.Telefone = reader.GetInt32("telefone");
                        usuario.Perfil = reader.GetString("perfil");
                        usuario.Status = reader.GetString("status");
                        usuarios.Add(usuario);
                    };
                    
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro no banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return usuarios;
        }
            
   

        public Usuario GetId(int id)
        {
            Usuario usuario = new Usuario();

            string query = $"SELECT * FROM usuario WHERE id_usuario = {id}";
            
                try
                {
                    _connection.Open();
                    MySqlCommand command = new MySqlCommand(query, _connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            usuario.IdUsuario = reader.GetInt32("id_usuario");
                            usuario.NomeCompleto = reader.GetString("nome_completo");
                            usuario.Email = reader.GetString("email");
                            usuario.Senha = reader.GetInt32("senha");
                            usuario.Telefone = reader.GetInt32("telefone");
                            usuario.Perfil = reader.GetString("perfil");
                            usuario.Status = reader.GetString("status");
                            
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erro no banco: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro Desconhecido: {ex.Message}");
                }
                return usuario;
        }
        public void CriarUsuario(Usuario usuarios)
        {
            string query = "INSERT INTO usuario (nome_completo, email, senha, telefone, perfil, status)"+
                            "VALUE (@nome_completo, @email, @senha, @telefone, @perfil, @status)";

            
            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@nome_completo", usuarios.NomeCompleto);
                    command.Parameters.AddWithValue("@email", usuarios.Email);
                    command.Parameters.AddWithValue("@senha", usuarios.Senha);
                    command.Parameters.AddWithValue("@telefone", usuarios.Telefone);
                    command.Parameters.AddWithValue("@perfil", usuarios.Perfil);
                    command.Parameters.AddWithValue("@status", usuarios.Status);
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

        public void AtualizarUsuario(int id, Usuario usuarios)
        {
            string query = "UPDATE usuarios SET "+ 
                            "nome_completo=@nome_completo, " +
                            "email=@email, " +
                            "senha=@senha, " +
                            "telefone=@telefone, " +
                            "perfil=@perfil, " +
                            "status=@status " +
                            "WHERE id_usuario=@id_usuario";
            
            try
            {
                _connection.Open();
                
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_usuario", id);
                    command.Parameters.AddWithValue("@nome_completo", usuarios.NomeCompleto);
                    command.Parameters.AddWithValue("@email", usuarios.Email);
                    command.Parameters.AddWithValue("@senha", usuarios.Senha);
                    command.Parameters.AddWithValue("@telefone", usuarios.Telefone);
                    command.Parameters.AddWithValue("@perfil", usuarios.Perfil);
                    command.Parameters.AddWithValue("@status", usuarios.Status);
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

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM usuario WHERE id_usuario = @id_usuario";

            try
            {
                _connection.Open();
                
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_usuario", id);
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

    

    internal class _connection
    {
        public static void Close()
        {
        }

        public static void Open()
        {
        }
    }
}
