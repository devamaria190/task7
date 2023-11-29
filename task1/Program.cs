using System;
using System.Collections.Generic;

abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

class Human
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving");
    }
}

class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Car is moving");
    }
}

class Bus : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bus is moving");
    }
}

class Train : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Train is moving");
    }
}

class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}

class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void ControlMovement()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public void CalculateOptimalRoute(Route route, Vehicle vehicle)
    {
        Console.WriteLine($"Calculating optimal route from {route.StartPoint} to {route.EndPoint} for {vehicle.GetType().Name}");
    }

    public void PassengerBoardingAndDisembarkation(Route route, Vehicle vehicle)
    {
        Console.WriteLine($"Passenger boarding and disembarkation for {vehicle.GetType().Name} on route from {route.StartPoint} to {route.EndPoint}");
    }
}

class Program
{
    static void Main()
    {
        Car car = new Car { Speed = 60, Capacity = 4 };
        Bus bus = new Bus { Speed = 40, Capacity = 30 };
        Train train = new Train { Speed = 100, Capacity = 200 };

        TransportNetwork network = new TransportNetwork();
        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        network.ControlMovement();

        Route route = new Route { StartPoint = "A", EndPoint = "B" };
        network.CalculateOptimalRoute(route, car);
        network.PassengerBoardingAndDisembarkation(route, bus);
    }
}
