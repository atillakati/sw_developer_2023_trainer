using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.CoreTypes.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;        

        [SetUp]
        public void Init()
        {            
            _fixture = new Playlist("TopHits 2023", "Gandalf");            
        }


        [Test]
        public void Name_get()
        {
            //Arrange            

            //Act
            var erg = _fixture.Name;

            //Assert
            Assert.That(erg, Is.EqualTo("TopHits 2023"));
        }

        [Test]
        public void Name_set()
        {
            //Arrange            
            _fixture.Name = "My SuperHits 1980";

            //Act
            var erg = _fixture.Name;

            //Assert
            Assert.That(erg, Is.EqualTo("My SuperHits 1980"));
        }

        [Test]
        public void Duration_get()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            item1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(80));
            item2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(200));

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //Act
            var duration = _fixture.Duration;

            //Assert
            Assert.That(duration, Is.EqualTo(TimeSpan.FromSeconds(280)));
        }

        [Test]
        public void Duration_get_NoItems()
        {
            //Arrange           

            //Act
            var duration = _fixture.Duration;

            //Assert
            Assert.That(duration, Is.EqualTo(TimeSpan.Zero));
        }


        [Test]
        public void BasicTest()
        {
            //Arrange
            int zahl = 4;
            int erg = 0;

            //Act
            erg = zahl * 2;

            //Assert
            Assert.That(erg, Is.EqualTo(8));
        }
    }
}
