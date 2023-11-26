using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories
{
    /// <summary>
    /// Type for reading and writing m3u playlist files.
    /// </summary>
    /// <see cref="https://github.com/tmk907/PlaylistsNET"/>
    public class M3uRepository : IPlaylistRepository
    {
        public string Description => throw new NotImplementedException();

        public string Extension => throw new NotImplementedException();

        public IPlaylist Load(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Save(IPlaylist playlist, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
