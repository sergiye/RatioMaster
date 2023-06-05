using System.Collections;

namespace RatioMaster {
  internal class RMCollection<item> : CollectionBase {
    internal item this[int index] {
      get => (item) List[index];

      set => List[index] = value;
    }

    internal int Add(item value) {
      return List.Add(value);
    }
  }
}