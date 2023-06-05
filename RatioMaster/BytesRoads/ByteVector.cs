using System;

namespace RatioMaster.BytesRoads {

  internal class ByteVector {

    #region Attributes

    internal byte[] Data { get; private set; } = Array.Empty<byte>();

    internal int Size { get; private set; }

    internal int Capacity { get; private set; }

    #endregion

    private void Reallocate(int requiredSize) {
      var newSize = Capacity > 0 ? Capacity : 1;
      while (newSize < requiredSize)
        newSize <<= 1;

      var data = new byte[newSize];
      if (null != Data)
        Data.CopyTo(data, 0);
      Data = data;
      Capacity = newSize;
    }

    private void EnsureSpace(int needMore) {
      if (Size + needMore >= Capacity)
        Reallocate(Size + needMore);
    }

    internal void Add(byte[] data, int offset, int length) {
      EnsureSpace(length);
      Array.Copy(data, offset, Data, Size, length);
      Size += length;
    }

    internal void CutTail(int count) {
      if (count < 0)
        throw new ArgumentException("Should be a positive value", "count");

      if (count > Size)
        Size = 0;
      else
        Size -= count;
    }

    internal void CutHead(int count) {
      if (count < 0)
        throw new ArgumentException("Should be a positive value", "count");

      if (count > Size) {
        Size = 0;
      }
      else {
        Size -= count;
        Array.Copy(Data, count, Data, 0, Size);
      }
    }
  }
}