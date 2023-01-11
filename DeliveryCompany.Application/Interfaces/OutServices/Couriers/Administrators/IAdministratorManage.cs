namespace DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators;

public interface IAdministratorManage
{
    public Results.CouriersResult GetUnassignedCouriers();
    public Results.CouriersResult GetCouriers();
    public Results.CourierResult GetCourier(Requests.CourierRequest request);
}