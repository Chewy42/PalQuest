namespace AdventureS25;

class Program
{
    public static void Main(string[] args)
    {
        var startMenu = new StartMenu();
        
        bool startGame = startMenu.Show();
        
        if (startGame)
        {
            Game.PlayGame();
        }
    }
}