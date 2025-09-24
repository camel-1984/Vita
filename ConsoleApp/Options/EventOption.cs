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

namespace ConsoleApp.Options;

public class EventOption
{
    private class EventNote
    {
        public EventNote(string title, string content)
        {
            Title = title;
            Content = content;
            CreationTime = DateTime.Now;
        }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("date")]
        public DateTime CreationTime { get; set; }


        public void Write()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Content);
            Console.WriteLine(CreationTime);
        }
    }

    private readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "notes.json");
    private List<EventNote> EventNoteList = new List<EventNote>();

    public EventOption()
    {
        LoadNotes();
    }
    
    public void AddNote(string title, string content)
    {
        EventNoteList.Add(new EventNote(title, content));
        SaveNotes();
    }

    public bool ShowNoteList()
    {
        if (!(EventNoteList.Count == 0))
        {
            Console.WriteLine("Select");
            int c = 0;
            foreach (var i in EventNoteList)
            {
                c++;
                Console.WriteLine($"{c}. {i.CreationTime} {i.Title}");
            }
            return true;
        }
        Console.WriteLine("Empty");
        return false;
    }

    public void ShowNote(int idx)
    {
        EventNoteList[idx].Write();
    }

    private void LoadNotes()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            EventNoteList = JsonSerializer.Deserialize<List<EventNote>>(json) ?? new List<EventNote>();
        }
        else
        {
            EventNoteList = new List<EventNote>();
        }
    }

    private void SaveNotes()
    {
        var json = JsonSerializer.Serialize(EventNoteList, new JsonSerializerOptions 
        { 
            WriteIndented = true 
        });
        File.WriteAllText(FilePath, json);
    }

    
}