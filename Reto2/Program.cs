// Reto 2. Condición de carrera
using System.Diagnostics;
using System.Threading;

int iteraciones = args.Length > 0 ? int.Parse(args[0]) : 100_000;
int esperado = iteraciones * 2;
Console.WriteLine($"Iteraciones por hilo: {iteraciones:N0}  ->  resultado esperado: {esperado:N0}\n");

int contador = 0;
object cerrojo = new object();

Probar("Sin protección", () => contador++);
Probar("Con lock", () => { lock (cerrojo) { contador++; } });
Probar("Con Interlocked", () => Interlocked.Increment(ref contador));

void Probar(string nombre, Action incrementar)
{
    Console.WriteLine($"--- {nombre} ---");
    for (int ejecucion = 1; ejecucion <= 5; ejecucion++)
    {
        contador = 0;
        var sw = Stopwatch.StartNew();
        Thread a = new Thread(() => { for (int i = 0; i < iteraciones; i++) incrementar(); });
        Thread b = new Thread(() => { for (int i = 0; i < iteraciones; i++) incrementar(); });
        a.Start(); b.Start();
        a.Join(); b.Join();
        sw.Stop();
        string ok = contador == esperado ? "OK" : $"faltan {esperado - contador:N0}";
        Console.WriteLine($"Ejecución {ejecucion}: {contador,12:N0}  ({ok})  {sw.ElapsedMilliseconds} ms");
    }
    Console.WriteLine();
}
