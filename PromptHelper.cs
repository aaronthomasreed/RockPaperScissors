using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    internal static class PromptHelper
    {
        public static bool PromptBoolean()
        {
            Dictionary<string, bool> promptOptions = new Dictionary<string, bool>
            {
                {"Y", true },
                {"N", false }
            };

            if (promptOptions.Count == 1)
                return promptOptions.FirstOrDefault().Value;

            Console.WriteLine(string.Join(", ", promptOptions.Select(s => $"[{s.Key}]")));

            var input = Console.ReadLine();

            if (!promptOptions.TryGetValue(input.ToUpper(), out var result))
            {
                Console.WriteLine($"Invalid selection! Please try again.");
                return PromptBoolean();
            }

            return result;
        }

        public static T? PromptAction<T>(Dictionary<string, T> promptOptions, string optionName) where T : IPromptOption
        {
            if (promptOptions.Count == 0)
                throw new Exception("Invalid promptOptions"); // - I would provide more detail with some more time.

            if (promptOptions.Count == 1)
                return promptOptions.FirstOrDefault().Value;

            Console.WriteLine($"Choose your {optionName}: ");
            Console.WriteLine(string.Join(", ", promptOptions.Select(s => $"[{s.Key}] - {s.Value.Name}")));

            var input = Console.ReadLine();

            if (!promptOptions.TryGetValue(input.ToUpper(), out var result))
            {
                Console.WriteLine($"Invalid selection for {optionName}! Please try again.");
                return PromptAction(promptOptions, optionName);
            }

            return result;
        }
    }
}
