using System.Security.Claims;
using DeliveryCompany.Application.Interfaces.ClientOrders.Client;
using DeliveryCompany.Application.Interfaces.ClientOrders.Client.Requests;
using DeliveryCompany.Application.Interfaces.ClientOrders.Client.Results;
using DeliveryCompany.Contracts.ClientOrders;
using DeliveryCompany.Domain.Orders;
using Mapster;
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

        var request = _mapper.Map<CreateRequest>((apiRequest, clientId));
        ClientOrderResult result = _manageClientOrders.CreateNewClientOrder(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelOrder(ClientOrderCancelApiRequest apiRequest)
    {
        Guid clientId = GetClientGuid();

        var request = _mapper.Map<CancelRequest>((apiRequest, clientId));
        ClientOrderResult result = _manageClientOrders.CancelClientOrder(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("get")]
    public async Task<IActionResult> GetOrder(ClientOrderClientGetApiRequest apiRequest)
    {
        Guid clientId = GetClientGuid();

        var request = _mapper.Map<GetRequest>((apiRequest, clientId));
        ClientOrderResult result = _manageClientOrders.GetOrder(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllOrders()
    {
        Guid clientId = GetClientGuid();

        GetAllResult result = _manageClientOrders.GetOrders(clientId);

        var target = Map(result); //TODO: Good to Change Map method to Mapster Invocation

        return Ok(target);
        // return Ok(_mapper.Map<ClientGetAllApiResponse>(result));
    }

    private Guid GetClientGuid()
    {
        var clientStringId = string.Empty;
        clientStringId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (clientStringId is null)
            throw new ArgumentException("Given Client ID does not exist");

        return new Guid(clientStringId);

    }

    private ClientGetAllApiResponse Map(GetAllResult result)
    {
        var response = new ClientGetAllApiResponse(new List<ClientOrderDTO>());
        
        foreach (var item in result.Orders)
        {
            var dto = new ClientOrderDTO(
                item.Id.Value,
                item.Name,
                item.Status.ToString()
            );
            response.list.Add(dto);
        }

        return response;
    }
}