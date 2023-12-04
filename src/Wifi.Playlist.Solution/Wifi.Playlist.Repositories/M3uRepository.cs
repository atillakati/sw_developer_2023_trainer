using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories
{
    public class M3uRepository : IPlaylistRepository
    {
        private readonly IFileSystem _fileSystem;

        public M3uRepository() : this(new FileSystem()) { }

        public M3uRepository(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }
        public string Description => "M3U Playlist format";

        public string Extension => ".m3u";

        public IPlaylist Load(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Save(IPlaylist playlist, string filePath)
        {
            var m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            m3uPlaylist.Comments.Add($"#Title:{playlist.Name}");
            m3uPlaylist.Comments.Add($"#Author:{playlist.Author}");
            m3uPlaylist.Comments.Add($"#CreatedAt:{playlist.CreatedAt}");

            foreach (var item in playlist.Items)
            {
                var entityItem = new M3uPlaylistEntry()
                {
                    AlbumArtist = item.Author,
                    Duration = item.Duration,
                    Path = item.FilePath,
                    Title = item.Title
                };

                m3uPlaylist.PlaylistEntries.Add(entityItem);
            }
            
            var content = new M3uContent();
            string text = content.ToText(m3uPlaylist);

            using(var stream = _fileSystem.File.CreateText(filePath))
            {                
                stream.WriteLine(text);
            }
        }
    }
}
