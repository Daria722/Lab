namespace Project;

public class PassengerTaxi : Car
{
    public int PassengerSeats { get; set; }

    public PassengerTaxi(string mark, int fuelConsumption, int passengerSeats) : base(mark, fuelConsumption)
    {
        if (passengerSeats < 2)
            throw new ArgumentException("Количество мест должно быть не менее 2");
        PassengerSeats = passengerSeats;
    }

    public override string ToString()
    {
        return base.ToString() + $"Тип: Пассажирское такси, Места: {PassengerSeats}";
    }
}