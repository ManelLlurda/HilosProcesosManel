// Reto 3. Tareas y tiempo
using System.Diagnostics;

// Secuencial: cada descarga empieza cuando acaba la anterior
var sw = Stopwatch.StartNew();
await Descargar("archivo1.zip", 1);
await Descargar("archivo2.zip", 2);
await Descargar("archivo3.zip", 3);
sw.Stop();
Console.WriteLine($"Tiempo total secuencial: {sw.ElapsedMilliseconds} ms\n");

// En paralelo: lanzo las tres y espero a todas con WhenAll
sw.Restart();
Task t1 = Descargar("archivo1.zip", 1);
Task t2 = Descargar("archivo2.zip", 2);
Task t3 = Descargar("archivo3.zip", 3);
await Task.WhenAll(t1, t2, t3);
sw.Stop();
Console.WriteLine($"Tiempo total con WhenAll: {sw.ElapsedMilliseconds} ms");

static async Task Descargar(string nombre, int segundos)
{
    Console.WriteLine($"Empieza {nombre} ({segundos} s)");
    await Task.Delay(segundos * 1000);
    Console.WriteLine($"Termina {nombre}");
}
