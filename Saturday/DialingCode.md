# DAY-14(Saturday) .NET(C#)

### Problem Statement

```csharp
using System;
using System.Collections.Generic;

namespace DialingCodesApp
{
    public static class DialingCodes
    {
        public static Dictionary<int,string> GetEmptyDictionary()
        {
            return new Dictionary<int,string>();
        }
        public static Dictionary<int, string> GetExistingDictionary()
        {
            Dictionary<int,string> dict=new Dictionary<int, string>();
            dict.Add(1,"United States of America");
            dict.Add(55,"Brazil");
            dict.Add(91,"India");
            return dict;

        }
        public static Dictionary<int,string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            Dictionary<int,string> count=new Dictionary<int, string>();
            count.Add(countryCode,countryName);
            return count;
        }
        public static Dictionary<int,string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary, int
countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode]=countryName;
            }
            else
            {
                existingDictionary.Add(countryCode,countryName);
            }
            return existingDictionary;
        }
        public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode)){
                return existingDictionary[countryCode];
            }
            return "";
        }
        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }
        public static Dictionary<int, string> UpdateDictionary(Dictionary<int, string> existingDictionary, int
countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode]=countryName;
            }
            return existingDictionary;
        }
        public static Dictionary<int, string> RemoveCountryFromDictionary(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Remove(countryCode);
            }
            return existingDictionary;
        }
        public static string FindLongestCountryName(Dictionary<int, string> existingDictionary
)
        {
            if (existingDictionary.Count == 0) return "";

            string longest="";
            foreach(var i in existingDictionary)
            {
                if (i.Value.Length > longest.Length)
                {
                    longest=i.Value;
                }
            }
            return longest;
        }
    }
    class Program
    {
        public static void Main()
        {
            Dictionary<int,string> task1=DialingCodes.GetEmptyDictionary();
            foreach(var i in task1)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }

            Dictionary<int,string> task2=DialingCodes.GetExistingDictionary();
            foreach(var i in task2)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
            Dictionary<int,string> task3=DialingCodes.AddCountryToEmptyDictionary(81,"japan");
            foreach(var i in task3)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
            DialingCodes.AddCountryToExistingDictionary(task2,44,"uk");
            foreach(var i in task2)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
            string res=DialingCodes.GetCountryNameFromDictionary(task2,91);
            Console.WriteLine(res);

            Console.WriteLine(DialingCodes.CheckCodeExists(task2,44));
            
            DialingCodes.UpdateDictionary(task2,91,"repo");
            foreach(var i in task2)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }

            DialingCodes.RemoveCountryFromDictionary(task2,91);
            foreach(var i in task2)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
            string res2=DialingCodes.FindLongestCountryName(task2);
            Console.WriteLine(res2);
           
            
        }
    }

}
```
