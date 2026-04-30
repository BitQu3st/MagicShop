using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            Item = item;

            if (maxStack <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxStack));
            }
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
            return !(addingQuantity <= 0 ||
                (Quantity + addingQuantity) > MaxStack);
        }

        private bool CanRemoveQuantity(int removingQuantity)
        {
            return !(removingQuantity <= 0 ||
                (Quantity - removingQuantity) < 0);
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
    }
}