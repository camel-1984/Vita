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

    public void Write()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Content);
    }
}

public class EventOption : Option<EventNode>
{
    public EventOption(string path) : base(path) {}
    
    public void AddNote(string title, string content)
    {
        NodeList.Add(new EventNode(title, content));
        SaveNodes();
    }

    public override bool DisplayNodeList()
    {
        if (!(NodeList.Count == 0))
        {
            for (int i = 0; i < NodeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {NodeList[i].CreationTime} {NodeList[i].Title}");
            }
            return true;
        }
        Console.WriteLine("Empty");
        return false;
    }

    public override void DisplayNode(int idx)
    {
        NodeList[idx].Write();
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
