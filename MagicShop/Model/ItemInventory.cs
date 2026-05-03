namespace MagicShop.Model
{
    internal class ItemInventory
    {
        public int MaxStack { get; }
        private int _quantity;
        public Item Item { get; }

        public int Quantity
        {
            get => _quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La quantita non puo essere inferiore a 0");
                }
                else
                {
                    _quantity = value;
                }
            }
        }

        public ItemInventory(Item item, int quantity, int maxStack)
        {
            ArgumentNullException.ThrowIfNull(item);
            Item = item;

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxStack);
            MaxStack = maxStack;

            if (quantity > MaxStack ||
                quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            Quantity = quantity;
        }

        public ItemInventory(Item item, int quantity) : this(item, quantity, 10)
        {
        }

        public ItemInventory(Item item) : this(item, 1, 10)
        {
        }

        private bool CanAddQuantity(int addingQuantity)
        {
            if (addingQuantity <= 0) return false;
            if ((Quantity + addingQuantity) > MaxStack) return false;

            return true;
        }

        private bool CanRemoveQuantity(int removingQuantity)
        {
            if (removingQuantity <= 0) return false;
            if (Quantity < removingQuantity) return false;

            return true;
        }

        public bool TryAddQuantity(int addingQuantity)
        {
            if (CanAddQuantity(addingQuantity))
            {
                Quantity += addingQuantity;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryRemoveQuantity(int removingQuantity)
        {
            if (CanRemoveQuantity(removingQuantity))
            {
                Quantity -= removingQuantity;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Item.Name} - x{Quantity}";
        }
    }
}