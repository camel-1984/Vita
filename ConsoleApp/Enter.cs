global using System;
global using System.Collections.Generic;
global using System.IO; 
global using System.Text.Json;
global using System.Text.Json.Serialization;

namespace ConsoleApp;

public class Enter()
{
    public static void Main()
    {
        Menus.Menu menu = new Menus.Menu();
        menu.Run();
    }
}
