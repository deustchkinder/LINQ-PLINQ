using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

//ParallelQuery<int> number = ParallelEnumerable.Range(0, 10);
IEnumerable<int> number = Enumerable.Range(0, 10);

var cancelToken = new CancellationTokenSource();

Console.WriteLine($"Thread Main Start {Environment.CurrentManagedThreadId}");
Console.WriteLine("==");

//ASENKRIYON YONTEMI
//await Task.Run(() =>
//{
//    var result = number.Select(n =>
//    {
//        Console.WriteLine($"Thread: {Environment.CurrentManagedThreadId} .......NR: ----> {n}");
//        //Thread.Sleep(100);
//        return new { aa = $"{n}", bb = "xyz" };
//    }).ToList();
//}); //ConfigıreAwait(true or false)

//PARALEL YONTEMI
var results = number.AsParallel()
    .AsOrdered()
    .WithDegreeOfParallelism(2)
    .WithCancellation(cancelToken.Token)
    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
    .WithMergeOptions(ParallelMergeOptions.NotBuffered)
    .Select((n,i) =>
{
    Console.WriteLine($"Thread: {Environment.CurrentManagedThreadId}........NR: -----> {n}");
    Thread.Sleep(new Random().Next(1,20));
    return new { i,aa = $"{n}", bb = "thread identity" };
});

foreach(var item in results) { Console.WriteLine($"Thread: {Environment.CurrentManagedThreadId}........Index: ----> {item.i} {item.aa} {item.bb}"); }

Console.WriteLine("==");
Console.WriteLine($"Thread Main End {Environment.CurrentManagedThreadId}    MS: {stopwatch.ElapsedMilliseconds}");
Console.Read();
