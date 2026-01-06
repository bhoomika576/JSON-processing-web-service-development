using System.Dynamic;
using System.Text.Json;

namespace JSON
{
    public class reader
    {
        string filePath = "model/data.json";

        public (int, string, string, int, int, DateOnly, int) ReadJSON()
        {
            string jsonString = System.IO.File.ReadAllText(filePath);
            using (JsonDocument doc  = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("vehicles", out JsonElement vehiclesElement) && vehiclesElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement vehicle in vehiclesElement.EnumerateArray())
                    {

                        int vehicleID = vehicle.GetProperty("Vehicle_ID").GetInt32();
                        string category = vehicle.GetProperty("Category").GetString() ?? string.Empty;
                        string reason = vehicle.GetProperty("Reason").GetString() ?? string.Empty;
                        int numOfIncidents = vehicle.GetProperty("Number_of_Incidents").GetInt32();
                        int operableRegion = vehicle.GetProperty("Operable_Region").GetInt32();
                        DateOnly lastInspection = DateOnly.Parse(vehicle.GetProperty("Last_Inspection_Date").GetString() ?? string.Empty);
                        int inspectorID = vehicle.GetProperty("Inspector_ID").GetInt32();
                        
                        return (vehicleID, category, reason, numOfIncidents, operableRegion, lastInspection, inspectorID);
                    }
                }
            }
            throw new InvalidOperationException("No vehicle data found in JSON.");
        }
    }
}
