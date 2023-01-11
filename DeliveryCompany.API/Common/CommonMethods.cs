using System.Security.Claims;

namespace DeliveryCompany.API.Common;

public static class CommonMethods
{
    public static Guid GetPersonsGuid(HttpContext context)
    {
        var clientStringId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (clientStringId is null)
            throw new ArgumentException("Given ID does not exist");

        return new Guid(clientStringId);
    }
}