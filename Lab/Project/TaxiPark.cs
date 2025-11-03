namespace Project;

public class TaxiPark
{
    private List<Car> cars;

    public TaxiPark()
    {
        cars = new List<Car>();
    }

    public void Add(Car car)
    {
        if (car == null)
            throw new ArgumentException("Автомобиль не может быть пустым");
        cars.Add(car);
    }

    public bool IsBigTaxi()
    {
        foreach (var car in cars)
        {
            if (car is PassengerTaxi passengerTaxi)
            {
                if (passengerTaxi.PassengerSeats >= 5)
                    return true;
            }
        }
        return false;
    }
    
    public void SortByFuelConsumption()
    {
        cars.Sort();
    }

    public Car GetMostEconomicalCar()
    {
        if (cars.Count==0)
            throw new InvalidOperationException("В таксопарке нет автомобилей");
        Car mostEconomical = cars[0];
        foreach (var car in cars)
        {
            if (car.FuelConsumption < mostEconomical.FuelConsumption)
                mostEconomical = car;
        }
        return mostEconomical;
    }
    
    public override string ToString()
    {
        if (cars.Count == 0)
            return "Таксопарк пуст";

        string result = "Автомобили в таксопарке:\n";
        for (int i = 0; i < cars.Count; i++)
        {
            result += $"{i + 1}. {cars[i]}\n";
        }

        return result;
    }
}