namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients;

public interface IClientManage{
    public Results.ClientOrderResult CreateNewClientOrder(Requests.CreateRequest request);
    public Task<Results.ClientOrderResult> CreateNewClientOrderAsync(Requests.CreateRequest request);
    public Results.ClientOrderResult CancelClientOrder(Requests.CancelRequest request);
    public Results.ClientOrderResult GetOrder(Requests.GetRequest request);
    public Results.GetAllResult GetOrders(Guid clientId);
}