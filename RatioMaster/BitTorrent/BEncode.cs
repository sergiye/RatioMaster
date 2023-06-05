using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace RatioMaster.BitTorrent {
  internal interface IBEncodeValue {
    byte[] Encode();

    void Parse(Stream p);
  }

  internal class TorrentException : Exception {
    internal TorrentException(string message)
      : base(message) {
    }
  }

  internal class ValueList : IBEncodeValue, IEnumerable, IEnumerator {
    internal Collection<IBEncodeValue> values;

    internal int Position = -1;

    public IEnumerator GetEnumerator() {
      return this;
    }

    /* Needed since Implementing IEnumerator*/

    public bool MoveNext() {
      if (Position < values.Count - 1) {
        ++Position;
        return true;
      }

      return false;
    }

    public void Reset() {
      Position = -1;
    }

    public object Current => values[Position];

    internal ValueList() {
      values = new Collection<IBEncodeValue>();
    }

    public void Parse(Stream s) {
      var current = (byte) s.ReadByte();
      while ((char) current != 'e') {
        var value = BEncode.Parse(s, current);
        values.Add(value);
        current = (byte) s.ReadByte();
      }
    }

    internal void Add(IBEncodeValue value) {
      values.Add(value);
    }

    internal Collection<IBEncodeValue> Values {
      get => values;

      set {
        values.Clear();
        foreach (var val in value) {
          value.Add(val);
        }
      }
    }

    internal IBEncodeValue this[int index] {
      get => values[index];

      set => values[index] = value;
    }

    public byte[] Encode() {
      var bytes = new Collection<byte>();
      bytes.Add((byte) 'l');

      foreach (var member in values)
      foreach (var b in member.Encode())
        bytes.Add(b);

      bytes.Add((byte) 'e');
      var newBytes = new Byte[bytes.Count];

      for (var i = 0; i < bytes.Count; i++) newBytes[i] = bytes[i];

      return newBytes;
    }
  }

  internal class ValueString : IBEncodeValue {
    private string v;

    internal int Length => v.Length;

    internal byte[] Bytes { get; private set; }

    internal string String {
      get => v;

      set {
        v = value;
        Bytes = Encoding.GetEncoding(1252).GetBytes(v);
      }
    }

    public byte[] Encode() {
      var prefix = v.Length + ":";
      var tempBytes = Encoding.GetEncoding(1252).GetBytes(prefix);

      var newBytes = new Byte[prefix.Length + Bytes.Length];
      for (var i = 0; i < prefix.Length; i++) newBytes[i] = tempBytes[i];
      for (var i = 0; i < Bytes.Length; i++) newBytes[i + prefix.Length] = Bytes[i];
      return newBytes;
    }

    internal ValueString(string StringValue) {
      String = StringValue;
    }

    internal ValueString() {
    }

    public void Parse(Stream s) {
      throw new TorrentException(
        "Parse method not supported, the " + "first byte must be passed into the " + "string parse routine.");
    }

    public void Parse(Stream s, byte firstByte) {
      var q = ((char) firstByte).ToString();
      if (!Char.IsNumber(q[0])) throw new TorrentException("\"" + q + "\" is not a string length number.");

      var current = (char) s.ReadByte();
      while (current != ':') {
        q += current.ToString();
        current = (char) s.ReadByte();
      }

      var length = Int32.Parse(q);
      Bytes = new Byte[length];
      s.Read(Bytes, 0, length);
      v = Encoding.GetEncoding(1252).GetString(Bytes); // store string also
    }
  }

  internal class ValueNumber : IBEncodeValue {
    private string v;

    private byte[] data;

    internal string String {
      get => v;

      set {
        v = value;
        data = Encoding.GetEncoding(1252).GetBytes(v);
      }
    }

    internal Int64 Integer {
      get => Int64.Parse(v);

      set => String = value.ToString();
    }

    public byte[] Encode() {
      var newByte = new Byte[data.Length + 2];
      newByte[0] = (byte) 'i';
      for (var i = 0; i < data.Length; i++) newByte[i + 1] = data[i];
      newByte[data.Length + 1] = (byte) 'e';
      return newByte;
    }

    internal ValueNumber(Int64 number) {
      v = number.ToString();
      String = v;
    }

    internal ValueNumber() {
    }

    public void Parse(Stream s) {
      var buffer = String.Empty;
      var current = (char) s.ReadByte();
      while (current != 'e') // discard when end of integer
      {
        buffer += current.ToString();
        current = (char) s.ReadByte();
      }

      String = Int64.Parse(buffer).ToString();
    }
  }

  internal class BEncode {
    internal BEncode() {
    }

    internal static IBEncodeValue Parse(Stream d) {
      return Parse(d, (byte) d.ReadByte());
    }

    internal static string String(IBEncodeValue v) {
      if (v is ValueString) return ((ValueString) v).String;
      else if (v is ValueNumber) return ((ValueNumber) v).String;
      else return null;
    }

    internal static IBEncodeValue Parse(Stream d, byte firstByte) {
      IBEncodeValue v;
      var first = (char) firstByte;

      // 
      if (first == 'd') v = new ValueDictionary();
      else if (first == 'l') v = new ValueList();
      else if (first == 'i') v = new ValueNumber();
      else v = new ValueString();
      if (v is ValueString) ((ValueString) v).Parse(d, (byte) first);
      else v.Parse(d);
      return v;
    }
  }
}