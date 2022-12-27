using System.Security.Claims;
using DeliveryCompany.Application.Interfaces.ManageClientOrders;
using DeliveryCompany.Application.Interfaces.ManageClientOrders.Requests;
using DeliveryCompany.Application.Interfaces.ManageClientOrders.Results;
using DeliveryCompany.Contracts.ClientOrders;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.ClientOrders;

[ApiController]
[Route("manageclientorder/client")]
public class ClientManageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IManageClientOrders _manageClientOrders;

    public ClientManageController(IMapper mapper, IManageClientOrders manageClientOrders)
    {
        _mapper = mapper;
        _manageClientOrders = manageClientOrders;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateNewOrder(ClientOrderCreateApiRequest apiRequest)
    {
        var clientStringId = string.Empty;
        clientStringId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        Console.WriteLine(clientStringId);

        if (clientStringId is null)
            return Ok("Given subject does not exist");

        Guid clientId = new Guid(clientStringId);

        var request = _mapper.Map<ClientOrderCreateRequest>((apiRequest, clientId));
        ClientOrderResult result = _manageClientOrders.CreateNewClientOrder(request);


        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }
}