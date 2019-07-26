﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //GameState
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuText("Hello Nic.");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            MainMenuText("Hello.");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            MainMenuText("Hello Mr Bond.");
        }
        else
        {
            Terminal.WriteLine("ERROR. Please use a valid input.");
        }
    }

    void MainMenuText(string greeting)
    {
        currentScreen = Screen.MainMenu;

        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Initializing... terminalHacker.py");
        Terminal.WriteLine("All systems online.");
        Terminal.WriteLine("IP masking activated.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Registering vulnerable reachable IPs...");
        Terminal.WriteLine("Press 1 to hack your dad's laptop");
        Terminal.WriteLine("Press 2 to break into your bank");
        Terminal.WriteLine("Press 3 to steal nuclear launch codes");
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        print(level);
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to level " + level);

        if (level == 1)
        {            
            Terminal.WriteLine("Laptop model: OldCrap 1000.");
            Terminal.WriteLine("Connecting...");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}