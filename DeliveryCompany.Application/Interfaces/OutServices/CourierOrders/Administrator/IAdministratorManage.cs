namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrator;

public interface IAdministratorManage
{
    public void Create();
    public void Cancel();
    public void Get();
    public void GetAll();
    public void GetAllExceptCancelled();
    public void GetMissing();   //Mostly Optional
    public void GetMissingForClientOrder(); //Mostly Optional
}