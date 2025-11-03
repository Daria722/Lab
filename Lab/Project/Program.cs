using Project;

class Program
{
    static void Main(string[] args)
    {
        TaxiPark taxiPark = new TaxiPark();
        Console.WriteLine("Добавляем автомобили в технопарк: ");

        taxiPark.Add(new PassengerTaxi("Toyota", 8, 5));
        taxiPark.Add(new PassengerTaxi("Hyundai", 7, 4));
        taxiPark.Add(new CargoTaxi("Ford", 12, 2));
        taxiPark.Add(new CargoTaxi("Mercedes", 11, 3));
        taxiPark.Add(new CargoTaxi("Ford", 13, 3));
        
        if (!taxiPark.IsBigTaxi())
        {
            Console.WriteLine("Добавляем большое такси на 8 мест");
            taxiPark.Add(new PassengerTaxi("Mercedes", 9, 8));
        }
        Console.WriteLine("\n" + taxiPark.ToString());
        
        Console.WriteLine("Сортируем автомобили по расходу топлива: ");
        taxiPark.SortByFuelConsumption();
        
        Console.WriteLine("После сортировки: ");
        Console.WriteLine(taxiPark.ToString());

        Car mostEconomical = taxiPark.GetMostEconomicalCar();
        Console.WriteLine($"Самый экономичный автомобиль: {mostEconomical} ");
        
        Console.WriteLine("Конечный технопарк:");
        Console.WriteLine(taxiPark.ToString());
        
    }
}