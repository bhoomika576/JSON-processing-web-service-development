using JSON.model;
using System.Text.Json;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {


            //debugging
            //reader reader = new reader();
            //List<Vehicle> myVehicles = reader.ReadJson();

            //foreach (var v in myVehicles)
            //{
            //    Console.WriteLine($"ID: {v.VehicleID} | Date: {v.LastInspection}");
            //}


            reader fileReader = new reader();
            List<Vehicle> myVehicles = fileReader.ReadJson();
            string dummyJson = """
        {
            "Vehicle_ID": 999,
            "Category": "Bulldozer",
            "Reason": "Engine overheating",
            "Number_of_Incidents": 3,
            "Operable_Region": 7,
            "Last_Inspection": "2024-01-15",
            "Inspector_ID": 404
        }
        """;
            try
            {
                Vehicle? newVehicle = JsonSerializer.Deserialize<Vehicle>(dummyJson);

                if (newVehicle != null)
                {
                    myVehicles.Add(newVehicle);
                    Console.WriteLine(">> New record created and added to list in memory.\n");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }

            foreach (var v in myVehicles)
            {
                Console.WriteLine(new string('=', 50));

                // Header: [ID] Name
                Console.WriteLine($"[{v.VehicleID}] {v.Category}");
                Console.WriteLine(new string('-', 50));

                // reason and number of incidents
                Console.WriteLine($"\n--- Risks ---");

                Console.WriteLine($"Reason why vehicle is deemed risky:   {v.Reason}");
                Console.WriteLine($"Number of Incidents: {v.NumOfIncidents}");

                // region operable 
                Console.WriteLine($"\n---Region Operable ---");
                Console.WriteLine($"Region Number: {v.OperableRegion}");

                // Footer
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"Last Inspected: {v.LastInspection}");
                Console.WriteLine("\n");
            }




        }
    }
}
