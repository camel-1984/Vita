namespace ConsoleApp.Uttils;

public class PasswordManager
{
    [JsonIgnore]
    private readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Password.json");

    [JsonIgnore]
    private readonly JsonSerializerOptions option = new() { WriteIndented = true };

    [JsonPropertyName("Hash")]
    [JsonInclude]
    private string? Hash { get; set; }

    [JsonPropertyName("LastEnter")]
    [JsonInclude]
    private DateTime? LastEnter { get; set; }

    private void LoadFile()
    {
        var json = File.ReadAllText(FilePath);
        var loadedObj = JsonSerializer.Deserialize<PasswordManager>(json) ?? new();
         
        Hash = loadedObj.Hash;
        LastEnter = loadedObj.LastEnter;
    }

    private void SaveFile()
    {
        var json = JsonSerializer.Serialize(this, option);
        File.WriteAllText(FilePath, json);
    }

    private string GivePassword()
    {
        Console.WriteLine();
        Console.Write("Enter password: ");
        string givenPassword = PasswordProcessing();
        return givenPassword;
    }

    private void SetPassword()
    {
        Console.WriteLine();
        Console.Write("Enter new password: ");
        string settedPassword = Console.ReadLine() ?? "";

        Hash = HashPassword(settedPassword);
        LastEnter = DateTime.Now;
    }

    private string PasswordProcessing()
    {
        string password = "";
        ConsoleKeyInfo key = Console.ReadKey(true);

        while (key.Key != ConsoleKey.Enter)
        {
            if (key.Key != ConsoleKey.Backspace)
            {
                password = password + key.KeyChar;
                Console.Write('*');
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Remove(password.Length - 1);
                Console.Write("\b \b");
            }
            key = Console.ReadKey(true);
        }
        return password;
    }

    private static string HashPassword(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.Create().ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public void PasswordCheck()
    {
        if (File.Exists(FilePath))
        {
            LoadFile();

            if (DateTime.Now - LastEnter > TimeSpan.FromHours(1))
            {
                while (true)
                {
                    string givenPassword = GivePassword();
                    if (HashPassword(givenPassword) == Hash)
                    {
                        LastEnter = DateTime.Now;
                        SaveFile();
                        break;

                    }
                    Console.WriteLine();
                    Console.WriteLine("Wrong password.");
                }
            }

        }
        else
        {
            SetPassword();
            SaveFile();
        }
    }
}