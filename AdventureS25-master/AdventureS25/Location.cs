namespace AdventureS25;

public class Location
{
    private string name;
    
    public string Name
    {
        get { return name; }
    }
    public string Description;
    
    public Dictionary<string, Location> Connections;
    public List<Item> Items = new List<Item>();
    public List<NPC> NPCs = new List<NPC>();
    
    public Location(string nameInput, string descriptionInput)
    {
        name = nameInput;
        Description = descriptionInput;
        Connections = new Dictionary<string, Location>();
    }

    public void AddConnection(string direction, Location location)
    {
        Connections.Add(direction, location);
    }

    public bool CanMoveInDirection(Command command)
    {
        if (Connections.ContainsKey(command.Noun))
        {
            return true;
        }
        return false;
    }

    public Location GetLocationInDirection(Command command)
    {
        return Connections[command.Noun];
    }

    public string GetDescription()
    {
        string fullDescription = Description;

        // List items in the location
        foreach (Item item in Items)
        {
            fullDescription += "\n" + item.GetLocationDescription();
        }
        
        // List NPCs in the location
        foreach (NPC npc in NPCs)
        {
            fullDescription += "\n" + npc.GetLocationDescription();
        }
        
        // Add available directions
        if (Connections.Count > 0)
        {
            fullDescription += "\n\nPossible directions: ";
            
            // Create and add descriptions for each direction with capitalized first letter
            foreach (var connection in Connections)
            {
                string direction = connection.Key;
                
                // Capitalize the first letter of the direction
                direction = char.ToUpper(direction[0]) + direction.Substring(1);
                
                string locationName = connection.Value.Name;
                fullDescription += direction + " [" + locationName + "] ";
            }
        }
        
        return fullDescription;
    }

    public void AddItem(Item item)
    {
        Debugger.Write("Adding item "+ item.Name + "to " + name);
        Items.Add(item);
    }

    public bool HasItem(Item itemLookingFor)
    {
        foreach (Item item in Items)
        {
            if (item.Name == itemLookingFor.Name)
            {
                return true;
            }
        }
        
        return false;
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }

    public void RemoveConnection(string direction)
    {
        if (Connections.ContainsKey(direction))
        {
            Connections.Remove(direction);
        }
    }
    
    public void AddNPC(NPC npc)
    {
        Debugger.Write("Adding NPC " + npc.Name + " to " + name);
        NPCs.Add(npc);
    }
    
    public bool HasNPC(NPC npcLookingFor)
    {
        foreach (NPC npc in NPCs)
        {
            if (npc.Name == npcLookingFor.Name)
            {
                return true;
            }
        }
        
        return false;
    }
    
    public void RemoveNPC(NPC npc)
    {
        NPCs.Remove(npc);
    }
}