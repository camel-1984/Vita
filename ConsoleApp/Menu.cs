using ConsoleApp.MenuSections;
using ConsoleApp.Options;
namespace ConsoleApp;

public class Menu
{
    private readonly Stack<string> MenuStack;

    public Menu()
    {
        MenuStack = new();
    }

    public void RunMenu()
    {

        MenuStack.Push("Main menu");

        Console.WriteLine("Welcome to Vita");

        while (true)
        {
            if (MenuStack.Count == 0)
            {
                Console.WriteLine("Goodbye");
                break;
            }
            switch (MenuStack.Peek())
            {
                case "Exit":
                    MenuStack.Pop();
                    MenuStack.Pop();
                    break;

                case "Main menu":

                    MainSection mainSection = new(MenuStack);

                    mainSection.DisplaySection();

                    var optionMain = Console.ReadLine();

                    mainSection.ParseOption<MaiEnum>(optionMain!);

                    break;

                case "Event":

                    EventSection eventSection = new(MenuStack);

                    eventSection.DisplaySection();

                    var optionEvent = Console.ReadLine();

                    eventSection.ParseOption<EventEnum>(optionEvent!);

                    break;



                case "TakeNote":

                    Console.WriteLine("Write something down");

                    var text = Console.ReadLine();

                    Event eveent = new Event(DateTime.Now);

                    eveent.ParseText(text);

                    MenuStack.Pop();

                    break;
            }
        }
    }
}
