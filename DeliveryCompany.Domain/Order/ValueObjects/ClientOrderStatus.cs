namespace DeliveryCompany.Domain.Order.ValueObjects;

public enum ClientOrderStatus{
    New = 0,
    Accepted = 1,
    Cancelled = 2,
    InProgress = 3,
    Delivered = 4
}