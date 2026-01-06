using JSON.model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JSON
{
    public class Add
    {
        private List<VehicleData> AddRecordToJson(string jsonToAdd, List<VehicleData> vehicleDataList)
        {
            VehicleData vehicle = JsonConvert.DeserializeObject<VehicleData>(jsonToAdd);
            vehicleDataList.Add(vehicle);
            return vehicleDataList;
        }

        
        public List<VehicleData> AddNewVehicle(string jsonToAdd, List<VehicleData> existingData)
        {
            return AddRecordToJson(jsonToAdd, existingData);
        }
    }
}