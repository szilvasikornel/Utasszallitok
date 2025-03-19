using Utasszallitok;

List<Repulogep> planes = new();
var elsoSor = string.Empty;

using (StreamReader sr = new(@"../../../src/utasszallitok.txt", System.Text.Encoding.UTF8))
{
    elsoSor = sr.ReadLine();
    while (!sr.EndOfStream)
    {
        planes.Add(new Repulogep(sr.ReadLine()));
    }
}

Console.WriteLine($"4. feladat: Adatsorok száma: {planes.Count}");

var f05 = planes.Count(x => x.Tipus.StartsWith("Boeing"));
Console.WriteLine($"5. feladat: Boeing típusok száma: {f05}");

var f06 = planes.OrderByDescending(x => x.GetMaxUtas()).First();
Console.WriteLine($"6. feladat: A legtöbb utast szállító repülőgéptípus");
Console.WriteLine($"\tTípus: {f06.Tipus}\n" +
                  $"\tElső felszállás: {f06.Ev}\n" +
                  $"\tUtasok száma: {f06.Utas}\n" +
                  $"\tSzemélyzet: {f06.Szemelyzet}\n" +
                  $"\tUtazósebesség: {f06.Utazosebesseg}");

List<string> allCategories = new(){"Alacsony sebességű","Szubszonikus","Transzszonikus","Szuperszonikus"};
List<string> availableCategories = new();

foreach (var plane in planes)
{
    var category = new Sebessegkategoria(plane.Utazosebesseg).Kategorianev;
    if (!availableCategories.Contains(category))
    {
        availableCategories.Add(category);
    }
}

List<string> missingCategories = allCategories.Except(availableCategories).ToList();
//Expect: azokat az elemeket adja vissza az első gyűjteményből, amelyek nem szerepelnek a második gyűjteményben

if (missingCategories.Any())
{
    Console.WriteLine($"7. feladat:\n\t{string.Join(", ", missingCategories)}");
    //string.Join: összefűzi és egy meghatározott elválasztót használ az elemek között
}
else
{
    Console.WriteLine("7. feladat:\n\tMinden sebességkategóriából található repülőgép.");
}

using(StreamWriter sw = new(@"../../../src/utasszallitok_new.txt"))
{
    sw.WriteLine(elsoSor);
    foreach (var plane in planes)
    {
        sw.WriteLine($"{plane.Tipus};{plane.Ev};{plane.GetMaxUtas()};{plane.GetMaxSzemely()};{plane.Utazosebesseg};{Math.Round((double)plane.Felszallotomeg * 0.001,0)};{Math.Round((double)plane.Fesztav * 3.2808,0)}");
    }
}
