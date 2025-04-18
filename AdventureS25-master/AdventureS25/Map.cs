namespace AdventureS25;

public static class Map
{
    private static Dictionary<string, Location> nameToLocation = 
        new Dictionary<string, Location>();
    public static Location StartLocation;
    
    public static void Initialize()
    {
        Location home = new Location("Home", 
            @"
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠘⣦⣌⠉⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⢹⡏⣿⡶⣤⣀⠉⠙⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⢁⡤⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⢀⣧⠀⢳⡘⣷⠈⣭⣛⣳⡤⣀⠀⠉⠻⠟⠛⠋⢁⠀⡀⠂⠋⢀⡄⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⣼⣿⡄⠈⣧⠸⣦⠠⣬⠙⣻⡌⢲⠀⠒⠤⠦⢔⡡⠂⠀⢁⣴⣿⣿⡀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⣰⣿⣿⣿⡄⠘⢇⠉⡄⢙⠃⠙⣿⡌⡄⠸⣶⣤⣤⣤⡄⣶⡖⠤⠤⢭⣍⠦⠘⠛⠿⢿⣿⣿⡟⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⢰⣿⣿⣿⣿⣷⡀⠘⣦⠹⠄⢻⣧⠹⣷⡐⡄⠙⣿⣿⣿⡇⢻⡇⣶⠄⡄⢸⡆⠗⢆⠢⣤⣀⣉⠁⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠁⣠⣿⣿⣿⣿⣿⣿⣧⡀⠘⣆⠲⡆⢰⣆⠸⣷⡘⣄⠈⢻⣿⣿⢸⡇⣬⢀⡁⢸⡇⢰⠈⢷⠘⢌⠻⡓⡄⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠘⣤⠠⣄⢩⣥⠈⣳⡘⢷⣄⠹⠿⢸⡇⠃⠀⠃⢸⡇⣘⠷⠀⠶⠐⢦⡐⡌⠀⠘⣿⣿⠟⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⠏⢀⣼⣿⣿⣿⣿⣿⠉⣿⣿⢿⣿⣿⣄⠈⢦⠙⣆⠙⢃⠘⠷⠌⢿⣿⢲⣤⣤⣥⣬⣌⠘⠣⠿⠤⠶⠦⠛⠘⠃⠉⠈⠀⠀⠀⡀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⡿⠋⢀⣾⣿⣿⣷⡀⢠⣤⠀⣶⣶⡆⣿⣿⣿⣦⠈⢷⡙⠷⠘⠷⡌⢿⡄⢻⣦⠹⣿⣿⡿⠋⠠⠔⠤⠀⣶⠖⢠⡶⣶⡶⣿⠟⢀⣾⣷⡀⠹⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⡟⢁⣴⣿⣿⣿⣿⣿⡇⠀⣿⡄⢻⣿⡇⢸⣿⣿⣿⣷⣄⠹⣌⢳⣄⢲⣄⢲⣦⠹⣷⡾⠋⢀⠔⠁⠔⠠⠶⠂⡴⢂⡴⢋⠜⠁⣠⣿⣿⣿⣷⡀⠙⢿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⢛⣴⢻⣿⣿⣿⣿⣿⣿⠁⠀⢛⡃⢙⣋⡁⢸⣿⣿⣿⣿⣿⣇⠘⠳⠿⠧⣽⠦⡿⠛⢁⡠⢞⡠⠄⣁⠘⠃⠴⢂⠠⡠⠔⠁⡠⠞⠋⣉⣉⡉⠙⢿⣆⠀⠻⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⡇⠈⢻⣿⣿⣿⣿⣿⡷⠀⣿⡇⢸⣿⡇⠸⣿⣿⣿⣿⣿⣿⣿⣶⣤⣤⣤⣀⠐⠚⠭⠶⠯⠶⠯⠥⠬⠩⠄⠁⢈⣠⣴⢋⡐⢿⠃⡿⢡⠟⡆⠀⢿⣷⣄⡈⠻⣿⣿⣿
⣿⣿⣿⣿⠏⠀⠀⠈⣿⣿⣿⣿⣿⡇⠐⠛⢓⡋⠭⠁⢠⣿⣿⣿⣿⣿⡏⢹⣿⣿⣿⣿⣿⣏⠰⣦⡤⣤⡤⢠⣤⣤⣴⣶⢺⣿⣿⡏⠚⠛⠀⠀⠤⠤⠾⠇⠀⣸⣿⣿⣿⣷⣼⣿⣿
⣿⣿⡿⠉⢀⣶⣮⠀⢻⣿⣿⣿⣿⣿⣤⣤⣤⣤⣴⣾⣿⣿⣿⣿⣿⣿⡇⢸⡏⣉⢩⠙⣿⣿⠀⣿⣦⢩⡍⣈⠙⣿⣿⣿⡜⣿⣿⣛⠛⠛⠛⠛⠛⠿⠿⠿⢿⣿⣿⣿⢸⣿⣿⣿⣿
⣿⠏⠠⣴⣾⣿⣿⡄⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢸⡇⠛⠈⠀⣿⣿⠀⣿⣿⠈⠃⠙⠀⣿⣿⣿⡇⣿⣿⣿⠹⣿⣿⡄⣿⣿⣿⠘⣿⣿⣿⠇⣸⣿⣿⣿⣿
⡿⠁⢸⣿⣿⣿⡿⠻⠈⣿⣿⣿⣿⣿⡛⢛⣉⡁⢨⣤⡄⢹⣿⣿⣿⣿⡇⢸⡇⣿⠀⠀⣿⣿⠀⣿⣿⢸⡇⣷⠀⣿⣿⣿⠀⣿⣿⣿⠀⣿⣿⡇⣿⣿⣿⠀⣿⣿⣿⠀⣿⣿⣿⣿⣿
⠠⢾⡿⢿⠛⡛⠂⢀⡄⢸⣿⣿⣿⣿⡇⠘⣿⡇⢸⣿⡇⢸⣿⣿⣿⣿⡇⣸⡇⣿⢠⠀⣿⣿⠀⢹⣿⢸⡇⣿⠀⣿⣿⣿⠀⣿⣿⣿⢀⣿⣿⡇⣿⣿⣿⢰⣿⣿⡿⠀⣿⣿⣿⣿⣿
⣶⣦⣅⣘⣀⡇⣼⣿⡅⢸⣿⣿⣿⣿⣿⠀⠘⠃⢈⣩⡅⠘⣿⣿⣿⣿⡇⣿⠃⠈⠘⠀⣿⣿⡆⢸⡇⢈⠁⣛⠀⣿⣿⣿⠀⣿⣿⡏⢸⣿⠿⠇⠿⣿⣿⢸⣿⣿⡇⢠⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣧⢩⣉⣉⠀⣿⣿⣿⣿⣿⠀⢸⡇⢸⣿⣧⠀⣿⣿⣿⣿⡇⣿⠀⠃⠘⢀⣿⣿⠃⢰⠇⠈⠁⠉⣠⣿⣿⣿⠀⢽⣿⡇⣿⣿⣦⢠⣶⣿⡏⣸⣿⣿⡇⢈⡉⢻⣿⣿⣿
⣿⣿⣿⣿⠁⣤⣼⣿⣿⡇⣿⣿⣿⣿⣿⠀⠸⠟⠘⢛⡋⠀⣿⣿⣿⣿⡇⢿⣤⣤⣴⣶⣿⣿⠀⣼⣦⣤⣴⣶⣶⣿⣿⣿⠀⣿⣿⡇⣿⣿⣿⢸⣿⣿⡇⣿⣿⣿⡇⣼⡆⢼⣿⣿⣿
⣿⣿⡟⢡⣶⣿⣿⣿⣿⣷⢸⣿⣿⣿⣿⣈⠁⢀⣀⣀⣤⣴⣾⣿⣿⣿⣇⣸⣿⣿⣿⣿⣿⣿⢰⣿⣿⣿⣿⣿⣿⣿⣿⡿⢠⣿⡿⢰⣿⣿⣯⣼⣿⣿⣇⣿⣿⣿⠀⣿⣿⣾⣧⣘⠛
⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣘⡿⠿⠿⠿⠛⣛⣛⣛⣛⡛⠉⠉⠭⠭⠭⠭⣥⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⠀⠀⣉⣉⣉⣉⣉⠛⠛⠛⠛⠛⠿⠯⠴⣿⣿⣿⣿⣏⠄
⣿⣿⣿⣿⣿⣿⣛⣫⣭⣭⡴⠶⠒⠚⣛⣛⣁⣄⠠⠀⠀⠶⠒⠂⠐⣉⣛⣋⣉⣭⣭⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡖⢘⣿⣿⣿⣿⣿⣿⣯⣐⠒⠶⣦⣤⣤⣬⣍⣙⡛⠓
⣿⣿⣿⣿⢟⣋⣉⢥⣶⠶⠾⠟⣛⣉⣉⣥⣴⣶⠶⠶⠾⢟⣻⣿⣿⣿⣿⣿⡿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠛⠛⠛⠉⣉⣉⣀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣌⠻⣿⣿⣿⣿⣷
⣿⣿⣿⣿⣿⣭⣵⣶⡶⠿⠿⢛⣋⣉⣭⣴⣶⠶⠾⠟⠛⠋⢉⣉⣀⣀⣤⣤⣴⣶⣶⣶⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠗⢸⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣯⣤⣶⣿⡿⠿⠛⠋⣉⣀⣤⣤⣴⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⠛⠛⠉⣀⣠⣾⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⠋⣉⣤⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠛⠉⣁⣠⣤⣤⣶⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣯⠀⠙⠛⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋⣠⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡈⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⣄⣈⣉⣙⠛⠛⠛⠻⠿⠿⠿⠿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣤⣤⣙⠻⠿⣿
This is your home. Everything starts here.");
        nameToLocation.Add("Home", home);
        
        Location grasslands = new Location("Verdant Grasslands", 
            @"
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⢀⠀⣠⡾⠿⠹⠟⣲⡿⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⡾⠛⣿⠇⠩⣘⡟⣀⢀⠛⠀⠉⢉⡽⠦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣴⣿⣟⣛⣷⣾⣤⣦⡴⣿⣽⣴⣾⣤⣤⣵⣮⣛⡂⠀⠀⠀⠀⠀⠀⣀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠤⢼⠏
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠚⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣷⣼⢻⠛⣿⣿⡟⣿⣦⢰⣵⣯⣤⣤⠀⠀⠈⠛⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⣈⣀⠝⣽⠝⠋⢰⡿⣿⣿⣦⣏⣷⣿⡞⠋⠈⠀⠌⠐⡖⠁⢰⠻⠽⣤⡀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⠻⠁⠀⠀⠀⣠⣶⣾⣯⠹⡦⠑⡆⠀⣀⠐⠛⣿⢿⢇⣽⣿⣿⣶⣾⠀⢀⣬⣇⣆⣀⡀⣶⣳⡆⠀⠀⠀⠀⠀⠐⠿⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣶⡰⢶⣦⢀⣤⣈⣀⠉⣾⡏⠿⣿⢯⣿⣿⣿⡟⠙⢀⡟⠛⠿⣷⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡻⣻⣿⣿⣿⣤⣿⣿⣾⣹⣿⣿⢟⠻⠿⠀⠟⢀⡀⣸⣯⡄⠲⠀⠀⠀⡐⢉⠙⣻⣿⣿⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠐⠻⠿⣟⣻⣿⣧⢯⣽⣿⢫⣶⡾⢿⡧⣠⣮⡴⣽⣿⣋⣁⠔⠉⠣⢨⠣⣲⡿⢿⠿⠟⠃⠀⠀⠀⠀⠀⣀⣤⠀⠀⠀⠀⠀
⣦⡄⠀⠀⠀⠀⠠⣾⣿⣷⣿⣶⣶⣿⣿⢊⠹⠉⣻⡿⣭⣿⠷⠀⣻⣷⣮⣾⠿⣟⡿⢿⣶⣺⣤⣠⣷⣷⣿⣦⣿⠇⣲⣶⣄⠀⠀⠀⠈⠃⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢨⣿⣿⢿⣿⣿⣟⣙⣩⣯⣿⣿⣿⣿⣧⣿⣶⣿⣿⠿⠙⠈⠚⠀⢀⠀⠉⢟⠻⣍⠋⠐⡉⠉⠁⠄⢙⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠐⠻⠻⢻⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣬⣴⠠⠐⣀⣠⡙⣿⡶⠚⡄⣸⢋⡀⠄⠀⢌⢡⣿⡥⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠐⠿⢿⠿⣿⣿⣿⣿⣿⣿⣟⣽⣿⣿⣯⣻⣿⣿⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣰⣬⣿⣿⣤⣐⣍⣻⡾⠅⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠀⠙⠉⢻⣿⣿⣿⣻⣿⣿⣿⣿⣿⣿⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢸⠟⣿⣿⣿⣿⣿⣿⣿⠿⠻⠿⢻⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⢩⢿⡟⠻⠛⠃⠛⠟⠃⠘⣿⣏⡗⣴⡿⠁⠀⠛⠛⡟⠟⠀⠀⠀⠀⠙⠛⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⢀⣿⡯⣯⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡗⣧⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣹⣿⣿⢿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣼⢿⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢀⣀⣦⣾⣶⣶⣶⣿⣿⣿⣿⢿⢸⠾⣿⣶⣶⣷⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣗⣿⡟⣷⢹⣿⣿⣿⣿⣿⣧⣦⣤⣄⣀⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⠀⣄⣿⣀⣀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣟⣿⣿⡿⣿⣿⣟⡿⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢠⢦⣦⣿⡿⠿⡿⠿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠫⣷⣿⣾⣿⣿⣿⣧⣦⣦⣿⣦⣶⣀⣄⡀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠉⢰⣤⣍⠛⣉⡙⠻⠿⠞⢛⣦⣧⣭⣴⣾⣿⣿⣿⣿⣿⣾⣿⣿⣿⣏⣽⡉⠻⠟⠿⣭⣾⣿⣧⡜⠛⠛⠻⣯⠤⠏⠀⠃⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠙⠟⠈⠀⠉⠃⠀⠀⠀⠀⠀⠘⢮⡿⠟⠛⠛⢿⣿⣿⡿⡛⡿⠿⠄⠉⠁⠀⠀⠺⠟⠏⠁⠈⠁⠐⠛⠓⠚⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠂⠉⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
A lush, open field where grass-type Pals roam freely. The gentle breeze carries sweet scents of wildflowers, and you can see small Pals playing in the tall grass.");
        nameToLocation.Add("Verdant Grasslands", grasslands);
        
        Location volcano = new Location("Ember Volcano", 
            "An active volcano with rivers of molten lava flowing down its sides. Fire-type Pals thrive in this scorching environment, basking in the heat that would be unbearable to most creatures.");
        nameToLocation.Add("Ember Volcano", volcano);

        Location ocean = new Location("Azure Depths", 
            "A vast underwater realm where water-type Pals swim through colorful coral reefs. Somehow, you can breathe here, and the water feels comfortable against your skin.");
        nameToLocation.Add("Azure Depths", ocean);
        
        Location forest = new Location("Whispering Woods", 
            "A dense forest with towering trees that block out most sunlight. Bug and grass-type Pals hide among the foliage, and you can hear their calls echoing through the trees.");
        nameToLocation.Add("Whispering Woods", forest);
        
        Location mountain = new Location("Stone Summit", 
            "A rocky mountain peak where rock and flying-type Pals make their homes. The air is thin up here, but the view of the surrounding lands is breathtaking.");
        nameToLocation.Add("Stone Summit", mountain);
        
        Location cavern = new Location("Crystal Caverns", 
            "A network of underground caves illuminated by glowing crystals. Ground and dark-type Pals lurk in the shadows, their eyes occasionally reflecting the crystal light.");
        nameToLocation.Add("Crystal Caverns", cavern);
        
        Location laboratory = new Location("Fusion Lab", 
            @"
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⣠⣞⡟⠙⣧⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣏⠈⠳⡀⠘⡄
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⣿⡀⠙⢷⡄⠹⣄⢹
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣶⣏⣀⢙⣷⣄⣙⣦⣸⣾
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣶⠶⢿⠛⠙⣿⡿⠛⠋⠙⠛⠋⠻⠋⠋⠁                                   
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⡿⣿⠉⢻⡄⠀⣇⣀⡟⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡿⣿⠀⠘⣆⠀⢻⡀⢻⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⡀⠈⠷⣄⠈⢧⠀⢳⣿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⠀⠙⢶⣄⠙⢦⣀⣷⣾⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣠⣄⣤⣾⣶⢾⣿⣿⣿⣿⠿⢿⡿⠻⠿⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠛⢿⡉⠙⣧⠀⢸⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⡄⠈⢷⡀⠘⡄⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠹⣄⠈⢷⡀⣿⠧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
A high-tech laboratory where scientists study Pal evolution and genetics. Steel and electric-type Pals assist with experiments, moving between complex machinery.");
        nameToLocation.Add("Fusion Lab", laboratory);
        
        Location ruins = new Location("Ancient Ruins", 
            "The remnants of a civilization that once worshipped Pals as gods. Psychic and ghost-type Pals are drawn to the mysterious energies that still linger here.");
        nameToLocation.Add("Ancient Ruins", ruins);
        
        Location meadow = new Location("Enchanted Meadow", 
            "A magical clearing where fairy and normal-type Pals gather to play. The air sparkles with mysterious energy, and flowers bloom year-round regardless of season.");
        nameToLocation.Add("Enchanted Meadow", meadow);
        
        Location arena = new Location("Battle Arena", 
            "A competitive stadium where trainers bring their strongest Pals to compete. Fighting-type Pals train rigorously here, always seeking to improve their skills.");
        nameToLocation.Add("Battle Arena", arena);
        
        Location palCenter = new Location("Pal Center", 
            "A modern healing facility with state-of-the-art technology for treating injured Pals. The center is staffed by friendly nurses and doctors who can restore your Pals to full health. A large red and white sign hangs above the entrance.");
        nameToLocation.Add("Pal Center", palCenter);
        
        // Connect all locations to home for easy navigation
        home.AddConnection("north", grasslands);
        grasslands.AddConnection("south", home);
        
        // Connect Pal Center to Verdant Grasslands
        grasslands.AddConnection("east", laboratory);
        laboratory.AddConnection("west", grasslands);    

        StartLocation = home;
    }
    

    public static void AddItem(string itemName, string locationName)
    {
        // find out which Location is named locationName
        Location location = GetLocationByName(locationName);
        Item item = Items.GetItemByName(itemName);
        
        // add the item to the location
        if (item != null && location != null)
        {
            location.AddItem(item);
        }
    }
    
    public static void RemoveItem(string itemName, string locationName)
    {
        // find out which Location is named locationName
        Location location = GetLocationByName(locationName);
        Item item = Items.GetItemByName(itemName);
        
        // remove the item to the location
        if (item != null && location != null)
        {
            location.RemoveItem(item);
        }
    }
    
    public static void AddNPC(string npcName, string locationName)
    {
        // find out which Location is named locationName
        Location? location = GetLocationByName(locationName);
        NPC? npc = NPCs.GetNPCByName(npcName);
        
        // add the NPC to the location
        if (npc != null && location != null)
        {
            location.AddNPC(npc);
        }
        else
        {
            if (npc == null)
            {
                Debugger.Write("Could not find NPC: " + npcName);
            }
            if (location == null)
            {
                Debugger.Write("Could not find location: " + locationName);
            }
        }
    }
    
    public static void RemoveNPC(string npcName, string locationName)
    {
        // find out which Location is named locationName
        Location? location = GetLocationByName(locationName);
        NPC? npc = NPCs.GetNPCByName(npcName);
        
        // remove the NPC from the location
        if (npc != null && location != null)
        {
            location.RemoveNPC(npc);
        }
    }

    public static Location GetLocationByName(string locationName)
    {
        if (nameToLocation.ContainsKey(locationName))
        {
            return nameToLocation[locationName];
        }
        else
        {
            return null;
        }
    }

    public static void AddConnection(string startLocationName, string direction, 
        string endLocationName)
    {
        // get the location objects based on the names
        Location start = GetLocationByName(startLocationName);
        Location end = GetLocationByName(endLocationName);
        
        // if the locations don't exist
        if (start == null || end == null)
        {
            TextDisplay.TypeLine("Tried to create a connection between unknown locations: " +
                              startLocationName + " and " + endLocationName);
            return;
        }
            
        // create the connection
        start.AddConnection(direction, end);
    }

    public static void RemoveConnection(string startLocationName, string direction)
    {
        Location start = GetLocationByName(startLocationName);
        
        if (start == null)
        {
            TextDisplay.TypeLine("Tried to remove a connection from an unknown location: " +
                              startLocationName);
            return;
        }

        start.RemoveConnection(direction);
    }
}