namespace ConsoleApp;

public static class ParsingConsole
{
    public static void ParseConsole()
    {
        var navigationStack = new Stack<string>();

        navigationStack.Push("Main menu");

        Console.WriteLine("Welcome to Vita");

        while (true)
        {
            if (navigationStack.Count == 0)
            {
                Console.WriteLine("Goodbye");
                break;
            }

            switch (navigationStack.Peek())
            {
                case "Exit":
                    navigationStack.Pop();
                    navigationStack.Pop();

                    break;
                case "Main menu":
                    Console.WriteLine("Select:");
                    Console.WriteLine("1. Event");
                    Console.WriteLine("2. Storage");
                    Console.WriteLine("3. SPECIAL");
                    Console.WriteLine("4. Timeline");
                    Console.WriteLine("5. Exit");

                    var optionKeyMain = Console.ReadLine();

                    if (int.TryParse(optionKeyMain, out int optionMain) &&
                    Enum.IsDefined(typeof(SelectedOptionMain), optionMain))
                    {
                        var selectedOption = (SelectedOptionMain)optionMain;
                        navigationStack.Push(selectedOption.ToString());

                    }
                    break;

                case "Event":
                    Console.WriteLine("Event");
                    Console.WriteLine("Select");
                    Console.WriteLine("1. TakeNote");
                    Console.WriteLine("2. Exit");

                    var optionKeyEvent = Console.ReadLine();

                    if (int.TryParse(optionKeyEvent, out int optionEvent) &&
                    Enum.IsDefined(typeof(SelectedOptionEvent), optionEvent))
                    {
                        var selectedOption = (SelectedOptionEvent)optionEvent;
                        navigationStack.Push(selectedOption.ToString());
                    }
                    break;
                case "TakeNote":
                    Console.WriteLine("Write something down");
                    string text = Console.ReadLine();

                    Eveent eveent = new Eveent(DateTime.Now);
                    eveent.ParseText(text);



                    navigationStack.Pop();
                    break;
            }
        }
    }
}
