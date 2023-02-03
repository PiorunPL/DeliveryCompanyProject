using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.ClientOrders;

public class SharedOrderMySql : ISharedOrders
{
    private readonly NewDeliveryDbContext _dbContext;

    public SharedOrderMySql(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(ClientOrder clientOrder)
    {
        var dtoList = MapToDto(clientOrder);
        if (dtoList.Count is 0)
            return;

        var foundDtos =
            _dbContext.SharedOrders.Where(dto => dto.ClientOrderDtoId.Equals(clientOrder.Id.Value.ToString())).ToList();

        _dbContext.SharedOrders.RemoveRange(foundDtos);
        _dbContext.SharedOrders.AddRange(dtoList);

        _dbContext.SaveChanges();
    }

    public List<PersonId> GetByClientOrderId(ClientOrderId clientOrderId)
    {
        List<SharedOrderDto> listDto = _dbContext.SharedOrders
            .Where(dto => dto.ClientOrderDtoId.Equals(clientOrderId.Value.ToString()))
            .ToList();
        

        List<PersonId> mappedList = MapFromDtos(listDto);
        return mappedList;
    }

    public List<ClientOrderId> GetByClientId(PersonId clientId)
    {
        List<SharedOrderDto> listDto = _dbContext.SharedOrders
            .Where(dto => dto.ClientId.Equals(clientId.Value.ToString())).ToList();

        List<ClientOrderId> mappedList = MapFromDtosToClientOrders(listDto);
        return mappedList;
    }

    private List<SharedOrderDto> MapToDto(ClientOrder clientOrder)
    {
        List<SharedOrderDto> sharedOrderDtos = new List<SharedOrderDto>();
        foreach (var id in clientOrder.SharedToClients)
        {
            SharedOrderDto dto = new SharedOrderDto
            {
                ClientOrderDtoId = clientOrder.Id.Value.ToString(),
                ClientId = id.Value.ToString()
            };
            sharedOrderDtos.Add(dto);
        }

        return sharedOrderDtos;
    }

    private List<PersonId> MapFromDtos(List<SharedOrderDto> sharedOrderDtos)
    {
        List<PersonId> personIds = new List<PersonId>();
        foreach (var dto in sharedOrderDtos)
        {
            if (Guid.TryParse(dto.ClientId, out var personGuid))
            {
                personIds.Add(new PersonId(personGuid));
            }
        }

        return personIds;
    }
    
    private List<ClientOrderId> MapFromDtosToClientOrders(List<SharedOrderDto> sharedOrderDtos)
    {
        List<ClientOrderId> personIds = new List<ClientOrderId>();
        foreach (var dto in sharedOrderDtos)
        {
            if (Guid.TryParse(dto.ClientOrderDtoId, out var orderGuid))
            {
                personIds.Add(new ClientOrderId(orderGuid));
            }
        }

        return personIds;
    }
}