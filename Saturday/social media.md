# DAY-18(Saturday) .NET(C#)

### Problem Statement

```csharp
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    public class SocialExecption : Exception
    {
        public SocialExecption(string message):base(message){}  //your message
        public SocialExecption(string message,Exception inner) : base(message,inner){}  //wraps inside error
    }
    public interface IPostable
    {
        public void AddPost(string content);
        public IReadOnlyList<Post> GetPosts();
    }
    public class Post
    {
        public User Author{get;set;}
        public string Content{get; set;}
        public DateTime CreatedAt{get; set;}
        public Post(User author,string content)
        {
            Author=author;
            Content=content;
            if (author==null)
            {
                throw new ArgumentException("Author cannot be null", nameof(author)); //cant create a post without being author
            }
            CreatedAt=DateTime.UtcNow;
        }
        public override string ToString() //show posts represent this
        {
            string pattern=@"#\p{L}+";  //any language character
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{Author} | {CreatedAt:dd MMM yyyy HH:mm}"); //AuthorName | 16 Jan 2026 10:30
            sb.AppendLine(Content);
            var res=Regex.Matches(Content,pattern);

            if (res.Count > 0) //#tag
            {
                sb.Append("Tags: ");

                sb.AppendJoin(", ", res.Cast<Match>().Select(m => m.Value));
            }
            return sb.ToString().TrimEnd();
        }
    }
    partial class User : IPostable, IComparable<User> //sorting user
    {
        public string Username{get;init;}//value set only during object creation
        public string Email{get;init;}
        private readonly List<Post> _posts=new();  //readobly -so list refrence cannot be replaced but itmes can be added
        private readonly HashSet<string> _following = new(StringComparer.OrdinalIgnoreCase);
        //hashet so no duplicate username , john,John,JOHN are same username 
        public event Action<Post> ? OnNewPost; //user posts something ,notify listen, ?-event can be null
        public IEnumerable<string> Following=>_following;//encapsulation -only reading no edit
        public User(string username, string email){
            Username=username;
            Email=email;
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null, empty, or whitespace.");
   
            }
            string pattern=@"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if(!Regex.IsMatch(email ?? "",pattern)) throw new SocialExecption("Invalid email format");
            //regex always gets  a string ??""
            Username=username.Trim();//remove space
            Email=email.Trim().ToLower();
        }
        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
            {
                throw new SocialExecption("Cannot follow yourself");
            }
            _following.Add(username);

        }
        public bool IsFollowing(string username) =>_following.Contains(username);
        //Checks whether the user already follows someone , prevent duplicate follow
        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Post content cannot be empty");
            }
            if (content.Length > 280)
            {
                throw new ArgumentException("Post too long (max 280 characters)");
            }
            var p=new Post(this,content.Trim());//this - currentuser becomes author
            _posts.Add(p);
            OnNewPost?.Invoke(p);
        }
        public IReadOnlyList<Post> GetPosts()=>_posts.AsReadOnly();
        
        public int CompareTo(User? other)//? -other is alloweded to be null
        {
            if(other==null) return 1;

            return string.Compare(Username,other.Username,StringComparison.OrdinalIgnoreCase); 
            //sort alphabetically  
        }
        public override string ToString() => $"@{Username}"; 
    }
    public partial class User
    {
        public string GetDisplayName()
        {
        return "User: "+Username+" "+Email;
        }
    }
    public class Repository<T> where T : class   //only objects
    {
        private readonly List<T> _items=new List<T>(); //readonly- reference cannot be replaced
        public void Add(T item)=>_items.Add(item);
        public IReadOnlyList<T> GetAll()=> _items.AsReadOnly(); //only read no modify
        public T Find(Predicate<T> match)=> _items.Find(match);  //predicate-true or false
    }
        public static class SocialUtils
        {
            public static string FormatTimeAgo(this DateTime dateTime)//extension method-adding datetime method without modifying
            {
                TimeSpan ts=DateTime.UtcNow-dateTime;

                if (ts.TotalMinutes < 1)
                {
                    return "just now";
                }
                else if (ts.TotalMinutes < 60)
                {
                    return ts.TotalMinutes+" min ago";
                }
                else if (ts.TotalHours < 24)
                {
                    return ts.TotalHours+" h ago";
                }
                else
                {
                    return dateTime.ToString("MMM dd");  //jan 25
                }
            }
        }
        class Program
        {
            private static Repository<User> _users=new Repository<User>();
            private static User? _currentUser=null;
            private static string _dataFile="social-data.json";
            
            //private static bool _exitRequested = false; 

            public static void Main()
            {
                Console.Title = "MiniSocial - Console Edition";
                Console.WriteLine("=== MiniSocial ===");
                LoadData();
                while (true)   //while(!_exitRequested)
                {
                    try{
                    if (_currentUser == null)
                    {
                        ShowLoginMenu();
                    }
                    else
                    {
                        ShowMainMenu();
                    }
                    }
                    catch(SocialExecption ex)
                    {
                        ConsoleColorWrite(ConsoleColor.Red,"Error: "+ex.Message);
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine("Inner exception: "+ex.InnerException.Message);
                        }
                        
                    }
                    catch(Exception ex)  //if there any nuwanted bugs, null refrence or crashes
                    {
                        Console.WriteLine("Unexpected Error!!");
                        Console.WriteLine(ex.Message);
                        LogError(ex);
                    }
                    Console.WriteLine("Press any key");//only refresh when user click a key
                    Console.ReadKey(true);
                }

            }
            static void ShowLoginMenu()
            {
                Console.Clear();
                Console.WriteLine("Display options: ");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter the choice: ");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    Register();
                    break;
                    case 2:
                    Login();
                    break;
                    case 0:
                    SaveData();
                    Environment.Exit(0);//terminate the process immediately
                    //_exitRequested=true;
                    return;
                    default:
                    Console.WriteLine("wrong choice");
                    break;
                }

            }
            static void Register()
            {
                Console.WriteLine("Enter username: ");
                string name=Console.ReadLine();
                Console.WriteLine("enter email");
                string mail=Console.ReadLine();
                var exists=_users.Find(u=>u.Username == name);//id nay duplicate exist
                if (exists != null)
                {
                    Console.WriteLine("Username already exists");
                    return;
                }
                User us=new User(name,mail);
                _users.Add(us);
                Console.WriteLine("Welcome "+name);
            }
            static void Login() //method is used to log an existing user into the app
            {
                Console.WriteLine("Enter username: ");
                string name=Console.ReadLine();
                var exists=_users.Find(u=>u.Username == name);
                if (exists == null)
                {
                    Console.WriteLine("user not found");
                    return;
                }
                _currentUser=exists;
                Console.WriteLine("Logged in as "+exists.Username);
                exists.OnNewPost+=ShowNotification; //user post something call shownotification
            }
            static void ShowNotification(Post post) //method runs automatically when a user creates a new post
            {
                string content;
                if (post.Content.Length > 40)
                {
                    content=post.Content.Substring(0,40)+"...";//cut after length 40 
                }
                else
                {
                    content=post.Content;
                }
                ConsoleColorWrite(ConsoleColor.Cyan,"New post by "+post.Author.Username);
            }
            static void ShowMainMenu()
            {
                Console.WriteLine("Logged in as "+_currentUser);
                Console.WriteLine("1.Post message");
                Console.WriteLine("2.View my posts");
                Console.WriteLine("3.View timeline(feed)");
                Console.WriteLine("4.Follow user");
                Console.WriteLine("5.List users");
                Console.WriteLine("6.Logout");
                Console.WriteLine("0.Exit and save");
                Console.WriteLine("Enter your choice: ");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    PostMessage();
                    break;
                    case 2:
                    ShowPosts(_currentUser!.GetPosts());
                    break;
                    case 3:
                    ShowTimeline();
                    break;
                    case 4:
                    FollowUser();
                    break;
                    case 5:
                    ListUsers();
                    break;
                    case 6:
                    _currentUser=null;
                    break;
                    case 0:
                    SaveData();
                    Environment.Exit(0);
                    return;
                    default:
                    Console.WriteLine("invalid choice");
                    break;
                }
            }
            static void PostMessage()
            {
                if(_currentUser==null) return; //need to be logged in
                Console.WriteLine(" Write the post(max 280 char)");
                Console.WriteLine("Submitting an empty input will cancel the post.");
                string cont=Console.ReadLine();
                cont=cont.Trim();
                if (string.IsNullOrWhiteSpace(cont))
                {
                    Console.WriteLine("Post cancelled");
                    return;
                }
                if (cont.Length > 280)
                {
                    Console.WriteLine("too lnegthy");
                    return;
                }
                _currentUser!.AddPost(cont);  //this means currentuser is not null
                Console.WriteLine("added successfully");
            }
            static void ShowTimeline()
            {
                if (_currentUser == null)
                {
                    return;
                }
                List<Post> timeline=new List<Post>();
                timeline.AddRange(_currentUser!.GetPosts());  //addrange-add many items at once in list
            
                foreach(string name in _currentUser.Following)
                {
                    User us=_users.Find(u=>u.Username.ToLower()==name.ToLower());  //check registred users to follwed one
                    if (us != null)
                    {
                        timeline.AddRange(us.GetPosts());
                    }
                }
                timeline.Sort((a,b)=>b.CreatedAt.CompareTo(a.CreatedAt)); //newer first then older
                Console.WriteLine("=== Your Timeline ===");
                ShowPosts(timeline);
            }
            private static void ShowPosts(IEnumerable<Post> posts)  //any collection of post 
            {
                int count=0;
                foreach(Post post in posts)
                {
                    if (count == 20) break;
                    Console.WriteLine(post);
                    Console.WriteLine(post.CreatedAt.FormatTimeAgo());
                    Console.WriteLine("--------------------");
                    count++;
                }
                if(count==0) Console.WriteLine("no posts yet");
            }
            static void FollowUser()
            {
                if (_currentUser == null) return;
                Console.WriteLine("Enter the username you want to follow");
                string follow=Console.ReadLine();
                follow=follow.Trim();
                if (string.IsNullOrWhiteSpace(follow))
                {
                    Console.WriteLine("Cancelled");
                    return;
                }
                User user=_users.Find(u=>u.Username.Equals(follow,StringComparison.OrdinalIgnoreCase));
                //look into registered users
                if (user == null)
                {
                    Console.WriteLine("user not found");
                    return;
                }
                if (!_currentUser.IsFollowing(follow)) //if not alreay following ,follow now
                {
                    _currentUser.Follow(follow);
                }
                Console.WriteLine("Now following "+follow);

            }
            static void ListUsers()
            {
                Console.WriteLine("Registered Users: ");
                var users=_users.GetAll();
                foreach(var u in users)
                {
                    Console.WriteLine(u.Username+" "+u.Email);
                }
            }
            static void SaveData()
            {
                try
                {
                    var users = _users.GetAll().Select(u => new
                    {
                        u.Username,
                        u.Email,
                        Following=u.Following.ToList(),
                        Posts = u.GetPosts().Select(p => new
                        {
                            p.Content,
                            p.CreatedAt
                        }).ToList()
                    });
                    string json=JsonSerializer.Serialize(users,new JsonSerializerOptions{WriteIndented=true});//make it readable
                    File.WriteAllText(_dataFile,json);
                    Console.WriteLine("Data saved");
                }
                catch(Exception ex)
                {
                    LogError(ex);
                    Console.WriteLine("Failed to save data");
                }
            }
            static void LoadData() //load data from json
            {
                try
                {
                    if(!File.Exists(_dataFile)) return;
                    Console.WriteLine("Data loaded");
                }
                catch(Exception ex)
                {
                    LogError(ex);
                    Console.WriteLine("Failed to load data");
                }
            }
            static void LogError(Exception ex)
            {
                try
                {
                    string log="Time: "+ DateTime.Now+"\n"+ "Message: "+ex.Message+"\n"+"StackTrace: "+ex.StackTrace+"\n"+"--------------------------\n";;
                    File.AppendAllText("error.log",log);
                }
                catch{} //If logging fails, ignore it
            }
            static void ConsoleColorWrite(ConsoleColor color, string text)
            {
                ConsoleColor old =Console.ForegroundColor;
                Console.ForegroundColor=color;
                Console.WriteLine(text);
                Console.ForegroundColor=old;
            }
        } 
}
```
