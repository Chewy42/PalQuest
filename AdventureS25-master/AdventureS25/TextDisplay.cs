namespace AdventureS25;

using System;
using System.Threading;
using System.Collections.Generic;

public static class TextDisplay
{
    // Delay between each character (in milliseconds)
    private static int characterDelay = 30;
    private static readonly Dictionary<char, int> punctuationDelays = new Dictionary<char, int>
    {
        { '.', 300 },
        { ',', 150 },
        { '!', 300 },
        { '?', 300 },
        { ';', 200 },
        { ':', 200 },
        { '-', 150 },
        { '(', 150 },
        { ')', 150 },
        { '[', 150 },
        { ']', 150 },
        { '"', 150 },
        { '\'', 150 }
    };

    /// <summary>
    /// Displays ASCII art with minimal delay for faster rendering, can be skipped with key press
    /// </summary>
    /// <param name="text">The ASCII art text to display</param>
    public static void TypeAsciiArt(string text)
    {
        // Use a minimal delay (1ms) for ASCII art
        const int minimalDelay = 5;
        
        // Check if a key was pressed to allow skipping
        foreach (char c in text)
        {
            // Check if a key is available and skip the animation if pressed
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true); // Clear the key
                Console.Write(text);    // Output all text at once
                Console.WriteLine();    // Add final newline
                return;                 // Exit the method
            }
            
            Console.Write(c);
            Thread.Sleep(minimalDelay);
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Displays text character by character with a delay between each character
    /// </summary>
    /// <param name="text">The text to display</param>
    public static void TypeLine(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine();
            return;
        }

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            Console.Write(c);
            // Skip typing effect if Enter is pressed
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                Console.Write(text.Substring(i + 1));
                break;
            }
            int delay;
            if (punctuationDelays.TryGetValue(c, out delay))
            {
                Thread.Sleep(delay);
            }
            else
            {
                Thread.Sleep(characterDelay);
            }
        }
        Console.WriteLine(); // Add newline at the end
    }

    /// <summary>
    /// Sets the delay between characters
    /// </summary>
    /// <param name="delay">Delay in milliseconds</param>
    public static void SetCharacterDelay(int delay)
    {
        if (delay >= 0)
        {
            characterDelay = delay;
        }
    }
}
