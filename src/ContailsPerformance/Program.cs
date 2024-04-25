Console.WriteLine("please enter the int number");
var count = int.Parse(Console.ReadLine());

var userList = CreateUserList(count);
Measure(() =>
{
    foreach (var user in userList)
    {
        userList.Contains(user);
    }
}, "List");

var userHash = CreateUserHash(count);
Measure(() =>
{
    foreach (var user in userHash)
    {
        userHash.Contains(user);
    }
}, "HaseSet");

return;

void Measure(Action action, string type)
{
    var sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    action();
    sw.Stop();
    Console.WriteLine($"{type}:{sw.ElapsedMilliseconds}msec");
}

IList<User> CreateUserList(int count)
{
    var users = new List<User>();
    for (var i = 1; i <= count; i++)
    {
        users.Add(new User(i));
    }
    return users;
}

HashSet<User> CreateUserHash(int count)
{
    var users = new HashSet<User>();
    for (var i = 1; i <= count; i++)
    {
        users.Add(new User(i));
    }
    return users;
}

class User
{
    public int Id { get; set; }

    public User(int id)
    {
        Id = id;
    }
}