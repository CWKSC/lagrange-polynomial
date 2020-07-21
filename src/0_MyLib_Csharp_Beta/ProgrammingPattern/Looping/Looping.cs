using MyLib_Csharp_Beta.CommonType;
using System;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    public static partial class Looping
    {

        //// ForEach ////

        /// <summary> Array.ForEach(array, action); </summary>
        public static T[] ForEach<T>(this T[] array, MyAction<T> action) {
            Array.ForEach(array, action.action);
            return array;
        }
        public static T[] ForEach<T>(this T[] array, Action<T> action) => array.ForEach((MyAction<T>)action);

        /// <summary> (array.Length).Loop(i => action(array[i], i)); </summary>
        public static T[] ForEach<T>(this T[] array, MyAction<T, int> action) {
            array.Length.Loop(i => action.Invoke(array[i], i), null);
            return array;
        }
        public static T[] ForEach<T>(this T[] array, Action<T, int> action) =>
            array.ForEach((MyAction<T, int>)action);




        //// Looping ////


        /// <summary>
        /// (start, end, step).Loop without condition version, <br />
        /// during effective consideration
        /// <code>
        /// int i = args.start; i &lt;= args.end; i += args.step
        /// </code>
        /// </summary>
        public static (int start, int end, int step) Loop(this (int start, int end, int step) args, MyAction<int> action) =>
            args.For(action);
        public static (int start, int end, int step) Loop(this (int start, int end, int step) args, Action<int> action) =>
            args.Loop((MyAction<int>)action);



        /// <summary>
        /// (start, end, step).Loop with condition version
        /// <code>
        /// int i = args.start; i &lt;= args.end; i += args.step <br />
        /// i => { if (condition) action(i); </code>
        /// </summary>
        public static (int start, int end, int step) Loop(this (int start, int end, int step) args, MyAction<int> action, MyFunc<int, bool> condition = null) => 
            args.Loop(i => { 
                if (condition == null || condition.Invoke(i))
                    action.Invoke(i);
            });
        public static (int start, int end, int step) Loop(this (int start, int end, int step) args, Action<int> action, MyFunc<int, bool> condition = null) =>
            args.Loop((MyAction<int>)action, condition);
        public static (int start, int end, int step) Loop(this (int start, int end, int step) args, MyAction<int> action, Func<int, bool> condition) =>
            args.Loop(action, (MyFunc<int, bool>)condition);
        public static (int start, int end, int step) Loop(this (int start, int end, int step) args, Action<int> action, Func<int, bool> condition) =>
            args.Loop((MyAction<int>)action, (MyFunc<int, bool>)condition);



        /// <summary> [start, end] </summary>
        public static (int start, int end) Loop(this (int start, int end) args, MyAction<int> action, MyFunc<int, bool> condition = null)
        {
            (args.start, args.end, 1).Loop(action, condition);
            return args;
        }
        public static (int start, int end) Loop(this (int start, int end) args, Action<int> action, MyFunc<int, bool> condition = null) =>
            args.Loop((MyAction<int>)action, condition);
        public static (int start, int end) Loop(this (int start, int end) args, MyAction<int> action, Func<int, bool> condition) =>
            args.Loop(action, (MyFunc<int, bool>)condition);
        public static (int start, int end) Loop(this (int start, int end) args, Action<int> action, Func<int, bool> condition) =>
            args.Loop((MyAction<int>)action, (MyFunc<int, bool>)condition);




        /// <summary> Loop n times </summary>
        public static int Loop(this int times, MyAction<int> action, MyFunc<int, bool> condition = null)
        {
            (0, times - 1).Loop(action, condition);
            return times;
        }
        public static int Loop(this int times, Action<int> action, MyFunc<int, bool> condition = null) =>
            times.Loop((MyAction<int>)action, condition);
        public static int Loop(this int times, MyAction<int> action, Func<int, bool> condition) =>
            times.Loop(action, (MyFunc<int, bool>)condition);
        public static int Loop(this int times, Action<int> action, Func<int, bool> condition) =>
            times.Loop((MyAction<int>)action, (MyFunc<int, bool>)condition);


    }
}
