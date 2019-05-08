``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.15063.0 (1703/CreatorsUpdate/Redstone2)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2742185 Hz, Resolution=364.6727 ns, Timer=TSC
.NET Core SDK=2.2.102
  [Host]     : .NET Core 2.1.6 (CoreCLR 4.6.27019.06, CoreFX 4.6.27019.05), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.1.6 (CoreCLR 4.6.27019.06, CoreFX 4.6.27019.05), 64bit RyuJIT


```
| Method |       Needle |         Mean |      Error |     StdDev |
|------- |------------- |-------------:|-----------:|-----------:|
| **Single** |    **EndNeedle** | **14,892.98 ns** | **255.819 ns** | **226.777 ns** |
|  First |    EndNeedle | 16,191.21 ns | 323.012 ns | 396.688 ns |
| **Single** | **MiddleNeedle** | **14,984.85 ns** | **354.448 ns** | **530.521 ns** |
|  First | MiddleNeedle |  8,238.26 ns | 161.183 ns | 191.877 ns |
| **Single** |  **StartNeedle** | **14,537.85 ns** | **280.167 ns** | **262.069 ns** |
|  First |  StartNeedle |     53.56 ns |   1.151 ns |   1.497 ns |
