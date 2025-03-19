using Utasszallitok;

List<Repulogep> planes = new();

using (StreamReader sr = new(@"../../../src/utasszallitok.txt", System.Text.Encoding.UTF8))
{
    sr.ReadLine();
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
                  $"\tElső felszállás: \n" +
                  $"\tUtasok száma: \n" +
                  $"\tSzemélyzet: \n" +
                  $"\tUtazósebesség: ");