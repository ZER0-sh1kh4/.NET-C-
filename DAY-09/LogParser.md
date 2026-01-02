# DAY-09 .NET (C#)

### Problem Statements

```csharp
namespace LogProcessing
{
    class LogParser
    {
        // public string validLineRegexPattern{get; private set;}
        // public string splitLineRegexPattern{get; private set;}
        // public string quotedPasswordRegexPattern{get; private set;}
        // public string endOfLineRegexPattern{get; private set;}
        // public string weakPasswordRegexPattern{get; private set;}
        public bool IsValidLine(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            string pattern=@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
            return Regex.IsMatch(text,pattern);
        }
        public string[] SplitLogLine(string text)
        {
             if (string.IsNullOrEmpty(text))
            {
                return new string[0];
            }

            string pattern=@"(<\*\*\*>|<====>|<\^\*>)";
            return Regex.Split(text,pattern);

        }
        public int CountQuotedPasswords(string lines)
        {
             if (string.IsNullOrEmpty(lines))
            {
                return 0;
            }

            string pattern="\"[^\"]*password[^\"]*\"";
            return Regex.Matches(lines,pattern,RegexOptions.IgnoreCase).Count;
        }
        public string RemoveEndOfLine(string line)
        {
             if (string.IsNullOrEmpty(line))
            {
                return line;
            }

            string pattern=@"end-of-line\d+";
            return Regex.Replace(line,pattern,"");
        }
        public string[] ListLinesWithPasswords(string[] lines)
        {
            List<string> res=new List<string>();
            
            string pattern=@"password[\w]+";
            foreach(string line in lines)
            {
                Match m=Regex.Match(line,pattern);
                if (m.Success)
                {
                    res.Add(m.Value+":"+line);
                }
                else
                {
                    res.Add("-----------: "+line);
                }
            }
            return res.ToArray();


        }
    }
    class Program{
    public static void Main()
        {
            LogParser log=new LogParser();

            Console.WriteLine(log.IsValidLine("[INF] Application started"));


           string[] split = log.SplitLogLine(
                "[INF] User login<*>Session created<====>Access granted"
            );
            foreach (string s in split)
                if (!string.IsNullOrWhiteSpace(s)) Console.WriteLine(s);


            string text =
                "User said \"password123 is weak\"\n" +
                "Admin noted \"PASSWORD456 expired\"\n" +
                "No issue found";
            Console.WriteLine(log.CountQuotedPasswords(text));

             Console.WriteLine(
                log.RemoveEndOfLine("Transaction completed successfully end-of-line456"));

            string[] lines =
            {
                "User entered password123 during login",
                "System startup completed",
                "Admin reset passwordABC",
                "Backup process finished"
            };

            foreach (string r in log.ListLinesWithPasswords(lines))
                Console.WriteLine(r);
        }
        }
    }
```
