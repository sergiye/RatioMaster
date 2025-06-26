using System;

namespace RatioMaster {
  internal struct TorrentInfo {
    private Random random;

    internal TorrentInfo(long uploaded, long downloaded) {
      this.uploaded = uploaded;
      this.downloaded = downloaded;
      tracker = string.Empty;
      hash = string.Empty;
      left = 10000;
      totalsize = 10000;
      filename = string.Empty;
      uploadRate = 10 * 1024 * 1024; //10 MB/s by default
      downloadRate = 30 * 1024;
      interval = 300;
      random = new Random();
      key = random.Next(1000).ToString();
      port = random.Next(1025, 65535).ToString();
      numberOfPeers = "200";
      peerID = string.Empty;
      trackerUri = null;
    }

    internal long downloaded { get; set; }

    internal long downloadRate { get; set; }

    internal string filename { get; set; }

    internal string hash { get; set; }

    internal int interval { get; set; }

    internal string key { get; set; }

    internal long left { get; set; }

    internal string numberOfPeers { get; set; }

    internal string peerID { get; set; }

    internal string port { get; set; }

    internal long totalsize { get; set; }

    internal string tracker { get; set; }

    internal long uploaded { get; set; }

    internal long uploadRate { get; set; }

    internal Uri trackerUri { get; set; }
  }
}