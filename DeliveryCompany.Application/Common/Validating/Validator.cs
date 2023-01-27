using System.Text.RegularExpressions;

namespace DeliveryCompany.Application.Authentication.Common;

public class Validator
{
    public static bool ValidateEmail(string email)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(email);
    }

    public static bool ValidateName(string name)
    {
        string pattern = @"^[A-z]+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(name);
    }

    public static bool ValidatePassword(string password)
    {
        string pattern = @"^(\w|\d|[\!\@\#\$\%\^\&\*])+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(password);
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

        return regex.IsMatch(address);
    }

    public static bool ValidatePackageName(string name)
    {
        string pattern = @"^[a-zA-Z0-9]+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(name);
    }
}