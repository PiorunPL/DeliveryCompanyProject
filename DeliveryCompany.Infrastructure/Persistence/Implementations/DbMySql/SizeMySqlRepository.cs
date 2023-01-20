using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Sizes;
using DeliveryCompany.Domain.Sizes.ValueObjects;
using DeliveryCompany.Infrastructure.Context;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class SizeMySqlRepository : ISizeRepository
{
    private readonly DeliveryDbContext _dbContext;

    public SizeMySqlRepository(DeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Size size)
    {
        Entities.Size? dto = _dbContext.Sizes.Find(size.Id.Value.ToString());
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
        List<Entities.Size> dtos = _dbContext.Sizes.ToList();
        foreach (var dto in dtos)
        {
            sizes.Add(MapFromDto(dto));
        }

        return sizes;
    }

    public Size? GetById(Guid id)
    {
        Entities.Size? foundDto = _dbContext.Sizes.SingleOrDefault(dto => dto.Sizeid.Equals(id.ToString()));
        if (foundDto is null)
            return null;
        return MapFromDto(foundDto);
    }

    public void Remove(Size size)
    {
        Entities.Size? dto = _dbContext.Sizes.FirstOrDefault(dto => dto.Sizeid.Equals(size.Id.Value.ToString()));
        if (dto is null)
            return;
        _dbContext.Sizes.Remove(dto);
        _dbContext.SaveChanges();
    }

    public void RemoveById(Guid id)
    {
        Entities.Size? dto = _dbContext.Sizes.FirstOrDefault(dto => dto.Sizeid.Equals(id.ToString()));
        if(dto is null)
            return;
        _dbContext.Sizes.Remove(dto);
        _dbContext.SaveChanges();
    }

    private Entities.Size MapToDto(Size size)
    {
        Entities.Size dto = new Entities.Size
        {
            Name = size.Name,
            Price = size.Price,
            Sizeid = size.Id.Value.ToString()
        };
        return dto;
    }

    private Size MapFromDto(Entities.Size dto)
    {
        Size size = new Size(
            new SizeId(Guid.Parse(dto.Sizeid)),
            dto.Name,
            dto.Price);
        return size;
    }
}