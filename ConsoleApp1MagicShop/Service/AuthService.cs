using MagicShop.Database;
using MySqlConnector;
using BCrypt.Net;
using MagicShop.Model;
using MagicShop.UX;
using MagicShop.Database.Repository;

namespace MagicShop.Service
{
    public static class AuthService
    {
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyHashPassword(string password, string password_hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, password_hashed);
        }

        public static bool VerifyUsername(string? username)
        {
            return !string.IsNullOrWhiteSpace(username) && username.Length >= 3;
        }

        public static bool VerifyPassword(string? password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }

        public static async Task<User> CreateUserAsync(DatabaseManager db, string username, string password)
        {
            UserRepository repository = new(db);
            User user;

            string hashPassword = HashPassword(password);
            user = new(username, hashPassword);
            bool isCreated = await repository.CreateUserAsync(user);

            if (!isCreated)
            {
                throw new Exception("Errore creazione utente");
            }
            return user;
        }

        //Metodo per verificare se un dato username esiste
        public static async Task<bool> VerifyExistUsernameAsync(string username, DatabaseManager db)
        {
            if (await new UserRepository(db)
                .SearchUserAsync(username) > 0)
            {
                return true;
            }

            return false;
        }

        public static async Task<User?> LoginAsync(string username, string password, DatabaseManager db)
        {
            UserRepository repository = new(db);
            User? user;
            if (await VerifyExistUsernameAsync(username, db))
            {
                user = await repository.GetUserAsync(username);

                if (user != null &&
                    !string.IsNullOrWhiteSpace(user.PasswordHash) &&
                    VerifyHashPassword(password, user.PasswordHash))

                {
                    return user;
                }
            }

            return user = null;
        }
    }
}