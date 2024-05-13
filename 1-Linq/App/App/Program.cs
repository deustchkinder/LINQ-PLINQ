using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using Dumpify;

List<int> ints = new List<int> { 1, 2, 3, 4, 5 }; //Hepsinin ortak özelliği collection olmaları içerisinde dataları barındırıyor olmaları
HashSet<int> hashSet = new HashSet<int> { 1, 2, 3, 4, 5 }; //Veriyi tutma ve işleme yöntemleri birbirinden farklı
Dictionary<int, string> dictionary = new Dictionary<int, string> { { 1, "Bir" }, { 2, "İki" }, { 3, "Üç" } };
int[] array = new int[] { 1, 2, 3, 4, 5 };
ints.Any();

IEnumerable<int> ints1 = new List<int> { 1, 2, 3, 4, 5 };
IEnumerable<int> hashSet1 = new HashSet<int> { 1, 2, 3, 4, 5 };
IEnumerable<KeyValuePair<int, string>> dictionary1 = new Dictionary<int, string> { {1,"Bir"}, {2,"İki"}, {3,"Üç" } };


IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
var queryx = numbers.Where(numbers => numbers > 2);
foreach(var number1 in queryx)
{
    Console.WriteLine(number1);
}
//---------------------------------------------------------------------------------------------------------------------------
int x = 5; //Bellekte oluştu
Console.WriteLine("Bekle");
Thread.Sleep(1000);
Console.WriteLine("Bekle");
Thread.Sleep(1000);
Console.WriteLine(x); //Bu aşamada yazdırılacak
//---------------------------------------------------------------------------------------------------------------------------
//var y = Cagırma;
var y = (int n) =>
{
    return n > 5;
};
Console.WriteLine("----");
Thread.Sleep(1000);
Console.WriteLine("----");
Thread.Sleep(1000);
Console.WriteLine(y(123));
/*bool Cagırma(int y)
{
    return y > 5;
}
*/
//---------------------------------------------------------------------------------------------------------------------------
// SELECT COMMANDS
IEnumerable<int> number = [1, 2, 3, 4, 5];

var query = number.Where(n => n > 2).Select(n => n + 10);
Console.WriteLine(string.Join(",\n",query));

var querys = number.Where(n => n > 2).Select(n => new { Column1 = "DEGER1", Column2 = "DEGER2", nr = n, n20 = n + 20 });
Console.WriteLine(string.Join(",\n", querys));

var queryd = number.Where(n => n > 2).Select(n => new { Column1 = "deger1", Column2 = "deger1", nr = n, nr10 = n + 10 }).Where(m => m.nr > 3);
Console.WriteLine(string.Join(",\n", queryd));

var queryf = from numberf in number where numberf > 2 select numberf + 10;
Console.WriteLine(string.Join(",\n", queryf));

var queryg = from numberg in number where numberg > 2 select new { Column1 = "DEGER1", Column2 = "DEGER2", nr = numberg, n30 = numberg + 30 };
Console.WriteLine(string.Join(",\n", queryg));

//SELECT WITH INDEX
var queryındex = number.Select((n, i) => new { index = i, nr = n , Column3 ="Aşağıya tırmanıyorum"});
var queryındx = number.Reverse().Select((n, i) => new { indx = i, nr = n, Column4 = "Yukarıya düşüyorum"});

//SELECT MANY
IEnumerable<int[]> sayi = [[1, 2, 3, 4, 5], [6, 7, 8, 9],[10,11,12]];
var selectMany = sayi.SelectMany(n => n);
foreach(var sayim in selectMany)
{
    Console.WriteLine(sayim);
}

var select = sayi.Select(n => n);
foreach(var item in select)
{
    foreach(var sayim in item)
    {
        Console.WriteLine(sayim);
    }
}

var SelectManyIndex = sayi.SelectMany((n, i) => n.Select(x => new { arrayIndeksi = i, nr = x , abc = "xyz" }));
foreach(var sayim in SelectManyIndex)
{
    Console.WriteLine(sayim);
}

//SKIP-SKIP WHILE-TAKE-TAKE WHILE
var queryh = number.Skip(2); foreach (var sayim in queryh) { Console.WriteLine(sayim); }
var queryj = number.Take(4); foreach (var sayim in queryj) { Console.WriteLine(sayim); }
var queryk = number.SkipWhile(n => n < 4); foreach (var sayim in queryk) { Console.WriteLine(sayim); }
var queryl = number.TakeWhile(n => n < 3); foreach (var sayim in queryl) { Console.WriteLine(sayim); }

