
using System;

namespace InclassActivity06
{
    // Prototype base class
    public abstract class Robot
    {
        public string ModelName { get; set; }
        public int BatteryCapacity { get; set; }
        public string SoftwareVersion { get; set; }

        protected Robot(string modelName, int batteryCapacity,
                        string softwareVersion)
        {
            ModelName = modelName;
            BatteryCapacity = batteryCapacity;
            SoftwareVersion = softwareVersion;
        }

        public abstract Robot Clone();

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Model Name: {ModelName}");
            Console.WriteLine($"Battery Capacity: {BatteryCapacity} hours");
            Console.WriteLine($"Software Version: {SoftwareVersion}");
        }
    }

    // Service Robot
    public class ServiceRobot : Robot
    {
        public string ServiceTask { get; set; }

        public ServiceRobot(string modelName, int batteryCapacity,
                            string softwareVersion, string serviceTask)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            ServiceTask = serviceTask;
        }

        public override Robot Clone()
        {
            return (ServiceRobot)MemberwiseClone();
        }

        public override void ShowDetails()
        {
            Console.WriteLine("\n--- Service Robot ---");
            base.ShowDetails();
            Console.WriteLine($"Service Task: {ServiceTask}");
        }
    }

    // Industrial Robot
    public class IndustrialRobot : Robot
    {
        public string IndustrialTask { get; set; }

        public IndustrialRobot(string modelName, int batteryCapacity,
                               string softwareVersion, string industrialTask)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            IndustrialTask = industrialTask;
        }

        public override Robot Clone()
        {
            return (IndustrialRobot)MemberwiseClone();
        }

        public override void ShowDetails()
        {
            Console.WriteLine("\n--- Industrial Robot ---");
            base.ShowDetails();
            Console.WriteLine($"Industrial Task: {IndustrialTask}");
        }
    }

    // Entertainment Robot
    public class EntertainmentRobot : Robot
    {
        public string EntertainmentFeature { get; set; }

        public EntertainmentRobot(string modelName, int batteryCapacity,
                                  string softwareVersion,
                                  string entertainmentFeature)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            EntertainmentFeature = entertainmentFeature;
        }

        public override Robot Clone()
        {
            return (EntertainmentRobot)MemberwiseClone();
        }

        public override void ShowDetails()
        {
            Console.WriteLine("\n--- Entertainment Robot ---");
            base.ShowDetails();
            Console.WriteLine($"Entertainment Feature: {EntertainmentFeature}");
        }
    }

    // Main program
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create original robot prototypes
            ServiceRobot servicePrototype = new ServiceRobot(
                "ServiceBot S1", 8, "1.0", "Assist hotel guests");

            IndustrialRobot industrialPrototype = new IndustrialRobot(
                "FactoryBot I1", 12, "1.0", "Welding");

            EntertainmentRobot entertainmentPrototype =
                new EntertainmentRobot(
                    "FunBot E1", 6, "1.0", "Dancing");

            // Display original prototypes
            Console.WriteLine("=== ORIGINAL ROBOTS ===");
            servicePrototype.ShowDetails();
            industrialPrototype.ShowDetails();
            entertainmentPrototype.ShowDetails();

            // Clone and customize the service robot
            ServiceRobot serviceClone =
                (ServiceRobot)servicePrototype.Clone();

            serviceClone.ModelName = "ServiceBot S1 - Custom";
            serviceClone.BatteryCapacity = 10;
            serviceClone.SoftwareVersion = "1.1";

            // Clone and customize the industrial robot
            IndustrialRobot industrialClone =
                (IndustrialRobot)industrialPrototype.Clone();

            industrialClone.ModelName = "FactoryBot I1 - Custom";
            industrialClone.BatteryCapacity = 15;
            industrialClone.SoftwareVersion = "2.0";

            // Clone and customize the entertainment robot
            EntertainmentRobot entertainmentClone =
                (EntertainmentRobot)entertainmentPrototype.Clone();

            entertainmentClone.ModelName = "FunBot E1 - Custom";
            entertainmentClone.BatteryCapacity = 9;
            entertainmentClone.SoftwareVersion = "1.2";

            // Display customized clones
            Console.WriteLine("\n=== CUSTOMIZED ROBOT CLONES ===");
            serviceClone.ShowDetails();
            industrialClone.ShowDetails();
            entertainmentClone.ShowDetails();

            // Verify originals remain unchanged
            Console.WriteLine("\n=== VERIFY ORIGINAL ROBOTS ===");
            servicePrototype.ShowDetails();
            industrialPrototype.ShowDetails();
            entertainmentPrototype.ShowDetails();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}

