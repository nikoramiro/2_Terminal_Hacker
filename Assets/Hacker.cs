using System;
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
        MainMenuText("Hello.");
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
        else if (currentScreen == Screen.Password)
        {
            RunPassword(input);
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
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to level " + level);

        if (level == 1)
        {            
            Terminal.WriteLine("Laptop model: OldCrap 1000.");
            Terminal.WriteLine("Connecting...");
            Terminal.WriteLine("Please input password:");
        }
    }

    void RunPassword(string input)
    {
        if(level == 1)
        {
            if (input == "baseball")
            {
                WinnerScreen();
            }
            else
            {
                Terminal.WriteLine("Please try again.");
            }
        }
        if(level == 2)
        {
            if (input == "account")
            {
                WinnerScreen();
            }
            else
            {
                Terminal.WriteLine("Please try again.");
            }
        }
        if (level == 3)
        {
            if (input == "plutonium")
            {
                WinnerScreen();
            }
            else
            {
                Terminal.WriteLine("Please try again.");
            }
        }
    }

    void WinnerScreen()
    {
        Terminal.WriteLine("Congratulations! You win.");
        Terminal.WriteLine("Type menu to go back to the main menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
