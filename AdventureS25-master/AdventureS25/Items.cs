namespace AdventureS25;

public static class Items
{
    private static Dictionary<string, Item> nameToItem = 
        new Dictionary<string, Item>();
    
    public static void Initialize()
    {
        Item note = new Item("note",
            "a letter from Professor Jon", 
            "There is a note from Professor Jon on the table.");
        nameToItem.Add("note", note);
        
        Item donut = new Item("donut",
            "A giant concrete donut that you can't take", 
            "A giant concrete donut rests on the floor.",
            false);
        nameToItem.Add("donut", donut);
        
        Item beer = new Item("beer",
            "beer's beer",
            "There is a beer's beer in a beer here.");
        nameToItem.Add("beer", beer);
        
        Item beerBottle = new Item("beer-bottle", "An empty beer bottle",
            "There is an empty beer bottle in a beer here.");
        nameToItem.Add("beer-bottle", beerBottle);
        
        Item apple = new Item("apple",
            "a shiny rotten apple",
            "A shiny rotten apple sits on the floor.");
        nameToItem.Add("apple", apple);
        
        Item spear = new Item("spear",
            "a shiny rotten spear",
            "A shiny rotten spear sits is propped in the corner.");
        nameToItem.Add("spear", spear);

        Item puke = new Item("puke",
            "some puke",
            "A disgusting pile of puke.");
        nameToItem.Add("puke", puke);
        
        // tell the map to add the item at a specific location
        Map.AddItem(note.Name, "Home");
        Map.AddItem(donut.Name, "Storage");
        Map.AddItem(beer.Name, "Throne Room");
    }

    public static Item GetItemByName(string itemName)
    {
        if (nameToItem.ContainsKey(itemName))
        {
            return nameToItem[itemName];
        }
        return null;
    }
}