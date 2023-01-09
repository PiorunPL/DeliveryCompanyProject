using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier.Results;

namespace DeliveryCompany.Application.CourierOrders;

public class CourierManage : ICourierManage
{
    public OrderListResult GetAvailableForFacility(FacilityRequest request)
    {
        throw new NotImplementedException();
    }

    public OrderListResult GetAllByCourier(CourierRequest request)
    {
        throw new NotImplementedException();
    }

    public OrderResult Accept(OrderRequest request)
    {
        throw new NotImplementedException();
    }

    public OrderResult Resign(OrderRequest request)
    {
        throw new NotImplementedException();
    }

    public OrderResult PickUpPackage(OrderRequest request)
    {
        throw new NotImplementedException();
    }

    public OrderResult SetAsDelivered(OrderRequest request)
    {
        throw new NotImplementedException();
    }
}