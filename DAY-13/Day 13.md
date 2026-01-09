# Day 13 – .NET (C#)

### Problem Statement

### Code
```csharp
delegate void PaymentDelegate(decimal amount);
class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Payment of "+amount);
    }
    public void RTGS(decimal amount)
    {
        Console.WriteLine("rtgs payment: "+amount);
    }
}
static class PaymentExtensions
{
    public static bool IsValidPayment(this decimal amount)
    {
        return amount>0 && amount<=1_000_000;
    }
}
class Program
{
    static void Main()
    {
        PaymentService service=new PaymentService();

        PaymentDelegate payment=null;
        payment+=service.ProcessPayment;  //multi casting delegant
        payment+=service.RTGS;
       // payment(5000);
        decimal amount=5000;

        if (amount.IsValidPayment())
        {
            payment(amount);
        }
        else
        {
            Console.WriteLine("invlaid");
        }
    }

}
```

### Problem Statement

### Code
```csharp
class Program
{
    static void Main()
    {
        Action<string> logActivity=msg=>Console.WriteLine("log entry: "+msg);
        logActivity("user loged in at 10:30am");
    }
}
```

### Problem Statement

### Code
```csharp
Func<decimal,decimal,decimal> cal=(price,dis)=>price-(price*dis/100);
Console.WriteLine(cal(1000,10));

Predicate<int> isEligibile=age=>age>=18;
Console.WriteLine(isEligibile(20));
```

### Problem Statement

### Code
```csharp
delegate void ErrorDelegate(string msg);
class Program
{
    static void Main()
    {
        ErrorDelegate error= delegate (string m)
        {
            Console.WriteLine("error : "+m);
        };
        error("not  found");
    }
}
```

### Problem Statement

### Code
```csharp
class Button
{
    public delegate void ClickHandler();
    public event ClickHandler Clicked;
    public void Click()
    {
        Clicked?.Invoke();
    }
}
class Program
    {
        static void Main()
        {
            Button btn=new Button();
            btn.Clicked+=()=>Console.WriteLine("m");
            btn.Clicked+=()=>Console.WriteLine("k");
            btn.Clicked-=()=>Console.WriteLine("l");
            btn.Click();

        }
    }
```
### Problem Statement

### Code
```csharp
namespace SmartHomeSecurity 
{
    // 1. DEFINITION: The "Contract" for any security response.
    // Any method responding to an alert must be void and take a string location.

    public delegate void SecurityAction(string zone); // definition

    public class MotionSensor
    {
        // The delegate instance (The Panic Button)
        public SecurityAction OnEmergency; // instance creation

        public void DetectIntruder(string zoneName)
        {
            Console.WriteLine($"[SENSOR] Motion detected in {zoneName}!");

            // 3. INVOCATION: Triggering the Panic Button
            if (OnEmergency != null)
            {
                OnEmergency(zoneName); // string value = Main Lobby or panicSequence?
            }
        }
    }

    // Diverse classes that don't know about each other
    public class AlarmSystem
    {
        public void SoundSiren(string zone) => Console.WriteLine($"[ALARM] WOO-OOO! High-decibel siren active in {zone}.");
    }

    public class PoliceNotifier
    {
        public void CallDispatch(string zone) => Console.WriteLine($"[POLICE] Notifying local precinct of intrusion in {zone}.");
    }

    class Program
    {
        static void Main()
        {
            // Objects Initialization
            MotionSensor livingRoomSensor = new MotionSensor();
            AlarmSystem siren = new AlarmSystem();
            PoliceNotifier police = new PoliceNotifier();

            // 2. INSTANTIATION & MULTICASTING
            // We "Subscribe" different methods to the sensor's delegate
            SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
            panicSequence += police.CallDispatch;

            // Linking the sequence to the sensor
            //dependency injection
            livingRoomSensor.OnEmergency = panicSequence;//livingroomsensor doent now panic sequnece 
	     // class_object.delegate_instance = delegate_instance_multicast

            // Simulation
            livingRoomSensor.DetectIntruder("Main Lobby");
        }
    }
}
```
### Problem Statement

### Code
```csharpnamespace CallbackDemo
{
    // STEP 1: Define the Delegate
    public delegate void DownloadFinishedHandler(string fileName);

    class FileDownloader
    {
        // STEP 2: Method that accepts the callback
        public void DownloadFile(string name, DownloadFinishedHandler callback)
        {
            Console.WriteLine($"Starting download: {name}...");

            // Simulating work
            Thread.Sleep(2000); 

            Console.WriteLine($"{name} download complete.");

            // STEP 3: Execute the Callback
            if (callback != null)
            {
                callback(name); 
            }
        }
    }

    class Program
    {
        // STEP 4: The actual Callback Method
        static void DisplayNotification(string file)
        {
            Console.WriteLine($"NOTIFICATION: You can now open {file}.");
        }
        static void Main()
        {
            FileDownloader downloader = new FileDownloader();

            // Pass the method 'DisplayNotification' as a callback
            downloader.DownloadFile("Presentation.pdf", DisplayNotification);
        }
    }
}
```

### Problem Statement

### Code
```csharp
Comparison<int> sort=(a,b)=>b.CompareTo(a);
Console.WriteLine(sort('a','b'));
Console.WriteLine(sort(3,2));
```
