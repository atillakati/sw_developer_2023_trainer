namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylistRepository : IFileInfo
    {
        IPlaylist Load(string filePath);

        void Save(IPlaylist playlist, string filePath);
    }
}
