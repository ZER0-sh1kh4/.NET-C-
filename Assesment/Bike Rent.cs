using System;

public class Bike
{
    public string Model { get; set; }
    public int PricePerDay { get; set; }
    public string Brand { get; set; }
}
public class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        Bike b = new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        };
        int key=Program.bikeDetails.Count + 1;
        Program.bikeDetails.Add(key,b);

    }
    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string,List<Bike>> res= new SortedDictionary<string, List<Bike>>();
        foreach(var item in Program.bikeDetails)
        {
            Bike b =item.Value;
            if(!res.ContainsKey(b.Brand))
            {
                res[b.Brand].Add(b);
            }
            else
            {
                List<Bike> bikes = new List<Bike>();
                bikes.Add(b);
                res.Add(b.Brand,bikes);
            }
        
        }
        return res;
    }
}
class Program
{
    public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();
    static void Main(string[] args)
    {
        BikeUtility obj = new BikeUtility();
        while (true)
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes by Brand");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice= Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Enter Bike Model: ");
                string model = Console.ReadLine();
                Console.Write("Enter Bike Brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter Price Per Day: ");

                int price= Convert.ToInt32(Console.ReadLine());
                obj.AddBikeDetails(model, brand, price);
                Console.WriteLine("Bike details added successfully.");
                Console.WriteLine();

            }
            else if (choice == 2)
            {
               SortedDictionary<string, List<Bike>> ans = obj.GroupBikesByBrand();
                foreach (var item in ans)
                {
                    foreach (Bike b in item.Value)
                    {
                        Console.WriteLine(item.Key + " " + b.Model);
                    }
                }

                Console.WriteLine();
            }
            else if (choice == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Choice");
        }
    }
}
}
