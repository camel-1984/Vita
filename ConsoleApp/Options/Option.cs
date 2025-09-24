using System.Data;

namespace ConsoleApp.Options;

public abstract class Option
{
    protected readonly DateTime CreationTime; 

    public Option()
    {
        CreationTime = DateTime.Now;
    }

    public abstract void ParseText(string text);

    
    



}

