namespace AdventureS25;

public static class Map
{
    private static Dictionary<string, Location> nameToLocation = 
        new Dictionary<string, Location>();
    public static Location StartLocation;
    
    public static void Initialize()
    {
        Location home = new Location("Home", 
            @"
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠘⣦⣌⠉⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⢹⡏⣿⡶⣤⣀⠉⠙⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⢁⡤⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⢀⣧⠀⢳⡘⣷⠈⣭⣛⣳⡤⣀⠀⠉⠻⠟⠛⠋⢁⠀⡀⠂⠋⢀⡄⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⣼⣿⡄⠈⣧⠸⣦⠠⣬⠙⣻⡌⢲⠀⠒⠤⠦⢔⡡⠂⠀⢁⣴⣿⣿⡀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⣰⣿⣿⣿⡄⠘⢇⠉⡄⢙⠃⠙⣿⡌⡄⠸⣶⣤⣤⣤⡄⣶⡖⠤⠤⢭⣍⠦⠘⠛⠿⢿⣿⣿⡟⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⢰⣿⣿⣿⣿⣷⡀⠘⣦⠹⠄⢻⣧⠹⣷⡐⡄⠙⣿⣿⣿⡇⢻⡇⣶⠄⡄⢸⡆⠗⢆⠢⣤⣀⣉⠁⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠁⣠⣿⣿⣿⣿⣿⣿⣧⡀⠘⣆⠲⡆⢰⣆⠸⣷⡘⣄⠈⢻⣿⣿⢸⡇⣬⢀⡁⢸⡇⢰⠈⢷⠘⢌⠻⡓⡄⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠘⣤⠠⣄⢩⣥⠈⣳⡘⢷⣄⠹⠿⢸⡇⠃⠀⠃⢸⡇⣘⠷⠀⠶⠐⢦⡐⡌⠀⠘⣿⣿⠟⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⠏⢀⣼⣿⣿⣿⣿⣿⠉⣿⣿⢿⣿⣿⣄⠈⢦⠙⣆⠙⢃⠘⠷⠌⢿⣿⢲⣤⣤⣥⣬⣌⠘⠣⠿⠤⠶⠦⠛⠘⠃⠉⠈⠀⠀⠀⡀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⡿⠋⢀⣾⣿⣿⣷⡀⢠⣤⠀⣶⣶⡆⣿⣿⣿⣦⠈⢷⡙⠷⠘⠷⡌⢿⡄⢻⣦⠹⣿⣿⡿⠋⠠⠔⠤⠀⣶⠖⢠⡶⣶⡶⣿⠟⢀⣾⣷⡀⠹⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⡟⢁⣴⣿⣿⣿⣿⣿⡇⠀⣿⡄⢻⣿⡇⢸⣿⣿⣿⣷⣄⠹⣌⢳⣄⢲⣄⢲⣦⠹⣷⡾⠋⢀⠔⠁⠔⠠⠶⠂⡴⢂⡴⢋⠜⠁⣠⣿⣿⣿⣷⡀⠙⢿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⢛⣴⢻⣿⣿⣿⣿⣿⣿⠁⠀⢛⡃⢙⣋⡁⢸⣿⣿⣿⣿⣿⣇⠘⠳⠿⠧⣽⠦⡿⠛⢁⡠⢞⡠⠄⣁⠘⠃⠴⢂⠠⡠⠔⠁⡠⠞⠋⣉⣉⡉⠙⢿⣆⠀⠻⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⡇⠈⢻⣿⣿⣿⣿⣿⡷⠀⣿⡇⢸⣿⡇⠸⣿⣿⣿⣿⣿⣿⣿⣶⣤⣤⣤⣀⠐⠚⠭⠶⠯⠶⠯⠥⠬⠩⠄⠁⢈⣠⣴⢋⡐⢿⠃⡿⢡⠟⡆⠀⢿⣷⣄⡈⠻⣿⣿⣿
⣿⣿⣿⣿⠏⠀⠀⠈⣿⣿⣿⣿⣿⡇⠐⠛⢓⡋⠭⠁⢠⣿⣿⣿⣿⣿⡏⢹⣿⣿⣿⣿⣿⣏⠰⣦⡤⣤⡤⢠⣤⣤⣴⣶⢺⣿⣿⡏⠚⠛⠀⠀⠤⠤⠾⠇⠀⣸⣿⣿⣿⣷⣼⣿⣿
⣿⣿⡿⠉⢀⣶⣮⠀⢻⣿⣿⣿⣿⣿⣤⣤⣤⣤⣴⣾⣿⣿⣿⣿⣿⣿⡇⢸⡏⣉⢩⠙⣿⣿⠀⣿⣦⢩⡍⣈⠙⣿⣿⣿⡜⣿⣿⣛⠛⠛⠛⠛⠛⠿⠿⠿⢿⣿⣿⣿⢸⣿⣿⣿⣿
⣿⠏⠠⣴⣾⣿⣿⡄⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢸⡇⠛⠈⠀⣿⣿⠀⣿⣿⠈⠃⠙⠀⣿⣿⣿⡇⣿⣿⣿⠹⣿⣿⡄⣿⣿⣿⠘⣿⣿⣿⠇⣸⣿⣿⣿⣿
⡿⠁⢸⣿⣿⣿⡿⠻⠈⣿⣿⣿⣿⣿⡛⢛⣉⡁⢨⣤⡄⢹⣿⣿⣿⣿⡇⢸⡇⣿⠀⠀⣿⣿⠀⣿⣿⢸⡇⣷⠀⣿⣿⣿⠀⣿⣿⣿⠀⣿⣿⡇⣿⣿⣿⠀⣿⣿⣿⠀⣿⣿⣿⣿⣿
⠠⢾⡿⢿⠛⡛⠂⢀⡄⢸⣿⣿⣿⣿⡇⠘⣿⡇⢸⣿⡇⢸⣿⣿⣿⣿⡇⣸⡇⣿⢠⠀⣿⣿⠀⢹⣿⢸⡇⣿⠀⣿⣿⣿⠀⣿⣿⣿⢀⣿⣿⡇⣿⣿⣿⢰⣿⣿⡿⠀⣿⣿⣿⣿⣿
⣶⣦⣅⣘⣀⡇⣼⣿⡅⢸⣿⣿⣿⣿⣿⠀⠘⠃⢈⣩⡅⠘⣿⣿⣿⣿⡇⣿⠃⠈⠘⠀⣿⣿⡆⢸⡇⢈⠁⣛⠀⣿⣿⣿⠀⣿⣿⡏⢸⣿⠿⠇⠿⣿⣿⢸⣿⣿⡇⢠⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣧⢩⣉⣉⠀⣿⣿⣿⣿⣿⠀⢸⡇⢸⣿⣧⠀⣿⣿⣿⣿⡇⣿⠀⠃⠘⢀⣿⣿⠃⢰⠇⠈⠁⠉⣠⣿⣿⣿⠀⢽⣿⡇⣿⣿⣦⢠⣶⣿⡏⣸⣿⣿⡇⢈⡉⢻⣿⣿⣿
⣿⣿⣿⣿⠁⣤⣼⣿⣿⡇⣿⣿⣿⣿⣿⠀⠸⠟⠘⢛⡋⠀⣿⣿⣿⣿⡇⢿⣤⣤⣴⣶⣿⣿⠀⣼⣦⣤⣴⣶⣶⣿⣿⣿⠀⣿⣿⡇⣿⣿⣿⢸⣿⣿⡇⣿⣿⣿⡇⣼⡆⢼⣿⣿⣿
⣿⣿⡟⢡⣶⣿⣿⣿⣿⣷⢸⣿⣿⣿⣿⣈⠁⢀⣀⣀⣤⣴⣾⣿⣿⣿⣇⣸⣿⣿⣿⣿⣿⣿⢰⣿⣿⣿⣿⣿⣿⣿⣿⡿⢠⣿⡿⢰⣿⣿⣯⣼⣿⣿⣇⣿⣿⣿⠀⣿⣿⣾⣧⣘⠛
⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣘⡿⠿⠿⠿⠛⣛⣛⣛⣛⡛⠉⠉⠭⠭⠭⠭⣥⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⠀⠀⣉⣉⣉⣉⣉⠛⠛⠛⠛⠛⠿⠯⠴⣿⣿⣿⣿⣏⠄
⣿⣿⣿⣿⣿⣿⣛⣫⣭⣭⡴⠶⠒⠚⣛⣛⣁⣄⠠⠀⠀⠶⠒⠂⠐⣉⣛⣋⣉⣭⣭⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡖⢘⣿⣿⣿⣿⣿⣿⣯⣐⠒⠶⣦⣤⣤⣬⣍⣙⡛⠓
⣿⣿⣿⣿⢟⣋⣉⢥⣶⠶⠾⠟⣛⣉⣉⣥⣴⣶⠶⠶⠾⢟⣻⣿⣿⣿⣿⣿⡿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠛⠛⠛⠉⣉⣉⣀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣌⠻⣿⣿⣿⣿⣷
⣿⣿⣿⣿⣿⣭⣵⣶⡶⠿⠿⢛⣋⣉⣭⣴⣶⠶⠾⠟⠛⠋⢉⣉⣀⣀⣤⣤⣴⣶⣶⣶⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠗⢸⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣯⣤⣶⣿⡿⠿⠛⠋⣉⣀⣤⣤⣴⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⠛⠛⠉⣀⣠⣾⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⠋⣉⣤⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠛⠉⣁⣠⣤⣤⣶⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣯⠀⠙⠛⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋⣠⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡈⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⣄⣈⣉⣙⠛⠛⠛⠻⠿⠿⠿⠿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣤⣤⣙⠻⠿⣿
This is your home. Everything starts here.");
        nameToLocation.Add("Home", home);
        
        Location storage = new Location("Storage", 
            "You are in a small storage room. There are lots of things.");
        nameToLocation.Add("Storage", storage);
        
        Location throne = new Location("Throne Room", 
            "There is a big ass throne here.");
        nameToLocation.Add("Throne Room", throne);

        Location cave = new Location("Cave", "It's a cave.  It's dark.  Dave lives in the cave");
        nameToLocation.Add("Cave", cave);
        
        home.AddConnection("east", storage);
        storage.AddConnection("west", home);
        throne.AddConnection("south", home);
        home.AddConnection("north", throne);

        StartLocation = home;
    }
    

    public static void AddItem(string itemName, string locationName)
    {
        // find out which Location is named locationName
        Location location = GetLocationByName(locationName);
        Item item = Items.GetItemByName(itemName);
        
        // add the item to the location
        if (item != null && location != null)
        {
            location.AddItem(item);
        }
    }
    
    public static void RemoveItem(string itemName, string locationName)
    {
        // find out which Location is named locationName
        Location location = GetLocationByName(locationName);
        Item item = Items.GetItemByName(itemName);
        
        // remove the item to the location
        if (item != null && location != null)
        {
            location.RemoveItem(item);
        }
    }

    public static Location GetLocationByName(string locationName)
    {
        if (nameToLocation.ContainsKey(locationName))
        {
            return nameToLocation[locationName];
        }
        else
        {
            return null;
        }
    }

    public static void AddConnection(string startLocationName, string direction, 
        string endLocationName)
    {
        // get the location objects based on the names
        Location start = GetLocationByName(startLocationName);
        Location end = GetLocationByName(endLocationName);
        
        // if the locations don't exist
        if (start == null || end == null)
        {
            TextDisplay.TypeLine("Tried to create a connection between unknown locations: " +
                              startLocationName + " and " + endLocationName);
            return;
        }
            
        // create the connection
        start.AddConnection(direction, end);
    }

    public static void RemoveConnection(string startLocationName, string direction)
    {
        Location start = GetLocationByName(startLocationName);
        
        if (start == null)
        {
            TextDisplay.TypeLine("Tried to remove a connection from an unknown location: " +
                              startLocationName);
            return;
        }

        start.RemoveConnection(direction);
    }
}