//OFTYPE
IEnumerable<object> tipler = [1, 2, 3, 4, "Emre", "Züleyha", "Sümeyye", "Zehra"];

IEnumerable<int> onlyNumbers = tipler.OfType<int>();
Console.WriteLine(string.Join("\n", onlyNumbers));

IEnumerable<string> onlyStrings = tipler.OfType<string>();
Console.WriteLine(string.Join(" \n", onlyStrings));

//CHUNK
IEnumerable<int[]> querychunk = number.Chunk(3);

//ANY-ALL-COUNT
var result = number.Any(n => n > 2); Console.WriteLine(result);
var result1 = number.All(n => n > 2); Console.WriteLine(result1);
var result2 = number.Count(n => n > 2); Console.WriteLine(result2);

//TRYGETENUMERATEDCOUNT
if(numbers.TryGetNonEnumeratedCount(out int count)) { Console.WriteLine(count); } 
else { Console.WriteLine("No Count"); }
Console.WriteLine(count);

//SUM-MIN-MAX-AVG
var sum = number.Sum(); Console.WriteLine(sum);
var min = number.Min(); Console.WriteLine(min);
var max = number.Max(); Console.WriteLine(max);
var avg = number.Average(); Console.WriteLine(avg);

//AGGRIGATE
var agrigate = number.Aggregate((a, b) => a + b);
Console.WriteLine(agrigate);

agrigate = number.Aggregate(10,(a, b) => a + b,result => result * 3); 
Console.WriteLine(agrigate);

//RECORDS and CLASSES kayıtçı,değerler üzerinden value'ler üzerinden kıyaslama yapılabiliyor.sınıf ise referance yani başvuru üzerinden kıyaslama yapılabiliyor.
//MAXBY-MINBY-CONTAINS
List<Userx> usersRecords = [new("Emre", 1), new("Züleyha", 2), new("Sümeyye", 3), new("Zehra", 4)];
var minBy = usersRecords.MinBy(m => m.Age);
Console.WriteLine(minBy);

Userx userRecord = new("Emre", 1);
var resultC = usersRecords.Contains(userRecord);

List<Usery> usersClass = new() { new("Emre", 1), new("Züleyha", 2), new("Zehra", 3), new("Sümeyye", 4) };
var maxBy = usersRecords.MaxBy(m => m.Age);
Console.WriteLine(maxBy);

Usery userClass = new("Zehra", 3);
var resultD = usersClass.Contains(userClass);

//APPEND-PREEND-ELEMENTAT-LONGCOUNT
number.Append(34);
number.Prepend(33);
var items = number.ElementAtOrDefault(20);
Console.WriteLine(items);

//IMMEDİATE EXTENSİONS

IEnumerable<int> sayilar = [1, 2, 3, 4, 5];

var first = sayilar.First();
Console.WriteLine(first);

var last = sayilar.Last();
Console.WriteLine(last);

var firstdefault = sayilar.FirstOrDefault(n => n > 20);
Console.WriteLine(firstdefault);

var lastdefault = sayilar.LastOrDefault(n => n < -1);
Console.WriteLine(lastdefault);

var single = sayilar.Single(n => n > 4);
Console.WriteLine(single);

var singledefault = sayilar.SingleOrDefault(n => n > 5);
Console.WriteLine(singledefault);

var ifempty = sayilar.DefaultIfEmpty();
foreach (var sayibos in ifempty) { Console.WriteLine(sayibos); }

var liste = sayilar.DefaultIfEmpty();
liste.Dump();

//COLLECTION CONVERSION
List<int> list = sayilar.ToList();
HashSet<int> hashSets = sayilar.ToHashSet();
Dictionary<int, string> dictionarys = hashSet.ToDictionary(n => n, n => n.ToString());

//IENUMERABLE,IQUERYABLE INFORMATION
IEnumerable<int> enumerable = sayilar.AsEnumerable();
IQueryable<int> queryable = sayilar.AsQueryable();

//RANGE-REPEAT-EMPTY 
IEnumerable<int> say= Enumerable.Range(5, 4);
Console.WriteLine(string.Join(",", say));

sayilar = Enumerable.Repeat(5, 4);
Console.WriteLine(string.Join(",", sayilar));

IEnumerable<int> empty = Enumerable.Empty<int>();
Console.WriteLine(string.Join(",", empty));

Console.Read();

record Userx(string Name,int Age);

class Usery { public string Name { get; set; }  public int Age { get; set; } public Usery(string name, int age) { Name = name; Age = age; } public override string ToString() { return $"Name:{Name} Age:{Age}"; } }

//-------------------------------------------------------------------------------------------------------------------------------



