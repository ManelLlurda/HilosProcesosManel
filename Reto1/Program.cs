// Reto 1. Mi primer hilo
using System.Threading;

Console.WriteLine($"[Main] Id del hilo principal: {Environment.CurrentManagedThreadId}");

// --- Prueba A: Join al final del programa ---
Console.WriteLine("\n=== Prueba A: Join al final ===");
Thread hiloA = new Thread(ContarHastaCinco);
hiloA.Start();
for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"[Main] Sigo trabajando mientras el hilo cuenta... (Id {Environment.CurrentManagedThreadId})");
    Thread.Sleep(300);
}
hiloA.Join();
Console.WriteLine("[Main] El hilo A ha terminado");

// --- Prueba B: Join justo después de Start ---
Console.WriteLine("\n=== Prueba B: Join justo después de Start ===");
Thread hiloB = new Thread(ContarHastaCinco);
hiloB.Start();
hiloB.Join(); // Main se queda bloqueado aquí hasta que el hilo acaba
for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"[Main] Sigo trabajando... (Id {Environment.CurrentManagedThreadId})");
    Thread.Sleep(300);
}
Console.WriteLine("[Main] Fin del programa");

static void ContarHastaCinco()
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"   [Hilo] {i} (Id {Environment.CurrentManagedThreadId})");
        Thread.Sleep(500);
    }
}
