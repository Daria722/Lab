public class SchoolBag
{
    private List<Item> items;

    public SchoolBag()
    {
        items = new List<Item>();
    }

    public void Add(Item item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        items.Add(item);
    }

    public int Weight
    {
        get { return items.Sum(item => item.Weight); }
    }

    public void RemoveHeaviest()
    {
        if (items.Count > 0)
        {
            var heaviest = items.OrderByDescending(item => item.Weight).First();
            items.Remove(heaviest);
        }
    }

    public bool HasMathTextbook()
    {
        return items.OfType<TextBook>().Any(textbook => 
            textbook.Subject.Equals("Математика", StringComparison.OrdinalIgnoreCase));
    }

    public void SortByWeight()
    {
        items.Sort();
    }

    public override string ToString()
    {
        if (items.Count == 0)
            return "Рюкзак пуст";
        
        string result = $"Содержимое рюкзака (Общий вес: {Weight}г):\n";
        for (int i = 0; i < items.Count; i++)
        {
            result += $"{i + 1}. {items[i]}\n";
        }
        return result;
    }
}