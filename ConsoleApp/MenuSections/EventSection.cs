namespace ConsoleApp.MenuSections;

public class EventSection : MenuSection
{
    public EventSection(Stack<string> menuStack) : base(menuStack) { }

    public override void DisplaySection()
    {
        Console.WriteLine("1. TakeNote");
        Console.WriteLine("2. ShowNoteList");
        Console.WriteLine("3. DeleteEventNote");
        Console.WriteLine("4. Exit");
    }
}
