namespace DeliveryCompany.Application.Common;

public class CodeGenerator
{
    private static int _codeLength = 16;
    private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static char[] characters = (alphabet + alphabet.ToLower()).ToCharArray();
    public static string GenerateSecretCode()
    {
        string code = "";
        Random random = new Random();
        for (int i = 0; i < _codeLength; i++)
        {
            int number = random.Next(characters.Length - 1);
            code += characters[number];
        }

        return code;
    }
}