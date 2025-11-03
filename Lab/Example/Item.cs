using System;

// Абстрактный класс Item, реализующий интерфейс IComparable для сравнения объектов
public abstract class Item : IComparable<Item>
{
    public int Weight { get; protected set; }

    // Конструктор с параметрами для инициализации объекта
    protected Item(int weight)
    {
        if (weight <= 0)
            throw new ArgumentException("Вес должен быть больше 0");
        Weight = weight;
    }

    // Метод сравнения объектов типа Item по весу
    public int CompareTo(Item other)
    {
        if (other == null) return 1;
        return Weight.CompareTo(other.Weight);
    }
    
    public override string ToString()
    {
        return $"Вес: {Weight}г";
    }
}