namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier;

public interface ICourierManage
{
    public void GetAvailableForFacility();
    public void GetAllByCourier();
    public void Accept();
    public void Resign();
    public void PickUpPackage();
    public void SetAsDelivered();
}