using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients.Results;
using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Sizes;

public class ClientManage : IClientManage
{
    private readonly ISizeRepository _sizeRepository;

    public ClientManage(ISizeRepository sizeRepository)
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
}