using MagicShop.Database;
using MagicShop.Model;
using MagicShop.UX.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicShop.Test
{
    internal static class TestMenuIniziale
    {
        public static async Task Main()
        {
            try
            {
                DatabaseManager db = new();

                User? currentUser = await InitialMenuUX.RunAsync(db);
                Console.Clear();
                if (currentUser == null)
                {
                    Console.WriteLine("TestMenuIniziale: Hai deciso di uscire dal menu iniziale");
                }
                else
                {
                    Console.WriteLine("TestMenuIniziale: Sei riuscito a loggarti/creare un utente: " +
                        $"{currentUser.Username}");
                }

                Console.Write("\nPremi un tasto per terminare...");
                Console.ReadKey(true);
            }
            catch (FileNotFoundException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRORE: File appsettings.json non trovato!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\nPremi un tasto per continuare...");
                Console.ReadKey(true);
            }
        }
    }
}