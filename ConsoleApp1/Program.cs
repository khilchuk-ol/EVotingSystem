using System.Numerics;

int a = 100;
int b = 51;

(int, int, int) ee(int a, int b)
{
    if (b == 0) return (a, 1, 0);
    var ee1 = ee(b, a % b);
    var t = ee1.Item2 - (a / b) * ee1.Item3;
    return (ee1.Item1, ee1.Item3, t);
}

Console.WriteLine(ee(a, b));