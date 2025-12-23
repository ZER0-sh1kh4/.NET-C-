# Day 04 – .NET (C#)

### Problem Statement
Title: Insurance Policy

```csharp
using System;

sealed class Security  //1
{
    public void Login()
    {
        Console.WriteLine("logged in..");
    }
}
abstract class Policy   //2
{   
    public int PolicyNo
    {
        get; init;
    }
    public int premium;
    public int Premium
    {
        get{return premium;}
        set
        {
            if (value > 0)
            {
                premium=value;
            }
        }
    }
    public string Name{get;init;}
    public virtual int CalPremium()
    {
        return premium;
    }
    public void ShowPolicy()
    {
        Console.Write("your policy is : ");
    }
}
class Life : Policy         //3a
{
        public override int CalPremium()
        {
            premium+=500;
            return premium ;
        }
        public new void ShowPolicy()
    {
        Console.WriteLine("LIFE policy");
    }
}
class Health : Policy    //3b
    {
        public override int CalPremium()
        {
          //  base.Premium();
          premium+=700;
            return premium;

        }
        public new void ShowPolicy()
    {
        Console.WriteLine("Health policy");
    }
}
class Directory   //4
    {
        private List<Policy> list =new List<Policy>();
        public void Add(Policy p)
        {
            list.Add(p);
        }
        public Policy this[int index]
        {
            get{return list[index];}
        }
        public Policy this[string name]
        {
            get
            {
                foreach (var p in list)
                {
                    if(p.Name == name) return p;
                }
                return null;
            }
        }
    }
class P    //5
{
    public static void Main()
    {
        Security s=new Security();
        s.Login();
        Life life=new Life()
        {
            Name="mufasa",
            PolicyNo=2,
            Premium=300
        };
        Health health=new Health()
        {
            Name="meeeh",
            PolicyNo=3,
            Premium=3476
        };
        Directory d=new Directory();
        d.Add(life);
        d.Add(health);
        Console.WriteLine(d[0].Name);
        Console.WriteLine(d["meeeh"].PolicyNo);
        Console.WriteLine(life.CalPremium());
        Console.WriteLine(health.CalPremium());
        // life.ShowPolicy();
        Policy p =life;
        p.ShowPolicy();
        life.ShowPolicy();

    }
} 
