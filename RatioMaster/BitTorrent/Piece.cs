using System;
using System.IO;

namespace RatioMaster.BitTorrent {
  internal class Piece {
    internal byte[] Bytes {
      get {
        var fs = new FileStream(Torrent.PhysicalFiles[0].Path, FileMode.Open);
        var r = new BinaryReader(fs);
        var bytes = r.ReadBytes((int) fs.Length);
        r.Close();
        fs.Close();
        return bytes;
      }
    }

    internal Torrent Torrent { get; }

    internal byte[] Hash { get; }

    internal int PieceNumber { get; }


    internal Piece(Torrent parent, int pieceNumber) {
      Hash = new byte[20];
      this.PieceNumber = pieceNumber;
      Torrent = parent;

      Buffer.BlockCopy(((ValueString) Torrent.Info["pieces"]).Bytes, pieceNumber * 20, Hash, 0, 20);
    }
  }
}