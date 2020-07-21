using MyLib_Csharp_Beta.CommonMethod;
using System;


namespace MyLib_Csharp_Beta.CommonType
{

    public partial class MyAction
    {
        public Action action;

        public MyAction(Action action) => this.action = action;
        public MyAction(string value) : this(() => value.Print()) { }

        public void Invoke() => action();

        public static implicit operator MyAction(Action action) => new MyAction(action);
        public static implicit operator MyAction(string value) => new MyAction(value);
    }

    public partial class MyAction<T>
    {
        public Action<T> action;

        public MyAction(Action<T> actionT) => action = actionT;
        public MyAction(Action action) : this(_ => action()) { }
        public MyAction(string value) : this(() => value.Print()) { }

        public void Invoke(T input) => action(input);

        public static implicit operator MyAction<T>(Action<T> actionT) => new MyAction<T>(actionT);
        public static implicit operator MyAction<T>(Action action) => new MyAction<T>(action);
        public static implicit operator MyAction<T>(string value) => new MyAction<T>(value);
    }


    public partial class MyAction<T1, T2>
    {
        public Action<T1, T2> action;

        public MyAction(Action<T1, T2> actionTT) => action = actionTT;
        public MyAction(Action<T1> actionT) : this((t1, _) => actionT(t1)) { }
        public MyAction(Action action) : this(_ => action()) { }
        public MyAction(string value) : this(() => value.Print()) { }

        public void Invoke(T1 p1, T2 p2) => action(p1, p2);

        public static implicit operator MyAction<T1, T2>(Action<T1, T2> actionTT) => new MyAction<T1, T2>(actionTT);
        public static implicit operator MyAction<T1, T2>(Action<T1> actionT) => new MyAction<T1, T2>(actionT);
        public static implicit operator MyAction<T1, T2>(Action action) => new MyAction<T1, T2>(action);
        public static implicit operator MyAction<T1, T2>(string value) => new MyAction<T1, T2>(value);
    }


}
