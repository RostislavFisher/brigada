// See https://aka.ms/new-console-template for more information

using System.Collections;

Brigada CinemaCity = new CinemaCity();
Brigadnik Fillip = new Brigadnik() {name = "Fillip"};
Brigadnik Jan = new Brigadnik() {name = "Jan"};
Brigadnik Jiri = new Brigadnik() {name = "Jiri"};
CinemaCity.brigadnici.Add(Fillip);
CinemaCity.brigadnici.Add(Jan);
CinemaCity.brigadnici.Add(Jiri);
CinemaCity.work();

Paladium Paladium = new Paladium();
Brigadnik Pavel = new Brigadnik() {name = "Pavel"};
Brigadnik Josef = new Brigadnik() {name = "Josef"};
Brigadnik Karina = new Brigadnik() {name = "Karina"};
Paladium.brigadnici.Add(Pavel);
Paladium.brigadnici.Add(Josef);
Paladium.brigadnici.Add(Karina);

Paladium.work();

public class Brigadnik
{
    public string name;

    public void work()
    {
        Console.WriteLine($"{name} >>> I am starting");
        Thread.Sleep(new Random().Next(1000, 4500));
        Console.WriteLine($"{name} >>> I am ending");
    }
}

public class Paladium: Brigada
{
    public List<Brigadnik> brigadnici { get; set; } = new List<Brigadnik>();
    public void work()
    {
        var timeBeforeStart = DateTime.Now;
        foreach (var i in brigadnici)
        {
            Thread childThread = new Thread(i.work);
            childThread.Start();
        }
        var timeAfterEnd = DateTime.Now;
        TimeSpan timeDiff = timeAfterEnd - timeBeforeStart;
        Console.WriteLine($"It took {timeDiff.TotalSeconds}");

    }
}
public class CinemaCity: Brigada
{
    public List<Brigadnik> brigadnici { get; set; } = new List<Brigadnik>();
    public void work()
    {
        var timeBeforeStart = DateTime.Now;
        foreach (var i in brigadnici)
        {
            i.work();
        }
        var timeAfterEnd = DateTime.Now;
        TimeSpan timeDiff = timeAfterEnd - timeBeforeStart;
        Console.WriteLine($"It took {timeDiff.TotalSeconds}");

    }
}

interface Brigada
{
    public List<Brigadnik> brigadnici { get; set; }
    public void work();
}
