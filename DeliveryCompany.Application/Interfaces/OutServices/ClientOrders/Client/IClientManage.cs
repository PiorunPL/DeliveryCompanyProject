namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client;

public interface IClientManage{
    public Results.ClientOrderResult CreateNewClientOrder(Requests.CreateRequest request);
    public Results.ClientOrderResult CancelClientOrder(Requests.CancelRequest request);
    public Results.ClientOrderResult GetOrder(Requests.GetRequest request);
    public Results.GetAllResult GetOrders(Guid clientId);
}