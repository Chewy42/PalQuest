using System;
using System.Collections.Generic;

namespace AdventureS25;

public static class Pals
{
    // Dictionary to store all Pals by name
    private static Dictionary<string, Pal> nameToPal = new Dictionary<string, Pal>();
    
    // List of player-owned Pals (useful for inventory management)
    private static List<string> playerPals = new List<string>();
    
    public static void Initialize()
    {
        // Create and register Sandie Pal
        Pal sandie = new Pal(
            "Sandie",
            "A rare corgi-type Pal with quantum-computing capabilities. She's extremely affectionate and loyal.\n",
            @"
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
⣧⣙⣻⣿⣿⣿⣛⣛⣛⣛⣛⣟⣛⣿⣻⣻⣿⣿⣿⣿⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣛⣻⣟⣻⣿⣛⣛⣛⣻⣟⣃⣾⣿⣿⣿⣿
",
            30);
        RegisterPal(sandie);
        
        // Create and register Morty (Professor Jon's Pal)
        Pal morty = new Pal(
            "Morty",
            "Professor Jon's prized digital-type Pal. It appears to be made of pure energy and code, displaying complex algorithms in its movements.",
            @"
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣛⣅⣒⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢇⣚⠉
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⠿⠟⠛⠛⣛⡛⠉⣑⠒⠘⠛⠻⠭⠟⠿⠟⠫⠉⠻⠛⠓⠉⠀⣁⣈⣤⣤⣄⣠⣀⣤⣤⣤
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠯⡀⠀⣠⣾⣿⡿⠁⣰⠂⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡂⣵⣾⣿⡿⠿⠿⠻⠛⠛⠙⠛⠿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣾⣿⣿⣶⡙⠿⢟⠁⢺⠋⠰⡀⠀⠂⠄⠀⠀⠀⠐⣲⣸⣷⡀⠘⡸⣿⣿⠋⠀⠉⠁⠀⣤⠀⠀⠀⠀
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣸⣿⣿⣿⣿⡇⠞⠁⠀⣰⣮⣄⣀⣀⣀⢔⠁⢀⣴⣾⣿⣿⣿⣷⡄⠀⢞⢻⠃⠀⠀⡀⠈⠉⠂⠀⠀⠀
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢼⣿⣿⣿⣿⣧⠀⢀⡐⠩⠽⠋⠝⠛⢃⣠⣴⣾⣿⣿⣿⣿⣿⣿⣿⣦⠄⠈⠀⠀⠀⠐⡶⣶⣶⣶⣶⠆
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣸⣿⣿⣿⣿⣿⢠⣣⣿⣿⣿⣿⢋⡴⡿⠿⠫⢿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣮⣤⣠⡀⠀⡀⠈⠉⢉⣁⣈
⣿⣿⣿⣿⣿⣿⣿⠿⣿⢿⠿⠟⣸⣽⣿⣿⣿⣿⢸⣿⣿⣿⠟⣁⣿⠋⠀⠀⠀⠀⠉⠉⠉⠉⠛⠿⠿⢿⣿⣿⣿⣯⣃⠂⠒⠒⠂⠀⢸⣿
⠉⣦⣧⣖⡎⡍⣦⣷⣿⣶⣗⠇⠸⣿⣿⣿⣿⣯⢈⢿⣯⣷⣾⣿⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣽⣽⣦⠀⠈⠀⣀⡀⢿
⢸⣿⣿⣽⣿⣅⢸⣿⣿⣿⣿⣿⠊⣿⣿⣿⣿⣿⢸⢇⣽⣿⡿⣿⣣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⡯⣀⠀⠀⢽⣾
⢸⣟⡿⡻⢿⢿⡊⡫⡿⡿⣟⡟⡁⢏⣿⣿⣿⣿⠄⢸⣿⣿⣧⢱⠿⡿⣆⠀⠀⠀⠀⠀⠀⠀⢀⣤⣶⣿⣿⣿⣿⣿⣿⣿⣿⠋⠀⠀⢸⣿
⣼⡗⢾⣿⣿⡹⡿⠿⣿⣿⣿⣿⣿⣷⣶⣭⣝⢿⠅⣿⣿⣟⣿⡿⣤⢡⢯⣤⣢⣀⣀⣀⣀⡀⠈⣻⠛⣿⣿⣿⣿⣿⣮⡍⠙⠀⠀⠀⣸⣿
⣿⣷⣎⣛⠿⠾⠮⠯⣫⡻⣷⡾⡝⣿⣿⣿⣿⣿⣷⡄⢹⣿⣿⣙⣻⣏⠁⠀⠘⣿⣿⣿⢾⣿⣿⡏⠈⠙⠛⠿⠿⠿⠋⠀⠀⠀⠀⢠⣿⣿
⣿⣿⣿⣿⣵⣵⣠⣤⣤⠄⠈⠸⣜⣾⣿⣿⣿⣿⣿⣟⢼⣿⣿⣿⣾⣿⣶⣤⣀⣈⠉⠁⠈⠉⠁⣀⣤⣾⣿⣿⣷⣀⣀⣠⣤⣴⣾⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣯⡇⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇
",
            25);
        RegisterPal(morty);
        
        // Create more Pals here for your game as needed
        Pal flameTail = new Pal(
            "FlameTail", 
            "A fire-type Pal with a tail that burns eternally. Its cheerful disposition makes it a favorite among beginners.",
            @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            20);
        RegisterPal(flameTail);
        
        Pal aquaTide = new Pal(
            "AquaTide", 
            "A water-type Pal that can control currents and tides. It's capable of creating small water bubbles for transportation.",
            @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⠏⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⡏⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⠁⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            18);
        RegisterPal(aquaTide);
    }
    
    // Add a Pal to the system
    public static void RegisterPal(Pal pal)
    {
        nameToPal[pal.Name] = pal;
    }
    
    // Add a Pal to the player's collection
    public static void GivePalToPlayer(string palName)
    {
        if (nameToPal.ContainsKey(palName) && !playerPals.Contains(palName))
        {
            playerPals.Add(palName);
            // You could trigger other events here, like updating the UI
        }
    }
    
    // Check if player has a specific Pal
    public static bool PlayerHasPal(string palName)
    {
        return playerPals.Contains(palName);
    }
    
    // Get a Pal by name - returns null if not found
    public static Pal? GetPalByName(string palName)
    {
        if (nameToPal.ContainsKey(palName))
        {
            return nameToPal[palName];
        }
        return null;
    }
    
    // Get all Pals owned by the player
    public static List<Pal> GetPlayerPals()
    {
        List<Pal> pals = new List<Pal>();
        foreach (string palName in playerPals)
        {
            if (nameToPal.ContainsKey(palName))
            {
                pals.Add(nameToPal[palName]);
            }
        }
        return pals;
    }
    
    // Get all available Pals in the game
    public static List<Pal> GetAllPals()
    {
        return new List<Pal>(nameToPal.Values);
    }
}
