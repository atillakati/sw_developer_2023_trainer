using System;
using System.Drawing;
using System.IO;
using TagLib;
using Wifi.Playlist.CoreTypes;
using File = TagLib.File;

namespace Wifi.Playlist.Items
{
    public class Mp3Item : IPlaylistItem
    {
        private readonly string _filePath;
        private readonly File _tagFile;

        public Mp3Item(string filePath)
        {
            _filePath = filePath;

            _tagFile = TagLib.File.Create(filePath);
        }
        public string Title => _tagFile.Tag.Title;

        public string Author => _tagFile.Tag.FirstPerformer;

        public TimeSpan Duration => _tagFile.Properties.Duration;

        public string FilePath => _filePath;

        public Image Thumbnail 
        {
            get 
            {
                if (_tagFile.Tag.Pictures != null && _tagFile.Tag.Pictures.Length > 0)
                {
                    //https://stackoverflow.com/questions/10247216/c-sharp-mp3-id-tags-with-taglib-album-art
                    return Image.FromStream(new MemoryStream(_tagFile.Tag.Pictures[0].Data.Data));
                    //return _tagFile.Tag.Pictures[0].Data.Data;
                }

                return null;
            }
        }

        public string Description => "MP3 music file";

        public string Extension => ".mp3";
        
    }
}
