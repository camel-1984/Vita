namespace ConsoleApp.Options;

public class StorageNode
{
    [JsonPropertyName("date")]
    public DateTime CreationTime { get; init; }

    [JsonPropertyName("age")]
    private int age_;

    public int Age
    {
        get => age_;
        init
        {
            if (18 <= value && value <= 100)
            {
                age_ = value;
            }
            else
            {
                throw new ArgumentException("Bad age. Age must be between 18 and 100.");
            }
        }
    }

    public void Write()
    {
        Console.WriteLine($"Age is {Age}");
    }
    public static StorageNode CreateStorageNode()
    {
        Console.WriteLine("What is your age?");
        var nodeAge = Console.ReadLine();

        if (int.TryParse(nodeAge, out int nodeAgeInt))
        {
            var obj = new StorageNode
            {
                CreationTime = DateTime.Now,
                Age = nodeAgeInt
            };
            return obj;
        }
        throw new ArgumentException("Invalid age format. Please enter a valid number.");
    }
}

public class StorageOption : Option<StorageNode>
{
    public StorageOption(string path) : base(path) { }

    public void AddStorageNode()
    {
        try
        {
            StorageNode node = StorageNode.CreateStorageNode();
            NodeList.Add(node);
            SaveNodes();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating storage node: {ex.Message}");
        }
    }

    public override bool DisplayNodeList()
    {
        if (!(NodeList.Count == 0))
        {
            for (int i = 0; i < NodeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Was created: {NodeList[i].CreationTime}");
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
