using MyLib_Csharp_Beta.CommonType;
using MyLib_Csharp_Beta.ProgrammingPattern;
using System;

using static MyLib_Csharp_Beta.ProgrammingPattern.ProgramStructure;

namespace MyLib_Csharp_Beta.CommonMethod
{
    public static class MyPrint
    {


        //// ln ////

#pragma warning disable IDE1006 // 命名樣式
        public static MyVoid ln() => ln(1);
        public static MyVoid lnln() => ln(2);
        public static MyVoid lnlnln() => ln(3);
        public static Any ln<Any>(this Any _) { ln(); return _; }
        public static Any lnln<Any>(this Any _) { lnln(); return _; }
        public static Any lnlnln<Any>(this Any _) { lnlnln(); return _; }
        public static Any ln<Any>(this Any _, int times) { ln(times); return _; }
        public static MyVoid ln(int times) => new string('\n', times).Print().ReturnVoid();

#pragma warning restore IDE1006 // 命名樣式

        //// Print ////

        public static T Print<T>(this T value) { Console.Write(value); return value; }
        public static T Println<T>(this T value) => value.Print().ln(); 
        public static T Printlnln<T>(this T value) => value.Println().ln(); 
        public static T Printlnlnln<T>(this T value) => value.Printlnln().ln();


        //// lnPrint ////

#pragma warning disable IDE1006 // 命名樣式
        public static T lnPrint<T>(this T value) { ("\n" + value).Print(); return value; }
        public static T lnPrintln<T>(this T value) { ("\n" + value).Println();  return value; }
        public static T lnPrintlnln<T>(this T value) { ("\n" + value).Printlnln(); return value; }

#pragma warning restore IDE1006 // 命名樣式


        //// Print for T[] ////

        public static T[] Print<T>(this T[] array)
        {
            array.JoinPrint((ele, _) => ele.ToString(), ", ");
            return array;
        }
        public static T[] Println<T>(this T[] array) => array.Print().ln();
        public static T[] Printlnln<T>(this T[] array) => array.Println().ln();
        public static T[] Printlnlnln<T>(this T[] array) => array.Printlnln().ln();


    }
}
