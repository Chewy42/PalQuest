namespace AdventureS25;

public static class Game
{
    public static void PlayGame()
    {
        Initialize();

        Console.WriteLine(Player.GetLocationDescription());
        
        bool isPlaying = true;
        
        while (isPlaying == true)
        {
            Command command = CommandProcessor.Process();
            
            if (command.IsValid)
            {
                if (command.Verb == "exit")
                {
                    TextDisplay.TypeLine("Game Over!");
                    isPlaying = false;
                }
                else
                {
                    CommandHandler.Handle(command);
                }
            }
        }
    }

    private static void Initialize()
    {
        Conditions.Initialize();
        States.Initialize();
        Map.Initialize();
        Items.Initialize();
        NPCs.Initialize();
        Pals.Initialize(); // Initialize the Pals system
        Player.Initialize();
    }
}