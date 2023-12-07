using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories.Json
{
    public class JsonRepository : IPlaylistRepository
    {
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public JsonRepository(IPlaylistItemFactory playlistItemFactory)
            : this(new FileSystem(), playlistItemFactory) { }

        public JsonRepository(IFileSystem fileSystem, IPlaylistItemFactory playlistItemFactory)
        {
            _fileSystem = fileSystem;
            _playlistItemFactory = playlistItemFactory;
        }

        public string Description => "Wifi Playlist Format";

        public string Extension => ".wifi";

        public IPlaylist Load(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Save(IPlaylist playlist, string filePath)
        {
            string json = JsonConvert.SerializeObject(playlist);
            _fileSystem.File.WriteAllText(filePath, json);
        }
    }
}
