using MyLib_Csharp_Beta.CommonMethod;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    public static partial class JoinMath
    {

        public static void Test()
        {

            //// JoinSum ////

            // string JoinSum(this (int start, int end, int step) args, MyFunc<int, string> work, string plus = "") //
            // 4+7+10+13+16+19
            (4, 20, 3).JoinSum(i => i.ToString()).Println();

            // string JoinSum(this (int start, int end) args, MyFunc<int, string> work) //
            // 1+2+3+4+5
            (1, 5).JoinSum(i => i.ToString()).Println();

            // string JoinSum(this int times, MyFunc<int, string> work) //
            // 0+1+2+3
            4.JoinSum(i => i.ToString()).Printlnln();



            //// JoinProdect ////

            // string JoinProduct(this (int start, int end, int step) args, MyFunc<int, string> work, string plus = "") //
            // 20*27*34*41*48
            (20, 50, 7).JoinProduct(i => i.ToString()).Println();

            // string JoinProduct(this (int start, int end) args, MyFunc<int, string> work) //
            // 2*3*4*5*6*7
            (2, 7).JoinProduct(i => i.ToString()).Println();

            // string JoinProduct(this int times, MyFunc<int, string> work) //
            // 0*1*2*3*4*5*6
            7.JoinProduct(i => i.ToString()).Printlnln();

            
            
            // Use JoinSum and JoinProduct at the same time //
            // (1)*(1+2)*(1+2+3)*(1+2+3+4)*(1+2+3+4+5)
            (1, 5).JoinProduct(i => 
                "(" +  (1, i).JoinSum(i => i.ToString()) + ")" 
            ).Printlnln();



            //// Array in JoinSum and JoinProdect ////

            int[] array = { 12, 34, 56, 78, 910 };

            // string JoinSum<T>(this T[] array, MyFunc<T, int, string> work) //
            // (12, 0)+(34, 1)+(56, 2)+(78, 3)+(910, 4)
            array.JoinSum((ele, i) => (ele, i).ToString() ).Println();

            // string JoinProduct<T>(this T[] array, MyFunc<T, int, string> work) //
            // (12, 0)*(34, 1)*(56, 2)*(78, 3)*(910, 4)
            array.JoinProduct((ele, i) => (ele, i).ToString() ).Printlnln();

            // Use JoinSum and JoinProduct with array at the same time //
            /*
            12*34*56*78*910+
            12*34*56*78*910+
            12*34*56*78*910+
            12*34*56*78*910+
            12*34*56*78*910
            */
            array.JoinSum((_, __) => 
                array.JoinProduct((ele, _) => 
                    ele.ToString() 
                )
            , "\n").Println();



        }
        /* Output
        4+7+10+13+16+19
        1+2+3+4+5
        0+1+2+3

        20*27*34*41*48
        2*3*4*5*6*7
        0*1*2*3*4*5*6

        (1)*(1+2)*(1+2+3)*(1+2+3+4)*(1+2+3+4+5)

        (12, 0)+(34, 1)+(56, 2)+(78, 3)+(910, 4)
        (12, 0)*(34, 1)*(56, 2)*(78, 3)*(910, 4)

        12*34*56*78*910+
        12*34*56*78*910+
        12*34*56*78*910+
        12*34*56*78*910+
        12*34*56*78*910
        */

    }
}
