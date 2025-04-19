namespace AdventureS25;

public static class CombatCommandHandler
{
    // Mapping all possible battle commands to handlers
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            // Battle commands - text only
            {"attack", Attack},
            {"defend", Defend},
            {"special", Special},
            {"run", Run},
        };
    
    public static void Handle(Command command)
    {
        // Convert to lowercase for case-insensitive matching
        string verb = command.Verb.ToLower();
        
        if (commandMap.ContainsKey(verb))
        {
            commandMap[verb].Invoke(command);
        }
        else
        {
            TextDisplay.TypeLine("Valid battle commands are: attack, defend, special, or run.");
        }
    }

    // Individual command methods for better reusability
    private static void Attack(Command command)
    {
        if (PalBattle.IsBattleActive)
        {
            // Create a standardized command for the battle system
            Command attackCommand = new Command { Verb = "attack", Noun = "" };
            PalBattle.HandleBattleCommand(attackCommand);
        }
        else
        {
            TextDisplay.TypeLine("There's no active battle right now.");
            States.ChangeState(StateTypes.Exploring);
        }
    }
    
    private static void Defend(Command command)
    {
        if (PalBattle.IsBattleActive)
        {
            Command defendCommand = new Command { Verb = "defend", Noun = "" };
            PalBattle.HandleBattleCommand(defendCommand);
        }
        else
        {
            TextDisplay.TypeLine("There's no active battle right now.");
            States.ChangeState(StateTypes.Exploring);
        }
    }
    
    private static void Special(Command command)
    {
        if (PalBattle.IsBattleActive)
        {
            Command specialCommand = new Command { Verb = "special", Noun = "" };
            PalBattle.HandleBattleCommand(specialCommand);
        }
        else
        {
            TextDisplay.TypeLine("There's no active battle right now.");
            States.ChangeState(StateTypes.Exploring);
        }
    }
    
    private static void Run(Command command)
    {
        if (PalBattle.IsBattleActive)
        {
            Command runCommand = new Command { Verb = "run", Noun = "" };
            PalBattle.HandleBattleCommand(runCommand);
        }
        else
        {
            TextDisplay.TypeLine("There's no active battle right now.");
            States.ChangeState(StateTypes.Exploring);
        }
    }
}