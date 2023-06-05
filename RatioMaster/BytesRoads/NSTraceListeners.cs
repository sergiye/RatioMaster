using System;
using System.Collections;
using System.Diagnostics;

namespace RatioMaster.BytesRoads {
  /// <summary>
  /// Provides a thread-safe list of 
  /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>
  /// objects.
  /// </summary>
  /// 
  /// <remarks>
  /// The <b>TraceListenerSet</b> class provides the same set of 
  /// functionality as
  /// <see cref="System.Diagnostics.TraceListenerCollection">TraceListenerCollection</see>
  /// provides. The reason for creating this class is inpossibility of
  /// using <b>TraceListenerCollection</b> due to hidden constructor.
  /// </remarks>
  public class NSTraceListeners : IList {
    private ArrayList _listeners = new ArrayList();

    internal NSTraceListeners() {
    }


    #region thunks for compilator

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    public virtual bool IsSynchronized => false;

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    public virtual bool IsFixedSize => false;

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    public virtual bool IsReadOnly => false;

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    object ICollection.SyncRoot => this;

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    int IList.Add(object val) {
      return Add((TraceListener) val);
    }

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    void IList.Remove(object val) {
      Remove((TraceListener) val);
    }

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    bool IList.Contains(object val) {
      return Contains((TraceListener) val);
    }

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    int IList.IndexOf(object val) {
      return IndexOf((TraceListener) val);
    }

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    void IList.Insert(int index, object val) {
      Insert(index, (TraceListener) val);
    }

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <exclude/>
    object IList.this[int index] {
      get => this[index];
      set => this[index] = (TraceListener) value;
    }

    #endregion

    /// <summary>
    /// Gets the number of listeners in the list.
    /// </summary>
    /// <value>
    /// The number of listeners in the list.
    /// </value>
    public virtual int Count => _listeners.Count; // ICollection member

    /// <overloads>
    /// Gets or sets the specified 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>.  
    /// </overloads>
    /// <summary>
    /// Gets or sets the 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>
    /// at the specified index.
    /// </summary>
    /// <value>
    /// A 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see> 
    /// with the specified index.
    /// </value>
    /// <remarks>
    /// Note that the index is zero-based. 
    /// </remarks>
    public TraceListener this[int index] {
      get => (TraceListener) _listeners[index];
      set => _listeners[index] = value;
    }

    /// <summary>
    /// Adds a 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>    
    /// to the list.
    /// </summary>
    /// <param name="listener">
    /// A 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>
    /// to add to the list.
    /// </param>
    /// <returns>
    /// The position at which the new listener was inserted.
    /// </returns>
    public int Add(TraceListener listener) {
      return _listeners.Add(listener);
    }

    /// <summary>
    /// Clears all the listeners from the list.
    /// </summary>
    public virtual void Clear() // IList member
    {
      _listeners.Clear();
    }

    /// <summary>
    /// Checks whether the list contains the specified listener.
    /// </summary>
    /// <param name="listener">
    /// A <see cref="System.Diagnostics.TraceListener">TraceListener</see>    
    /// to find in the list.
    /// </param>
    /// <returns>
    /// <b>true</b> if the listener is in the list; otherwise, <b>false</b>.
    /// </returns>
    /// <remarks>
    /// The <b>Contains</b> method can confirm the existence of a 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>    
    /// before you perform further operations.
    /// </remarks>
    public bool Contains(TraceListener listener) // IList 
    {
      return _listeners.Contains(listener);
    }

    /// <summary>
    /// This member supports the .NET Framework infrastructure 
    /// and is not intended to be used directly from your code.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="index"></param>
    /// <exclude/>
    public void CopyTo(Array array, int index) {
    }

    /// <summary>
    /// Gets an enumerator for this list.
    /// </summary>
    /// <returns>
    /// An enumerator of type 
    /// <see cref="System.Collections.IEnumerator">IEnumerator</see>.
    /// </returns>
    public virtual IEnumerator GetEnumerator() // IEnumerable
    {
      return _listeners.GetEnumerator();
    }

    /// <summary>
    /// Gets the index of the specified listener.
    /// </summary>
    /// <param name="listener">
    /// A 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>    
    /// to find in the list. 
    /// </param>
    /// <returns>
    /// The index of the listener, if it can be found
    /// in the list; otherwise, -1.
    /// </returns>
    public int IndexOf(TraceListener listener) {
      return _listeners.IndexOf(listener);
    }

    /// <summary>
    /// Inserts the listener at the specified index.
    /// </summary>
    /// <param name="index">
    /// The zero-based index at which the new
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>.
    /// should be inserted.
    /// </param>
    /// <param name="listener">
    /// A 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>
    /// to insert in the list. 
    /// </param>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// The <i>index</i> is not a valid index in the list.
    /// </exception>
    public void Insert(int index, TraceListener listener) {
      _listeners.Insert(index, listener);
    }

    /// <overloads>
    /// Removes a specific
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>
    /// from the collection.
    /// </overloads>
    /// <summary>
    /// Removes from the collection the specified 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see>.
    /// </summary>
    /// <param name="listener">
    /// A 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see> 
    /// to remove from the list.
    /// </param>
    /// <exception cref="System.ArgumentException">
    /// The <i>listener</i> does not exist in the list.
    /// </exception>
    public void Remove(TraceListener listener) {
      if (false == Contains(listener))
        throw new ArgumentException("The listener does not exist in the list.", "listener");
      _listeners.Remove(listener);
    }

    /// <summary>
    /// Removes from the collection the 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see> 
    /// at the specified index.
    /// </summary>
    /// <param name="index">
    /// The zero-based index of the 
    /// <see cref="System.Diagnostics.TraceListener">TraceListener</see> 
    /// to remove from the list.
    /// </param>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// The <i>index</i> is not a valid index in the list.
    /// </exception>
    public virtual void RemoveAt(int index) {
      _listeners.RemoveAt(index);
    }
  }
}