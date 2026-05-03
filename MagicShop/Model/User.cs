namespace MagicShop.Model

{
    public class User
    {
        private string _userName = "", _passwordHash = "";
        private int _gold;

        //TODO Implementare invetario una volta finita la classe Inventory
        private readonly Inventory inventory = new Inventory();

        public User(string userName, string passwordHash, int gold)
        {
            Username = userName;
            PasswordHash = passwordHash;
            Gold = gold;
        }

        public User(string userName, string passwordHash) : this(userName, passwordHash, 500)
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

        public bool TryAddGold(int gold)
        {
            if (gold <= 0) return false;

            Gold += gold;
            return true;
        }

        public bool TryRemoveGold(int gold)
        {
            if (gold <= 0) return false;
            if (Gold < gold) return false;

            Gold -= gold;
            return true;
        }
    }
}