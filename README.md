# Lagrange polynomial

[What is Lagrange polynomial?](https://en.wikipedia.org/wiki/Lagrange_polynomial) 

This is part of the library [CWKSC/MyLib_Csharp](https://github.com/CWKSC/MyLib_Csharp)

### Usage

```C#
LagrangePolynomial fx = new LagrangePolynomial(points);

fx.Generate(); // return formula string
fx.Print(); // print formula 
fx.Invoke(5); // input x to formula and return result (double)
```

### Demo

```C#
(double, double)[] points = { (2, 7), (0, -9), (3, -3), (4, 6), (-5, 3), (1, 5), (-6, 2) };

("Generate LagrangePolynomial of " + points.ToStr()).Printlnln();

// Instance //
"Using Instance Method".Printlnln();

LagrangePolynomial fx = new LagrangePolynomial(points);

"f(x) = ".Println();
fx.Generate().Printlnln();
"f(5) = ".Print();
fx.Invoke(5).Printlnlnln();


// Static Method //
"Using Static Method".Printlnln();

"f(x) = ".Println();
LagrangePolynomial.Generate(points).Printlnln();
"f(5) = ".Print();
LagrangePolynomial.Invoke(5, points).Println();
```

### Output

```C#
Generate LagrangePolynomial of (2, 7), (0, -9), (3, -3), (4, 6), (-5, 3), (1, 5), (-6, 2)

Using Instance Method

f(x) =
(7)*((x-0)/(2))*((x-3)/(-1))*((x-4)/(-2))*((x--5)/(7))*((x-1)/(1))*((x--6)/(8))+((x-2)/(-2))*(-9)*((x-3)/(-3))*((x-4)/(-4))*((x--5)/(5))*((x-1)/(-1))*((x--6)/(6))+((x-2)/(1))*((x-0)/(3))*(-3)*((x-4)/(-1))*((x--5)/(8))*((x-1)/(2))*((x--6)/(9))+((x-2)/(2))*((x-0)/(4))*((x-3)/(1))*(6)*((x--5)/(9))*((x-1)/(3))*((x--6)/(10))+((x-2)/(-7))*((x-0)/(-5))*((x-3)/(-8))*((x-4)/(-9))*(3)*((x-1)/(-6))*((x--6)/(1))+((x-2)/(-1))*((x-0)/(1))*((x-3)/(-2))*((x-4)/(-3))*((x--5)/(6))*(5)*((x--6)/(7))+((x-2)/(-8))*((x-0)/(-6))*((x-3)/(-9))*((x-4)/(-10))*((x--5)/(-1))*((x-1)/(-7))*(2)

f(5) = 121.34126984126983


Using Static Method

f(x) =
(7)*((x-0)/(2))*((x-3)/(-1))*((x-4)/(-2))*((x--5)/(7))*((x-1)/(1))*((x--6)/(8))+((x-2)/(-2))*(-9)*((x-3)/(-3))*((x-4)/(-4))*((x--5)/(5))*((x-1)/(-1))*((x--6)/(6))+((x-2)/(1))*((x-0)/(3))*(-3)*((x-4)/(-1))*((x--5)/(8))*((x-1)/(2))*((x--6)/(9))+((x-2)/(2))*((x-0)/(4))*((x-3)/(1))*(6)*((x--5)/(9))*((x-1)/(3))*((x--6)/(10))+((x-2)/(-7))*((x-0)/(-5))*((x-3)/(-8))*((x-4)/(-9))*(3)*((x-1)/(-6))*((x--6)/(1))+((x-2)/(-1))*((x-0)/(1))*((x-3)/(-2))*((x-4)/(-3))*((x--5)/(6))*(5)*((x--6)/(7))+((x-2)/(-8))*((x-0)/(-6))*((x-3)/(-9))*((x-4)/(-10))*((x--5)/(-1))*((x-1)/(-7))*(2)

f(5) = 121.34126984126983
```

