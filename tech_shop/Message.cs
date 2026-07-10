internal static class Message
{
    public static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

    public static void ShowInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

    public static void ShowWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

}