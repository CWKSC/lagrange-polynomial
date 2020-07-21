using MyLib_Csharp_Beta.CommonMethod;
using System;

using static MyLib_Csharp_Beta.ProgrammingPattern.ProgramStructure;

namespace MyLib_Csharp_Beta.CommonType
{
    public partial class MyFunc
    {


        public static double Foo(int n, MyFunc<double, double> func)
        {
            double sum = 0;
            for(int i = 0; i < n; i++)
            {
                sum += func.Invoke(1);
            }
            return sum;
        }

        // If no overload function is provided
        // Users need to use an adapter to convert lambda to func
        public static double Foo(int n, Func<double, double> func) => Foo(n, (MyFunc<double, double>)func);


        public static void Test()
        {
            ("0 + 1 + 2 = " + Foo(3, i => i)).Println();
            ("2 + 2 + 2 = " + Foo(3, _ => 2)).Println();
            ("7 + 7 + 7 = " + Foo(3, 7)).Printlnln();

            // Use Func Adapter //
            ("0 + 1 + 2 + 3 = " + Foo(4, _f((double i) => i)) ).Println();
            ("2 + 2 + 2 + 4 = " + Foo(4, _f<double>(() => 2)) ).Println();
            ("7 + 7 + 7 + 7 = " + Foo(4, 7)).Println();

            // You can see that Func<int, int, int>, Func<int, int>, Func<int> and int //
            // all can implicit convert to MyFunc<int, int, int> 
            // Generally, it means Func<T1, T2, R>, Func<T1, R>, Func<R> and R can convert to MyFunc<T1, T2, R>
            Func<int, int, int> funcTT = (x1, x2) => 1;
            Func<int, int> funcT = x => 1;
            Func<int> func = () => 1;
            int value = 1;
            MyFunc<int, int, int> myFunc;
            myFunc = funcTT;
            myFunc = funcT;
            myFunc = func;
            myFunc = value;
        }
        /* Output
        0 + 1 + 2 = 3
        2 + 2 + 2 = 6
        7 + 7 + 7 = 21

        0 + 1 + 2 + 3 = 4
        2 + 2 + 2 + 4 = 8
        7 + 7 + 7 + 7 = 28
        */


    }

}
