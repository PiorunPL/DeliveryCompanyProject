namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrator;

public interface IAdministratorManage
{
    public Results.OrderResult Create(Requests.CreateOrderRequest request);
    public Results.OrderResult Cancel(Requests.OrderRequest request);
    public Results.OrderResult Get(Requests.OrderRequest request);
    public Results.OrderListResult GetMissingForClientOrder(Requests.ClientOrderRequest request); //Mostly Optional
}