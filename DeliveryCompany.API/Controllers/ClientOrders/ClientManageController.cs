using System.Security.Claims;
using DeliveryCompany.Application.Interfaces.ClientOrders;
using DeliveryCompany.Application.Interfaces.ClientOrders.Requests;
using DeliveryCompany.Application.Interfaces.ClientOrders.Results;
using DeliveryCompany.Contracts.ClientOrders;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.ClientOrders;

[ApiController]
[Authorize(Roles = "Client")]
[Route("manageclientorder/client")]
public class ClientManageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IClientManage _manageClientOrders;

    public ClientManageController(IMapper mapper, IClientManage manageClientOrders)
    {
        _mapper = mapper;
        _manageClientOrders = manageClientOrders;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateNewOrder(ClientOrderCreateApiRequest apiRequest)
    {
        Guid clientId = GetClientGuid();

        var request = _mapper.Map<ClientOrderCreateRequest>((apiRequest, clientId));
        ClientOrderResult result = _manageClientOrders.CreateNewClientOrder(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelOrder(ClientOrderCancelApiRequest apiRequest)
    {
        Guid clientId = GetClientGuid();

        var request = _mapper.Map<ClientOrderCancelRequest>((apiRequest, clientId));
        ClientOrderResult result = _manageClientOrders.CancelClientOrder(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("get")]
    public async Task<IActionResult> GetOrder(ClientOrderClientGetApiRequest apiRequest)
    {
        Guid clientId = GetClientGuid();

        var request = _mapper.Map<ClientOrderGetRequest>((apiRequest, clientId));
        ClientOrderResult result = _manageClientOrders.GetOrder(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    private Guid GetClientGuid()
    {
        var clientStringId = string.Empty;
        clientStringId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (clientStringId is null)
            throw new ArgumentException("Given Client ID does not exist");

        return new Guid(clientStringId);

    }
}