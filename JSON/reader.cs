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


