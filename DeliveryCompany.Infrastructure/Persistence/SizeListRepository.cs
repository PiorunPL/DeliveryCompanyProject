using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Sizes;
using DeliveryCompany.Domain.Sizes.ValueObjects;

namespace DeliveryCompany.Infrastructure.Persistence;

public class SizeListRepository : ISizeRepository
{
    private readonly List<SizeDto> _sizesDb = new List<SizeDto>();
    
    public void Add(Size size)
    {
        SizeDto? found = _sizesDb.Find(dto => dto.Id.Equals(size.Id.Value.ToString()));
        if (found is null)
            return;
        SizeDto dto = MapToDto(size);
        _sizesDb.Add(dto);
    }

    public void Update(Size size)
    {
        SizeDto dto = MapToDto(size);
        SizeDto? foundDto = _sizesDb.Find(sizeDto => sizeDto.Id.Equals(size.Id.Value.ToString()));
        if (foundDto is not null)
            _sizesDb.Remove(foundDto);
        _sizesDb.Add(dto);
    }

    public List<Size> GetAll()
    {
        List<Size> sizes = new List<Size>();
        foreach (SizeDto dto in _sizesDb)
        {
            Size size = MapFromDto(dto);
            sizes.Add(size);
        }

        return sizes;
    }

    public Size? GetById(Guid id)
    {
        SizeDto? foundDto = _sizesDb.Find(dto => dto.Id.Equals(id.ToString()));
        if (foundDto is null)
            return null;
        Size size = MapFromDto(foundDto);
        return size;
    }

    public void Remove(Size size)
    {
        RemoveById(size.Id.Value);
    }

    public void RemoveById(Guid id)
    {
        SizeDto? foundDto = _sizesDb.Find(dto => dto.Id.Equals(id.ToString()));
        if (foundDto is not null)
            _sizesDb.Remove(foundDto);
    }

    private Size MapFromDto(SizeDto dto)
    {
        Size size = new Size(new SizeId(Guid.Parse(dto.Id)),dto.Name, dto.Price);
        return size;
    }

    private SizeDto MapToDto(Size size)
    {
        SizeDto dto = new SizeDto(size.Id.Value.ToString(), size.Name, size.Price);
        return dto;
    }
    
    private class SizeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    
        public SizeDto(string id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
    
}