using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories.Test
{
    [TestFixture]
    public class M3uRepositoryTests
    {
        private M3uRepository _fixture;   
        private MockFileSystem _mockFileSystem;
        private Mock<IPlaylist> _mockedPlaylist;        

        [SetUp]
        public void Init()
        {
            _mockFileSystem = new MockFileSystem();            

            var playlistItem1 = new Mock<IPlaylistItem>();
            playlistItem1.Setup(x => x.Title).Returns("Song title 1");
            playlistItem1.Setup(x => x.Author).Returns("Super singer 1");
            playlistItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(15));
            playlistItem1.Setup(x => x.FilePath).Returns("song1.mp3");

            var playlistItem2 = new Mock<IPlaylistItem>();
            playlistItem2.Setup(x => x.Title).Returns("Song title 1");
            playlistItem2.Setup(x => x.Author).Returns("Super singer 1");
            playlistItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(15));
            playlistItem2.Setup(x => x.FilePath).Returns("song1.mp3");

            _mockedPlaylist = new Mock<IPlaylist>();
            _mockedPlaylist.Setup(x => x.Name).Returns("My super charts 2022");
            _mockedPlaylist.Setup(x => x.Author).Returns("Gandalf");
            _mockedPlaylist.Setup(x => x.CreatedAt).Returns(DateTime.Now);
            _mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[] { playlistItem1.Object, playlistItem2.Object });
            
            _fixture = new M3uRepository(_mockFileSystem);
        }

        [Test]
        public void Save()
        {
            _fixture.Save(_mockedPlaylist.Object, "myPlaylist.m3u");

            Assert.That(_mockFileSystem.AllFiles.Count, Is.EqualTo(1)); 
        }
    }
}
