### Problem Statement

### Code
```csharp
namespace EcommerceAssessment
{
    public class Repository<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }
        public List<T> GetAll()
        {
            return items;
        }
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {CustomerName}, Amount: {Amount}";
        }
    }
    public delegate void OrderCallback(string message);
    public class OrderProcessor
    {
        public event Action<string> OrderProcessed;
        public void ProcessOrder(
            Order order,
            Func<double, double> taxCalculator,
            Func<double, double> discountCalculator,
            Predicate<Order> validator,
            OrderCallback callback)
        {
            if (!validator(order))
            {
                callback("Order validation failed.");
                return;
            }
            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);

            order.Amount = order.Amount + tax - discount;

            callback($"Order {order.OrderId} processed successfully.");
            OrderProcessed?.Invoke($"Order {order.OrderId} completed.");
        }
    }

class Program
    {
        static void Main()
        {
            Repository<Order> repository = new Repository<Order>();

            repository.Add(new Order {OrderId = 1, CustomerName = "A", Amount = 5000 });
            repository.Add(new Order { OrderId = 2, CustomerName = "B", Amount = 2000 });
            repository.Add(new Order {OrderId = 3, CustomerName = "C", Amount = 8000 });

            OrderProcessor processor = new OrderProcessor();
            Func<double, double> taxCalculator = amount => amount * 0.18;
            Func<double, double> discountCalculator = amount => amount * 0.10;
            Predicate<Order> validator = order => order.Amount >= 3000;
            OrderCallback callback = message =>
            {
                Console.WriteLine("Callback: "+message);
            };
            Action<string> logger = msg =>
            {
                Console.WriteLine("Logger: Event: " + msg);
            };

            Action<string> notifier = msg =>
            {
                Console.WriteLine("Notifier: Event: " + msg);
            };
            Action<string> multicast=logger+notifier;
            processor.OrderProcessed += logger;
            processor.OrderProcessed += notifier;
            foreach (Order order in repository.GetAll())
            {
                processor.ProcessOrder(
                    order,
                    taxCalculator,
                    discountCalculator,
                    validator,
                    callback
                );
                Console.WriteLine();
            }
            List<Order> orders = repository.GetAll();
            orders.Sort((a, b) => b.Amount.CompareTo(a.Amount));
            Console.WriteLine("Sorted Orders (Descending Amount):");
            foreach (Order order in orders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
```
