namespace RatioMaster.BitTorrent {
  internal class IncompleteTorrentData : TorrentException {
    internal IncompleteTorrentData(string message)
      : base(message) {
    }
  }
}