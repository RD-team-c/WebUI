using WebUI.Models;

namespace WebUI.Services;
public static class ItemService
{
    static List<Item> Items { get; }
    static int nextId = 3;
    static ItemService()
    {
        Items = new List<Item>
                {
                    new Item { Id = 1, Name = "Classic Italian", Price=20.00M, Size=ItemSize.Large, IsGlutenFree = false },
                    new Item { Id = 2, Name = "Veggie", Price=15.00M, Size=ItemSize.Small, IsGlutenFree = true }
                };
    }

    public static List<Item> GetAll() => Items;

    public static Item? Get(int id) => Items.FirstOrDefault(p => p.Id == id);

    public static void Add(Item item)
    {
        item.Id = nextId++;
        Items.Add(item);
    }

    public static void Delete(int id)
    {
        var item = Get(id);
        if (item is null)
            return;

        Items.Remove(item);
    }

    public static void Update(Item item)
    {
        var index = Items.FindIndex(p => p.Id == item.Id);
        if (index == -1)
            return;

        Items[index] = item;
    }
}