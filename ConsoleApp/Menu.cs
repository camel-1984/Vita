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
        Console.WriteLine("=== VITA ===");
        Console.WriteLine("Welcome to Vita Notes Manager!");
        Console.WriteLine(new string('-', 40));
        MenuStack.Push("Main menu");

        EventOption eventOption = new("Event.json");
        StorageOption storageOption = new("Storage.json");

        while (true)
        {

            Console.WriteLine();

            if (MenuStack.Count == 0)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Thank you for using Vita Notes Manager!");
                Console.WriteLine("=== VITA ===");
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
                    Console.WriteLine("=== CREATE NEW NOTE ===");
                    Console.Write("Enter note title: ");
                    var noteTitle = Console.ReadLine() ?? "";
                    Console.Write("Enter note content: ");
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
                    Console.Write("Select note to display [number]: ");
                    var noteToShow = Console.ReadLine() ?? "";

                    if (int.TryParse(noteToShow, out int noteToShowInt) &&
                        eventOption.InRange(noteToShowInt - 1))
                    {
                        eventOption.DisplayNode(noteToShowInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid note selection");
                    }
                    MenuStack.Pop();
                    break;

                case "DeleteEventNode":
                    if (!eventOption.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }
                    Console.Write("Select note to delete [number]: ");
                    var noteToDelete = Console.ReadLine() ?? "";

                    if (int.TryParse(noteToDelete, out int notToDeleteInt) &&
                        eventOption.InRange(notToDeleteInt - 1))
                    {
                        eventOption.DeleteNode(notToDeleteInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid note selection");
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
                    Console.Write("Select record to display [number]: ");
                    var nodeToShow = Console.ReadLine() ?? "";

                    if (int.TryParse(nodeToShow, out int nodeToShowInt) &&
                        storageOption.InRange(nodeToShowInt - 1))
                    {
                        storageOption.DisplayNode(nodeToShowInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid record selection");
                    }
                    MenuStack.Pop();
                    break;

                case "DeleteStorageNode":
                    if (!storageOption.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }
                    Console.Write("Select record to delete [number]: ");
                    var nodeToDelete = Console.ReadLine() ?? "";

                    if (int.TryParse(nodeToDelete, out int nodeToDeleteInt) &&
                        storageOption.InRange(nodeToDeleteInt - 1))
                    {
                        storageOption.DeleteNode(nodeToDeleteInt - 1);
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid record selection");
                    }
                    MenuStack.Pop();
                    break;
            }
        }
    }
}