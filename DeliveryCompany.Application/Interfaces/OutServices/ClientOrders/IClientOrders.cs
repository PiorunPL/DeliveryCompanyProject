namespace DeliveryCompany.Application.Interfaces.ClientOrders;

public interface IClientManage{
    public Results.ClientOrderResult CreateNewClientOrder(Requests.ClientOrderCreateRequest request);
    public Results.ClientOrderResult CancelClientOrder(Requests.ClientOrderCancelRequest request);
    public Results.ClientOrderResult GetOrder(Requests.ClientOrderGetRequest request);
    public void GetOrders();
}