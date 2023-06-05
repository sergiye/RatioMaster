using System;
using System.Threading;

namespace RatioMaster.BytesRoads {

  public class AsyncResultBase : IAsyncResult {
    private ManualResetEvent _wait;
    private bool _isHandled;
    private int _startThreadId;

    internal AsyncResultBase(AsyncCallback cb, object callerState) {
      CallBack = cb;
      AsyncState = callerState;
      _startThreadId = Thread.CurrentThread.GetHashCode();
    }

    internal void UpdateContext() {
      if (Thread.CurrentThread.GetHashCode() != _startThreadId)
        CompletedSynchronously = false;
    }


    internal void SetCompleted() {
      lock (this) // sync with 'AsyncWaitHandle' property
      {
        UpdateContext();
        IsCompleted = true;
        if (null != _wait)
          _wait.Set();
      }

      DumpActivityException();

      try {
        if (null != CallBack)
          CallBack(this);
      }
      catch (Exception e) {
        NsTrace.WriteLineError("Exception in CB: " + e);
        throw;
      }
    }

    private void CloseWaitHandle() {
      lock (this) {
        if (null == _wait) return;
        _wait.Close();
        _wait = null;
      }
    }

    private void DumpActivityException() {
      var e = Exception;
      if (null == e)
        return;

      var tid = Thread.CurrentThread.GetHashCode();
      var msg = string.Format("{0} ---------- Start Exception Info -----------------------------\n", tid);
      msg += string.Format("{0} Activity: {1}\n", tid, ActivityName);
      msg += string.Format("{0} Stack: {1}\n", tid, Environment.StackTrace);
      msg += string.Format("{0} Exception: {1}\n", tid, e);
      msg += string.Format("{0} ---------- End   Exception Info -----------------------------", tid);

      NsTrace.WriteLineError(msg);
    }


    #region Attributes

    internal virtual string ActivityName => GetType().FullName;

    internal AsyncCallback CallBack { get; private set; }

    internal Exception Exception { get; set; }

    internal virtual bool IsHandled {
      get => _isHandled;

      set {
        if (value) {
          CloseWaitHandle();
          AsyncState = null;
          CallBack = null;
        }
        else {
          NsTrace.WriteLineError("IsHandled assigned 'false'");
        }

        _isHandled = value;
      }
    }

    #endregion

    #region IAsyncResult Members

    public object AsyncState { get; private set; }

    public bool CompletedSynchronously { get; private set; } = true;

    public WaitHandle AsyncWaitHandle {
      get {
        lock (this) // sync with 'SetCompleted' method
        {
          if (null == _wait)
            _wait = new ManualResetEvent(IsCompleted);
        }

        return _wait;
      }
    }

    public bool IsCompleted { get; private set; }

    #endregion
  }
}