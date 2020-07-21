using MyLib_Csharp_Beta.CommonMethod;

namespace MyLib_Csharp_Beta.Math
{
    public static partial class SumOf_ProductOf
    {

        public static void Test()
        {
            //// SumOf ////

            /// double SumOf(this (int start, int end, int step) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null) ///

            "Sum of 50 to 200 step 7 -> 50 + 57 + 64 + 71 + ... (50 + 7 * n)".Println();
            (50, 200, 7).SumOf(i => i).Printlnln();
            // 2717

            "Sum of 2 to 100 step 2 (even number)".Println();
            (2, 100, 2).SumOf(i => i).Printlnln();
            // 2550

            "Sum of 1 to 100 step 1 with condition i % 2 == 0 (even number)".Println();
            (1, 100, 1).SumOf(i => i, i => i % 2 == 0).Printlnlnln();
            // 2550


            /// double SumOf(this (int start, int end) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null) ///

            "Sum of 1 to 100".Println();
            (1, 100).SumOf(i => i).Printlnln();
            // 5050

            "Sum of 1 to 100 with condition i % 2 == 0 (even number)".Println();
            (1, 100).SumOf(i => i, i => i % 2 == 0).Printlnlnln();
            // 2550



            //// ProductOf ////

            /// double ProductOf(this (int start, int end, int step) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null) ///

            "Product of 7 to 50 step 7 -> 7 * 14 * 21 * 28 ... (7 + 7*n)".Println();
            (7, 50, 7).ProductOf(i => i).Printlnln();
            // 4150656720

            "Product of 2 to 20 step 3 -> 2 * 5 * 8 * 11 * ... (2 + 3*n) (even number)".Println();
            (2, 20, 3).ProductOf(i => i).Printlnln();
            // 3715891200


            /// double ProductOf(this (int start, int end) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null) ///
            
            "Product of 1 to 10 -> 1 * 2 * 3 * 4 ... (n+1) (it is 10!)".Println(); ///
            (1, 10).ProductOf(i => i).Printlnln();
            // 3628800

            "Product of 1 to 10 with condition i % 2 == 0 -> 2 * 4 * 6 * 8 * 10 (even number)".Println();
            (1, 10).ProductOf(i => i, i => i % 2 == 0).Printlnlnln();
            // 3840

        }

    }
}
