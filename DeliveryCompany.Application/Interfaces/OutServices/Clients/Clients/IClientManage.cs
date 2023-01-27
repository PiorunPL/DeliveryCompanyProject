namespace DeliveryCompany.Application.Interfaces.OutServices.Clients.Clients;

public interface IClientManage
{
    public void changePassword(Guid clientId, string password);
    public void restorePassword(string email, string password, string secretCode);
}