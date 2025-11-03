
public abstract class Car : IComparable<Car>
{
    public string Mark { get; set; }
    public int FuelConsumption { get; set; }

    protected Car(string mark, int fuelConsumption)
    {
        if (string.IsNullOrWhiteSpace(mark))
            throw new ArgumentException("Марка не может быть пустой");
        Mark = mark;
        FuelConsumption = fuelConsumption;
    }

    public int CompareTo(Car other)
    {
        if (other == null) return 1;
        return FuelConsumption.CompareTo(other.FuelConsumption);
    }

    public override string ToString()
    {
        return $"Марка: {Mark}, Расход топлива: {FuelConsumption} л/100км";
    }
}