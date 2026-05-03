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

        public static bool VerifyPasswordHash(string password, string password_hashed)
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
        //richiama per ora il metodo dal repository ma da tenere in caso
        //si debbano aggiungere ulteriori controlli...
        public static async Task<bool> VerifyExistUsernameAsync(string username, DatabaseManager db)
        {
            return (await new UserRepository(db)
                 .SearchUserAsync(username));
        }

        public static async Task<User?> LoginAsync(string username, string password, DatabaseManager db)
        {
            UserRepository repository = new(db);
            User? user = await repository.GetUserAsync(username);

            if (user != null &&
                !string.IsNullOrWhiteSpace(user.PasswordHash) &&
                VerifyPasswordHash(password, user.PasswordHash))

            {
                return user;
            }

            return null;
        }
    }
}