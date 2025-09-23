namespace ConsoleApp;

public class Eveent : IOption
{
    public DateTime CreationTime { get; set; }

    public Eveent(DateTime creationTime)
    {
        CreationTime = creationTime;
    }

    public void ParseText(string text)
{
    string currentDir = Directory.GetCurrentDirectory();
    string projectRoot = Directory.GetParent(currentDir).Parent.Parent.FullName;
    
    string fileName = $"{CreationTime:HH:mm---dd:MM}.txt";
    string filePath = Path.Combine(projectRoot, fileName);
    
    File.WriteAllText(filePath, text);

}
    
}
