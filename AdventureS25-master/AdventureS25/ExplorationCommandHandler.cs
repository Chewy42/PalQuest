namespace AdventureS25;

public static class ExplorationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"eat", Eat},
            {"go", Move},
            {"tron", Tron},
            {"troff", Troff},
            {"take", Take},
            {"inventory", ShowInventory},
            {"look", Look},
            {"drop", Drop},
            {"nouns", Nouns},
            {"verbs", Verbs},
            {"fight", ChangeToFightState},
            {"explore", ChangeToExploreState},
            {"talk", Talk},
            {"drink", Drink},
            {"use", Use},
            {"pet", Pet},
            {"beerme", SpawnBeerInInventory},
            {"unbeerme", UnSpawnBeerInInventory},
            {"puke", Puke},
            {"tidyup", TidyUp},
            {"teleport", Teleport},
            {"connect", Connect},
            {"disconnect", Disconnect}
        };

    private static void Disconnect(Command obj)
    {
        Conditions.ChangeCondition(ConditionTypes.IsRemovedConnection, true);
    }

    private static void Connect(Command obj)
    {
        Conditions.ChangeCondition(ConditionTypes.IsCreatedConnection, true);
    }

    private static void Teleport(Command obj)
    {
        Conditions.ChangeCondition(ConditionTypes.IsTeleported, true);
    }   

    private static void TidyUp(Command command)
    {
        Conditions.ChangeCondition(ConditionTypes.IsTidiedUp, true);
    }

    private static void Puke(Command obj)
    {
        Conditions.ChangeCondition(ConditionTypes.IsHungover, true);
    }

    private static void UnSpawnBeerInInventory(Command command)
    {
        Conditions.ChangeCondition(ConditionTypes.IsBeerMed, false);

    }

    private static void SpawnBeerInInventory(Command command)
    {
        Conditions.ChangeCondition(ConditionTypes.IsBeerMed, true);
    }

    private static void Drink(Command command)
    {
        Player.Drink(command);
    }

    private static void Talk(Command command)
    {
        Player.Talk(command);
    }
    
    private static void ChangeToFightState(Command obj)
    {
        States.ChangeState(StateTypes.Fighting);
    }
    
    private static void ChangeToExploreState(Command obj)
    {
        States.ChangeState(StateTypes.Exploring);
    }

    private static void Verbs(Command command)
    {
        List<string> verbs = ExplorationCommandValidator.GetVerbs();
        foreach (string verb in verbs)
        {
            TextDisplay.TypeLine(verb);
        }
    }

    private static void Nouns(Command command)
    {
        List<string> nouns = ExplorationCommandValidator.GetNouns();
        foreach (string noun in nouns)
        {
            TextDisplay.TypeLine(noun);
        }
    }

    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> method = commandMap[command.Verb];
            method.Invoke(command);
        }
        else
        {
            TextDisplay.TypeLine("I don't know how to do that.");
        }
    }
    
    private static void Drop(Command command)
    {
        Player.Drop(command);
    }
    
    private static void Look(Command command)
    {
        Player.Look();
    }

    private static void ShowInventory(Command command)
    {
        Player.ShowInventory();
    }
    
    private static void Take(Command command)
    {
        Player.Take(command);
    }

    private static void Troff(Command command)
    {
        Debugger.Troff();
    }

    private static void Tron(Command command)
    {
        Debugger.Tron();
    }

    public static void Eat(Command command)
    {
        TextDisplay.TypeLine("Eating..." + command.Noun);
    }

    public static void Move(Command command)
    {
        Player.Move(command);
    }
    
    private static void Use(Command command)
    {
        Player.Use(command);
    }
    
    private static void Pet(Command command)
    {
        Player.Pet(command);
    }
}