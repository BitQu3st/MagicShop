using MagicShop.Model;
using MySqlConnector;

namespace MagicShop.Database.Repository
{
    internal class UserRepository
    {
        private readonly DatabaseManager _db;

        public UserRepository(DatabaseManager db)
        {
            _db = db;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            await using MySqlConnection conn = _db.GetConnection();
            await conn.OpenAsync();
            string query = @"INSERT INTO users" +
                    "(username,password_hash,gold)" +
                    "VALUES" +
                    "(@username,@password_hash,@gold);";

            await using MySqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password_hash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@gold", user.Gold);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        //metodo che ricerca un utente x nel db restituendo numero di row trovate
        //principalmente viene usato per evitare eccezioni quando si tenta di creare un nuovo utente
        //o semplicemente per vedere se esiste
        public async Task<bool> SearchUserAsync(string username)
        {
            using MySqlConnection conn = _db.GetConnection();
            await conn.OpenAsync();

            string query = @"SELECT COUNT(*) FROM users
                WHERE username = @username;";

            await using MySqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@username", username);

            var rows = await cmd.ExecuteScalarAsync();
            return (Convert.ToInt32(rows) > 0);
        }

        //Restituisce un oggetto user passando come parametro la stringa
        //che ne indentifica username salvato a db(NON verifica corrispondenza password)
        //di conseguenza non usare direttamente per login senza controlli adeguati
        //N.B. ho pensato di usare un dictionary un po come fa MySqlDataReader per non esporre al suo posto, fuori dal repository
        //un oggetto MysqlDataReader, meno problemi con db,chiusura del oggetto etc...
        public async Task<User?> GetUserAsync(string username)
        {
            await using MySqlConnection conn = _db.GetConnection();
            await conn.OpenAsync();

            string query = @"SELECT username,password_hash,gold " +
                "FROM users " +
                "WHERE username = @username";

            await using MySqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@username", username);

            using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

            User? user = null;
            if (await reader.ReadAsync())
            {
                user = new(
                 reader.GetString("username"),
                reader.GetString("password_hash"),
                reader.GetInt32("gold"));
            }

            return user;
        }
    }
}