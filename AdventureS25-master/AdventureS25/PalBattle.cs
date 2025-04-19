using System;
using System.Collections.Generic;

namespace AdventureS25;

public class Pal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string AsciiArt { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public List<string> Moves { get; set; }

    public Pal(string name, string description, string asciiArt, int health)
    {
        Name = name;
        Description = description;
        AsciiArt = asciiArt;
        Health = health;
        MaxHealth = health;
        Moves = new List<string>() { "Attack", "Defend", "Special" };
    }

    public void DisplayInfo()
    {
        Console.WriteLine(AsciiArt);
        TextDisplay.TypeLine($"{Name} - Health: {Health}/{MaxHealth}");
        TextDisplay.TypeLine(Description);
    }
}

public static class PalBattle
{
    public static Pal PlayerPal { get; private set; }
    public static Pal EnemyPal { get; private set; }
    public static bool IsBattleActive { get; private set; } = false;
    public static bool IsPlayerTurn { get; private set; } = true;
    public static int TurnCount { get; private set; } = 0;

    private static readonly Random random = new Random();

    public static void StartBattle()
    {
        // Initialize battle with default Pals
        StartBattle("Sandie", "Morty");
    }
    
    public static void StartBattle(string playerPalName, string enemyPalName)
    {
        // Get Pals from the Pals system
        PlayerPal = Pals.GetPalByName(playerPalName) ?? 
            throw new ArgumentException($"Player Pal '{playerPalName}' not found!");
            
        EnemyPal = Pals.GetPalByName(enemyPalName) ?? 
            throw new ArgumentException($"Enemy Pal '{enemyPalName}' not found!");
        
        // Mark the Sandie Pal as owned by the player if it's in the battle
        if (playerPalName == "Sandie")
        {
            Pals.GivePalToPlayer("Sandie");
        }
        
        IsBattleActive = true;
        IsPlayerTurn = true;
        TurnCount = 0;
        
        // Display battle intro
        TextDisplay.TypeLine($"\nA battle begins between {PlayerPal.Name} and {EnemyPal.Name}!");
        Console.WriteLine(@"
+======================================================================+

▀█████████▄     ▄████████     ███         ███      ▄█          ▄████████ 
  ███    ███   ███    ███ ▀█████████▄ ▀█████████▄ ███         ███    ███ 
  ███    ███   ███    ███    ▀███▀▀██    ▀███▀▀██ ███         ███    █▀  
 ▄███▄▄▄██▀    ███    ███     ███   ▀     ███   ▀ ███        ▄███▄▄▄     
▀▀███▀▀▀██▄  ▀███████████     ███         ███     ███       ▀▀███▀▀▀     
  ███    ██▄   ███    ███     ███         ███     ███         ███    █▄  
  ███    ███   ███    ███     ███         ███     ███▌    ▄   ███    ███ 
▄█████████▀    ███    █▀     ▄████▀      ▄████▀   █████▄▄██   ██████████ 
                                                  ▀                      
+======================================================================+");
        
        // Show both Pals
        EnemyPal.DisplayInfo();
        TextDisplay.TypeLine(@" 
██▒   █▓  ██████ 
▓██░   █▒▒██    ▒ 
 ▓██  █▒░░ ▓██▄   
  ▒██ █░░  ▒   ██▒
   ▒▀█░  ▒██████▒▒
   ░ ▐░  ▒ ▒▓▒ ▒ ░
   ░ ░░  ░ ░▒  ░ ░
     ░░  ░  ░  ░  
      ░        ░  
     ░");
        PlayerPal.DisplayInfo();
        
        // First make sure we're not in conversation mode
        if (States.CurrentStateType == StateTypes.Talking)
        {
            States.ChangeState(StateTypes.Exploring);
        }
        
        // Then change to fighting state
        States.ChangeState(StateTypes.Fighting);
        
        // Show battle commands
        ShowBattleCommands();
    }

    public static void ShowBattleCommands()
    {
        TextDisplay.TypeLine($"\nWhat will {PlayerPal.Name} do?");
        TextDisplay.TypeLine("Commands: attack, defend, special, run");
    }

    public static void HandleBattleCommand(Command command)
    {
        if (!IsBattleActive)
        {
            return;
        }

        if (!IsPlayerTurn)
        {
            TextDisplay.TypeLine("Wait for your turn!");
            return;
        }

        string action = command.Verb.ToLower();

        switch (action)
        {
            case "attack":
                PlayerAttack();
                break;
            case "defend":
                PlayerDefend();
                break;
            case "special":
                PlayerSpecial();
                break;
            case "run":
                AttemptToFlee();
                break;
            default:
                TextDisplay.TypeLine("Invalid command. Please type: attack, defend, special, or run");
                return;
        }

        // After player turn, check if battle should continue
        if (IsBattleActive && !IsPlayerTurn)
        {
            // Enemy turn
            TextDisplay.TypeLine($"\n{EnemyPal.Name}'s turn!");
            EnemyTurn();
        }
    }

    private static void PlayerAttack()
    {
        TextDisplay.TypeLine($"\n{PlayerPal.Name} lunges forward with a basic attack!");
        
        int damage = random.Next(5, 11); // 5-10 damage
        EnemyPal.Health -= damage;
        
        TextDisplay.TypeLine($"{EnemyPal.Name} took {damage} damage!");
        
        if (EnemyPal.Health <= 0)
        {
            EnemyPal.Health = 0;
            EndBattle(true);
        }
        else
        {
            IsPlayerTurn = false;
        }
    }

    private static void PlayerDefend()
    {
        TextDisplay.TypeLine($"\n{PlayerPal.Name} takes a defensive stance!");
        TextDisplay.TypeLine($"{(PlayerPal.Name.EndsWith("s") ? PlayerPal.Name : PlayerPal.Name + "'s")} defense increases temporarily.");
        
        // Implementing a simple defense buff
        PlayerPal.Health += 2;
        if (PlayerPal.Health > PlayerPal.MaxHealth)
        {
            PlayerPal.Health = PlayerPal.MaxHealth;
        }
        
        TextDisplay.TypeLine($"{PlayerPal.Name} recovered 2 health points!");
        
        IsPlayerTurn = false;
    }

    private static void PlayerSpecial()
    {
        // Use a special move from the Pal's move list if available
        string specialMove = "special attack";
        
        // If the Pal has moves defined, use the special move (index 2 is typically Special)
        if (PlayerPal.Moves != null && PlayerPal.Moves.Count > 2)
        {
            specialMove = PlayerPal.Moves[2]; // Index 2 should be the Special move
        }
        
        TextDisplay.TypeLine($"\n{PlayerPal.Name} unleashes a powerful {specialMove}!");
        
        int damage = random.Next(8, 16); // 8-15 damage
        EnemyPal.Health -= damage;
        
        TextDisplay.TypeLine($"{EnemyPal.Name} was hit for {damage} damage!");
        
        if (EnemyPal.Health <= 0)
        {
            EnemyPal.Health = 0;
            EndBattle(true);
        }
        else
        {
            IsPlayerTurn = false;
        }
    }

    private static void AttemptToFlee()
    {
        int escapeChance = random.Next(1, 101); // 1-100
        
        if (escapeChance > 50)
        {
            TextDisplay.TypeLine($"\n{PlayerPal.Name} tries to run away...");
            TextDisplay.TypeLine($"But {EnemyPal.Name} blocks the exit!");
            TextDisplay.TypeLine($"{EnemyPal.Name}: \"Where do you think you're going?! This isn't *burp* over!\"");
            
            IsPlayerTurn = false;
        }
        else
        {
            TextDisplay.TypeLine($"\n{PlayerPal.Name} tries to run away...");
            TextDisplay.TypeLine($"{EnemyPal.Name}: \"Running away? That's the smartest *burp* move you've made today!\"");
            TextDisplay.TypeLine("You've escaped the battle!");
            
            EndBattle(false);
        }
    }

    private static void EnemyTurn()
    {
        // Simple AI for enemy turn - universally works for any enemy Pal
        int choice = random.Next(0, 3); // 0-2 for different actions
        
        switch (choice)
        {
            case 0:
                // Basic attack
                TextDisplay.TypeLine($"{EnemyPal.Name} uses a basic attack!");
                int damage = random.Next(4, 9); // 4-8 damage
                PlayerPal.Health -= damage;
                TextDisplay.TypeLine($"{PlayerPal.Name} took {damage} damage!");
                break;
            case 1:
                // Special attack - use Pal's special move if available
                string specialMove = "special attack";
                
                // If the Pal has moves defined, use one of them randomly
                if (EnemyPal.Moves != null && EnemyPal.Moves.Count > 0)
                {
                    // Pick a random move from the Pal's move list
                    int moveIndex = random.Next(0, EnemyPal.Moves.Count);
                    specialMove = EnemyPal.Moves[moveIndex];
                }
                
                TextDisplay.TypeLine($"{EnemyPal.Name} executes a {specialMove}!");
                int specialDamage = random.Next(7, 13); // 7-12 damage
                PlayerPal.Health -= specialDamage;
                TextDisplay.TypeLine($"{PlayerPal.Name} took {specialDamage} damage!");
                break;
            case 2:
                // Heal
                TextDisplay.TypeLine($"{EnemyPal.Name} regenerates some health!");
                int heal = random.Next(3, 7); // 3-6 healing
                EnemyPal.Health += heal;
                if (EnemyPal.Health > EnemyPal.MaxHealth)
                {
                    EnemyPal.Health = EnemyPal.MaxHealth;
                }
                TextDisplay.TypeLine($"{EnemyPal.Name} recovered {heal} health points!");
                break;
        }
        
        // Check if player lost
        if (PlayerPal.Health <= 0)
        {
            PlayerPal.Health = 0;
            EndBattle(false);
        }
        else
        {
            TurnCount++;
            IsPlayerTurn = true;
            
            // Display health status - dynamically use Pal names
            TextDisplay.TypeLine($"\n{PlayerPal.Name}'s Health: {PlayerPal.Health}/{PlayerPal.MaxHealth}");
            TextDisplay.TypeLine($"{EnemyPal.Name}'s Health: {EnemyPal.Health}/{EnemyPal.MaxHealth}");
            
            // Show battle commands for next player turn
            ShowBattleCommands();
        }
    }

    private static void EndBattle(bool playerWon)
    {
        IsBattleActive = false;
        
        if (playerWon)
        {
            // Player won the battle
            TextDisplay.TypeLine($"\n{EnemyPal.Name} has been defeated!");
            
            // Generic victory message
            TextDisplay.TypeLine($"You and {PlayerPal.Name} have won the battle!");
            TextDisplay.TypeLine($"Your bond with {PlayerPal.Name} grows stronger.");
        }
        else
        {
            if (PlayerPal.Health <= 0)
            {
                // Player's Pal was defeated
                TextDisplay.TypeLine($"\n{PlayerPal.Name} has been defeated!");
                TextDisplay.TypeLine("Your Pal needs more training and experience.");
                
                // Restore player Pal's health for gameplay purposes
                PlayerPal.Health = PlayerPal.MaxHealth;
            }
            else
            {
                // Player ran away
                TextDisplay.TypeLine($"You and {PlayerPal.Name} retreat from the battle.");
                TextDisplay.TypeLine("Sometimes the wisest move is a tactical retreat.");
            }
        }
        
        Console.WriteLine(@"
 ▄▄▄▄    ▄▄▄      ▄▄▄█████▓▄▄▄█████▓ ██▓    ▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
▓█████▄ ▒████▄    ▓  ██▒ ▓▒▓  ██▒ ▓▒▓██▒    ▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
▒██▒ ▄██▒██  ▀█▄  ▒ ▓██░ ▒░▒ ▓██░ ▒░▒██░    ▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
▒██░█▀  ░██▄▄▄▄██ ░ ▓██▓ ░ ░ ▓██▓ ░ ▒██░    ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
░▓█  ▀█▓ ▓█   ▓██▒  ▒██▒ ░   ▒██▒ ░ ░██████▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
░▒▓███▀▒ ▒▒   ▓▒█░  ▒ ░░     ▒ ░░   ░ ▒░▓  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
▒░▒   ░   ▒   ▒▒ ░    ░        ░    ░ ░ ▒  ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
 ░    ░   ░   ▒     ░        ░        ░ ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
 ░            ░  ░                      ░  ░   ░  ░       ░ ░        ░     ░  ░   ░     
      ░                                                             ░                   
");
        
        // Return to exploration state
        States.ChangeState(StateTypes.Exploring);
    }
}
