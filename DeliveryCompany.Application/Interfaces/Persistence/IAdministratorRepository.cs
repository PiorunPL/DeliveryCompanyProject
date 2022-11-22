using DeliveryCompany.Domain.Administrator;

namespace DeliveryCompany.Application.Interfaces.Persistence;

public interface IAdministratorRepository
{
    public void Add(Administrator administrator);
    public void Remove(Administrator administrator);
    public Administrator? GetAdministratorByEmail(string email);
    public List<Administrator> GetAllAdministrators();
}