using System;
using System.Drawing;
using System.IO;
using TagLib;
using Wifi.Playlist.CoreTypes;
using File = TagLib.File;

namespace Wifi.Playlist.Items
{
    /// <summary>
    /// Base Imageitem type for Playlist. 
    /// Supported image types: bmp, gif, jpeg, pbm, pgm, ppm, pnm, pcx, png, tiff, dng, svg    
    /// </summary>
    /// <see cref="https://github.com/mono/taglib-sharp"/>
    public abstract class PictureItemBase : IPlaylistItem
    {
        private readonly string _filePath;
        private readonly File _tagFile;
        private readonly string _extension;
        

        public PictureItemBase(string filePath, string extension)
        {
            _filePath = filePath;
            _tagFile = TagLib.File.Create(filePath);
            _extension = extension;
        }

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_tagFile.Tag.Title))
                {
                    return System.IO.Path.GetFileName(_filePath);
                }

                return _tagFile.Tag.Title;
            }
        }

        public string Author
        {
            get
            {
                if(string.IsNullOrEmpty(_tagFile.Tag.FirstPerformer))
                {
                    return "Unknown";
                }

                return _tagFile.Tag.FirstPerformer;
            }
        }
        

        public TimeSpan Duration => TimeSpan.FromSeconds(10);

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

        public string Description => $"{_extension.ToUpper().Replace(".", "")} picture file";

        public string Extension => _extension;
    }
}
