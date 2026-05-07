using LojaVirtual.Interfaces;
using LojaVirtual.Models;
using MySql.Data.MySqlClient;

namespace LojaVirtual.Repository
{
    public class UserRepository : IUserRepository
    {
        // variável de leitura que recebe a string de conexâo
        private readonly string _connectionString;
        // construtor que recebe a string de conexâo obrigatóriamente
        public UserRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao")!;
        }
        // método para validr o login do usuário
        public LoginViewModel? Validar(string Email, string Senha)
        {
            // criando variável de conexão com o banco de dados MYSQL
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            // criando variável de comando SQl manual
            var sql = "select * from tbUsuario Where Email= @email";
            // criando variável de operação SQL
            var cmd = new MySqlCommand(sql, conn);
            // adicionando email digitado do usuário como parâmetro
            cmd.Parameters.AddWithValue("@email", Email);
            // criando reader do comando que junta tudo para executar
            using var reader = cmd.ExecuteReader();
            // condicional que verifica os dados digitados
            if (reader.Read())
            {
                // criando variável que lê a senha digitada como string
                string senhaBanco = reader["Senha"].ToString()!;
                // compara a senha digitada com a senha do banco de dados
                if (BCrypt.Net.BCrypt.Verify(Senha, senhaBanco))
                {
                    return new LoginViewModel
                    {
                        // retorna os dados do usuário para LoginViewModel
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        Nivel = reader["Nivel"].ToString()!
                    };
                }
                
            }
            return null;
        }
    }
}
