using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators.Results;
using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Sizes;

public class AdministratorManage : IAdministratorManage
{
    private readonly ISizeRepository _sizeRepository;

    public AdministratorManage(ISizeRepository sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }

    public SizeListResult GetAllSizes()
    {
        return new SizeListResult(_sizeRepository.GetAll());
    }

    public SizeResult GetSize(SizeRequest request)
    {
        Size? size = _sizeRepository.GetById(request.SizeId);
        if (size is null)
            throw new ArgumentException("There is no Size with Given ID");
        
        return new SizeResult(size);
    }

    public SizeResult Create(CreateSizeRequest request)
    {
        Size size = Size.Create(request.Name, request.Price);
        
        _sizeRepository.Add(size);
        return new SizeResult(size);
    }
}