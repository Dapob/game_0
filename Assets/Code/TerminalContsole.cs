using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerminalContsole : MonoBehaviour
{
    //Choice action
    int level;
    const string menuHint = "Напишите 'меню', что бы вернутся назад";
    string password;
    string[] Level1Password = {"книга","страница","читать","знание","литература","библиотека","автор","сказка","слово","печать"};
    string[] Level2Password = {"полиция","закон","оружие","арест","служба","дозор","патруль","преступник","нарушение","детектив"};
    string[] Level3Password = {"космос","галактика","звезда","астронавт","луна","планета","космический","пространство","вселенная","ракета"};
    string[] Level2909Password = {"The Cake Is a Lie"};
    enum Screen {MainMenu,Password,Win};
    Screen currentScreen = Screen.MainMenu;


    // Its main code
    void Start()
    {
        ShowMainMenu("Игрок");
    }


    void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Привет, " + playerName + "!");
        Terminal.WriteLine("Какой терминал вы хотите взломать сегодня?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Введите ваш выбор:");
        Terminal.WriteLine("Введите 1 - городская библиотека");
        Terminal.WriteLine("Введите 2 - полицейский участок");
        Terminal.WriteLine("Введите 3 - космический корабыль");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Игра создана автором Дапобом)");
    
    }


    void OnUserInput(string input)
    {
        if (input.ToLower() == "меню")
        {
            ShowMainMenu("рад видеть тебя сново");
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
            bool isValidLevelNumber = ( input == "1" || input == "2" || input == "3" || input == "2909");
            if (isValidLevelNumber)
            {
                level = int.Parse(input);
                GameStart();
            }
            else if (input == "777")
            {
                Terminal.WriteLine("Ты выграл 1 гривну)))");
            }
            else
            {
                Terminal.WriteLine("Введите правильное значение!");
            }
    }


    void GameStart() // часть кода
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        switch(level)
        {

            case 1:
                password = Level1Password[Random.Range(0,Level1Password.Length)];
            break;
            case 2:
                password = Level2Password[Random.Range(0,Level2Password.Length)];
            break;
            case 3:
                password = Level3Password[Random.Range(0,Level3Password.Length)];
            break;
            case 2909:
                password = Level2909Password[Random.Range(0,Level2909Password.Length)];
            break;

        }
        switch(level)
        {

            case 1:
                Terminal.WriteLine("Вы в годской библиотеке");
            break;
            case 2:
                Terminal.WriteLine("Вы в полицейском участке");
            break;
            case 3:
                Terminal.WriteLine("Вы на космическом корабле");
            break;
            case 2909:
                Terminal.WriteLine("Вы на секретном уровне");
            break;

        }
        Terminal.WriteLine("Буквы которые есть в слове(подсказка): " + password.Anagram());
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Введите пароль:");
    }
   
    
    void CheckPassword (string input)
    {
         if (input == password)
        {
            ChowWinScreen();
        }
        else 
        {
            GameStart();
        }
    }


    void ChowWinScreen()
    {
        Terminal.ClearScreen();
        Reward();
    }


    void Reward()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine(menuHint);
        switch(level)
        {

            case 1:
                Terminal.WriteLine("Вы выграли, вот ваша книга:");
                Terminal.WriteLine(@"
      ______ ______
    _/   \_
   // ~~ ~~ | ~~ ~ \\
  // ~ ~ ~~ | ~~~ ~~ \\ 
 //________.|.________\\ 
`----------`-'----------'");
            break;
            case 2:
                Terminal.WriteLine("Вы выграли, вот ваше оружие:");
                Terminal.WriteLine(@"
   __,_____ 
  / __.==--)
 /#(-'
`-'     ");
            break;
            case 3:
                Terminal.WriteLine("Вы выграли, вот ваша звезда:");
                Terminal.WriteLine(@"
      ,
   \  :  /
`. __/ \__ .'
_ _\     /_ _
   /_   _\
 .'  \ /  `.
   /  :  \ 
      '");
            break;
            case 2909:
                Terminal.WriteLine("Вы прошли секретный уровень, вот ваш   тортик:");
                Terminal.WriteLine(@"
 _!_!_!_!_
|  ||    ||
|  ||   |||
}{{{{}}}{{{
  __||__");
            break;
        
        }
    }
}