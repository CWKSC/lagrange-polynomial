using MyLib_Csharp_Beta.CommonMethod;
using System;

using static MyLib_Csharp_Beta.ProgrammingPattern.ProgramStructure;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    public static partial class JoinPrintString
    {

        private static readonly Func<int, string> StringI = i => i.ToString();

        public static void Test()
        {

            // string JoinPrint(this (int start, int end, int step) args, MyFunc<int, string> work, MyFunc<int, string> join) // 
            // 4, 7, 10, 13, 16, 19
            (4, 20, 3).JoinPrint(i => i.ToString(), _ => ", ").ln();
            (4, 20, 3).JoinPrint(StringI, _ => ", ").ln();
            (4, 20, 3).JoinPrint(i => i.ToString(), ", ").ln();
            (4, 20, 3).JoinPrint(StringI, ", ").lnln();

            // string JoinPrint(this (int start, int end) args, MyFunc<int, string> work, MyFunc<int, string> join) //
            // 1, 2, 3, 4, 5
            (1, 5).JoinPrint(i => i.ToString(), _ => ", ").ln();
            (1, 5).JoinPrint(StringI, _ => ", ").ln();
            (1, 5).JoinPrint(i => i.ToString(), ", ").ln();
            (1, 5).JoinPrint(StringI, ", ").lnln();

            // string JoinPrint(this int times, MyFunc<int, string> work, MyFunc<int, string> join) //
            // 0, 1, 2
            3.JoinPrint(i => i.ToString(), _ => ", ").ln();
            3.JoinPrint(StringI, _ => ", ").ln();
            3.JoinPrint(i => i.ToString(), ", ").ln();
            3.JoinPrint(StringI, ", ").lnln();

            // string JoinPrint<T>(this T[] array, MyFunc<T, int, string> work, MyFunc<T, int, string> join) //
            // 12, 34, 56, 78, 910
            int[] array = { 12, 34, 56, 78, 910 };
            array.JoinPrint((ele, _) => ele.ToString(), (_, __) => ", ").ln();
            array.JoinPrint(StringI, (_, __) => ", ").ln();
            array.JoinPrint((ele, _) => ele.ToString(), ", ").ln();
            array.JoinPrint(StringI, ", ").lnln();

            // Use Adapter //
            // If function not provide overloading function for adapt MyAction/MyFunc Type parameter //
            // You need to use Action/Func Adapter //

            // 1, 2, 3, 4, 5
            (1, 5).JoinPrint(
                _f((int i) => i.ToString()),
                _f(() => ", ")
            ).ln();

            // 0, 1, 2
            3.JoinPrint(
                _f((int i) => i.ToString()),
                _f(() => ", ")
            ).ln();

            // 12, 34, 56, 78, 910
            array.JoinPrint(
                _f((int i) => i.ToString()),
                _f(() => ", ")
            ).lnln();


            // Some Advanced Usage //
            // Compare to JoinStr Version on JoinString.Test()
            // Only (1, 5).JoinStr change to (1, 5).JoinPrint
            // JoinPrint equal to JoinStr + Print, it just sugar syntax 
            (1, 5).JoinPrint(
                i => "(" + (1, i).JoinStr(i => i.ToString(), " + ") + ")",
                " * \n"
            ).lnln();
            /* Output
            (1) *
            (1 + 2) *
            (1 + 2 + 3) *
            (1 + 2 + 3 + 4) *
            (1 + 2 + 3 + 4 + 5)
            */

        }
        /*
        4, 7, 10, 13, 16, 19
        4, 7, 10, 13, 16, 19
        4, 7, 10, 13, 16, 19
        4, 7, 10, 13, 16, 19

        1, 2, 3, 4, 5
        1, 2, 3, 4, 5
        1, 2, 3, 4, 5
        1, 2, 3, 4, 5

        0, 1, 2
        0, 1, 2
        0, 1, 2
        0, 1, 2

        12, 34, 56, 78, 910
        12, 34, 56, 78, 910
        12, 34, 56, 78, 910
        12, 34, 56, 78, 910

        1, 2, 3, 4, 5
        0, 1, 2
        12, 34, 56, 78, 910

        (1) *
        (1 + 2) *
        (1 + 2 + 3) *
        (1 + 2 + 3 + 4) *
        (1 + 2 + 3 + 4 + 5)
        */
    }
}
