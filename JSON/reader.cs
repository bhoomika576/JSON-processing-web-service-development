using JSON.model;
using System.Dynamic;
using System.Net.Http.Json;
using System.Text.Json;

namespace JSON
{
    public class reader
    {
        string filePath = "data.json";

        public List<Vehicle> ReadJson()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found at {Path.GetFullPath(filePath)}");
                return new List<Vehicle>();
            }


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
=======
            try
            {
                string jsonContent = File.ReadAllText(filePath);


                var data = JsonSerializer.Deserialize<VehicleData>(jsonContent);

                return data?.Vehicles ?? new List<Vehicle>();

            }
            
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON Error: {jsonEx.Message}");
                return new List<Vehicle>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Vehicle>();
            }

        }


    }
}


