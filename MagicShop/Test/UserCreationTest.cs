using MagicShop.Database;
using MagicShop.Model;
using MagicShop.Service;
using MagicShop.UX;
using MySqlConnector;

namespace MagicShop.Test
{
    internal static class UserCreationTest
    {
        public static async Task Main()
        {
            DatabaseManager db = new();

            //password che devo immettere per verificare hashing
            //commentare finito debugging
            string passwordDiVerifica = "verifica";

            User? user = null;

            while (user == null)
            {
                try
                {
                    user = await UserCreationUX.RunAsync(db);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (user != null)
                {
                    Console.WriteLine("Utente creato!");

                    Console.Write("Corrispondenza password plain vs Db: ");
                    Console.WriteLine(AuthService.VerifyPasswordHash(passwordDiVerifica, user.PasswordHash));
                }
            }
        }
    }
}