using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Administrators;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.List;

public class AdministratorListRepository : IAdministratorRepository
{
    private static readonly List<Administrator> _administrators = new(){
        Administrator.Create(
            "Default",
            "Default",
            "default@default.com",
            "DeFaUlT",
            "ekcidulm",
            DateTime.UtcNow,
            "DefaultAddress"
        )
    };

    public void Add(Administrator administrator)
    {
        _administrators.Add(administrator);
    }

    public Administrator? GetAdministratorByEmail(string email)
    {
        return _administrators.SingleOrDefault(admin => admin.Email == email);
    }

    public List<Administrator> GetAllAdministrators()
    {
        return _administrators.ToList();
    }

    public void Remove(Administrator administrator)
    {
        _administrators.Remove(administrator);
    }
}