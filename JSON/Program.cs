using JSON;
using JSON.model;
using System.Reflection.PortableExecutable;

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



            reader reader = new reader();
            List<Vehicle> myVehicles = reader.ReadJson();

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