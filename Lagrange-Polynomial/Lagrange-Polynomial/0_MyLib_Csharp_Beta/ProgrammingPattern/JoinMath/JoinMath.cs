using MyLib_Csharp_Beta.CommonType;
using System;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{

    public static partial class JoinMath
    {

        //// JoinSum ////


        /// <summary>
        /// <code> (4, 20, 3).JoinSum(i => i.ToString()).Println(); </code>
        /// Output:
        /// <code> 4+7+10+13+16+19 </code>
        /// </summary>
        public static string JoinSum(this (int start, int end, int step) args, MyFunc<int, string> work, string plus = "") =>
            args.JoinStr(work, "+" + plus);
        public static string JoinSum(this (int start, int end, int step) args, Func<int, string> work, string plus = "") =>
            args.JoinSum((MyFunc<int, string>)work, plus);

        /// <summary>
        /// <code> (1, 5).JoinSum(i => i.ToString()).Printlnln(); </code>
        /// Output:
        /// <code> 1+2+3+4+5 </code>
        /// </summary>
        public static string JoinSum(this (int start, int end) args, MyFunc<int, string> work, string plus = "") =>
            (args.start, args.end, 1).JoinSum(work, plus);
        public static string JoinSum(this (int start, int end) args, Func<int, string> work, string plus = "") =>
            args.JoinSum((MyFunc<int, string>)work, plus);


        /// <summary>
        /// <code> 4.JoinSum(i => i.ToString()).Printlnln(); </code>
        /// Output:
        /// <code> 0+1+2+3 </code>
        /// </summary>
        public static string JoinSum(this int times, MyFunc<int, string> work, string plus = "") =>
            (0, times - 1).JoinSum(work, plus);
        public static string JoinSum(this int times, Func<int, string> work, string plus = "") =>
            times.JoinSum((MyFunc<int, string>)work, plus);


        /// <summary>
        /// <code>
        /// int[] array = { 12, 34, 56, 78, 910 }; <br />
        /// array.JoinSum((ele, i) => (ele, i).ToString() ).Printlnln(); </code>
        /// Output:
        /// <code> (12, 0)+(34, 1)+(56, 2)+(78, 3)+(910, 4) </code>
        /// </summary>
        public static string JoinSum<T>(this T[] array, MyFunc<T, int, string> work, string plus = "") =>
            array.Length.JoinSum(
                (MyFunc<int, string>)(i => work.Invoke(array[i], i)), plus);
        public static string JoinSum<T>(this T[] array, Func<T, int, string> work, string plus = "") =>
            array.JoinSum((MyFunc<T, int, string>)work, plus);





        //// JoinProduct ////


        /// <summary>
        /// <code> (20, 50, 7).JoinProduct(i => i.ToString()).Println(); </code>
        /// Output:
        /// <code> 20*27*34*41*48 </code>
        /// </summary>
        public static string JoinProduct(this (int start, int end, int step) args, MyFunc<int, string> work, string plus = "") =>
            args.JoinStr(work, "*" + plus);
        public static string JoinProduct(this (int start, int end, int step) args, Func<int, string> work, string plus = "") =>
            args.JoinProduct((MyFunc<int, string>)work, plus);

        /// <summary>
        /// <code> (2, 7).JoinProduct(i => i.ToString()).Println(); </code>
        /// Output:
        /// <code> 2*3*4*5*6*7 </code>
        /// </summary>
        public static string JoinProduct(this (int start, int end) args, MyFunc<int, string> work, string plus = "") =>
            (args.start, args.end, 1).JoinProduct(work, plus);
        public static string JoinProduct(this (int start, int end) args, Func<int, string> work, string plus = "") =>
            args.JoinProduct((MyFunc<int, string>)work, plus);


        /// <summary>
        /// <code> 7.JoinProduct(i => i.ToString()).Printlnln(); </code>
        /// Output:
        /// <code> 0*1*2*3*4*5*6 </code>
        /// </summary>
        public static string JoinProduct(this int times, MyFunc<int, string> work, string plus = "") =>
            (0, times - 1).JoinProduct(work, plus);
        public static string JoinProduct(this int times, Func<int, string> work, string plus = "") =>
            times.JoinProduct((MyFunc<int, string>)work, plus);


        /// <summary>
        /// <code>
        /// int[] array = { 12, 34, 56, 78, 910 }; <br />
        /// array.JoinProduct((ele, i) => (ele, i).ToString() ).Printlnln(); </code>
        /// Output:
        /// <code> (12, 0)*(34, 1)*(56, 2)*(78, 3)*(910, 4) </code>
        /// </summary>
        public static string JoinProduct<T>(this T[] array, MyFunc<T, int, string> work, string plus = "") =>
            array.Length.JoinProduct(
                (MyFunc<int, string>)(i => work.Invoke(array[i], i)), plus);
        public static string JoinProduct<T>(this T[] array, Func<T, int, string> work, string plus = "") =>
         array.JoinProduct((MyFunc<T, int, string>)work, plus);




        //// Advance Usage ////
        /*

        // Use JoinSum and JoinProduct at the same time //

        (1, 5).JoinProduct(i => 
            "(" +  (1, i).JoinSum(i => i.ToString()) + ")" 
        ).Printlnln();

        Output:
        (1)*(1+2)*(1+2+3)*(1+2+3+4)*(1+2+3+4+5)


        // Another example with using array //

        int[] array = { 12, 34, 56, 78, 910 };

        array.JoinSum((_, __) => 
            array.JoinProduct((ele, _) => 
                ele.ToString() 
            )
        , "\n").Println();

        Output:
        12*34*56*78*910+
        12*34*56*78*910+
        12*34*56*78*910+
        12*34*56*78*910+
        12*34*56*78*910

        */




    }
}
