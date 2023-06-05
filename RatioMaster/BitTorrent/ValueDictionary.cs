using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace RatioMaster.BitTorrent {
  internal class ValueDictionary : IBEncodeValue {
    internal ValueDictionary() {
      dict = new Dictionary<string, IBEncodeValue>();
    }

    internal void Add(string key, IBEncodeValue value) {
      dict.Add(key, value);
    }

    internal bool Contains(string key) {
      return dict.ContainsKey(key);
    }

    public byte[] Encode() {
      var collection1 = new Collection<byte>();
      collection1.Add(100);
      var list1 = new ArrayList();
      foreach (var text1 in dict.Keys) {
        list1.Add(text1);
      }

      foreach (string text2 in list1) {
        var text3 = new ValueString(text2);
        foreach (var num1 in text3.Encode()) {
          collection1.Add(num1);
        }

        foreach (var num2 in dict[text2].Encode()) {
          collection1.Add(num2);
        }
      }

      collection1.Add(0x65);
      var buffer1 = new byte[collection1.Count];
      collection1.CopyTo(buffer1, 0);
      return buffer1;
    }

    public void Parse(Stream s) {
      for (var num1 = (byte) s.ReadByte(); num1 != 0x65; num1 = (byte) s.ReadByte()) {
        if (!char.IsNumber((char) num1)) {
          throw new TorrentException("Key expected to be a string.");
        }

        var text1 = new ValueString();
        text1.Parse(s, num1);
        var value1 = BEncode.Parse(s);
        if (dict.ContainsKey(text1.String)) {
          dict[text1.String] = value1;
        }
        else {
          dict.Add(text1.String, value1);
        }
      }
    }

    internal void Remove(string key) {
      dict.Remove(key);
    }

    internal void SetStringValue(string key, string value) {
      if (Contains(value)) {
        ((ValueString) this[key]).String = value;
      }
      else {
        this[key] = new ValueString(value);
      }
    }

    internal IBEncodeValue this[string key] {
      get {
        if (!dict.ContainsKey(key)) {
          dict.Add(key, new ValueString(""));
        }

        return dict[key];
      }

      set {
        if (dict.ContainsKey(key)) {
          dict.Remove(key);
        }

        dict.Add(key, value);
      }
    }

    internal ICollection Keys => dict.Keys;

    internal ICollection Values => dict.Values;

    private Dictionary<string, IBEncodeValue> dict;
  }
}