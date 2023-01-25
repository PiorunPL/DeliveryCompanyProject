using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Sizes;
using DeliveryCompany.Domain.Sizes.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class SizeMySqlRepository : ISizeRepository
{
    private readonly NewDeliveryDbContext _dbContext;

    public SizeMySqlRepository(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Size size)
    {
        SizeDto? dto = _dbContext.Sizes.Find(size.Id.Value.ToString());
        if (dto is not null)
            return;

        _dbContext.Sizes.Add(MapToDto(size));
        _dbContext.SaveChanges();
    }

    public void Update(Size size)
    {
        _dbContext.Update(MapToDto(size));
        _dbContext.SaveChanges();
    }

    public List<Size> GetAll()
    {
        List<Size> sizes = new List<Size>();
        List<SizeDto> dtos = _dbContext.Sizes.ToList();
        foreach (var dto in dtos)
        {
            sizes.Add(MapFromDto(dto));
        }

        return sizes;
    }

    public Size? GetById(Guid id)
    {
        SizeDto? foundDto = _dbContext.Sizes.SingleOrDefault(dto => dto.SizeId.Equals(id.ToString()));
        if (foundDto is null)
            return null;
        return MapFromDto(foundDto);
    }

    public void Remove(Size size)
    {
        SizeDto? dto = _dbContext.Sizes.FirstOrDefault(dto => dto.SizeId.Equals(size.Id.Value.ToString()));
        if (dto is null)
            return;
        _dbContext.Sizes.Remove(dto);
        _dbContext.SaveChanges();
    }

    public void RemoveById(Guid id)
    {
        SizeDto? dto = _dbContext.Sizes.FirstOrDefault(dto => dto.SizeId.Equals(id.ToString()));
        if(dto is null)
            return;
        _dbContext.Sizes.Remove(dto);
        _dbContext.SaveChanges();
    }

    private SizeDto MapToDto(Size size)
    {
        SizeDto dto = new SizeDto
        {
            Name = size.Name,
            Price = size.Price,
            SizeId = size.Id.Value.ToString()
        };
        return dto;
    }

    private Size MapFromDto(SizeDto dto)
    {
        Size size = new Size(
            new SizeId(Guid.Parse(dto.SizeId)),
            dto.Name,
            dto.Price);
        return size;
    }
}