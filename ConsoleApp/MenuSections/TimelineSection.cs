namespace ConsoleApp.MenuSections;

public class TimelineSection : MenuSection
{
    public TimelineSection(Stack<string> menuStack) : base(menuStack) { }

    public override void DisplaySection()
    {
        Console.WriteLine("Select:");
        Console.WriteLine("1. Show");
        Console.WriteLine("2. Exit");
    }

}