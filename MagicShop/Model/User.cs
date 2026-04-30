namespace MagicShop.Model

{
    public class User
    {
        private string _userName = "", _passwordHash = "";
        private int _gold;

        public User(string userName, string passwordHashed, int gold)
        {
            Username = userName;
            PasswordHash = passwordHashed;
            Gold = gold;
        }

        public User(string userName, string password) : this(userName, password, 500)
        { }

        //TODO: Da implementare quando creato classe inventario
        //private List<Inventory> _inventory;

        public int Gold
        {
            get => _gold;
            private set
            {
                if (value >= 0)
                {
                    _gold = value;
                }
                else
                {
                    throw new ArgumentException("gold cannot be negative");
                }
            }
        }

        public string Username
        {
            get => _userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("invalid username");
                }
                _userName = value;
            }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("invalid password");
                }
                _passwordHash = value;
            }
        }
    }
}