namespace ConsoleApp.MenuSections;

public class StorageSection : MenuSection
{
    public StorageSection(Stack<string> menuStack) : base(menuStack) { }

    public override void DisplaySection()
    {
        Console.WriteLine("Select:");
        Console.WriteLine("1. Store");
        Console.WriteLine("2. Exit");
    }

}