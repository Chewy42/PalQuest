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
        Console.WriteLine(@"
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢁⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢃⣿⡏⣿⡿⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⡍⣉⠽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢡⣾⣿⣷⠲⠀⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣷⢻⣷⣮⣝⡻⢿⣿⣿⣿⣿⣿⢣⣿⣿⣿⣿⡄⠀⠀⢸⣿⣿⣿⣿⣿⣿⠿⠛⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣟⡊⣿⣿⣿⣿⣷⣬⣛⠛⣻⢃⣿⣿⣿⣿⣿⣧⠀⠀⠀⣛⣻⣿⠟⣋⣵⡞⠀⣿⣟⣛⠛⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⡘⣿⣿⣿⣿⣿⣿⣷⣍⣼⣿⣿⣿⣿⣿⣿⡄⠀⢀⣨⣭⣶⣿⣿⣿⠁⠰⠟⠋⠁⢰⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣷⡹⣿⣿⣿⣿⣿⣿⡿⢟⣛⣫⣭⣽⣛⣻⠷⣾⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡹⣿⣿⣿⢛⣵⣾⣿⣿⣿⣿⣿⣿⣿⣿⣶⣭⡻⣿⣿⣿⣿⠃⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿
⣫⢿⣿⣿⣿⣿⣿⣷⣶⣶⣶⣿⡿⣱⣿⣿⣿⣿⠿⣛⡭⢟⣩⣽⣿⠿⠿⠿⣎⢿⣿⣿⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿
⣿⣷⣮⠛⢿⣿⣿⣿⣿⣿⣿⣿⢱⣿⣿⣟⣻⣴⣭⡷⢟⣻⣭⠷⣞⣛⣯⣥⣾⣦⢻⣿⣦⣤⣤⣄⡀⢉⣬⡉⠙⣿⣿⣿⣿
⣿⣿⣿⣿⣦⡝⢿⣿⣿⣿⣿⡏⡾⢛⣯⣭⣭⡵⠶⢟⣫⣥⣶⢿⣿⣿⣿⣷⣭⡻⣏⢿⣿⣿⣿⠟⣡⡿⠋⠐⠺⠿⠿⣿⣿
⣿⣿⣿⣿⣿⣿⣬⣛⢿⣿⣿⡇⣷⡶⣾⣶⣶⣿⣶⣝⢿⣿⢧⣿⡿⠿⠟⢛⣿⣧⡸⡜⣿⣿⠋⠒⠉⠀⠀⠀⠀⠀⢀⣠⣾
⣿⣿⣿⣿⣿⣿⣿⠿⣃⣼⣿⡇⠟⣼⣿⣿⣿⠿⢟⣛⣃⢿⡄⣶⣾⣿⣶⣿⣿⣿⢃⣇⢿⣿⣷⣄⡀⠀⠀⠀⣠⣶⣿⣿⣿
⣿⣿⡟⠟⣛⣭⣵⣾⣿⣿⣿⣷⢰⢙⣭⣷⣦⣼⣿⣿⡟⣸⣷⣝⠿⣿⣿⣿⠿⣫⣾⣿⠸⣿⣿⣿⡿⢂⣤⠀⠙⠿⢿⣿⣿
⣿⣿⣿⣷⣮⣝⡻⢿⣿⣿⣿⣿⡸⣧⡹⢿⣿⣿⡿⢟⣵⢻⣿⡏⣿⣶⣶⣶⠟⠋⣰⣿⠄⣭⡻⡏⠰⠛⠁⠀⠀⠀⠙⠻⣿
⣿⣿⣿⣿⣿⣿⣦⡄⠈⠙⢿⣿⡇⢿⣿⢷⣶⣶⡾⢟⣽⡇⣿⣿⢸⣦⣤⣤⣴⣾⣿⣿⠀⢸⡿⢠⠀⠀⠀⠀⠀⠀⣠⣴⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⣸⣿⢋⣸⣿⣷⣶⣶⣿⣿⣿⣿⡜⠟⣸⣿⣿⣿⣿⣿⣿⣿⠀⠀⢠⣿⡄⣄⠀⢠⣶⣶⣶⣾⣿
⣿⣿⣿⣿⣿⣿⡿⢟⣩⣾⣿⡇⣿⣧⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⠿⠿⣯⡉⠀⡈⠐⠒⠛⠉⠀⠀⠙⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣭⣤⣭⣭⣛⣛⡍⣮⣙⡘⣿⣿⣿⣿⡿⢛⡩⣽⣶⣶⢇⣾⣿⣿⣿⡿⠁⠁⣷⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣁⠀⣿⣿⣷⡹⣇⠻⣵⣾⣿⣿⢶⡹⣿⢹⠿⣿⣿⣿⠏⡀⠈⠉⠁⠀⠀⠰⣶⣶⣿⣿⣿⣿⣿
        ");
        TextDisplay.TypeLine("Professor Jon looks up from his flask and scientific equipment with bloodshot eyes.");
        TextDisplay.TypeLine("\"W-w-well look what the *burp* interdimensional portal dragged in! Perfect ti-timing! I've been *burp* working on somethin' real special here. I've d-discovered a remarkable new P-Pal specimen, kid!\"");
        TextDisplay.TypeLine("\"It's a rare corgi-*burp*-type Pal named Sandie. Th-they're like little furry test subjects but with less screaming, y'know? Wanna s-see it? It's a hundred times better than those *burp* lame government-approved creatures.\"");
        
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
            TextDisplay.TypeLine("\"Awww y-yeahhh! *burp* That's what I'm talking about! Let me introduce you to S-Sandie, the greatest achievement in *burp* Pal science!\"");
            TextDisplay.TypeLine("Professor Jon takes a swig from his flask, belches loudly, then whistles as a small corgi-like Pal bounces into view.");
            
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
            
            TextDisplay.TypeLine("\"I-i-isn't she *burp* wonderful? A hundred times better than any of those m-mass produced Pals! Would you like to t-take Sandie with you on your *burp* journey? She's only slightly radioactive, M-Morty—I mean, uh, whatever your name is!\"");
            
            AwaitingResponse = true;
            OfferType = "sandie_offer";
        }
        else if (OfferType == "sandie_offer")
        {
            TextDisplay.TypeLine("Sandie jumps excitedly and follows you now, wagging her little nub tail.");
            
            // Add Sandie to player's pals collection and set the condition
            Conditions.ChangeCondition(ConditionTypes.HasSandiePal, true);
            TextDisplay.TypeLine("You've received Sandie the Corgi Pal!");
            
            TextDisplay.TypeLine("\"That's *burrrp* right! She's all yours now, k-kid! Don't feed her after midnight, and d-don't get her wet unless you want to see some REAL *burp* science happen! Wubba lubba dub dub!\"");
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
            TextDisplay.TypeLine("\"Oh, w-what do you know, *burp* Mr. I-Don't-Want-To-See-Amazing-Scientific-Discoveries! Listen here, you little turd, I d-don't care what you think! You s-simply *burp* MUST see this remarkable Pal! It's a matter of g-galactic importance!\"");
            Yes(command); // Force the introduction anyway
        }
        else if (OfferType == "sandie_offer")
        {
            TextDisplay.TypeLine("\"W-what? *BURP* Not take Sandie?! Are you out of your m-mind?! Look at me! I'm Professor Jon, motherf*cker! I turned myself into a *burp* professor! I'm PROFESSOR JOOOOON!\"");
            TextDisplay.TypeLine("\"Listen here, you l-little piece of sh*t, Sandie has already chosen you, and a Pal's choice is f-final! That's just how the universe *burp* works, kid! Did you think you had a c-choice in this? HAHAHAHA!\"");
            
            // Add Sandie to player's pals collection anyway and set the condition
            Conditions.ChangeCondition(ConditionTypes.HasSandiePal, true);
            TextDisplay.TypeLine("You've received Sandie the Corgi Pal despite your objections!");
            
            TextDisplay.TypeLine("\"Now you two are s-stuck together! *burp* That's science, b*tch!\"");
            TextDisplay.TypeLine("Type 'leave' to end the conversation.");
            AwaitingResponse = false;
        }
    }

    private static void Leave(Command command)
    {
        if (AwaitingResponse && CurrentNPC != null && CurrentNPC.Name == "Professor Jon")
        {
            TextDisplay.TypeLine("\"W-w-wait! *BUUURP* Where do you think you're going?! We're not done yet, you ungrateful little turd! This is important s-science happening right here! Do you have any idea how many dimensions I had to travel through to find this Pal?! NINE! NINE DIMENSIONS!\"");
            return;
        }
        
        TextDisplay.TypeLine("You end the conversation.");
        States.ChangeState(StateTypes.Exploring);
    }
}