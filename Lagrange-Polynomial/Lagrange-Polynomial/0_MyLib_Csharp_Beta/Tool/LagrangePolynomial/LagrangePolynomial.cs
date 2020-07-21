using MyLib_Csharp_Beta.CommonMethod;
using MyLib_Csharp_Beta.Math;
using MyLib_Csharp_Beta.ProgrammingPattern;

namespace MyLib_Csharp_Beta.Tool
{
    public partial class LagrangePolynomial
    {
        public (double x, double y)[] points;

		public LagrangePolynomial(params (double x, double y)[] points)
		{
			this.points = points;
		}


		// Generate //
		public string Generate() =>
			points.JoinSum((pointT, t) =>
				points.JoinProduct((pointI, i) =>
					t == i ? $"({pointI.y})" : $"((x-{pointI.x})/({pointT.x - pointI.x}))"));
		public static string Generate(params (double x, double y)[] points) =>
			new LagrangePolynomial(points).Generate();


		// Print //
		public string Print() => Generate().Print();
        public static string Print(params (double x, double y)[] points) => Generate(points).Print();


        // Invoke //
        public double Invoke(int x) =>
            (0, points.Length - 1).SumOf(
                j => points[j].y *
                (0, points.Length - 1).ProductOf(
                    m => (x - points[m].x) / (points[j].x - points[m].x),
                    m => m != j));
        public static double Invoke(int x, params (double x, double y)[] points) =>
            new LagrangePolynomial(points).Invoke(x);


    }
}
