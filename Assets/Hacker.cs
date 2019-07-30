using UnityEngine;
using System.Net.Http;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type menu at any time.";
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
            Terminal.WriteLine(menuHint);
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
        SetLevelPassword();
        LevelGreeting();
        Terminal.WriteLine("Input password. Hint: " + password.Anagram());
    }

    void SetLevelPassword()
    {
        //Setting password and text for the right level.
        switch (level)
        {
            case 1:
                password = psw1[Random.Range(0, psw1.Length)];
                break;
            case 2:
                password = psw2[Random.Range(0, psw2.Length)];
                break;
            case 3:
                password = psw3[Random.Range(0, psw3.Length)];
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }
    }

    void LevelGreeting()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Laptop model: OldCrap 1000.");
                Terminal.WriteLine("Connected");
                break;
            case 2:
                Terminal.WriteLine("Connected to Bank of Bankland");
                Terminal.WriteLine("Firewall bypass required");
                break;
            case 3:
                Terminal.WriteLine("Connected to nuclear plant.");
                Terminal.WriteLine("I hope you know what you're doing.");
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
            TryAgain();
        }
    }

    void TryAgain()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Please try again.");
        SetLevelPassword();
        Terminal.WriteLine("Input password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
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
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
