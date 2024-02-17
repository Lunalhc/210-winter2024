

public class Prompt
{
    private static List<string> prompts = new List<string>
    {
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "If I could change one thing about today, what would it be?"
    };

    public static void DisplayRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, prompts.Count);
        string randomPrompt = prompts[randomIndex];
        Console.WriteLine(randomPrompt);
    }
}