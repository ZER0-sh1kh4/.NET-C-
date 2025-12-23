

#Day-05 – .NET (C#)

### Problem Statement
You are developing a Library Management System that handles Books, eBooks, and Magazines, where you need to manage borrowing, returning, and calculating fines. The system also includes user notifications, library analytics, and role-based access control.<br>
This scenario allows you to use all the above concepts effectively.


```charp
using Alias=LibrarySystem.Items;          //Alias
namespace LibrarySystem{                  //nmaespace Library system started ...
namespace Items{                         //namespace Items started..
public abstract class LibraryItem       //parent LibraryItem
{
    public string title;
    public string author;
    public int itemId;
    public abstract void DisplayDetails();
    public abstract double Latefee(int days);
} 
    class Book : LibraryItem, IReservable , INotifiable              //child class Book inherting LibraryItem, interfaces(IReservable,INotifiable)
    {
        public override void DisplayDetails()
        {
            Console.WriteLine("Item=Book");
            Console.WriteLine("Title : "+title);
            Console.WriteLine("Author: "+author);
            Console.WriteLine("Item id: "+itemId);
        }
        public override double Latefee(int days)
        {
            return days*1.0;
        }
    void IReservable.reserve()                     //explicit interface 
    {
        Console.WriteLine("book reserved..");
    }
    void INotifiable.message(string msg)               //explicit interfcae 
    {
        Console.WriteLine("message.."+msg);
    }
    }
    class Magazine : LibraryItem                         //second child Magazine inherting from LibraryItem
    {
        public override void DisplayDetails()
        {
        Console.WriteLine("Item=Mgazine");
            Console.WriteLine("Title : "+title);
            Console.WriteLine("Author: "+author);
            Console.WriteLine("Item id: "+itemId);
        }
        public override double Latefee(int days)
        {
            return days*0.5;
        }
        
    }
    class EBook : LibraryItem                          //third Child Ebook inherting from LibraryItem
        {
        public override void DisplayDetails()
        {
        Console.WriteLine("Item=EBook");
            Console.WriteLine("Title : "+title);
            Console.WriteLine("Author: "+author);
            Console.WriteLine("Item id: "+itemId);
        }
        public override double Latefee(int days)
        {
            return 0;
        }
        public void Special()
            {
                Console.WriteLine("ebook special method");
            }
        }
}                                //namespace Items ended
namespace Users{                //namespace users started......
public class Member
    {
        public string Name;
    }
}                            //namespace users ended.........
interface IReservable                //interface 1
{
    public void reserve();
}
interface INotifiable               //interface 2
{
    public void message(string msg);
   // public void Notify(LibrarySystem.Roles role, string msg);

}
public partial class LibraryAnalytics                   //partial class 1
    {
        public static int track;
        
    }
public partial class LibraryAnalytics                       //partial class 2
    {
        public static void DisplayAnalytics()
        {
            Console.WriteLine("those items were borrowed.."+track);
        }
    }
enum Roles                //enum roles
    {
        Admin=1,
        Librarian=2,
        Member=3
    };
enum ItemStatus               //enum itemstatus
    {
        Available=1,
        Borrowed=2,
        Reserved=3,
        Lost=4
    };

}                              //namespace librarysystem ended...

class Program                         //MAIN class starts...
{
    public static void Main()
    {
        List<Alias.LibraryItem> list=new List<Alias.LibraryItem>();                 //list

        list.Add(new Alias.Book
        {
            title="math",
            author="me",
            itemId=2
        });
        list.Add(new Alias.Magazine
        {
            title="science",
            author="not me",
            itemId=3
        });
        list.Add(new Alias.EBook{
        title="phtysics",
        author="he",
        itemId=4
        });

        foreach(Alias.LibraryItem item in list)
        {
            item.DisplayDetails();
        
        }
        Alias.Book b=new Alias.Book();
        // b.DisplayDetails();
        Console.WriteLine("late fee for 3days for book :"+b.Latefee(3));
        LibrarySystem.IReservable ir= new Alias.Book();
        ir.reserve();
        LibrarySystem.INotifiable it=new Alias.Book();
        it.message("called by referebce");
        Alias.Magazine m=new Alias.Magazine();
        // m.DisplayDetails();
        Console.WriteLine("late for 3 days for magazine : "+m.Latefee(3));
      //  b.reserve();
      //  b.message("notification sucess");
       Alias.EBook a=new Alias.EBook();
      // a.DisplayDetails();
       a.Special();

        LibraryAnalytics.track+=3;
        LibraryAnalytics.DisplayAnalytics();
    
        LibrarySystem.Roles role =LibrarySystem.Roles.Member;
        LibrarySystem.ItemStatus status=LibrarySystem.ItemStatus.Borrowed;
        Console.WriteLine("user role: "+role);
        Console.WriteLine("Item STATUS: "+status);
        if (role == LibrarySystem.Roles.Admin)
        {
            Console.WriteLine("alert Admin...");
        }
        else if (status == LibrarySystem.ItemStatus.Borrowed)
        {
            Console.WriteLine("member is borrowing something");
        }
        
    }
}
```
