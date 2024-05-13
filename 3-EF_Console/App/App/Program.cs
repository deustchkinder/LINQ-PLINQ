using App.Databases;
using App.Entities;
using App.Repository;
using Dumpify;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

//-----------------------IENUMERABLE vs IQUERYABLE ----------------------------

//MyDbContext db = new(); //HEP ACIK

//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();

//List<Userx> users = new()
//{
//    new Userx{Name="Emre",Age=25,City="EAST" },
//    new Userx{Name="Sümeyye",Age=28,City="EAST" },
//    new Userx{Name="Züleyha",Age=23,City="WEST" },
//    new Userx{Name= "Azra",Age=23,City="EAST" },
//    new Userx{Name="Melisa",Age=28,City="WEST" },
//    new Userx{Name="Makbule",Age=25,City="EAST" },
//    new Userx{Name="Merve",Age=28,City="EAST" },
//    new Userx{Name="Ceren",Age=28,City="WEST" },
//    new Userx{Name="Buse",Age=23,City="EAST" }
//};

//db.Users.AddRange(users);
//db.SaveChanges();

//IEnumerable<Userx> users = db.Users;
//IQueryable<Userx> users = db.Users;
//Console.WriteLine("BEKLENİYOR");
//Thread.Sleep(2000);
//users = users.Skip(2).Take(3);

//UserxRepo userxRepo = new(db);
//IEnumerable<Userx> users = userxRepo.GetAll().Skip(2).Take(3);
//IQueryable<Userx> usersQ = userxRepo.GetAllQ().Skip(2).Take(3);
//users.Dump();
//Console.WriteLine("DUMPFRİESSS");
//usersQ.Dump();




//--------------------GROUP BY --------------------------------------------------
//var groups = userxRepo.GetAll().GroupBy(m => m.City).ToList().Select((m, i) => new
//{
//    i,
//    m.Key,
//    Count = m.Count()
//});

//UserxRepo userxRepo = new(db);
//var groups = userxRepo.GetAll().GroupBy(m => new { m.City, m.Age });
//foreach (var group in groups) { Console.WriteLine($"{group.Key.City} {group.Key.Age}{group.Count()}"); }

//CLIENT-END SERVICE KONULARINI İŞLEMLERİNİ KOLAYLAŞTIRMA
//var groups = userxRepo.GetAll().GroupBy(u => new { u.City, u.Age }).Select((g, i) => new { i, g.Key.City, g.Key.Age, Count = g.Count(), Users = g.ToList() });
//groups.Dump();



//foreach(var user in users)
//{
//    Console.WriteLine(user);
//}

/*
List<ActivityX> activities = new()
{
    new() {Id = 1, Name = "Activity 1", Year = 2024, Month =1, Day = 1, },
    new() {Id = 2, Name = "Activity 2", Year = 2024, Month =1, Day = 2, },
    new() {Id = 3, Name = "Activity 3", Year = 2024, Month =2, Day = 1, },
    new() {Id = 4, Name = "Activity 4", Year = 2024, Month =2, Day = 2, },
    new() {Id = 5, Name = "Activity 5", Year = 2024, Month =1, Day = 3, },
    new() {Id = 6, Name = "Activity 6", Year = 2024, Month =1, Day = 4, },
    new() {Id = 7, Name = "Activity 7", Year = 2024, Month =2, Day = 3, },
    new() {Id = 8, Name = "Activity 8", Year = 2024, Month =2, Day = 4, },

    new() {Id = 9,  Name = "Activity 9",  Year = 2024, Month =2, Day = 4, },
    new() {Id = 10, Name = "Activity 10", Year = 2024, Month =2, Day = 4, },
    new() {Id = 11, Name = "Activity 11", Year = 2024, Month =2, Day = 5, },
    new() {Id = 12, Name = "Activity 12", Year = 2024, Month =2, Day = 5, },
    new() {Id = 13, Name = "Activity 13", Year = 2024, Month =3, Day = 4, },
    new() {Id = 14, Name = "Activity 14", Year = 2024, Month =3, Day = 4, },
    new() {Id = 15, Name = "Activity 15", Year = 2024, Month =3, Day = 5, },
    new() {Id = 16, Name = "Activity 16", Year = 2024, Month =3, Day = 5, },
};

var links = activities.GroupBy(m => new { m.Year, m.Month, m.Day }).Select(g => new
{
    g.Key.Year,
    g.Key.Month,
    g.Key.Day,
    Count = g.Count(),
    Activities = g.Select(x => new { url = $"/activaties/{g.Key.Year}/{g.Key.Month}/{g.Key.Day}/{x.Name}" })
}).OrderByDescending(m => m.Year) ;

foreach (var link in links)
{
    Console.WriteLine($"{link.Year }{link.Month}{link.Day} {link.Count }");
    foreach(var activity in link.Activities)
    {
        Console.WriteLine($"{activity.url}");
    }
}

Console.Read();

class ActivityX
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
}
*/

//----------------------JOIN------------------------

MyDbContext db = new();

//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();

//Userx userx1 = new()
//{
//    Name = "Emre",
//    Age = 25,
//    City = "EAST",
//    Orders =[new() {Name = ".NET LEARN"},new(){ Name = "CV LEARN"}]
//};

//db.Users.AddRange(userx1);
//db.SaveChanges();

var result = db.Users.Join(db.Orders, u => u.Id, o => o.UserxId, (u, o) => new { u, o });
foreach (var item in result) { Console.WriteLine($"{item.u.Name} - {item.o.Name}"); }

var resultSelect = db.Users.SelectMany(u => u.Orders,(u,o) => new { u,o });
foreach(var items in resultSelect) { Console.WriteLine($"{items.u.Name} - {items.o.Name}"); }

Console.Read();