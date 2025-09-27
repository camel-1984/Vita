namespace ConsoleApp.Options;

public class NotesOptions : Option<NotesNode>
{
    public NotesOptions(string path) : base(path) { }

    public void AddNote(string title, string content)
    {
        NodeList.Add(new NotesNode(title, content));
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

public class NotesNode
{
    public NotesNode(string title, string content)
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
