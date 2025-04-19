namespace AdventureS25;

public static class CombatCommandValidator
{
    public static bool IsValid(Command command)
    {
        // Only accept text commands and reject numeric commands
        if (command.Verb.ToLower() == "attack" ||
            command.Verb.ToLower() == "defend" ||
            command.Verb.ToLower() == "special" ||
            command.Verb.ToLower() == "run")
        {
            return true;
        }
        
        // Check for numeric input to give more helpful error message
        if (command.Verb == "1" || command.Verb == "2" ||
            command.Verb == "3" || command.Verb == "4")
        {
            TextDisplay.TypeLine("Please use text commands instead of numbers.");
        }
        
        TextDisplay.TypeLine("Valid commands are: attack, defend, special, run");
        return false;
    }
}