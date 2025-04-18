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
        int cursorPos = 0;
        
        while (true)
        {
            keyInfo = System.Console.ReadKey(true);
            
            if (keyInfo.Key == System.ConsoleKey.Enter)
            {
                if (inputBuilder.Length == 0)
                    continue;
                break;
            }
            else if (keyInfo.Key == System.ConsoleKey.Backspace && cursorPos > 0)
            {
                // Handle backspace - remove the last character
                inputBuilder.Remove(cursorPos - 1, 1);
                cursorPos--;
                
                // Clear the line and rewrite it
                Console.Write("\b \b");
                
                // If there are more characters after the cursor position, redraw them
                if (cursorPos < inputBuilder.Length)
                {
                    // Clear the rest of the line
                    Console.Write(new string(' ', inputBuilder.Length - cursorPos));
                    Console.CursorLeft -= inputBuilder.Length - cursorPos;
                }
            }
            else if (keyInfo.Key != System.ConsoleKey.Backspace)
            {
                // Handle regular character input
                inputBuilder.Insert(cursorPos, keyInfo.KeyChar);
                cursorPos++;
                Console.Write(keyInfo.KeyChar);
            }
        }
        
        string input = inputBuilder.ToString();
        if (input.Length > 0)
        {
            Console.WriteLine();
        }
        return input;
    }
}