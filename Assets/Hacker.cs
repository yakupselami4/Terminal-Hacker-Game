using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game configuration data

    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "asile","self","password","font","borrow","books" };
    string[] level2Passwords = { "prisoner", "handcuffs", "murder", "gate", "uniform", "arrest" };
    string[] level3Passwords = { "reflect", "planet", "alien", "earth", "unknown object", "invisible" };
    string[] devilWords = {"satan","hell","fire","death","lucifer","doom"};

    //Game State
    string barcode;
    string choose;
    string pill;
    int level;
    enum Screen { MainMenu,Password, Win,Matrix,Hitman};
    Screen currentScreen;
    string password;
    string words;



    // Start is called before the first frame update
    void Start()
    {

        ShowMainMenu();
        

    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the X Files");
        Terminal.WriteLine("Enter your selection: ");
    }



    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if(currentScreen==Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input){
        bool isValidLevelNumber = (input == "1" || input == "2" || input=="3");
        if(isValidLevelNumber){
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "69")
        {
            Terminal.WriteLine("You are in BayburtZone! Dangereous Level!");
            Terminal.WriteLine(@"
(｡)(｡)");
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Welcome Mr. Bond");
            Terminal.WriteLine(@"
    JAMES BOND 007
            "); 
        }else if (input=="Matrix"){
            currentScreen = Screen.Matrix;
            Terminal.WriteLine("Do you want enter to Matrix?");
            if(input=="yes"){
                Terminal.WriteLine("For choose Redpill you can write 1, for choose Bluepill you can write 2 ?");
                switch (input)
                    {
                        case "1":
                            Terminal.WriteLine("You are in the matrix!");
                            break;
                        case "2":
                            Terminal.WriteLine("You take the blue pill... the story ends, you wake up in your bed and believe whatever you want to believe.");
                            break;
                        default:
                            Terminal.WriteLine("You can say only red or blue");
                            break;
                    }
            }else if(input=="no"){
                Terminal.WriteLine("okey");
            }
            }
        
        else if (input == "666")
        {
            Terminal.WriteLine("I'm the devil!");
                words = devilWords[Random.Range(0, devilWords.Length)];
                Terminal.WriteLine(words);
            Terminal.WriteLine("You can write 666 for another devil word");
        }
        else if (input=="47"){
            currentScreen = Screen.Hitman;
            Terminal.WriteLine("Enter right barcode: "+barcode);
            Terminal.WriteLine(@"
            HITMAN");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level!");
            Terminal.WriteLine(menuHint);
        }
    }

    void CheckPassword(string input){
        if(input==password){
            DisplayWinScreen();

        }else{
            AskForPassword();
        }
    }
    void AskForPassword(){
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: "+password.Anagram());
    }
    
    void DisplayWinScreen(){
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }
    
    void ShowLevelReward(){
        switch(level){
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
");
                break;
                case 2:
                Terminal.WriteLine(@"
     _,     ,_
    .'/  ,_   \'.
   |  \__( >__/  |
   \             /
    '-..__ __..-'
         /_\

"+"You are free now...");
            break;
            case 3:
                Terminal.WriteLine(@"
     ___    ___
    (_ _)  (_ _)
      \\    //
       \\  //
        \\//
THE      ||      FILES
        //\\
       //  \\
     _//    \\_
    (___)  (___)
"+"You are in x files now...");
                break;
            default:
                Debug.LogError("Invalid level reached!");
            break;
        }
    }

    void SetRandomPassword(){
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Are you sure you want to do this?");
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number!");
                break;
        }
    }

}
