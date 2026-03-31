using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится. В доме, Который построил Джек.";

        // 1. Подсчет
        Console.WriteLine("1. ПОДСЧЕТ:");
        Console.WriteLine($"Букв 'о': {Regex.Matches(text, "о", RegexOptions.IgnoreCase).Count}");
        Console.WriteLine($"Слов 'дом': {Regex.Matches(text, @"\bдом\b", RegexOptions.IgnoreCase).Count}");
        Console.WriteLine($"Всего слов: {Regex.Matches(text, @"\b\w+\b").Count}\n");

        // 2. Строки на 'В'
        Console.WriteLine("2. СТРОКИ НА 'В':");
        foreach (string line in text.Split('.'))
            if (Regex.IsMatch(line.Trim(), "^В", RegexOptions.IgnoreCase))
                Console.WriteLine($"  {line.Trim()}");

        // 3. Строки на '.'
        Console.WriteLine("\n3. СТРОКИ НА '.':");
        foreach (string line in text.Split('.'))
            if (Regex.IsMatch(line.Trim(), @"\.$"))
                Console.WriteLine($"  {line.Trim()}");

        // 4. Изменение
        Console.WriteLine($"\n4. ИЗМЕНЕНО: {Regex.Replace(text, "Джек", "Саймон")}");
    }
}