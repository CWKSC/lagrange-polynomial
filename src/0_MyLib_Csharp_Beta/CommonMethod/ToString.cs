using MyLib_Csharp_Beta.ProgrammingPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib_Csharp_Beta.CommonMethod
{
    public static partial class ToString
    {

        public static string ToStr<T>(this T[] array) => 
            array.JoinStr((ele, _) => ele.ToString(), ", ");



    }
}
