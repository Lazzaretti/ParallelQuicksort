# Paralell Quicksort Test

1. `dotnet build`
2. `dotnet run`

##Result
### Intel i5 6th Generation, 2 Cores, 4 logical processors
```
Sequential      :       Elapsed=15899
Parallel        :       Elapsed=5368
P. Separate Method:     Elapsed=2241
Sequential      :       Elapsed=14679
Parallel        :       Elapsed=5307
P. Separate Method:     Elapsed=2534
Sequential      :       Elapsed=14759
Parallel        :       Elapsed=5391
P. Separate Method:     Elapsed=2122
Sequential      :       Elapsed=15060
Parallel        :       Elapsed=5972
P. Separate Method:     Elapsed=2061
Sequential      :       Elapsed=14877
Parallel        :       Elapsed=5245
P. Separate Method:     Elapsed=2180
```

### Intel i7 6th Generation, 2 Cores, 4 logical processors
```
Sequential      :       Elapsed=14568
Parallel        :       Elapsed=4966
P. Separate Method:     Elapsed=2123
Sequential      :       Elapsed=14618
Parallel        :       Elapsed=4906
P. Separate Method:     Elapsed=2156
Sequential      :       Elapsed=14509
Parallel        :       Elapsed=4954
P. Separate Method:     Elapsed=2067
Sequential      :       Elapsed=14450
Parallel        :       Elapsed=4958
P. Separate Method:     Elapsed=2075
Sequential      :       Elapsed=14484
Parallel        :       Elapsed=5176
P. Separate Method:     Elapsed=2154
```