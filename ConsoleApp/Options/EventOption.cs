namespace ConsoleApp.Options;

public class EventOption : Option
{

    public EventOption() : base(){}

    public override void ParseText(string text)
{
    string currentDir = Directory.GetCurrentDirectory();

    string fileName = $"{CreationTime:HH:mm---dd:MM}.txt";
    string filePath = Path.Combine(currentDir, fileName);
    
    File.WriteAllText(filePath, text);

}
    
}
