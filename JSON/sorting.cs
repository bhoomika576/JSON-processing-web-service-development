using JSON.model;
using System.Collections.Generic;
using System.Linq;

namespace JSON //.model
{
    public static class VehicleSorter
    {
        public static List<Vehicle> SortVehicles(List<Vehicle> vehicles)
    {
        return vehicles.OrderBy(v => v.Category)
            .ThenBy(v => v.OperableRegion)
            .ToList();
   
    
        }
    }
}
