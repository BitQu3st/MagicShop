using MagicShop.Database;
using MagicShop.Model;
using MagicShop.UX;

namespace MagicShop.Test
{
    internal static class TestLogin
    {
        public static async Task Main()
        {
            try
            {
                DatabaseManager db = new();
                User user = await LoginUX.RunAsync(db);

                if (user != null)
                {
                    Console.WriteLine($"{user.Username} loggato con Successo!");
                }
                else
                {
                    Console.WriteLine("Login fallito!");
                }
            } catch (IOException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRORE: File appsettings.json non trovato!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ReadKey();
            }
            
            }
    }
}