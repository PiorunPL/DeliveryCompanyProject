using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Domain.Orders.Entities;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Application.CourierOrders;

public class Common
{
    // How it works? 
    // Divides given list into cancelled orders and other orders.
    // Checks if route is valid - if not returns given list unchanged
    // Next it starts sorting other orders, beginning with empty starting facility
    // Next it follows destination with sources
    // When that step has ended, cancelled orders are added at the end of list (no specified order)
    public List<CourierOrder> SortCourierOrdersActiveFirst(List<CourierOrder> courierOrdersList)
    {
        if (courierOrdersList.Count == 0)
            return courierOrdersList;

        if (!CheckIfRouteIsCorrect(courierOrdersList))
            return courierOrdersList;

        List<CourierOrder> filteredCourierOrders = ListWithoutCancelledCourierOrders(courierOrdersList);
        List<CourierOrder> cancelledCourierOrders = ListCancelledCourierOrders(courierOrdersList);

        List<CourierOrder> sortedCourierOrders = filteredCourierOrders.ToList();
        
        if (sortedCourierOrders[0].FacilitySentId is not null)
        {
            CourierOrder? fromSource = sortedCourierOrders.Find(order => order.FacilitySentId is null);
            if (fromSource is null)
                return sortedCourierOrders;
            sortedCourierOrders.Remove(fromSource);
            sortedCourierOrders.Insert(0, fromSource);
        }

        FacilityId? destination = sortedCourierOrders[0].FacilityDeliveryId;

        if (destination is null)
            return sortedCourierOrders;

        for (int i = 0; i < sortedCourierOrders.Count; i++)
        {
            CourierOrder order = sortedCourierOrders[i];
            if (destination is not null && !destination.Equals(order.FacilitySentId))
            {
                CourierOrder? found = sortedCourierOrders.Find(o => destination.Equals(o.FacilitySentId));
                if (found is not null)
                {
                    sortedCourierOrders.Remove(found);
                    sortedCourierOrders.Insert(i, found);
                }
            }

            destination = order.FacilityDeliveryId;
        }
        
        sortedCourierOrders.AddRange(cancelledCourierOrders);
        
        return sortedCourierOrders;
    }

    public List<CourierOrder> ListWithoutCancelledCourierOrders(List<CourierOrder> courierOrders)
    {
        List<CourierOrder> list = courierOrders.FindAll(order => order.Status != CourierOrderStatus.Cancelled);
        return list;
    }

    public List<CourierOrder> ListCancelledCourierOrders(List<CourierOrder> courierOrders)
    {
        return courierOrders.FindAll(order => order.Status == CourierOrderStatus.Cancelled);
    }

    public bool CheckIfRouteIsCorrect(List<CourierOrder> courierOrders)
    {
        throw new NotImplementedException();
    }
}