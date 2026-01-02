# DAY-09 .NET(C#)

### Problem Statement

```csharp
class CreatorStats
{
    public string CreatorName{get; set;}
    public double[] WeeklyLikes{get; set;}
    

}
class Program{
public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

public void RegisterCreator(CreatorStats record)
{
    EngagementBoard.Add(record);
}
public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
{
    Dictionary<string,int> res=new Dictionary<string, int>();
    foreach(var i in records)
        {
            int count=0;
        
        foreach(double l in i.WeeklyLikes)
        {
            if (l >= likeThreshold)
            {
                count++;
            }
        }
            if (count > 0)
            {
                res.Add(i.CreatorName,count);
            }
        }
        return res;
}
public double CalculateAverageLikes()
{
    double likes=0;
    int week=0;
    foreach(var i in EngagementBoard)
        {
            foreach(double l in i.WeeklyLikes)
            {
              likes+=l;
              week++;  
            }
        }
        if (week == 0)
        {
            return 0;
        }
        return likes/week;
}
public static void Main()
    {
            Program p=new Program();
        while (true)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");
            int opt;
            opt=Convert.ToInt32(Console.ReadLine());
            switch (opt)
            {
                case 1:
                CreatorStats creator =new CreatorStats();
                Console.WriteLine("Enter Creator Name:");
                creator.CreatorName=Console.ReadLine();
                creator.WeeklyLikes=new double[4];
                Console.WriteLine("Enter weekly likes (Week 1 to 4)");
                for(int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i]=double.Parse(Console.ReadLine());
                    }
                p.RegisterCreator(creator);
                Console.WriteLine("Creator registered successfully");
                break;
                case 2:
                Console.WriteLine("Enter like threshold:");
                double threshold=double.Parse(Console.ReadLine());
                Dictionary<string,int> top=p.GetTopPostCounts(EngagementBoard,threshold);
                    if (top.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach(var i in top)
                        {
                            Console.WriteLine(i.Key+" "+i.Value);
                        }
                    }

                break;
                case 3:
                double avg=p.CalculateAverageLikes();
                Console.WriteLine("Overall average weekly likes: "+avg);
                break;
                case 4:
                Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                return;
                default:
                Console.WriteLine("invalid choice");
                break;
                
            }
        }
    }
}
```



