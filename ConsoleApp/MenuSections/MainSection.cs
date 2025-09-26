namespace ConsoleApp.MenuSections;

public class MainSection : MenuSection
{
    public MainSection(Stack<string> menuStack) : base(menuStack) { }

    public override void DisplaySection()
    {
        Console.WriteLine("1. Event");
        Console.WriteLine("2. Storage");
        Console.WriteLine("3. Exit");
    }
}
