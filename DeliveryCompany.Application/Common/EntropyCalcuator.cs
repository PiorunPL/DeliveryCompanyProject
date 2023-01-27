namespace DeliveryCompany.Application.Common;

public class EntropyCalcuator
{
    static readonly char[] SpecialCharacters = new[] { '!', '@', '#', '$', '%', '^', '&', '*' };

    static readonly string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    static readonly char[] LowercaseCharacters = Alphabet.ToLower().ToCharArray();
    static readonly char[] UppercaseCharacters = Alphabet.ToCharArray();

    static readonly string Digits = "0123456789";
    static readonly char[] DigitCharacters = Digits.ToCharArray();

    public static double GetEntropy(string password)
    {
        int pool = CalculatePool(password);

        // List<(char character, int count)> listStatistic = PrepareListOfAllCharacters();

        // listStatistic = CountStaticticPassword(password, listStatistic);
        
        // double entropy = CalculateEntropy(pool, listStatistic, password);
        double entropy = CalculateEntropyAlternative(pool, password);
        
        // Console.WriteLine("Entropy: " + entropy + ", password: " + password);
        
        return entropy;
    }

    private static double CalculateEntropy(int pool, List<(char character, int count)> list, string password)
    {
        double entropy = 0;
        foreach (var tuple in list)
        {
            double frequency = (double)tuple.count / (double)password.Length;
            entropy += frequency * Math.Log2(pool);
        }

        return entropy;
    }

    private static double CalculateEntropyAlternative(int pool, string password)
    {
        double entropy = password.Length * Math.Log2(pool);
        return entropy;
    }
    
    private static int CalculatePool(string password)
    {
        int pool = 0;

        pool += CheckIfStringContainsAnyFromCollection(password, LowercaseCharacters);
        pool += CheckIfStringContainsAnyFromCollection(password, UppercaseCharacters);
        pool += CheckIfStringContainsAnyFromCollection(password, DigitCharacters);
        pool += CheckIfStringContainsAnyFromCollection(password, SpecialCharacters);

        return pool;
    }

    private static List<(char character, int count)> CountStaticticPassword(string password, List<(char character, int count)> list)
    {
        foreach (var character in password.ToCharArray())
        {
            var element = list.Single(element => element.character == character);
            list.Remove(element);
            element.count++;
            list.Add(element);
        }

        return list;
    }

    private static List<(char character, int count)> PrepareListOfAllCharacters()
    {
        var list = new List<(char character, int count)>();
        foreach (var character in SpecialCharacters)
        {
            list.Add((character, 0));
        }

        foreach (var character in LowercaseCharacters)
        {
            list.Add((character, 0));
        }
        
        foreach (var character in UppercaseCharacters)
        {
            list.Add((character, 0));
        }
        
        foreach (var character in DigitCharacters)
        {
            list.Add((character, 0));
        }

        return list;
    }

    private static int CheckIfStringContainsAnyFromCollection(string password, char[] collection)
    {
        foreach (var character in collection)
        {
            if (password.Contains(character))
            {
                return collection.Length;
            }
        }

        return 0;
    }
}