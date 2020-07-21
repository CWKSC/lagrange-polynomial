using MyLib_Csharp_Beta.CommonMethod;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    public static partial class Looping
    {

        private static void PrintI(int i) => (i + " ").Print();

        public static void Test()
        {
            // (start, end, step) //
            (0, 17, 3).Loop(PrintI).ln();
            (50, 100, 7).Loop(i => (i + " ").Print()).lnln();

            // (start, end) //
            (0, 5).Loop(PrintI).ln();
            (4, 9).Loop(i => (i + " ").Print()).lnln();

            // times //
            3.Loop(PrintI).ln();
            5.Loop(i => (i + " ").Print()).lnln();

            // T[] //
            int[] array = { 1, 2, 3, 4, 5 };
            array.ForEach(ele => (ele + " ").Print()).lnln();

            (int x, int y)[] points = { (1, 2), (4, 5), (7, 8), (10, 11) };
            points.ForEach(ele => $"({ele.x}, {ele.y}) ".Print());
        }
        /*
        0 3 6 9 12 15
        50 57 64 71 78 85 92 99

        0 1 2 3 4 5
        4 5 6 7 8 9

        0 1 2
        0 1 2 3 4

        1 2 3 4 5

        (1, 2) (4, 5) (7, 8) (10, 11)
        */

    }
}
