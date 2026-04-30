using MagicShop.Database;
using MagicShop.Model;
using MagicShop.Service;

namespace MagicShop.UX
{
    internal static class UserCreationUX
    {
        public static async Task<User> RunAsync(DatabaseManager db)
        {
            string username = await RequestAvailableUsernameAsync(db);

            Console.Clear();

            string password = RequestValidPassword();
            Console.WriteLine("\nAttendere prego...");
            return await AuthService.CreateUserAsync(db, username, password);
        }

        //Metodo che richiede all utente l immisione di uno username e
        //verifica che vengano rispettati i requisiti dello username
        //e che lo username non esista gia nel Database
        private static async Task<string> RequestAvailableUsernameAsync(DatabaseManager db)
        {
            string? username = "";
            bool isVerified = false;
            do
            {
                Console.Write("Inserisci Username: ");
                username = Console.ReadLine() ?? "";

                isVerified = AuthService.VerifyUsername(username);
                if (!isVerified)
                {
                    Console.WriteLine("Username non valido. Riprova.");
                    Pause();
                }

                if (isVerified)
                {
                    Console.WriteLine("\nAttendere prego...");

                    if (await AuthService.VerifyExistUsernameAsync(username, db))
                    {
                        Console.Clear();
                        Console.WriteLine("Utente gia presente. Riprova.");
                        isVerified = false;
                        Pause();
                        Console.Clear();
                    }
                }
            } while (!isVerified);

            return username;
        }

        private static string RequestValidPassword()
        {
            string password = "";
            bool isVerified = false;
            do
            {
                Console.Write("Inserisci Password: ");
                password = Console.ReadLine() ?? "";

                isVerified = AuthService.VerifyPassword(password);
                if (!isVerified)
                {
                    Console.WriteLine("Password non valida. Riprova.");
                    Pause();
                    Console.Clear();
                }
            } while (!isVerified);

            return password;
        }

        private static void Pause()
        {
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey(true);
        }
    }
}