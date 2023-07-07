using System.IO;
using System.IO.Compression;

namespace NBWAPI
{
    public static class BWClientHelper
    {
        public static void DumpGameStateBuffer(this BWClient bwClient, string filePath)
        {
            var gameViewStream = bwClient.Client.GameViewStream;
            using var fileStream = File.OpenWrite(filePath);
            using var deflateStream = new DeflateStream(fileStream, CompressionLevel.Optimal, true);
            gameViewStream.CopyTo(deflateStream);
        }
    }
}
