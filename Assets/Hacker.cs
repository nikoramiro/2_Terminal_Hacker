using UnityEngine;
using System.Net.Http;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    string[] psw1 = { "baseball", "jazz", "football", "oreo", "cars" };
    string[] psw2 = { "interest", "account", "withdraw", "overdraft", "statement" };
    string[] psw3 = { "meltdown", "plutonium", "thermonuclear", "contamination", "enrichment" };

    //GameState
    public int level;
    public string password;
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
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007") //Easter egg.
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
        string please = "Please input password:";
        Terminal.ClearScreen();

        //Setting password and text for the right level.
        switch (level)
        {
            case 1:
                password = psw1[Random.Range(0, psw1.Length)];
                Terminal.WriteLine("Laptop model: OldCrap 1000.");
                Terminal.WriteLine("Connecting...");
                Terminal.WriteLine(please);
                break;
            case 2:
                password = psw2[Random.Range(0, psw2.Length)];
                Terminal.WriteLine("Connecting to Bank of Bankland");
                Terminal.WriteLine("Firewall bypass required");
                Terminal.WriteLine(please);
                break;
            case 3:
                password = psw3[Random.Range(0, psw3.Length)];
                Terminal.WriteLine("Connecting to Chernobyl");
                Terminal.WriteLine("I hope you know what you're doing here.");
                Terminal.WriteLine(please);
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }
    }

    void CheckPassword(string input)
    {   
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Please try again.");
        }               
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        Terminal.WriteLine("Congratulations! You win.");
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Here, have a dad joke.");
                Terminal.WriteLine("Why was the big cat disqualified from the race? Because it was a cheetah.");
                
                break;
            case 2:
                Terminal.WriteLine(@"
___________________________________
|#######====================#######|
|#(1)*UNITED STATES OF AMERICA*(1)#|
|#**          /===\   ********  **#|
|*# {G}      | ( ) |             #*|
|#*  ******  | /v\ |    O N E    *#|
|#(1)         \===/            (1)#|
|##=========ONE DOLLAR===========##|
------------------------------------
"
);
                break;
            case 3:
                Terminal.WriteLine(@"
          _ ._  _ , _ ._
        (_ ' ( `  )_  .__)
      ( (  (    )   `)  ) _)
     (__ (_   (_ . _) _) ,__)
         `~~`\ ' . /`~~`
              ;   ;
              /   \
_____________/_ __ \_____________
"
                );
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }
        Terminal.WriteLine("Type menu to go back to the main menu");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
