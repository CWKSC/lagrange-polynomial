using MyLib_Csharp_Beta.CommonMethod;
using MyLib_Csharp_Beta.CommonType;
using System;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    /// <summary>
    /// JoinPrint will be implemented based on JoinStr <br />
    /// Compare to JoinStr, JoinPrint just a sugar syntax to JoinStr + Print<br />
    /// There are three main functions here:
    /// <code> string JoinPrint(this (int start, int end) args,MyFunc&lt;int, string&gt; work, MyFunc&lt;int, string&gt; join) </code>
    /// <code> string JoinPrint(this int times, MyFunc&lt;int, string&gt; work, MyFunc&lt;int, string&gt; join) </code>
    /// <code> string JoinPrint&lt;T&gt;(this T[] array, MyFunc&lt;T, int, string&gt; work, MyFunc&lt;T, int, string&gt; join) </code>
    /// </summary>
    public static partial class JoinPrintString
    {


        /// <summary>
        /// <code> (4, 20, 3).JoinPrint(i => i.ToString(), _ => ", ").ln(); </code>
        /// Output:
        /// <code> 4, 7, 10, 13, 16, 19 </code>
        /// </summary>
        public static string JoinPrint(this (int start, int end, int step) args, MyFunc<int, string> work, MyFunc<int, string> join) =>
            args.JoinStr(work, join).Print();
        public static string JoinPrint(this (int start, int end, int step) args, Func<int, string> work, MyFunc<int, string> join) =>
            args.JoinPrint((MyFunc<int, string>)work, join);
        public static string JoinPrint(this (int start, int end, int step) args, MyFunc<int, string> work, Func<int, string> join) =>
            args.JoinPrint(work, (MyFunc<int, string>)join);
        public static string JoinPrint(this (int start, int end, int step) args, Func<int, string> work, Func<int, string> join) =>
            args.JoinPrint((MyFunc<int, string>)work, (MyFunc<int, string>)join);




        /// <summary>
        /// <code> (1, 5).JoinPrint(i => i.ToString(), _ => ", ").ln(); </code>
        /// Output:
        /// <code> 1, 2, 3, 4, 5 </code>
        /// </summary>
        public static string JoinPrint(this (int start, int end) args, MyFunc<int, string> work, MyFunc<int, string> join) => 
            (args.start, args.end, 1).JoinPrint(work, join);
        public static string JoinPrint(this (int start, int end) args, Func<int, string> work, MyFunc<int, string> join) =>
            args.JoinPrint((MyFunc<int, string>)work, join);
        public static string JoinPrint(this (int start, int end) args, MyFunc<int, string> work, Func<int, string> join) =>
            args.JoinPrint(work, (MyFunc<int, string>)join);
        public static string JoinPrint(this (int start, int end) args, Func<int, string> work, Func<int, string> join) =>
            args.JoinPrint((MyFunc<int, string>)work, (MyFunc<int, string>)join);


        /// <summary>
        /// <code> 3.JoinPrint(i => i.ToString(), _ => ", ").ln(); </code>
        /// Output:
        /// <code> 0, 1, 2 </code>
        /// </summary>
        public static string JoinPrint(this int times, MyFunc<int, string> work, MyFunc<int, string> join) =>
            (0, times - 1).JoinPrint(work, join);
        public static string JoinPrint(this int times, Func<int, string> work, MyFunc<int, string> join) =>
            times.JoinPrint((MyFunc<int, string>)work, join);
        public static string JoinPrint(this int times, MyFunc<int, string> work, Func<int, string> join) =>
            times.JoinPrint(work, (MyFunc<int, string>)join);
        public static string JoinPrint(this int times, Func<int, string> work, Func<int, string> join) =>
            times.JoinPrint((MyFunc<int, string>)work, (MyFunc<int, string>)join);



        /// <summary>
        /// <code>
        /// int[] array = { 12, 34, 56, 78, 910 }; <br />
        /// array.JoinPrint((ele, _) => ele.ToString(), (_, __) => ", ").ln(); </code>
        /// Output:
        /// <code> 12, 34, 56, 78, 910 </code>
        /// </summary>
        public static string JoinPrint<T>(this T[] array, MyFunc<T, int, string> work, MyFunc<T, int, string> join) =>
            array.Length.JoinPrint(
                (MyFunc<int, string>)(i => work.Invoke(array[i], i)),
                (MyFunc<int, string>)(i => join.Invoke(array[i], i)));
        public static string JoinPrint<T>(this T[] array, Func<T, int, string> work, MyFunc<T, int, string> join) =>
            array.JoinPrint((MyFunc<T, int, string>)work, join);
        public static string JoinPrint<T>(this T[] array, MyFunc<T, int, string> work, Func<T, int, string> join) =>
            array.JoinPrint(work, (MyFunc<T, int, string>)join);
        public static string JoinPrint<T>(this T[] array, Func<T, int, string> work, Func<T, int, string> join) =>
            array.JoinPrint((MyFunc<T, int, string>)work, (MyFunc<T, int, string>)join);



    }
}
