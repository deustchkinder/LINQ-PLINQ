using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Dumpify;

var userxes = new List<Userx> { new("Emre", 25, "Doğu"), new("Züleyha", 23, "Batı"), new("Merve", 28, "Doğu"), new("Melisa", 28, "Kuzey"), new("Buse", 23, "Doğu"), new("Gülşen", 28, "Kuzey"), new("Makbule", 25, "Kuzey"), new("Zeynep", 23, "Doğu"), new("Ceren", 28, "Batı") };
var useryes = new List<Userx> { new("Şefkat", 25, "Doğu"), new("Ece", 23, "Batı"), new("Dilan", 28, "Doğu"), new("Büşra", 28, "Kuzey"), new("Şehriban", 23, "Doğu"), new("Ceren K.", 28, "Kuzey"), new("Sevgi", 25, "Kuzey"), new("Rabia", 23, "Doğu"), new("Tuğba", 28, "Batı") };

var result = userxes.Distinct();
Console.WriteLine(string.Join(",\n", result));

Console.WriteLine("---------------------------------------------------");

var result1 = userxes.DistinctBy(m => m.Name).Reverse();
Console.WriteLine(string.Join(",\n", result1));

Console.WriteLine("---------------------------------------------------");

var lookup = userxes.ToLookup(u => u.Age);
foreach (var group in lookup)
{
    Console.WriteLine(group.Key);
    foreach(var user in group)
    {
        Console.WriteLine(user);
    }
}

Console.WriteLine("---------------------------------------------------");

var tolookup = userxes.ToLookup(a => new { a.City, a.Age });
foreach (var togroup in tolookup)
{
    Console.WriteLine(togroup.Key);
    foreach (var user in togroup)
    {
        Console.WriteLine(user);
    }
}

Console.WriteLine("---------------------------------------------------");

var result2 = userxes.ToLookup(b => new { b.City, b.Age }).Select(c => new { c.Key.City, c.Key.Age, userxes = c });
foreach(var groups in result2)
{
    Console.WriteLine(groups.City);
    Console.WriteLine(groups.Age);
    foreach(var userx in groups.userxes)
    {
        Console.WriteLine(userx);
    }

}

Console.WriteLine("----------------------------------------------------");

var result3 = userxes.Union(useryes);
Console.WriteLine(string.Join(",\n", result3));
result3.Dump();

Console.WriteLine("----------------------------------------------------");

var result4 = userxes.Intersect(useryes);
Console.WriteLine(string.Join(",\n", result4));

Console.WriteLine("----------------------------------------------------");

var result5 = userxes.IntersectBy(useryes.Select(m => new { m.Age }), m => new { m.Age });
Console.WriteLine(string.Join(",\n", result5));

Console.WriteLine("----------------------------------------------------");

var result6 = userxes.ExceptBy(useryes, m => m);
Console.WriteLine(string.Join(",\n", result6));

Console.WriteLine("----------------------------------------------------");

var result7 = userxes.SequenceEqual(useryes);
Console.WriteLine(string.Join(",\n", result7));

Console.WriteLine("----------------------------------------------------");

IEnumerable<(Userx first, Userx second)> result8 = userxes.Zip(useryes);
foreach(var(first,second) in result8) { Console.WriteLine($"First: {first}, Second:{second}"); }

Console.WriteLine("----------------------------------------------------");

var result9 = userxes.Concat(useryes);
result9.Dump();

Console.WriteLine("----------------------------------------------------");

var order = userxes.OrderBy(m => m.Age);
Console.WriteLine(string.Join(",\n", order));

Console.WriteLine("----------------------------------------------------");

var orderby = userxes.OrderBy(m => m.Age).ThenBy(m => m.Name);
Console.WriteLine(string.Join(",\n", orderby));


Console.Read();

record Userx(string Name, int Age,string City);

class Usery { public string Name { get; set; } public int Age { get; set; }public string City { get; set; } public Usery(string name, int age, string city) { Name = name; Age = age; City = city; } public override string ToString() { return $"Name:{Name} Age:{Age} City:{City}"; } }

