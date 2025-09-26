namespace ConsoleApp.MenuSections;

public abstract class MenuSection
{
    protected readonly Stack<string> MenuStack;

    public MenuSection(Stack<string> menuStack)
    {
        MenuStack = menuStack;
    }

    public void ParseOption<T>(string optionKey) where T : Enum
    {
        if (int.TryParse(optionKey, out int optionOut) && Enum.IsDefined(typeof(T), optionOut))
        {
            var selectedOption = (T)Enum.ToObject(typeof(T), optionOut);
            MenuStack.Push(selectedOption.ToString());
        }
        else
        {
            Console.WriteLine("Error: Invalid option selected");
            Console.WriteLine("Please enter a valid number from the menu");
            Console.WriteLine(new string('-', 30));
        }
    }

    public abstract void DisplaySection();
}
