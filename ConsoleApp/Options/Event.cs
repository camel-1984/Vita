namespace ConsoleApp.Options;

public class Event : IOption
{
    public DateTime CreationTime { get; set; }

    public Event(DateTime creationTime)
    {
        CreationTime = creationTime;
    }

    public void ParseText(string text)
{
    string currentDir = Directory.GetCurrentDirectory();

    string fileName = $"{CreationTime:HH:mm---dd:MM}.txt";
    string filePath = Path.Combine(currentDir, fileName);
    
    File.WriteAllText(filePath, text);

}
    
}
