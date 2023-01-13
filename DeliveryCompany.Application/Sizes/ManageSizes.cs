using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Sizes;

//TODO: to delete
public static class ManageSizes{
    public static Size? GetSizeFromName(string name){
        if(SizeCollection.Small.Name.Equals(name)){
            return SizeCollection.Small;
        }
        else if(SizeCollection.Medium.Name.Equals(name)){
            return SizeCollection.Medium;
        }
        else if(SizeCollection.Large.Name.Equals(name)){
            return SizeCollection.Large;
        }
        return null;
    }
}