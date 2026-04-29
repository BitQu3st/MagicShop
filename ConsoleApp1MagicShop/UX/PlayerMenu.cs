using MagicShop.Database;
using MagicShop.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MagicShop.UX
{
    //Classe principale che gestisce l intero gioco(vendite,acquisti,visualizzazione inventario,etc...)
    internal class PlayerMenu
    {
        private readonly DatabaseManager _db;
        private User _currentUser;

        //Property che "espone" l user attuale del campo della classe.
        //il set lo uso piu che altro in previsione di aggiunta di feature di modifica del User(es. cambio username)

        public User CurrentUser
        {
            get => _currentUser; private set => _currentUser = value;
        }

        public PlayerMenu(User user, DatabaseManager db)
        {
            _db = db;
            CurrentUser = user;
        }

        //Metodo che stampa il menu e lancia esecuzione delle varie feature
        //Attualmente ritorna un void...vedro con l evolversi del software se necessita
        //di restituire qualcosa.
        public async Task RunAsync()
        {
            Console.WriteLine($"Benvenuto {CurrentUser.Username}," +
                $" hai {CurrentUser.Gold} gold.\n");
            bool isContinue = true;
            while (isContinue)
            {
                int menuChoose = 0;
                do
                {
                    Console.Clear();
                    PrintMenu();
                    Console.Write("Scegli: ");
                    int.TryParse(Console.ReadLine(), out menuChoose);
                } while (menuChoose < 1 || menuChoose > 6);

                Console.Clear();
                isContinue = await ChooseActionAsync(menuChoose);
            }
        }

        //Metodo che stampa semplicemente il menu delle azioni disponibili dal utente
        private void PrintMenu()
        {
            Console.WriteLine($"---Azioni di {CurrentUser.Username}---\n");
            Console.WriteLine("1 - Visualizza gold");
            Console.WriteLine("2 - Visualizza inventario");
            Console.WriteLine("3 - Tuo negozio");
            Console.WriteLine("4 - Acquista oggetto");
            Console.WriteLine("5 - Giorno seguente");
            Console.WriteLine("6 - Salva e esci");
        }

        //Metodo che orchestra tutte le interazioni del personaggio avviando
        //le varie azioni disponibili.
        //restituisce True se sceglie un azione
        //restituisce False quando giocatore decide di salvare e uscire per poter gestire logica do while
        //del ciclo di gioco
        private async Task<bool> ChooseActionAsync(int choose)
        {
            Console.Clear();

            bool IsContinue = true;

            switch (choose)
            {
                case 1:
                    GetGoldAction();
                    break;

                case 2:
                    //TODO: DA FARE
                    break;

                case 3:
                    //TODO: DA FARE
                    break;

                case 4:
                    //TODO: DA FARE
                    break;

                case 5:
                    //TODO: DA FARE
                    break;

                case 6:
                    ////TODO: DA FARE (implementare salvataggio)
                    IsContinue = false;
                    break;
            }

            return IsContinue;
        }

        //Metodo che semplicemente pulisce lo schermo e stampa i gold posseduti
        //dal utente corrente
        private void GetGoldAction()
        {
            Console.WriteLine($"Attualmente hai: {CurrentUser.Gold} gold\n");
            Console.Write("Premi un tasto per continuare...");
            Console.ReadKey(true);
        }
    }
}