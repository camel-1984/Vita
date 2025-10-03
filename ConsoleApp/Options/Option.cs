using Microsoft.VisualBasic;

namespace ConsoleApp.Options;

public abstract class Option<T>
{
    protected string FilePath{ get; init; }

    protected List<T> NodeList = new();

    protected readonly static JsonSerializerOptions option = new(){WriteIndented = true};

    public Option(string path)
    {
        FilePath = Path.Combine(Directory.GetCurrentDirectory(), path);
        LoadNodeList();
    }

    public abstract bool DisplayNodeList();

    public abstract void DisplayNode(int idx);

    public void DeleteNode(int idx)
    {
        NodeList.RemoveAt(idx);
        SaveNodes();
        Console.WriteLine();
        Console.WriteLine($"Object successfully deleted");
    }

    public bool InRange(int idx)
    {
        if (idx < 0 || NodeList.Count - 1 < idx)
        {
            return false;
        }
        return true;
    }

    protected void LoadNodeList()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            NodeList = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        else
        {
            NodeList = new List<T>();
        }
    }

    

    protected void SaveNodes()
    {
        var json = JsonSerializer.Serialize(NodeList, option);
        File.WriteAllText(FilePath, json);
    }
}
