namespace MagicShop.Model
{
    internal class Inventory
    {
        private readonly List<ItemInventory> _itemInventoryList;
        public IReadOnlyList<ItemInventory> ItemInventoryList => _itemInventoryList;

        public Inventory()
        {
            _itemInventoryList = new();
        }

        public Inventory(ItemInventory item) : this()
        {
            _itemInventoryList.Add(item);
        }

        public Inventory(Item item) : this(new ItemInventory(item))
        {
        }

        public Inventory(List<ItemInventory> itemInventoryList) : this()
        {
            ArgumentNullException.ThrowIfNull(itemInventoryList);
            _itemInventoryList = new(itemInventoryList);
        }

        public bool TryAddItem(ItemInventory item)
        {
            //TODO: Implementare logica
            return false;
        }
    }
}