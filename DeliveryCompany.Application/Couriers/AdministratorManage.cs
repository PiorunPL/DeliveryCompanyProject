using DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators;
using DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators.Results;

namespace DeliveryCompany.Application.Couriers;

public class AdministratorManage : IAdministratorManage
{
    public CouriersResult GetUnassignedCouriers()
    {
        // 1. Get all Couriers
        // 2. Filter only unassigned
        throw new NotImplementedException();
    }

    public CouriersResult GetCouriers()
    {
        // 1. Get all Couriers
        throw new NotImplementedException();
    }

    public CourierResult GetCourier(CourierRequest request)
    {
        // 1. Check if Courier exists
        // 2. Return Courier
        throw new NotImplementedException();
    }
}