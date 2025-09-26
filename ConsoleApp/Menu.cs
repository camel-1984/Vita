using System.Threading;
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

    public void Run()
    {
        Console.WriteLine("Welcome to Vita");
        MenuStack.Push("Main menu");

        EventOption eventOption = new("Event.json");
        StorageOption storageOption = new("Storage.json");

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

                    var optionMain = Console.ReadLine() ?? "";

                    mainSection.ParseOption<MaiEnum>(optionMain);

                    break;

                case "Event":

                    EventSection eventSection = new(MenuStack);

                    eventSection.DisplaySection();

                    var optionEvent = Console.ReadLine() ?? "";

                    eventSection.ParseOption<EventEnum>(optionEvent);

                    break;

                case "TakeNode":

                    Console.WriteLine("Write title");

                    var noteTitle = Console.ReadLine() ?? "";

                    Console.WriteLine("Write content");

                    var noteContent = Console.ReadLine() ?? "";

                    eventOption.AddNote(noteTitle, noteContent);

                    MenuStack.Pop();

                    break;

                case "ShowNodeList":

                    if (!eventOption.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }

                    var noteToShow = Console.ReadLine() ?? "";

                    if (int.TryParse(noteToShow, out int noteToShowInt) &&
                        eventOption.InRange(noteToShowInt - 1))
                    {

                        eventOption.DisplayNode(noteToShowInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("No such note");
                    }

                    MenuStack.Pop();

                    break;

                case "DeleteEventNode":

                    if (!eventOption.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }

                    var noteToDelete = Console.ReadLine() ?? "";

                    if (int.TryParse(noteToDelete, out int notToDeleteInt) &&
                        eventOption.InRange(notToDeleteInt - 1))
                    {

                        eventOption.DeleteNode(notToDeleteInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("No such note");
                    }

                    MenuStack.Pop();

                    break;

                case "Storage":

                    StorageSection storageSection = new(MenuStack);

                    storageSection.DisplaySection();

                    var optionStorage = Console.ReadLine() ?? "";

                    storageSection.ParseOption<StorageEnum>(optionStorage);

                    break;

                case "Store":

                    storageOption.AddStorageNode();

                    MenuStack.Pop();

                    break;

                case "ShowStorageList":

                    if (!storageOption.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }

                    var nodeToShow = Console.ReadLine() ?? "";

                    if (int.TryParse(nodeToShow, out int nodeToShowInt) &&
                        storageOption.InRange(nodeToShowInt - 1))
                    {

                        storageOption.DisplayNode(nodeToShowInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("No such note");
                    }

                    MenuStack.Pop();

                    break;

                case "DeleteStorageNode":

                    if (!storageOption.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }

                    var nodeToDelete = Console.ReadLine() ?? "";

                    if (int.TryParse(nodeToDelete, out int nodeToDeleteInt) &&
                        storageOption.InRange(nodeToDeleteInt - 1))
                    {

                        storageOption.DeleteNode(nodeToDeleteInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("No such note");
                    }

                    MenuStack.Pop();

                    break; 
            }
        }
    }
}
