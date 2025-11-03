namespace Project;

public class CargoTaxi : Car
{
    public int LoadCapacity { get; set; }

    public CargoTaxi(string mark, int fuelConsumption, int loadCapacity) : base(mark, fuelConsumption)
    {
        if (loadCapacity <= 0)
            throw new ArgumentException("Грузоподъёмность должна быть больше 0");
        LoadCapacity = loadCapacity;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Тип: Грузовое такси, Грузоподъемность: {LoadCapacity} т";
    }
}