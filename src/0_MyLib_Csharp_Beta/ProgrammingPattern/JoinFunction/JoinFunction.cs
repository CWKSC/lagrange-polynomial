using MyLib_Csharp_Beta.CommonType;
using System;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{

    /// <summary>
    /// There are three main functions here:
    /// <code> (int start, int end) JoinFunc(this (int start, int end) args, MyAction&lt;int&gt; work, MyAction&lt;int&gt; join) </code>
    /// <code> int JoinFunc(this int times, MyAction&lt;int&gt; work, MyAction&lt;int&gt; join) </code>
    /// <code> T[] JoinFunc&lt;T&gt;(this T[] array, MyAction&lt;T, int&gt; work, MyAction&lt;T, int&gt; join) </code>
    /// </summary>
    public static partial class JoinFunction
    {

        //// [Some Note for JoinFunc idea] ////
        // 
        // define f(x) = print x
        // define g(x) = print ", "
        //
        // // Pattern A //
        // /*g(0)*/ f(0) g(1) f(1) g(2) f(2) ... g(i) f(i)
        //
        // // Pattern B //
        // f(0) g(0) f(1) g(1) f(2) g(2) ... f(i) /*g(i)*/
        //
        // x = {1, 2, 3}
        // 
        // // Pattern A //
        // , 1, 2, 3
        // 
        // (0, array.length - 1).Loop(i => {
        //     ", ".Print();
        //     array[i].Print();
        // })
        // 
        // // Pattern B //
        // 1, 2, 3, 
        // 
        // (0, array.length - 1).Loop(i => {
        //     array[i].Print();
        //     ", ".Print();
        // })
        // 



        /// <summary>
        /// <code> (4, 20, 3).JoinFunc(i => i.Print(), _ => ", ".Print()).ln(); </code>
        /// Output:
        /// <code> 4, 7, 10, 13, 16, 19 </code>
        /// </summary>
        public static (int start, int end, int step) JoinFunc(this (int start, int end, int step) args, MyAction<int> work, MyAction<int> join)
        {
            work.Invoke(args.start);
            (args.start + args.step, args.end, args.step).Loop(i =>
            {
                join.Invoke(i);
                work.Invoke(i);
            });
            return args;
        }
        public static (int start, int end, int step) JoinFunc(this (int start, int end, int step) args, Action<int> work, MyAction<int> join) =>
            args.JoinFunc((MyAction<int>)work, join);
        public static (int start, int end, int step) JoinFunc(this (int start, int end, int step) args, MyAction<int> work, Action<int> join) =>
            args.JoinFunc(work, (MyAction<int>)join);
        public static (int start, int end, int step) JoinFunc(this (int start, int end, int step) args, Action<int> work, Action<int> join) =>
            args.JoinFunc((MyAction<int>)work, (MyAction<int>)join);




        /// <summary>
        /// JoinFunc from start to end, range is [start, end]
        /// <code>(1, 5).JoinFunc(i => i.Print(), _ => ", ".Print()).ln();</code>
        /// Output:
        /// <code>1, 2, 3, 4, 5</code>
        /// </summary>
        public static (int start, int end) JoinFunc(this (int start, int end) args, MyAction<int> work, MyAction<int> join)
        {
            work.Invoke(args.start);
            (args.start + 1, args.end).Loop(i =>
            {
                join.Invoke(i);
                work.Invoke(i);
            });

            // [Another Version]
            // 
            //(args.start, args.end - 1).Loop(i =>
            //{
            //    work.Invoke(i);
            //    joinAction.Invoke(i);
            //});
            //work.Invoke(args.end);

            return args;
        }
        public static (int start, int end) JoinFunc(this (int start, int end) args, Action<int> work, MyAction<int> join) =>
            args.JoinFunc((MyAction<int>)work, join);
        public static (int start, int end) JoinFunc(this (int start, int end) args, MyAction<int> work, Action<int> join) =>
            args.JoinFunc(work, (MyAction<int>)join);
        public static (int start, int end) JoinFunc(this (int start, int end) args, Action<int> work, Action<int> join) =>
            args.JoinFunc((MyAction<int>)work, (MyAction<int>)join);




        /// <summary>
        /// JoinFunc for n times, range is [0, times - 1]
        /// <code> 3.JoinFunc(i => i.Print(), _ => ", ".Print()).ln(); </code>
        /// Output:
        /// <code> 0, 1, 2 </code>
        /// </summary>
        public static int JoinFunc(this int times, MyAction<int> work, MyAction<int> join)
        {
            (0, times - 1).JoinFunc(work, join);
            return times;
        }
        public static int JoinFunc(this int times, Action<int> work, MyAction<int> join) =>
            times.JoinFunc((MyAction<int>)work, join);
        public static int JoinFunc(this int times, MyAction<int> work, Action<int> join) =>
            times.JoinFunc(work, (MyAction<int>)join);
        public static int JoinFunc(this int times, Action<int> work, Action<int> join) =>
            times.JoinFunc((MyAction<int>)work, (MyAction<int>)join);


        /// <summary> 
        /// JoinFunc for array
        /// <code>
        /// int[] array = { 12, 34, 56, 78, 910 }; <br />
        /// array.JoinFunc((ele, _) => ele.Print(), (_, __) => ", ".Print()).ln(); </code>
        /// Output:
        /// <code> 12, 34, 56, 78, 910 </code>
        /// </summary>
        public static T[] JoinFunc<T>(this T[] array, MyAction<T, int> work, MyAction<T, int> join)
        {
            array.Length.JoinFunc(
                (MyAction<int>)(i => work.Invoke(array[i], i) ),
                (MyAction<int>)(i => join.Invoke(array[i], i)) );
            return array;
        }
        public static T[] JoinFunc<T>(this T[] array, Action<T, int> work, MyAction<T, int> join) =>
            array.JoinFunc((MyAction<T, int>)work, join);
        public static T[] JoinFunc<T>(this T[] array, MyAction<T, int> work, Action<T, int> join) =>
            array.JoinFunc(work, (MyAction<T, int>)join);
        public static T[] JoinFunc<T>(this T[] array, Action<T, int> work, Action<T, int> join) =>
            array.JoinFunc((MyAction<T, int>)work, (MyAction<T, int>)join);





    }
}
