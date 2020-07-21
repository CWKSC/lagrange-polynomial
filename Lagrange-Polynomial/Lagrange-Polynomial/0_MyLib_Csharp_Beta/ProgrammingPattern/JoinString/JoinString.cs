using MyLib_Csharp_Beta.CommonType;
using System;
using System.Text;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{

    /// <summary>
    /// JoinString will be implemented based on JoinFunc
    /// There are three main functions here:
    /// <code> string JoinStr(this (int start, int end) args, MyFunc&lt;int, string&gt; work, MyFunc&lt;int, string&gt; join) </code>
    /// <code> string JoinStr(this int times, MyFunc&lt;int, string&gt; work, MyFunc&lt;int, string&gt; join) </code>
    /// <code> string JoinStr&lt;T&gt;(this T[] array, MyFunc&lt;T, int, string&gt; work, MyFunc&lt;T, int, string&gt; join) </code>
    /// </summary>
    public static partial class JoinString
    {


        /// <summary>
        /// 
        /// </summary>
        public static string JoinStr(this (int start, int end, int step) args, MyFunc<int, string> work, MyFunc<int, string> join)
        {
            StringBuilder result = new StringBuilder();
            args.JoinFunc(
                i => result.Append(work.Invoke(i)),
                i => result.Append(join.Invoke(i)));
            return result.ToString();
        }
        public static string JoinStr(this (int start, int end, int step) args, Func<int, string> work, MyFunc<int, string> join) =>
            args.JoinStr((MyFunc<int, string>)work, join);
        public static string JoinStr(this (int start, int end, int step) args, MyFunc<int, string> work, Func<int, string> join) =>
            args.JoinStr(work, (MyFunc<int, string>)join);
        public static string JoinStr(this (int start, int end, int step) args, Func<int, string> work, Func<int, string> join) =>
            args.JoinStr((MyFunc<int, string>)work, (MyFunc<int, string>)join);



        /// <summary>
        /// JoinStr from start to end, range is [start, end]
        /// <code> (1, 5).JoinStr(i => i.ToString(), _ => ", ").Println(); </code>
        /// Output:
        /// <code>1, 2, 3, 4, 5</code>
        /// </summary>
        public static string JoinStr(this (int start, int end) args, MyFunc<int, string> work, MyFunc<int, string> join) => 
            (args.start, args.end, 1).JoinStr(work, join);
        public static string JoinStr(this (int start, int end) args, Func<int, string> work, MyFunc<int, string> join) => 
            args.JoinStr((MyFunc<int, string>)work, join);
        public static string JoinStr(this (int start, int end) args, MyFunc<int, string> work, Func<int, string> join) =>
            args.JoinStr(work, (MyFunc<int, string>)join);
        public static string JoinStr(this (int start, int end) args, Func<int, string> work, Func<int, string> join) =>
            args.JoinStr((MyFunc<int, string>)work, (MyFunc<int, string>)join);



        /// <summary>
        /// JoinStr for n times, range is [0, times - 1]
        /// <code> 3.JoinStr(i => i.ToString(), _ => ", ").Println(); </code>
        /// Output:
        /// <code>0, 1, 2</code>
        /// </summary>
        public static string JoinStr(this int times, MyFunc<int, string> work, MyFunc<int, string> join) => 
            (0, times - 1).JoinStr(work, join);
        public static string JoinStr(this int times, Func<int, string> work, MyFunc<int, string> join) =>
            times.JoinStr((MyFunc<int, string>)work, join);
        public static string JoinStr(this int times, MyFunc<int, string> work, Func<int, string> join) =>
            times.JoinStr(work, (MyFunc<int, string>)join);
        public static string JoinStr(this int times, Func<int, string> work, Func<int, string> join) =>
            times.JoinStr((MyFunc<int, string>)work, (MyFunc<int, string>)join);



        /// <summary>
        /// JoinStr for array
        /// <code> int[] array = { 12, 34, 56, 78, 910 }; <br />
        /// array.JoinStr((ele, _) => ele.ToString(), (_, __) => ", ").Println(); </code>
        /// Output:
        /// <code> 12, 34, 56, 78, 910 </code>
        /// </summary>
        public static string JoinStr<T>(this T[] array, MyFunc<T, int, string> work, MyFunc<T, int, string> join) => 
            array.Length.JoinStr(
                (MyFunc<int, string>)(i => work.Invoke(array[i], i)),
                (MyFunc<int, string>)(i => join.Invoke(array[i], i)));
        public static string JoinStr<T>(this T[] array, Func<T, int, string> work, MyFunc<T, int, string> join) =>
            array.JoinStr((MyFunc<T, int, string>)work, join);
        public static string JoinStr<T>(this T[] array, MyFunc<T, int, string> work, Func<T, int, string> join) =>
            array.JoinStr(work, (MyFunc<T, int, string>)join);
        public static string JoinStr<T>(this T[] array, Func<T, int, string> work, Func<T, int, string> join) =>
            array.JoinStr((MyFunc<T, int, string>)work, (MyFunc<T, int, string>)join);



    }

}
