namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Couriers;

public interface ICourierManage
{
    public Results.OrderListResult GetAvailableForFacility(Requests.FacilityRequest request);
    public Results.OrderListResult GetAllByCourier(Requests.CourierRequest request);
    public Results.OrderResult Accept(Requests.OrderRequest request);
    public Results.OrderResult Resign(Requests.OrderRequest request);
    public Results.OrderResult PickUpPackage(Requests.OrderRequest request);
    public Results.OrderResult SetAsDelivered(Requests.OrderRequest request);
}