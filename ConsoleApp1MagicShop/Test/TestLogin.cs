using System;
using System.Collections.Generic;
using System.Text;
using MagicShop.Database;
using MagicShop.Model;
using MagicShop.UX;

namespace MagicShop.Test
{
    internal static class TestLogin
    {
        public static async Task Main()
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
        }
    }
}