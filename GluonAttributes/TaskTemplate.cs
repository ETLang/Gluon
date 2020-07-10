using ABI.Gluon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gluon
{
    public enum GluonTaskStatus : int { Incomplete, Complete, Canceled, Failed }

    public delegate void TaskCompletionHandler(IntPtr task, GluonTaskStatus status);

    [Internal]
    public interface TaskBase
    {
        void SetCompletionCallback(TaskCompletionHandler cb);
        void GetException(out ExceptionType type, out string msg);
        void NotifyComplete();
        void NotifyCanceled();
        void NotifyException(ExceptionType type, string msg);
    }
}


//internal partial class T_1234
//{
//    public Task<int> Task { get; private set; }

//    // kruft
//    void SetCompletionCallback(Action<int, GluonTaskStatus> cb) { }
//    void GetException(out ExceptionType type, out string msg) { type = ExceptionType.Generic; msg = null; }
//    void NotifyComplete(int result) { }
//    void NotifyCanceled() { }
//    void NotifyException(ExceptionType type, string msg) { }

//    public T_1234(Task<int> t) : this(Make()) { Task = t; Init(); }

//    void Init()
//    {
//        if (Task == null)
//        {
//            _tcs = new TaskCompletionSource<int>();
//            Task = _tcs.Task;
//            SetCompletionCallback(OnComplete);
//        }
//        else
//        {
//            Task.ContinueWith(task =>
//            {
//                if (Task.IsCompleted) NotifyComplete(task.Result);
//                else if (Task.IsCanceled) NotifyCanceled();
//                else NotifyException(Translate.Exception(Task.Exception), Task.Exception.ToString());
//            });
//        }

//        _Table[Task] = this;
//    }

//    void OnComplete(int result, GluonTaskStatus status)
//    {
//        if (status == GluonTaskStatus.Complete) _tcs.SetResult(result);
//        else if (status == GluonTaskStatus.Canceled) _tcs.SetCanceled();
//        else if (status == GluonTaskStatus.Failed)
//        {
//            ExceptionType exType;
//            string exMsg;
//            GetException(out exType, out exMsg);
//            _tcs.SetException(Translate.Exception(exType, exMsg));
//        }
//    }

//    private TaskCompletionSource<int> _tcs;

//    public static T_1234 Unwrap(Task<int> task)
//    {
//        T_1234 ret;
//        bool got;

//        lock (_Table)
//        {
//            got = _Table.TryGetValue(task, out ret);
//        }

//        if (got) return ret;
//        else return new T_1234(task);
//    }

//    private static Dictionary<Task<int>, T_1234> _Table = new Dictionary<Task<int>, T_1234>();
//}
