using System.Text.Json.Serialization;

namespace JSON.model
{
    public class Vehicle
    {
        [JsonPropertyName("Vehicle_ID")]
        public int VehicleID { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("Reason")]
        public string Reason { get; set; }

        [JsonPropertyName("Number_of_Incidents")]
        public int NumOfIncidents { get; set; }

        [JsonPropertyName("Operable_Region")]
        public int OperableRegion { get; set; }

        [JsonPropertyName("Last_Inspection")]
        public DateOnly LastInspection { get; set; }

        [JsonPropertyName("Inspector_ID")]
        public int InspectorID { get; set; }
    }

    public class VehicleData
    {
        [JsonPropertyName("Vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}