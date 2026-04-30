using MagicShop.Database;
using MagicShop.Model;

namespace MagicShop.UX.Menu
{
    internal static class InitialMenuUX
    {
        public static async Task<User?> RunAsync(DatabaseManager db)
        {
            int choose = 0;
            while (choose < 1 || choose > 3)
            {
                PrintMenu();
                Console.Write("Scelta: ");
                int.TryParse(Console.ReadLine(), out choose);
                Console.Clear();
            }

            return await ChooseAction(choose, db);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("---MENU---");
            Console.WriteLine("1 - Crea nuovo account");
            Console.WriteLine("2 - Login");
            Console.WriteLine("3 - Esci");
        }

        private static async Task<User?> ChooseAction(int choose, DatabaseManager db)
        {
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    return await UserCreationUX.RunAsync(db);

                case 2:
                    Console.Clear();
                    return await LoginUX.RunAsync(db);

                case 3:
                    Exit();
                    return null;

                default:
                    throw new ArgumentOutOfRangeException("Parametro scelta menu non valido");
            }
        }

        private static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Grazie, Torna presto...\n");
            Console.Write("Premi un tasto per continuare..");
            Console.ReadKey(true);
        }
    }
}