global using System;
global using System.Collections.Generic;
global using System.IO; 
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Security.Cryptography;
global using System.Text;

namespace ConsoleApp;

public class Enter()
{
    public static void Main()
    {
        Uttils.PasswordManager password = new();
        password.PasswordCheck();

        Menus.Menu menu = new Menus.Menu();
        menu.Run();
    }
}
