using Microsoft.AspNetCore.Http;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients;

public interface IClientManage{
    public Results.ClientOrderResult CreateNewClientOrder(Requests.CreateRequest request);
    public Task<Results.ClientOrderResult> CreateNewClientOrderAsync(Requests.CreateRequest request);
    public Results.ClientOrderResult CancelClientOrder(Requests.CancelRequest request);
    public Results.ClientOrderResult GetOrder(Requests.GetRequest request);
    public Results.ClientOrderResult GetSharedOrder(Requests.GetRequest request);
    public Results.GetAllResult GetOrders(Guid clientId);
    public void SetImage(IFormFile file, Guid clientId, Guid orderId);
    public Results.GetAllResult GetOrdersShared(Guid clientId);
    public void ShareOrder(Guid clientId, Guid orderId, string sharedToEmail);
    public string? GetImage(Guid clientId, Guid orderId);
}