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
            if (value >= 18 && value <= 100)
            {
                age_ = value;
            }
            else
            {
                throw new ArgumentException("Invalid age selected");
            }
        }
    }

    public void Display()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"Age: {Age} years");
        Console.WriteLine(new string('-', 30));
    }

    public static StorageNode CreateStorageNode()
    {
        Console.WriteLine("=== CREATE STORAGE RECORD ===");
        Console.Write("Enter age: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out int age))
        {
            var node = new StorageNode
            {
                CreationTime = DateTime.Now,
                Age = age
            };
            Console.WriteLine();
            Console.WriteLine("Record successfully created");
            return node;
        }
        throw new ArgumentException("Invalid input. Please try again with valid input.");
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
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Please try again with valid age");
        }
    }

    public override bool DisplayNodeList()
    {
        if (NodeList.Count > 0)
        {
            Console.WriteLine("=== STORAGE INFO ===");
            for (int i = 0; i < NodeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Created: {NodeList[i].CreationTime:yyyy-MM-dd HH-mm-ss}");
            }
            Console.WriteLine(new string('-', 30));
            return true;
        }
        Console.WriteLine("No Info available");
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
            Console.WriteLine("Error: Invalid node index");
            Console.WriteLine($"Please select between 1 and {NodeList.Count}");
        }
    }
}