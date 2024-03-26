using System;

// Vehicle class representing a generic vehicle
class Vehicle
{
    // Properties
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public double RentalPrice { get; set; }

    // Constructor
    public Vehicle(string model, string manufacturer, int year, double rentalPrice)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        RentalPrice = rentalPrice;
    }

    // Display vehicle details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}, Manufacturer: {Manufacturer}, Year: {Year}, Rental Price: {RentalPrice}");
    }
}

// Car class inheriting from Vehicle
class Car : Vehicle
{
    // Additional properties
    public int Seats { get; set; }
    public string EngineType { get; set; }
    public string Transmission { get; set; }
    public bool Convertible { get; set; }

    // Constructor
    public Car(string model, string manufacturer, int year, double rentalPrice, int seats, string engineType, string transmission, bool convertible)
        : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
    }

    // Override DisplayDetails method
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Seats: {Seats}, Engine Type: {EngineType}, Transmission: {Transmission}, Convertible: {Convertible}");
    }
}

// Truck class inheriting from Vehicle
class Truck : Vehicle
{
    // Additional properties
    public int Capacity { get; set; }
    public string TruckType { get; set; }
    public bool FourWheelDrive { get; set; }

    // Constructor
    public Truck(string model, string manufacturer, int year, double rentalPrice, int capacity, string truckType, bool fourWheelDrive)
        : base(model, manufacturer, year, rentalPrice)
    {
        Capacity = capacity;
        TruckType = truckType;
        FourWheelDrive = fourWheelDrive;
    }

    // Override DisplayDetails method
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Capacity: {Capacity}, Truck Type: {TruckType}, Four-Wheel Drive: {FourWheelDrive}");
    }
}

// Motorcycle class inheriting from Vehicle
class Motorcycle : Vehicle
{
    // Additional properties
    public int EngineCapacity { get; set; }
    public string FuelType { get; set; }
    public bool HasFairing { get; set; }

    // Constructor
    public Motorcycle(string model, string manufacturer, int year, double rentalPrice, int engineCapacity, string fuelType, bool hasFairing)
        : base(model, manufacturer, year, rentalPrice)
    {
        EngineCapacity = engineCapacity;
        FuelType = fuelType;
        HasFairing = hasFairing;
    }

    // Override DisplayDetails method
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Engine Capacity: {EngineCapacity}, Fuel Type: {FuelType}, Has Fairing: {HasFairing}");
    }
}

// RentalAgency class to manage the rental agency's fleet of vehicles
class RentalAgency
{
    // Array to store instances of vehicles
    private Vehicle[] Fleet { get; set; }

    // Total revenue earned by the rental agency
    public double TotalRevenue { get; private set; }

    // Constructor
    public RentalAgency(int capacity)
    {
        Fleet = new Vehicle[capacity];
    }

    // Method to add vehicles to the fleet
    public void AddVehicle(Vehicle vehicle, int index)
    {
        if (index >= 0 && index < Fleet.Length)
        {
            Fleet[index] = vehicle;
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    // Method to remove vehicles from the fleet
    public void RemoveVehicle(int index)
    {
        if (index >= 0 && index < Fleet.Length)
        {
            Fleet[index] = null;
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    // Method to rent vehicles
    public void RentVehicle(int index)
    {
        if (index >= 0 && index < Fleet.Length && Fleet[index] != null)
        {
            TotalRevenue += Fleet[index].RentalPrice;
            Fleet[index] = null;
            Console.WriteLine("Vehicle rented successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index or vehicle not available.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of vehicles
        Car car = new Car("Camry", "Toyota", 2022, 50.00, 5, "Petrol", "Automatic", false);
        Truck truck = new Truck("F-150", "Ford", 2020, 70.00, 4, "Pickup", true);
        Motorcycle motorcycle = new Motorcycle("Ninja", "Kawasaki", 2021, 40.00, 1000, "Petrol", true);

        // Displaying vehicle details
        car.DisplayDetails();
        truck.DisplayDetails();
        motorcycle.DisplayDetails();

        // Creating rental agency
        RentalAgency agency = new RentalAgency(10);

        // Adding vehicles to the fleet
        agency.AddVehicle(car, 0);
        agency.AddVehicle(truck, 1);
        agency.AddVehicle(motorcycle, 2);

        // Renting a vehicle
        agency.RentVehicle(1);

        // Displaying total revenue
        Console.WriteLine($"Total revenue: {agency.TotalRevenue}");
    }
}
