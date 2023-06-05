using System.Collections.Generic;

namespace RatioMaster {
  internal class PeerList : List<Peer> {
    internal int maxPeersToShow;

    internal int peerCounter;

    internal PeerList() {
      maxPeersToShow = 5;
    }

    public override string ToString() {
      var result = string.Format("({0}) ", Count);
      foreach (var peer in this) {
        if (peerCounter < maxPeersToShow) {
          result = result + peer + ";";
        }

        peerCounter++;
      }

      return result;
    }
  }
}