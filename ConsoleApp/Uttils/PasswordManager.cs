namespace ConsoleApp.Uttils;

public class PasswordManager
{
    private readonly string HashFilePath = Path.Combine(Directory.GetCurrentDirectory(), "hash.txt");

    public bool PasswordCheck()
    {
        if (File.Exists(HashFilePath))
        {
            string givenPassword = GivePassword();

            if (HashPassword(givenPassword) == File.ReadAllText(HashFilePath))
            {
                return true;
            }
            else
            {
                Console.WriteLine("wrong password");
                return false;
            }
        }
        else
        {
            SetPassword();
            return true;
        }
    }

    private void SetPassword()
    {
        Console.Write("set password: ");
        string settedPassword = Console.ReadLine() ?? "";
        File.AppendAllText(HashFilePath, HashPassword(settedPassword));
    }

    private static string HashPassword(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.Create().ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    private static string GivePassword()
    {
        Console.Write("give password: ");
        string givenPassword = Console.ReadLine() ?? " ";
        return givenPassword;
    }

}