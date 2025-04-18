namespace AdventureS25;

public static class Debugger
{
    private static bool isActive = false;
    
    public static void Write(string message)
    {
        if (isActive)
        {
            TextDisplay.TypeLine(message);
        }
    }

    public static void Tron()
    {
        isActive = true;
        TextDisplay.TypeLine("Debugging on");
    }
    
    public static void Troff()
    {
        isActive = false;
        TextDisplay.TypeLine("Debugging off");
    }
}