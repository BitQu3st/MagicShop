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
        }

        //Metodo che stampa semplicemente il menu delle azioni disponibili dal utente
        private void PrintMenu()
        {
        }
    }
}