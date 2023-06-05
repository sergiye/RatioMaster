using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;

namespace RatioMaster.BitTorrent {
  internal class Torrent {
    // if the torrent is multiple files, an array of them

    private string localTorrentFile; // path of the local torrent file

    private Int64 pieceLength; // length of each piece in bytes

    private Piece[] pieceArray; // an array of the torrent pieces

    private byte[] infohash; // a hash of the pieces

    private int pieces; // number of pieces the file is made up of

    internal Collection<TorrentFile> PhysicalFiles { get; private set; }

    internal Torrent() {
      Data = new ValueDictionary();
      localTorrentFile = String.Empty;
      PhysicalFiles = new Collection<TorrentFile>();
    }

    internal Torrent(string localFilename) {
      PhysicalFiles = new Collection<TorrentFile>();
      OpenTorrent(localFilename);
    }

    internal ulong totalLength { get; private set; }

    internal bool SingleFile => ((ValueDictionary) Data["info"]).Contains("length");

    internal ValueDictionary Data { get; private set; }

    internal ValueDictionary Info => (ValueDictionary) Data["info"];

    internal byte[] InfoHash {
      get {
        SHA1 sha = new SHA1CryptoServiceProvider();
        return sha.ComputeHash(Data["info"].Encode());
      }
    }

    internal string Name {
      get =>
        // if (data.Contains("info") == false)
        // data.Add("info", new ValueDictionary());
        BEncode.String(((ValueDictionary) Data["info"])["name"]);

      set {
        if (Data.Contains("info") == false) Data.Add("info", new ValueDictionary());
        ((ValueDictionary) Data["info"]).SetStringValue("name", value);
      }
    }

    internal string Comment {
      get => BEncode.String(Data["comment"]);

      set => Data.SetStringValue("comment", value);
    }

    internal string Announce {
      get => BEncode.String(Data["announce"]);

      set => Data.SetStringValue("announce", value);
    }

    internal string CreatedBy {
      get => BEncode.String(Data["created by"]);

      set => Data.SetStringValue("created by", value);
    }

    internal bool OpenTorrent(string localFilename) {
      Data = null; // clear any old data
      var hasOpened = false;
      localTorrentFile = localFilename;
      Data = new ValueDictionary();
      FileStream fs = null;
      BinaryReader r = null;

      try {
        fs = File.OpenRead(localFilename);
        r = new BinaryReader(fs);

        // Parse the BEncode .torrent file
        Data = (ValueDictionary) BEncode.Parse(r.BaseStream);

        // Check the torrent for its form, initialize this object
        LoadTorrent();

        hasOpened = true;
        r.Close();
        fs.Close();
      }
      catch (IOException) {
        hasOpened = false;
      }
      finally {
        if (r != null) r.Close();
        if (fs != null) fs.Close();
      }

      return hasOpened;
    }

    private void ParsePieceHashes(byte[] hashdata) {
      var targetPieces = hashdata.Length / 20;
      pieces = 0; // reset! careful
      pieceArray = null;
      pieceArray = new Piece[targetPieces];
      while (pieces < targetPieces) {
        var p = new Piece(this, pieces);
        pieceArray[pieces] = p;
        pieces++;
      }
    }

    internal int Pieces => pieceArray.Length;

    private void LoadTorrent() {
      if (Data.Contains("announce") == false) throw new IncompleteTorrentData("No tracker URL");

      if (Data.Contains("info") == false) throw new IncompleteTorrentData("No internal torrent information");

      var info = (ValueDictionary) Data["info"];
      pieceLength = ((ValueNumber) info["piece length"]).Integer;

      if (info.Contains("pieces") == false) throw new IncompleteTorrentData("No piece hash data");

      var pieces = (ValueString) info["pieces"];

      if (pieces.Length % 20 != 0) throw new IncompleteTorrentData("Missing or damaged piece hash codes");

      // Parse out the hash codes
      ParsePieceHashes(pieces.Bytes);

      // if (info.Contains("length") == true)

      // if (data.Contains("files") == true)
      // throw new Exception("This is not a single file");

      // SingleFile = true;

      // Determine what files are in the torrent
      if (SingleFile) ParseSingleFile();
      else ParseMultipleFiles();
      infohash = InfoHash;
    }

    private void ParseSingleFile() {
      var info = (ValueDictionary) Data["info"];
      totalLength = (ulong) ((ValueNumber) info["length"]).Integer;
      var f = new TorrentFile(((ValueNumber) info["length"]).Integer, ((ValueString) info["name"]).String);
      PhysicalFiles.Add(f);
    }

    private void ParseMultipleFiles() {
      var info = (ValueDictionary) Data["info"];
      var files = (ValueList) info["files"];
      PhysicalFiles = null;
      PhysicalFiles = new Collection<TorrentFile>();
      foreach (ValueDictionary o in files) {
        var components = (ValueList) o["path"];
        var first = true;
        var path = "";
        foreach (ValueString vs in components) {
          if (!first) path += "/";
          first = false;
          path += vs.String;
        }

        totalLength += (ulong) ((ValueNumber) o["length"]).Integer;
        var f = new TorrentFile(((ValueNumber) o["length"]).Integer, path);
        PhysicalFiles.Add(f);
      }
    }
  }
}