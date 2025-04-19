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
        // Get the professor NPC and display his information
        NPC? professor = NPCs.GetNPCByName("Professor Jon");
        if (professor != null)
        {
            // Display the NPC details
            professor.DisplayInfo();
        }
        
        TextDisplay.TypeLine("Professor Jon looks up from his computer, his eyes squinting slightly as he focuses on you.\n");
        TextDisplay.TypeLine("Jon: \"P-P-Perfect timing! I've been *burp* coding all night, kid! I finally managed to bring Sandie to life! *burp* It's a Pal unlike any other!\"");
        TextDisplay.TypeLine("Jon: \"It's a rare corgi-*burp*-type Pal named Sandie. Th-they're like little furry test subjects but with less screaming, y'know? Wanna s-see it? It's a hundred times better than those *burp* lame government-approved creatures.\"");
        
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
            TextDisplay.TypeLine("\"Fuck y-yeahhh! *burp* That's what I'm talking about! Let me introduce you to S-Sandie, the greatest achievement in *burp* Pal Computer Science!\"");
            TextDisplay.TypeLine("Professor Jon takes a swig from his Everclear, belches loudly, then whistles as a small corgi-like Pal bounces into view.");
            Pal? sandie = Pals.GetPalByName("Sandie");
            if (sandie != null)
            {
                sandie.DisplayInfo();
            }
            TextDisplay.TypeLine("Jon: \"I-i-isn't she *burp* wonderful? A hundred times better than any of those m-mass produced Pals! Would you like to t-take Sandie with you on your *burp* journey?\"");
            
            AwaitingResponse = true;
            OfferType = "sandie_offer";
        }
        else if (OfferType == "sandie_offer")
        {
            TextDisplay.TypeLine("Sandie jumps excitedly and follows you now, wagging her little nub tail.");
            
            // Add Sandie to player's pals collection and set the condition
            Pals.GivePalToPlayer("Sandie");
            Conditions.ChangeCondition(ConditionTypes.HasSandiePal, true);
            
            TextDisplay.TypeLine("You've received Sandie the Corgi!");
            
            TextDisplay.TypeLine("Jon: \"That's *burrrp* right! She's all yours now, k-kid! Don't feed her after midnight, and d-don't get her wet unless you want to see some REAL *burp* Computer Science happen! Wubba lubba dub dub!\"");
            
            TextDisplay.TypeLine("Jon: \"But wait! *burp* You think I'm just going to give you a top of the line Pal for free? No way! First, we need to see if you're *burp* worthy! Let's test your Pal's capabilities in a battle!\"");
            
            // End the conversation completely
            CurrentNPC = null;
            AwaitingResponse = false;
            States.ChangeState(StateTypes.Exploring);
            
            // Start a battle with Jon's Pal
            PalBattle.StartBattle();
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
            TextDisplay.TypeLine("Jon: \"Oh, p-please, *burp* Mr. I'm-A-Snobby-Little-Turd-Who-Doesn't-Want-To-See-Amazing-Computer-Science-Discoveries! Listen here, you tiny d-dickhead, I d-don't give a flying f-fuck what you think! You s-simply *burp* MUST behold the g-glory of Sandie, the most m-majestic Pal the galaxy has ever s-seen! It's a matter of g-galactic importance, and if you don't comply, I'll *burp* fucking kill you!\"");
            Yes(command); // Force the introduction anyway
        }
        else if (OfferType == "sandie_offer")
        {
            TextDisplay.TypeLine("Jon: \"W-what? *BURP* Not take Sandie?! Are you out of your m-mind?! Look at me! I'm Professor Jon, motherfucker! I turned myself into a *burp* professor! I'm PROFESSOR JOOOOON!\"");
            TextDisplay.TypeLine("Jon: \"Listen here, you l-little piece of shit, Sandie has already chosen you, and a Pal's choice is f-final! That's just how the universe *burp* works, kid! Did you think you had a c-choice in this? HAHAHAHA!\"");
            
            // Add Sandie to player's pals collection anyway and set the condition
            Pals.GivePalToPlayer("Sandie");
            Conditions.ChangeCondition(ConditionTypes.HasSandiePal, true);
            TextDisplay.TypeLine("You've received Sandie the Corgi Pal despite your objections!");
            
            TextDisplay.TypeLine("Jon: \"Now you two are s-stuck together! *burp* That's computer science, biiitch!\"");
            TextDisplay.TypeLine("Type 'leave' to end the conversation.");
            AwaitingResponse = false;
        }
    }

    private static void Leave(Command command)
    {
        if (AwaitingResponse && CurrentNPC != null && CurrentNPC.Name == "Professor Jon")
        {
            TextDisplay.TypeLine("Jon: \"W-w-wait! *BUUURP* Where do you think you're going?! We're not done yet, you ungrateful little piece of shit! This is important Computer Science happening right here! Do you have any idea how long it took  me to code this Pal?\"");
            return;
        }
        
        TextDisplay.TypeLine("You end the conversation.");
        States.ChangeState(StateTypes.Exploring);
    }
}