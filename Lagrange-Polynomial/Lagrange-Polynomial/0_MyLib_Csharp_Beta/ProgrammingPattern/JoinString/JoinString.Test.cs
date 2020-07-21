using MyLib_Csharp_Beta.CommonMethod;
using System;
using System.Collections.Generic;
using System.Text;

using static MyLib_Csharp_Beta.ProgrammingPattern.ProgramStructure;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    public static partial class JoinString
    {

        private static readonly Func<int, string> StringI = i => i.ToString();

        /// <summary>
        /// JoinString test is similar to Join function test <br />
        /// Almost the same, but a little different
        /// </summary>
        public static void Test()
        {

            // string JoinStr(this (int start, int end, int step) args, MyFunc<int, string> work, MyFunc<int, string> join) //
            // 4, 7, 10, 13, 16, 19
            (4, 20, 3).JoinStr(i => i.ToString(), _ => ", ").Println();
            (4, 20, 3).JoinStr(StringI, _ => ", ").Println();
            (4, 20, 3).JoinStr(i => i.ToString(), ", ").Println();
            (4, 20, 3).JoinStr(StringI, ", ").Printlnln();

            // string JoinStr(this (int start, int end) args, MyFunc<int, string> work, MyFunc<int, string> join) //
            // 1, 2, 3, 4, 5
            (1, 5).JoinStr(i => i.ToString(), _ => ", ").Println();
            (1, 5).JoinStr(StringI, _ => ", ").Println();
            (1, 5).JoinStr(i => i.ToString(), ", ").Println();
            (1, 5).JoinStr(StringI, ", ").Printlnln();

            // string JoinStr(this int times, MyFunc<int, string> work, MyFunc<int, string> join) //\
            // 0, 1, 2
            3.JoinStr(i => i.ToString(), _ => ", ").Println();
            3.JoinStr(StringI, _ => ", ").Println();
            3.JoinStr(i => i.ToString(), ", ").Println();
            3.JoinStr(StringI, ", ").Printlnln();

            // string JoinStr<T>(this T[] array, MyFunc<T, int, string> work, MyFunc<T, int, string> join) //
            // 12, 34, 56, 78, 910
            int[] array = { 12, 34, 56, 78, 910 };
            array.JoinStr((ele, _) => ele.ToString(), (_, __) => ", ").Println();
            array.JoinStr(StringI, (_, __) => ", ").Println();
            array.JoinStr((ele, _) => ele.ToString(), ", ").Println();
            array.JoinStr(StringI, ", ").Printlnln();

            // Use Adapter //
            // If function not provide overloading function for adapt MyAction/MyFunc Type parameter //
            // You need to use Action/Func Adapter //

            // 1, 2, 3, 4, 5
            (1, 5).JoinStr(
                _f((int i) => i.ToString()),
                _f(() => ", ")
            ).Println();

            // 0, 1, 2
            3.JoinStr(
                _f((int i) => i.ToString()),
                _f(() => ", ")
            ).Println();

            // 12, 34, 56, 78, 910
            array.JoinStr(
                _f((int i) => i.ToString()),
                _f(() => ", ")
            ).Printlnln();


            // Some Advanced Usage //
            (1, 5).JoinStr(
                i => "(" + (1, i).JoinStr(i => i.ToString(), " + ") + ")",
                " * \n"
            ).Printlnln();
            /* Output
            (1) *
            (1 + 2) *
            (1 + 2 + 3) *
            (1 + 2 + 3 + 4) *
            (1 + 2 + 3 + 4 + 5)
            */

        }
        /* Output
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
