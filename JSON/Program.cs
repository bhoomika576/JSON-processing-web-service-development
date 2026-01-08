using JSON.model;
using System.Security.Cryptography;
using System.Text.Json;

namespace JSON
{
    class Program
    {

        public static List<Vehicle> SortVehicles(List<Vehicle> vehicles)
        {
            return vehicles.OrderBy(v => v.Category)
                .ThenBy(v => v.OperableRegion)
                .ToList();


        }

        static int RandomNumber(string input)
        {
            int maxRange = Convert.ToInt32(input);

            Random rnd = new Random();
            int deleteIndex = rnd.Next(0, maxRange);

            return deleteIndex;


        }
        static void DeleteRecord(List<Vehicle> vehicleList)
        {


            Console.WriteLine("Enter a number for the random number generation, greater than 0");
            string input = Console.ReadLine();
            int indexToDelete = RandomNumber(input);

            if (vehicleList.Count > 0 && indexToDelete >= 0 && indexToDelete < vehicleList.Count)
            {
                Vehicle v = vehicleList[indexToDelete];

                Console.WriteLine($"DELETING Record at Index {indexToDelete}: [{v.VehicleID}] {v.Category}");

                vehicleList.RemoveAt(indexToDelete);

                Console.WriteLine("Record deleted successfully.");
                DisplayVehicles(vehicleList);

            }
            else
            {
                Console.WriteLine("\nError: Cannot delete. List is empty or index is invalid.");
            }






        }

        static void DisplayVehicles(List<Vehicle> vehicleList)
        {
            if (vehicleList == null || vehicleList.Count == 0)
            {
                Console.WriteLine("No records to display.");
                return;
            }

            foreach (var v in vehicleList)
            {
                Console.WriteLine(new string('=', 50));

                // Header: [ID] Name
                Console.WriteLine($"[{v.VehicleID}] {v.Category}");
                Console.WriteLine(new string('-', 50));

                // reason and number of incidents
                Console.WriteLine($"\n--- Risks ---");

                Console.WriteLine($"Reason why vehicle is deemed risky:    {v.Reason}");
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

        static void AddRecord(List<Vehicle> vehicleList)
        {

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
                    vehicleList.Add(newVehicle);
                    Console.WriteLine(">> New record created and added to list in memory.\n");
                }
                DisplayVehicles(vehicleList);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }


        }




        static void Main(string[] args)
        {
            reader fileReader = new reader();
            List<Vehicle> Vehicles = fileReader.ReadJson();

            while (true)
            {
                Console.WriteLine("Select an option: \n1. View List" +
                    " \n2. Add Dummy Record" +
                    "\n3. Delete a random Record" +
                    "\n4. Sort By Category & Region");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        DisplayVehicles(Vehicles);
                        break;

                    case "2":
                        AddRecord(Vehicles);
                        break;

                    case "3":
                        DeleteRecord(Vehicles);
                        break;
                    case "4":
                        Vehicles = SortVehicles(Vehicles);
                        Console.WriteLine("List sorted by Category and Operable Region.\n");
                        DisplayVehicles(Vehicles);
                        break;



                }

            }





                //debugging
                //reader reader = new reader();
                //List<Vehicle> myVehicles = reader.ReadJson();

                //foreach (var v in myVehicles)
                //{
                //    Console.WriteLine($"ID: {v.VehicleID} | Date: {v.LastInspection}");
                //}





        }
    }
}
