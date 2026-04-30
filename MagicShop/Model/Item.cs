using System;
using System.Collections.Generic;
using System.Text;

namespace MagicShop.Model
{
    internal class Item
    {
        public string Name { get; }
        public EnumRarity RarityVal { get; }
        public int BasePrice { get; }

        public Item(string name, EnumRarity rarityVal, int basePrice)
        {
            Name = name;
            RarityVal = rarityVal;
            BasePrice = basePrice;
        }
    }
}