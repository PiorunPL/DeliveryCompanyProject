namespace DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrator;

public interface IAdministratorManage
{
    public Results.CouriersResult GetUnassignedCouriers();
    public Results.CouriersResult GetCouriers();
    public Results.CourierResult GetCourier(Requests.CourierRequest request);
}