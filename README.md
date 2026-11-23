# Hilos y procesos en C#

Ejercicios de la práctica T01 (DAM2 · Programación de Servicios y Procesos).

| Proyecto | Reto |
|---|---|
| `Reto1` | Mi primer hilo (Thread, Join, Sleep, Id de hilo) |
| `Reto2` | Condición de carrera (sin protección, `lock`, `Interlocked`) |
| `Reto3` | Tareas y tiempo (`Task.Delay`, `Task.WhenAll`, `Stopwatch`) |
| `Reto4` | Lanzar un proceso externo (`Process`, `ExitCode`) |

## Ejecutar

```bash
dotnet run --project Reto1
dotnet run --project Reto2            # 100.000 iteraciones por hilo
dotnet run --project Reto2 -- 1000000 # 1.000.000 iteraciones por hilo
dotnet run --project Reto3
dotnet run --project Reto4
```

Requiere .NET 8.
