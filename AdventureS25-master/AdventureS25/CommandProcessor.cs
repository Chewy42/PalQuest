namespace AdventureS25;

public static class CommandProcessor
{
    public static Command Process()
    {
        // get input
        string rawInput = GetInput();
        while (string.IsNullOrWhiteSpace(rawInput))
        {
            rawInput = GetInput(false);
        }
        
        // make sure two words
        Command command = Parser.Parse(rawInput);

        Debugger.Write("Verb: [" + command.Verb + "]");
        Debugger.Write("Noun: [" + command.Noun + "]");
        
        // make sure we have the words in our vocabulary
        bool isValid = CommandValidator.IsValid(command);
        command.IsValid = isValid;

        // do stuff with the command
        Debugger.Write("isValid = " + isValid);

        return command;
    }
    
    public static string GetInput(bool printPrompt = true)
    {
        if (printPrompt) Console.Write("> ");
        var inputBuilder = new System.Text.StringBuilder();
        System.ConsoleKeyInfo keyInfo;
        while (true)
        {
            keyInfo = System.Console.ReadKey(true);
            if (keyInfo.Key == System.ConsoleKey.Enter)
            {
                if (inputBuilder.Length == 0)
                    continue;
                break;
            }
            inputBuilder.Append(keyInfo.KeyChar);
            Console.Write(keyInfo.KeyChar);
        }
        string input = inputBuilder.ToString();
        if (input.Length > 0)
        {
            Console.WriteLine();
        }
        return input;
    }
}