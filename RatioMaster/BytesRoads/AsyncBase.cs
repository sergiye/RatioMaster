using System;

namespace RatioMaster.BytesRoads {

  public class AsyncBase {
    protected bool inProgress;


    internal virtual void SetProgress(bool progress) {
      // prevent from nested calls
      lock (this) {
        if (progress) {
          if (inProgress)
            throw new InvalidOperationException("Attempt to start operation which is already in the progress");
          inProgress = true;
        }
        else {
          inProgress = false;
        }
      }
    }

    internal virtual void CheckProgress() {
      lock (this) {
        if (inProgress)
          throw new InvalidOperationException("Attempt to start operation which is already in the progress");
      }
    }

    internal static void VerifyAsyncResult(
      IAsyncResult ar,
      Type arType) {
      VerifyAsyncResult(ar, arType, null);
    }

    internal static void VerifyAsyncResult(
      IAsyncResult ar,
      Type arType,
      string metName) {
      if (null == ar)
        throw new ArgumentNullException("asyncResult", "The value cannot be null.");

      if (null == metName)
        metName = "End*";

      if (false == ar.GetType().Equals(arType))
        throw new ArgumentException(
          "asyncResult was not returned by a call to the " +
          metName + " method.", "asyncResult");

      var stateObj = (AsyncResultBase) ar;
      if (stateObj.IsHandled)
        throw new InvalidOperationException(metName + " was previously called for the asynchronous operation.");
    }

    internal virtual void HandleAsyncEnd(IAsyncResult ar, bool turnProgressOff) {
      if (false == ar.GetType().IsSubclassOf(typeof(AsyncResultBase)) &&
          false == ar.GetType().Equals(typeof(AsyncResultBase)))
        throw new ArgumentException("asyncResult was not returned by a call to End* method.", "asyncResult");

      var stateObj = (AsyncResultBase) ar;
      if (stateObj.IsHandled)
        throw new InvalidOperationException("End* method was previously called for the asynchronous operation.");

      if (false == stateObj.IsCompleted)
        stateObj.AsyncWaitHandle.WaitOne();

      stateObj.IsHandled = true;

      if (turnProgressOff)
        SetProgress(false);

      if (null != stateObj.Exception) {
        // dumpActivityException(stateObj);
        throw stateObj.Exception;
      }
    }
  }
}