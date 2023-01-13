namespace DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators;

public interface IAdministratorManage
{
    public Results.SizeListResult GetAllSizes();
    public Results.SizeResult GetSize(Requests.SizeRequest request);
    public Results.SizeResult Create(Requests.CreateSizeRequest request);
}