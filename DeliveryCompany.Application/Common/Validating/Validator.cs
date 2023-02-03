using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace DeliveryCompany.Application.Authentication.Common;

public class Validator
{
    public static bool ValidateEmail(string email)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(email) && email.Length < 100;
    }

    public static bool ValidateName(string name)
    {
        string pattern = @"^[A-z]+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(name) && name.Length < 30;
    }

    public static bool ValidatePassword(string password)
    {
        string pattern = @"^(\w|\d|[\!\@\#\$\%\^\&\*])+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(password) && password.Length < 100;
    }

    public static bool ValidateGuid(string guid)
    {
        string pattern = @"^([0-9A-Fa-f]{8}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{12})$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(guid);
    }

    public static bool ValidateAddress(string address)
    {
        string pattern = @"^(\w+) (\d{2}-\d{3}) (\w+) (\d*|(\d*\/\d*\w+))$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(address) && address.Length < 100;
    }

    public static bool ValidatePackageName(string name)
    {
        string pattern = @"^[a-zA-Z0-9]+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(name) && name.Length < 50;
    }

    public static bool ValidateSecretCode(string code)
    {
        string pattern = @"^[a-zA-Z]{16}$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(code);
    }

    public static bool ValidateImage(IFormFile file)
    {
        var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        var bytes = memoryStream.ToArray();

        if (file.FileName.Contains(".jpg") || file.FileName.Contains(".jpeg"))
        {
            if (bytes.Length < 4)
                return false;
            byte[] exemplaryBytes1 = { 0xFF, 0xD8, 0xFF, 0xDB };
            byte[] exemplaryBytes2 = { 0xFF, 0xD8, 0xFF, 0xEE };
            byte[] exemplaryBytes3 = { 0xFF, 0xD8, 0xFF, 0xE0 };
            byte[] jpgBytes = new[] { bytes[0], bytes[1], bytes[2], bytes[3] };
            if (!jpgBytes.SequenceEqual(exemplaryBytes1) && !jpgBytes.SequenceEqual(exemplaryBytes2) &&
                !jpgBytes.SequenceEqual(exemplaryBytes3))
                return false;
        }
        else if (file.FileName.Contains(".png"))
        {
            if (bytes.Length < 8)
                return false;
            byte[] exemplaryBytes = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            byte[] pngBytes = new[] { bytes[0], bytes[1], bytes[2], bytes[3], bytes[4], bytes[5], bytes[6], bytes[7] };
            if (!pngBytes.SequenceEqual(exemplaryBytes))
                return false;
        }
        else
        {
            return false;
        }


        return true;
    }
}