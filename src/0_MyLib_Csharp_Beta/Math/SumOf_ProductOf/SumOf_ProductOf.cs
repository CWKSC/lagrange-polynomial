using MyLib_Csharp_Beta.CommonType;
using MyLib_Csharp_Beta.ProgrammingPattern;
using System;

namespace MyLib_Csharp_Beta.Math
{

    /// <summary>
    /// It Class contain 2 function : SumOf and ProductOf <br /><br />
    /// // SumOf //
    /// <code> double SumOf(this (int start, int end, int step) args, MyFunc&lt;int, double&gt; f, MyFunc&lt;int, bool&gt; condition = null) </code>
    /// <code> double SumOf(this (int start, int end) args, MyFunc&lt;int, double&gt; f, MyFunc&lt;int, bool&gt; condition = null) </code>
    /// // ProductOf //
    /// <code> double ProductOf(this (int start, int end, int step) args, MyFunc&lt;int, double&gt; f, MyFunc&lt;int, bool&gt; condition = null) </code>
    /// <code> double ProductOf(this (int start, int end) args, MyFunc&lt;int, double&gt; f, MyFunc&lt;int, bool&gt; condition = null) </code>
    /// </summary>
    public static partial class SumOf_ProductOf
    {

        //// SumOf ////


        /// <summary>
        /// <code> 
        /// Sum of 2 to 100 step 2 (even number) <br />
        /// (2, 100, 2).SumOf(i => i).Printlnln(); // 2550 <br /><br />
        /// Sum of 1 to 100 step 1 with condition i % 2 == 0 (even number) <br />
        /// (1, 100, 1).SumOf(i => i, i => i % 2 == 0).Printlnln(); // 2550 <br /><br />
        /// Sum of 50 to 200 step 7 -> 50 + 57 + 64 + 71 + ... (50 + 7 * n) <br />
        /// (50, 200, 7).SumOf(i => i).Printlnln(); // 2717
        ///  </code>
        /// </summary>
        public static double SumOf(this (int start, int end, int step) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null)
        {
            double sum = 0;
            args.Loop(i => sum += f.Invoke(i), condition);
            return sum;
        }
        public static double SumOf(this (int start, int end, int step) args, Func<int, double> f, MyFunc<int, bool> condition = null) =>
            args.SumOf((MyFunc<int, double>)f, condition);
        public static double SumOf(this (int start, int end, int step) args, MyFunc<int, double> f, Func<int, bool> condition) =>
            args.SumOf(f, (MyFunc<int, bool>)condition);
        public static double SumOf(this (int start, int end, int step) args, Func<int, double> f, Func<int, bool> condition) =>
            args.SumOf((MyFunc<int, double>)f, (MyFunc<int, bool>)condition);


        /// <summary>
        /// <code> 
        /// Sum of 1 to 100 <br />
        /// (1, 100).SumOf(i => i).Printlnln(); // 5050 <br /><br />
        /// Sum of 1 to 100 with condition i % 2 == 0 (even number) <br/>
        /// (1, 100).SumOf(i => i, i => i % 2 == 0).Printlnln(); // 2550
        /// </code>
        /// </summary>
        public static double SumOf(this (int start, int end) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null) =>
            (args.start, args.end, 1).SumOf(f, condition);
        public static double SumOf(this (int start, int end) args, Func<int, double> f, MyFunc<int, bool> condition = null) =>
           args.SumOf((MyFunc<int, double>)f, condition);
        public static double SumOf(this (int start, int end) args, MyFunc<int, double> f, Func<int, bool> condition) =>
            args.SumOf(f, (MyFunc<int, bool>)condition);
        public static double SumOf(this (int start, int end) args, Func<int, double> f, Func<int, bool> condition) =>
            args.SumOf((MyFunc<int, double>)f, (MyFunc<int, bool>)condition);





        //// ProductOf ////


        /// <summary>
        /// <code>
        /// Product of 7 to 50 step 7 -> 7 * 14 * 21 * 28 ... (7 + 7*n) <br />
        /// (7, 50, 7).ProductOf(i => i).Printlnln(); // 4150656720 <br /><br />
        /// Product of 2 to 20 step 3 -> 2 * 5 * 8 * 11 * ... (2 + 3*n) (even number) <br />
        /// (2, 20, 3).ProductOf(i => i).Printlnln(); // 3715891200
        /// </code>
        /// </summary>
        public static double ProductOf(this (int start, int end, int step) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null)
        {
            double product = 1;
            args.Loop(i => product *= f.Invoke(i), condition);
            return product;
        }
        public static double ProductOf(this (int start, int end, int step) args, Func<int, double> f, MyFunc<int, bool> condition = null) =>
            args.ProductOf((MyFunc<int, double>)f, condition);
        public static double ProductOf(this (int start, int end, int step) args, MyFunc<int, double> f, Func<int, bool> condition) =>
            args.ProductOf(f, (MyFunc<int, bool>)condition);
        public static double ProductOf(this (int start, int end, int step) args, Func<int, double> f, Func<int, bool> condition) =>
            args.ProductOf((MyFunc<int, double>)f, (MyFunc<int, bool>)condition);



        /// <summary>
        /// <code>
        /// Product of 1 to 10 -> 1 * 2 * 3 * 4 ... (n+1) (it is 10!) <br />
        /// (1, 10).ProductOf(i => i).Printlnln(); // 3628800 <br /><br />
        /// Product of 1 to 10 with condition i % 2 == 0 -> 2 * 4 * 6 * 8 * 10 (even number) <br />
        /// (1, 10).ProductOf(i => i, i => i % 2 == 0).Printlnlnln(); // 3840
        /// </code>
        /// </summary>
        public static double ProductOf(this (int start, int end) args, MyFunc<int, double> f, MyFunc<int, bool> condition = null) =>
            (args.start, args.end, 1).ProductOf(f, condition);
        public static double ProductOf(this (int start, int end) args, Func<int, double> f, MyFunc<int, bool> condition = null) =>
            args.ProductOf((MyFunc<int, double>)f, condition);
        public static double ProductOf(this (int start, int end) args, MyFunc<int, double> f, Func<int, bool> condition) =>
            args.ProductOf(f, (MyFunc<int, bool>)condition);
        public static double ProductOf(this (int start, int end) args, Func<int, double> f, Func<int, bool> condition) =>
            args.ProductOf((MyFunc<int, double>)f, (MyFunc<int, bool>)condition);



    }
}
