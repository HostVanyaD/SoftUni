// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
        }

		[Test]
	    public void Ctor_WorksCorrectly()
	    {
			Assert.IsNotNull(stage.Performers);
			Assert.That(stage.Performers.Count, Is.EqualTo(0));
		}

		[Test]
		public void AddPerformer_ThrowsArgumentNullEx_WhenPerformerIsNull()
        {
			Performer nullPerformer = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(nullPerformer));
        }

		[Test]
		public void AddPerformer_ThrowsArgumentEx_WhenPerformersAgeIsLessThan18()
        {
			Performer performer = new Performer("Daniela", "Tuleshova", 14);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

		[Test]
		public void AddPerformer_IncreaseCount_WhenNewPerformerIsAdded()
        {
			stage.AddPerformer(new Performer("Lenny", "Kravitz", 57));
			int expectedCount = 1;

			Assert.That(stage.Performers.Count, Is.EqualTo(expectedCount));
        }

		[Test]
		public void AddPerformer_WorksCorrectly()
        {
			Performer performer = new Performer("Lenny", "Kravitz", 57);
			stage.AddPerformer(performer);

			Assert.IsTrue(stage.Performers.Contains(performer));
		}

		[Test]
		public void AddSong_ThrowsArgumentNullEx_WhenSongIsNull()
        {
			Song nullSong = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(nullSong));
        }

		[Test]
		public void AddSong_ThrowsArgumentEx_WhenSongsDurationIsLessThanAMinute()
		{
			Song shortSong = new Song("InvalidSong", new TimeSpan(0, 0, 20));

			Assert.Throws<ArgumentException>(() => stage.AddSong(shortSong));
		}

		[Test]
		public void AddSongToPerformer_WorksCorrectly()
        {
			Performer performer = new Performer("Lenny", "Kravitz", 57);
			Song song = new Song("I belong to you", new TimeSpan(0, 04, 17));

			stage.AddPerformer(performer);
			stage.AddSong(song);

			string expectedResult = $"{song.ToString()} will be performed by {performer.FullName}";

			int expectedPerfomerSongsCount = 1;

			Assert.AreEqual(expectedResult, stage.AddSongToPerformer(song.Name, performer.FullName));
			Assert.AreEqual(expectedPerfomerSongsCount, performer.SongList.Count);
		}

		[Test]
		public void AddSongToPerformer_ThrowsArgumentEx_WhenPerformerDoesNotExist()
		{
			Performer performer = new Performer("Lenny", "Kravitz", 57);
			Song song = new Song("I belong to you", new TimeSpan(0, 04, 17));

			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, performer.FullName));
		}

		[Test]
		public void AddSongToPerformer_ThrowsArgumentEx_WhenSongDoesNotExist()
		{
			Performer performer = new Performer("Lenny", "Kravitz", 57);
			Song song = new Song("I belong to you", new TimeSpan(0, 04, 17));

			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, performer.FullName));
		}

		[Test]
		public void Play_WorksCorrectly()
        {
			Performer performer = new Performer("Lenny", "Kravitz", 57);
			Song song = new Song("I belong to you", new TimeSpan(0, 04, 17));

			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer(song.Name, performer.FullName);

			string expectedResult = "1 performers played 1 songs";

			Assert.AreEqual(expectedResult, stage.Play());
		}
	}
}