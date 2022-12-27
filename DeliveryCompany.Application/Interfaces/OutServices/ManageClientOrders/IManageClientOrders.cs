namespace DeliveryCompany.Application.Interfaces.ManageClientOrders;

public interface IManageClientOrders{
    public Results.ClientOrderResult CreateNewClientOrder(Requests.ClientOrderCreateRequest request);
    public Results.ClientOrderResult CancelClientOrder(Requests.ClientOrderCancelRequest request);
    public Results.ClientOrderResult GetOrder();
    public void GetOrders();
}