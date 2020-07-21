using System;
using System.Text;
using static MyLib_Csharp_Beta.CommonMethod.MyPrint;
using static MyLib_Csharp_Beta.ProgrammingPattern.ProgramStructure;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    public static partial class JoinFunction
    {

        private static readonly Action<int> PrintI = i => i.Print();

        public static void Test()
        {
            // (int start, int end, int step) JoinFunc(this (int start, int end, int step) args, MyAction<int> work, MyAction<int> join) //
            // 4, 7, 10, 13, 16, 19
            (4, 20, 3).JoinFunc(i => i.Print(), _ => ", ".Print()).ln();
            (4, 20, 3).JoinFunc(PrintI, _ => ", ".Print()).ln();
            (4, 20, 3).JoinFunc(i => i.Print(), ", ").ln();
            (4, 20, 3).JoinFunc(PrintI, ", ").lnln();

            // (int start, int end) JoinFunc(this (int start, int end) args, MyAction<int> work, MyAction<int> joinAction) //
            // 1, 2, 3, 4, 5
            (1, 5).JoinFunc(i => i.Print(), _ => ", ".Print()).ln();
            (1, 5).JoinFunc(PrintI, _ => ", ".Print()).ln();
            (1, 5).JoinFunc(i => i.Print(), ", ").ln();
            (1, 5).JoinFunc(PrintI, ", ").lnln();

            // int JoinFunc(this int times, MyAction<int> work, MyAction<int> joinAction) //
            // 0, 1, 2
            3.JoinFunc(i => i.Print(), _ => ", ".Print()).ln();
            3.JoinFunc(PrintI, _ => ", ".Print()).ln();
            3.JoinFunc(i => i.Print(), ", ").ln();
            3.JoinFunc(PrintI, ", ").lnln();

            // T[] JoinFunc<T>(this T[] array, MyAction<T, int> work, MyAction<T, int> joinAction) //
            // 12, 34, 56, 78, 910
            int[] array = { 12, 34, 56, 78, 910 };
            array.JoinFunc((ele, _) => ele.Print(), (_, __) => ", ".Print()).ln();
            array.JoinFunc(PrintI, (_, __) => ", ".Print()).ln();
            array.JoinFunc((ele, _) => ele.Print(), ", ").ln();
            array.JoinFunc(PrintI, ", ").lnln();

            // Use Adapter //
            // If function not provide overloading function for adapt MyAction/MyFunc Type parameter //
            // You need to use Action/Func Adapter //

            // 1, 2, 3, 4, 5
            (1, 5).JoinFunc(
                _a((int i) => i.Print()),
                _a(() => ", ".Print())
            ).ln();

            // 0, 1, 2
            3.JoinFunc(
                _a((int i) => i.Print()), 
                _a(() => ", ".Print())
            ).ln();

            // 12, 34, 56, 78, 910
            array.JoinFunc(
                _a((int i) => i.Print()),
                _a(() => ", ".Print())
            ).lnln();


            // Some Advanced Usage //
            StringBuilder result = new StringBuilder();
            (1, 5).JoinFunc(
                i => {
                    result.Append("(");
                    (1, i).JoinFunc(
                        i => result.Append(i),
                        _ => result.Append(" + ")
                    );
                    result.Append(")");
                },
                _ => result.Append(" * \n")
            );
            result.Printlnln();
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
        */

    }
}
