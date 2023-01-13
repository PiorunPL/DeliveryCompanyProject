namespace DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators;

public interface IAdministratorManage
{
    public Results.CourierListResult GetUnassignedCouriers();
    public Results.CourierListResult GetCouriers();
    public Results.CourierResult GetCourier(Requests.CourierRequest request);
}