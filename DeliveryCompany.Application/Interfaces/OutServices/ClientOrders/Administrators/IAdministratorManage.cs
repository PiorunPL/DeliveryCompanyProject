namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrators;

public interface IAdministratorManage{
    public Results.OrderResult AcceptOrder(Requests.OrderRequest request); 
    public Results.OrderResult SubmitOrderRoute(Requests.OrderRequest request); 
    public Results.OrderResult CancelOrder(Requests.OrderRequest request);
    public Results.OrderResult GetOrder(Requests.OrderRequest request);
    public Results.OrderListResult GetAllActiveOrders(); 
    public Results.OrderListResult GetAllOrders(); 

}