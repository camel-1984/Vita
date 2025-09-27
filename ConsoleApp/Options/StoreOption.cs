namespace ConsoleApp.Options;

public class StorageNode
{
    [JsonPropertyName("date")]
    public DateTime CreationTime { get; }

    public StorageNode()
    {
        CreationTime = DateTime.Now;
    }

    [JsonPropertyName("calories")]
    private int calories_;

    public int Calories
    {
        get => calories_;
        set
        {
            if (value >= 0)
            {
                calories_ = value;
            }
            else
            {
                Console.WriteLine();
                throw new ArgumentException("Invalid calories value");
            }
        }
    }

    [JsonPropertyName("protein")]
    private int protein_;

    public int Protein
    {
        get => protein_;
        set
        {
            if (value >= 0)
            {
                protein_ = value;
            }
            else
            {
                Console.WriteLine();
                throw new ArgumentException("Invalid protein value");
            }
        }
    }

    [JsonPropertyName("fats")]
    private int fats_;

    public int Fats
    {
        get => fats_;
        set
        {
            if (value >= 0)
            {
                fats_ = value;
            }
            else
            {
                Console.WriteLine();
                throw new ArgumentException("Invalid fats value");
            }
        }
    }

    [JsonPropertyName("carbohydrates")]
    private int carbohydrates_;

    public int Carbohydrates
    {
        get => carbohydrates_;
        set
        {
            if (value >= 0)
            {
                carbohydrates_ = value;
            }
            else
            {
                Console.WriteLine();
                throw new ArgumentException("Invalid carbohydrates value");
            }
        }
    }

    [JsonPropertyName("water")]
    private int water_;

    public int Water
    {
        get => water_;
        set
        {
            if (value >= 0)
            {
                water_ = value;
            }
            else
            {
                Console.WriteLine();
                throw new ArgumentException("Invalid water value");
            }
        }
    }

    public void Display()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"Calories: {Calories}/3600kcal.");
        Console.WriteLine($"Protein: {Protein}/160g.");
        Console.WriteLine($"Fats: {Fats}/80g.");
        Console.WriteLine($"Carbohydrates: {Carbohydrates}/560g.");
        Console.WriteLine($"Water: {Water}/2500ml.");
        Console.WriteLine(new string('-', 30));
    }

    public static StorageNode CreateStorageNode()
    {
        Console.WriteLine("=== CREATE STORAGE RECORD ===");

        var node = new StorageNode();

        Console.Write("Enter calories: ");
        var inputCalories = Console.ReadLine();

        if (int.TryParse(inputCalories, out int outCalories)) {
            node.Calories = outCalories;
        }

        Console.Write("Enter protein: ");
        var inputProtein = Console.ReadLine();

        if (int.TryParse(inputProtein, out int outProtein)) {
            node.Protein = outProtein;
        }

        Console.Write("Enter fats: ");
        var inputFats = Console.ReadLine();

        if (int.TryParse(inputFats, out int outFats)) {
            node.Fats = outFats;
        }

        Console.Write("Enter carbohydrates: ");
        var inputCarbohydrates = Console.ReadLine();

        if (int.TryParse(inputCarbohydrates, out int outCarbohydrates)) {
            node.Carbohydrates = outCarbohydrates;
        }

        Console.Write("Enter water: ");
        var inputWater = Console.ReadLine();

        if (int.TryParse(inputWater, out int outWater)) {
            node.Water = outWater;
        }

        Console.WriteLine();
        Console.WriteLine("Record successfully created");
        return node;
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
            Console.WriteLine("Please try again with valid input");
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