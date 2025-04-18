namespace AdventureS25;

public static class ConversationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"y", Yes},
            {"n", No},
            {"leave", Leave},
        };
    
    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
    }

    private static void Yes(Command command)
    {
        TextDisplay.TypeLine("You agreed");
    }
    
    private static void No(Command command)
    {
        TextDisplay.TypeLine("You are disagreed");
    }

    private static void Leave(Command command)
    {
        TextDisplay.TypeLine("You are dead");
        States.ChangeState(StateTypes.Exploring);
    }
}