using MagicShop.Database;
using MagicShop.Model;
using MagicShop.Service;

namespace MagicShop.UX
{
    internal static class LoginUX
    {
        public static async Task<User> RunAsync(DatabaseManager db)
        {
            string? username;
            string? password;
            User? user = null;

            while (user == null)
            {
                Console.WriteLine("---Login---");
                Console.Write("Username: ");
                username = Console.ReadLine() ?? "";

                Console.Write("Password: ");
                password = Console.ReadLine() ?? "";

                Console.WriteLine("\nAttendere prego...");
                user = await AuthService.LoginAsync(username, password, db);

                if (user == null)
                {
                    LoginErrorPause();
                }
            }

            return user;
        }

        private static void Pause()
        {
            Console.Write("\nPremi un tasto per continuare...");
            Console.ReadKey(true);
        }

        private static void LoginErrorPause()
        {
            Console.Clear();
            Console.WriteLine("Username o password errati. Riprova.");
            Pause();
            Console.Clear();
        }
    }
}