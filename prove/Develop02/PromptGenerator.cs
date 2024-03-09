public class PromptGenerator
{
    public List<string> _prompts;   

    public string GetRandomPrompt()
    {
        // Generate a random index to select a prompt from the list
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}