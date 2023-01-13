namespace DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients;

public interface IClientManage
{
    public Results.SizeListResult GetAllSizes();
    public Results.SizeResult GetSize(Requests.SizeRequest request);
}