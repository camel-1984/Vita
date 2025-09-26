namespace ConsoleApp.Options;

public class EventNode
{
    public EventNode(string title, string content)
    {
        Title = title;
        Content = content;
        CreationTime = DateTime.Now;
    }

    [JsonPropertyName("title")]
    public string Title { get; }

    [JsonPropertyName("content")]
    public string Content { get; }

    [JsonPropertyName("date")]
    public DateTime CreationTime { get; }

    public void Display()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"Content: {Content}");
        Console.WriteLine($"Created: {CreationTime:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine(new string('-', 30));
    }
}

public class EventOption : Option<EventNode>
{
    public EventOption(string path) : base(path) {}
    
    public void AddNote(string title, string content)
    {
        NodeList.Add(new EventNode(title, content));
        SaveNodes();
        Console.WriteLine();
        Console.WriteLine($"Note successfully created");
    }

    public override bool DisplayNodeList()
    {
        if (NodeList.Count > 0)
        {
            Console.WriteLine("=== NOTES LIST ===");
            for (int i = 0; i < NodeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Title: {NodeList[i].Title}");
            }
            Console.WriteLine(new string('-', 30));
            return true;
        }
        
        Console.WriteLine("No notes available");
        return false;
    }

    public override void DisplayNode(int index)
    {
        if (index >= 0 && index < NodeList.Count)
        {
            NodeList[index].Display();
        }
        else
        {
            Console.WriteLine("Error: Invalid note index");
        }
    }
}

// namespace ConsoleApp.Options;

// public class EventOption : Option
// {

//     public EventOption() : base(){}

//     public override void ParseText(string text)
// {
//     string currentDir = Directory.GetCurrentDirectory();

//     string fileName = $"{CreationTime:HH:mm---dd:MM}.txt";
//     string filePath = Path.Combine(currentDir, fileName);

//     File.WriteAllText(filePath, text);
// }
// }
