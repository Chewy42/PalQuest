namespace AdventureS25;

public class NPC
{
    private string name;
    private string description;
    private string locationDescription;
    
    public string Name
    {
        get { return name; }
    }
    
    public string Description
    {
        get { return description; }
    }
    
    public NPC(string name, string description, string locationDescription)
    {
        this.name = name;
        this.description = description;
        this.locationDescription = locationDescription;
    }
    
    public string GetLocationDescription()
    {
        return locationDescription;
    }
}
