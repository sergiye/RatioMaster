using System.IO;

namespace RatioMaster.BitTorrent {
  internal class TorrentFile {
    private readonly FileInfo fileInfo;

    internal TorrentFile(long len, string path) // : this()
    {
      fileInfo = new FileInfo(path);
    }

    internal long Length => fileInfo.Length;

    internal string Path => fileInfo.FullName;

    internal string Name => fileInfo.Name;
  }
}