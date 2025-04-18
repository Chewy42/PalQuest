namespace AdventureS25;

public static class ConversationCommandHandler
{
    // Static variables to track the current conversation
    public static NPC? CurrentNPC { get; set; }
    public static bool AwaitingResponse { get; set; } = false;
    public static string OfferType { get; set; } = string.Empty;
    
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"y", Yes},
            {"n", No},
            {"leave", Leave},
            {"yes", Yes},
            {"no", No},
            {"accept", Yes},
            {"decline", No}
        };
    
    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
        else
        {
            TextDisplay.TypeLine("Valid options are: yes (y), no (n), or leave.");
        }
    }

    public static void StartConversation(NPC npc)
    {
        CurrentNPC = npc;
        AwaitingResponse = false;
        OfferType = "";
        
        if (npc.Name == "Professor Jon")
        {
            ProfessorJonConversation();
        }
        else
        {
            // Generic greeting for other NPCs
            TextDisplay.TypeLine($"{npc.Name} greets you warmly.");
            TextDisplay.TypeLine("Type 'leave' to end the conversation.");
        }
    }
    
    private static void ProfessorJonConversation()
    {
        TextDisplay.TypeLine("Professor Jon looks up from his notes with excitement.");
        TextDisplay.TypeLine("\"Ah, perfect timing! I've been working on something special. I've discovered a remarkable new Pal specimen!\"");
        TextDisplay.TypeLine("\"It's a rare corgi-type Pal named Sandie. Would you like to see it?\"");
        
        AwaitingResponse = true;
        OfferType = "sandie_introduction";
    }

    private static void Yes(Command command)
    {
        if (!AwaitingResponse)
        {
            TextDisplay.TypeLine("You agreed, but to what?");
            return;
        }
        
        if (OfferType == "sandie_introduction")
        {
            TextDisplay.TypeLine("\"Excellent! Let me introduce you to Sandie.\"");
            TextDisplay.TypeLine("Professor Jon whistles and a small corgi-like Pal bounces into view.");
            
            // Space for ASCII art
            Console.WriteLine(@"
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⢟⣛⣛⣛⣛⣛⣛⣛⣛⣛⡻⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠟⣛⣫⣥⠶⢛⣩⣭⣭⣭⣵⣶⣤⣍⠻⣿⣟⡻⢿⣶⣝⠻⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢟⣋⣭⠴⠶⠾⠿⣛⣭⣴⣾⠟⣫⣭⣶⣾⣿⣿⣿⣿⣷⣙⣿⣿⣷⣌⠻⣷⡜⢿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣛⣩⣶⠟⣩⣶⣾⢿⣿⣿⣿⣿⣿⢗⣹⣿⡿⢛⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠿⠳⡘⣿⣎⢿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⠿⣛⣫⣥⡶⠿⠟⠋⠰⣶⣬⣍⠻⢷⣎⣹⣿⢿⣷⣿⣿⣏⣴⠋⠀⠀⠀⠈⠋⢻⠁⣏⢿⣷⡉⠀⠀⠈⣿⢈⣿⣿⣿⣿
⣿⣿⣿⣿⡿⢡⡾⠛⣩⣴⣦⣤⣀⠀⠐⠻⣯⣉⣭⡛⡟⢻⡏⢸⣿⣿⣿⡿⢰⣤⣀⣀⣀⣀⣀⠀⢰⣿⣦⡻⣷⡀⠀⠀⣿⠈⣿⣿⣿⣿
⣿⣿⣿⣿⣇⢨⣧⣀⠉⠻⡿⢿⠟⣛⣷⣿⣦⣀⣘⣧⣴⡞⢀⣿⣿⣿⣿⣷⣾⣿⣿⡿⠯⠚⣣⣴⡿⣿⣿⣿⣿⣿⣦⣀⢿⣧⣝⠻⣿⣿
⣿⣿⣿⣿⣿⣶⣭⡛⠿⣶⣦⣀⠀⢸⣿⣿⣿⣋⣭⣾⣿⠃⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣭⣾⣿⣿⣿⣿⣿⡿⠟⠓⢉⠻⣷⣎⢻
⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣍⡛⢿⣶⡬⢙⣿⠛⢍⢻⣷⣾⣿⣿⣿⣿⣿⣿⢟⣵⣾⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠉⠀⠀⠀⠀⠁⠈⣿⡎
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣡⣿⢋⣴⣿⣿⣴⣾⣿⣾⣿⣿⣿⣿⣿⣿⣿⣼⣿⡇⠐⢿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⢠⣿⢃
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣱⣿⢏⣾⣿⣿⣿⣿⣾⣿⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣤⣤⡙⢿⣿⣿⣿⣿⣿⣿⡿⠆⠀⠀⠀⣠⡾⢃⣾
⣿⣿⣿⣿⣿⣿⣿⣿⢟⣴⣿⢯⣾⣿⣿⣿⣿⣿⣿⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣉⠛⠛⠟⠛⠋⠀⠀⠀⠀⣼⡟⣤⣾⣿
⣿⣿⣿⣿⣿⣿⠟⣱⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⣵⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣾⣶⣤⣄⣴⡇⣿⡆⣿⣿⣿
⣿⣿⣿⣿⣿⢏⣼⡿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⢼⢹⣱⠏⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣿⡇⣿⣿⣿
⣿⣿⣿⣿⡏⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⠸⡏⣷⢣⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣽⡇⢹⣿⣿
⣿⣿⣿⡟⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣥⣟⢁⣻⣧⢻⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⢻⣿⣿⣿⢈⣿⠃⣿⣿⣿
⣿⣿⡿⣱⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣍⣏⡌⠁⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⡹⣿⣷⡹⣿⢰⣿⢰⣿⣿⣿
⣿⡟⣱⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣷⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⡟⣾⡿⢼⣿⣿⣿
⣿⢀⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢏⣾⡇⣸⣿⣿⣿
⣿⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠡⣿⢇⣿⣿⣿⣿
⣿⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⢨⣿⢠⣿⣿⣿⣿
⣿⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣹⣿⢸⣿⣿⣿⣿
⢃⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⢼⣿⢸⣿⣿⣿⣿
⠸⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢫⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⢼⣿⢸⣿⣿⣿⣿
⢡⣾⣿⣿⣿⣿⣿⣿⡟⣽⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⢡⣿⠏⣿⣿⣿⠿⣿⢹⡟⣿⣿⣿⣿⣿⣿⣿⣿⣿⡯⢬⣿⢸⣿⣿⣿⣿
⠸⣿⠿⠿⠿⠿⠿⠿⠼⠏⠼⠯⠴⠿⠿⠿⠿⠿⠿⠿⠿⠿⠷⠮⠼⠷⠿⠿⠿⠴⠿⠆⠴⠘⠜⠿⠿⠿⠿⠿⠿⠿⠿⠨⣿⢀⣿⣿⣿⣿
⣧⣙⣻⣿⣿⣿⣛⣛⣛⣛⣛⣟⣛⣿⣻⣻⣿⣿⣿⣿⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣻⣟⣻⣿⣛⣛⣛⣻⣟⣃⣾⣿⣿⣿⣿");
            
            TextDisplay.TypeLine("\"Isn't she wonderful? Would you like to take Sandie with you on your journey?\"");
            
            AwaitingResponse = true;
            OfferType = "sandie_offer";
        }
        else if (OfferType == "sandie_offer")
        {
            TextDisplay.TypeLine("Sandie jumps excitedly and follows you now.");
            
            // Add Sandie to player's pals collection and set the condition
            Conditions.ChangeCondition(ConditionTypes.HasSandiePal, true);
            TextDisplay.TypeLine("You've received Sandie the Corgi Pal!");
            
            TextDisplay.TypeLine("Type 'leave' to end the conversation.");
            AwaitingResponse = false;
        }
    }
    
    private static void No(Command command)
    {
        if (!AwaitingResponse)
        {
            TextDisplay.TypeLine("You declined, but why?");
            return;
        }
        
        if (OfferType == "sandie_introduction")
        {
            TextDisplay.TypeLine("\"Oh, but I insist! You simply must see this remarkable Pal!\"");
            Yes(command); // Force the introduction anyway
        }
        else if (OfferType == "sandie_offer")
        {
            TextDisplay.TypeLine("\"What? Not take Sandie? I'm afraid that's not an option!\"");
            TextDisplay.TypeLine("\"Sandie has already chosen you, and a Pal's choice is final.\"");
            
            // Add Sandie to player's pals collection anyway and set the condition
            Conditions.ChangeCondition(ConditionTypes.HasSandiePal, true);
            TextDisplay.TypeLine("You've received Sandie the Corgi Pal!");
            
            TextDisplay.TypeLine("Type 'leave' to end the conversation.");
            AwaitingResponse = false;
        }
    }

    private static void Leave(Command command)
    {
        if (AwaitingResponse && CurrentNPC != null && CurrentNPC.Name == "Professor Jon")
        {
            TextDisplay.TypeLine("\"Wait! We're not done yet!\"");
            return;
        }
        
        TextDisplay.TypeLine("You end the conversation.");
        States.ChangeState(StateTypes.Exploring);
    }
}