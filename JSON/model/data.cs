using System.Text.Json.Serialization;

    namespace JSON.model
    {
        public class data
        {

            [JsonPropertyName("Vehicle_ID")]
            public int VehicleID { get; set; }

            [JsonPropertyName("Category")]
            public string Category { get; set; }

            [JsonPropertyName("Reason")]
            public string Reason { get; set; }

            [JsonPropertyName("Number_of_Incidents")]
            public int Num_Of_Incidents { get; set; }

            [JsonPropertyName("Operable_Region")]
            public int Region { get; set; }

            [JsonPropertyName("last_inspection")]
            public DateOnly LastInspection { get; set; }

            [JsonPropertyName("Inspector_ID")]
            public int InspectorID { get; set; }
        }


        public class VehicleData
        {
            [JsonPropertyName("Vehicles")]

            public List<data> vehicles { get; set; }
        }
    }