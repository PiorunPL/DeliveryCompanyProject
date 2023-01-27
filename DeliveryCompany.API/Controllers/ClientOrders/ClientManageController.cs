using DeliveryCompany.API.Common;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Results;
using DeliveryCompany.Contracts.ClientOrders.Clients.Requests;
using DeliveryCompany.Contracts.ClientOrders.Clients.Responses;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.ClientOrders;

[ApiController]
[Authorize(Roles = "Client")]
[Route("manageClientOrder/client")]
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
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        var request = _mapper.Map<CreateRequest>((apiRequest, clientId));
        ClientOrderResult result = await _manageClientOrders.CreateNewClientOrderAsync(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelOrder(ClientOrderCancelApiRequest apiRequest)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        var request = _mapper.Map<CancelRequest>((apiRequest, clientId));
        ClientOrderResult result = await Task.Run(() => _manageClientOrders.CancelClientOrder(request));

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("get")]
    public async Task<IActionResult> GetOrder(ClientOrderClientGetApiRequest apiRequest)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        var request = _mapper.Map<GetRequest>((apiRequest, clientId));
        ClientOrderResult result = await Task.Run((() => _manageClientOrders.GetOrder(request)));

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllOrders()
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        GetAllResult result = await Task.Run((() => _manageClientOrders.GetOrders(clientId)));

        var target = Map(result); //TODO: Good to Change Map method to Mapster Invocation

        return Ok(target);
        // return Ok(_mapper.Map<ClientGetAllApiResponse>(result));
    }

    

    private ClientGetAllApiResponse Map(GetAllResult result)
    {
        var response = new ClientGetAllApiResponse(new List<ClientOrderDto>());

        foreach (var item in result.Orders)
        {
            var dto = new ClientOrderDto(
                item.Id.Value,
                item.Name,
                item.Status.ToString()
            );
            response.list.Add(dto);
        }

        return response;
    }
}