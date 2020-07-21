using MyLib_Csharp_Beta.CommonMethod;
using MyLib_Csharp_Beta.ProgrammingPattern;
using System;
using static MyLib_Csharp_Beta.ProgrammingPattern.ProgramStructure;
using static MyLib_Csharp_Beta.CommonMethod.MyPrint;

namespace MyLib_Csharp_Beta.CommonType
{
    public partial class MyAction
    {

        private static MyVoid Foo(int n, MyAction<int> myAction)
        {
            (0, n - 1).Loop(i => myAction.Invoke(i));
            return MyVoid.instance;
        }

        // If no overload function is provided
        // Users need to use an adapter to convert lambda to action
        private static MyVoid Foo(int n, Action<int> action) => 
            Foo(n, (MyAction<int>)action);


        public static void Test()
        {
            Foo(3, _ => "0".Print()).ln();  // 000
            Foo(3, i => i.Print()).ln();    // 012
            Foo(3, "2").lnln();             // 222

            // Use Action Adapter //
            Foo(3, _a(() => "3".Print())).ln();     // 333
            Foo(3, _a((int i) => i.Print())).ln();  // 012
            Foo(3, "5").ln();                       // 555

            // You can see that Action<int, int>, Action<int>, Action and string //
            // all can implicit convert to MyAction<int, int> 
            // Generally, it means Action<T1, T2>, Action<T1>, Action and string can convert to MyAction<T1, T2>
            // Note that string is special for convert to MyAction type
            Action<int, int> actionTT = (x1, x2) => { };
            Action<int> actionT = x => { };
            Action action = () => { };
            string value = "";
            MyAction<int, int> myAction;
            myAction = actionTT;
            myAction = actionT;
            myAction = action;
            myAction = value;
        }
        /* Output
        000
        012
        222

        333
        012
        555
        */


    }
}
