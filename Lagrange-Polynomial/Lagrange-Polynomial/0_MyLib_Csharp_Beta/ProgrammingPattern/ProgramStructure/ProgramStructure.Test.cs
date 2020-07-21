using MyLib_Csharp_Beta.CommonMethod;
using MyLib_Csharp_Beta.CommonType;
using System;

namespace MyLib_Csharp_Beta.ProgrammingPattern
{
    public static partial class ProgramStructure
    {

        public static MyVoid Test() =>
            _(out bool condition).
            _(out Action isIfElseReach, () =>
                condition.If("If is reach\n").Else("Else is reach\n") ).
            _(out Action printCondition, () => 
                ("condition variable : " + condition).Println() ).
            Call(printCondition, isIfElseReach).
            _(condition = true).
            Call(printCondition, isIfElseReach).
            ReturnVoid();

        /* Output
        condition variable : False
        Else is reach
        condition variable : True
        If is reach
        */

    }
}
