using MyLib_Csharp_Beta.CommonMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib_Csharp_Beta.Tool
{
    public partial class LagrangePolynomial
    {

        public static void Test()
        {
            (double, double)[] points = { (2, 7), (0, -9), (3, -3), (4, 6), (-5, 3), (1, 5), (-6, 2) };

            ("Generate LagrangePolynomial of " + points.ToStr()).Printlnln();

            // Instance //
            "Using Instance Method".Printlnln();

            LagrangePolynomial fx = new LagrangePolynomial(points);

            "f(x) = ".Println();
            fx.Generate().Printlnln(); // equal to fx.Print().lnln()
            "f(5) = ".Print();
            fx.Invoke(5).Printlnlnln();


            // Static Method //
            "Using Static Method".Printlnln();

            "f(x) = ".Println();
            Generate(points).Printlnln(); // equal to LagrangePolynomial.Print(points).lnln()
            "f(5) = ".Print();
            Invoke(5, points).Println();

        }


    }
}
