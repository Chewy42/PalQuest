namespace AdventureS25;

public class NPC
{
    private string name;
    private string description;
    private string locationDescription;
    private string asciiArt; // For character visualization
    
    public string Name
    {
        get { return name; }
    }
    
    public string Description
    {
        get { return description; }
    }
    
    public NPC(string name, string description, string locationDescription, string asciiArt = "")
    {
        this.name = name;
        this.description = description;
        this.locationDescription = locationDescription;
        this.asciiArt = asciiArt;
    }
    
    public string GetLocationDescription()
    {
        return locationDescription;
    }
    
    // Display NPC information with ASCII art if available
    public void DisplayInfo()
    {
        if (!string.IsNullOrEmpty(asciiArt))
        {
            Console.WriteLine(asciiArt);
        }
        
        TextDisplay.TypeLine($"{name}");
        TextDisplay.TypeLine(description);
    }
}
