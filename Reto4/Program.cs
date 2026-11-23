// Reto 4. Lanzar un proceso
using System.ComponentModel;
using System.Diagnostics;

Ejecutar("dotnet", "--version");      // programa que existe
Ejecutar("dotnet", "comando-falso");  // existe pero falla
Ejecutar("programaQueNoExiste", "");  // no existe

static void Ejecutar(string programa, string argumentos)
{
    Console.WriteLine($"> {programa} {argumentos}");
    var info = new ProcessStartInfo(programa, argumentos)
    {
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };
    try
    {
        using Process p = Process.Start(info)!;
        string salida = p.StandardOutput.ReadToEnd();
        string errores = p.StandardError.ReadToEnd();
        p.WaitForExit();
        if (salida.Length > 0) Console.WriteLine($"Salida: {salida.Trim()}");
        if (errores.Length > 0) Console.WriteLine($"Error: {errores.Trim().Split('\n')[0]}");
        Console.WriteLine($"ExitCode: {p.ExitCode}\n");
    }
    catch (Win32Exception ex)
    {
        Console.WriteLine($"No se pudo arrancar el proceso: {ex.Message}");
        Console.WriteLine("No hay ExitCode porque el proceso nunca llegó a crearse.\n");
    }
}
