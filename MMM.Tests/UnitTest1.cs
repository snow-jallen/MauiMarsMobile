using MauiMarsMobile.Models;

namespace MMM.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanParseSingle10x10()
        {
            List<LowResolutionMapTile> lowResolutionMapTiles = new List<LowResolutionMapTile>();
            lowResolutionMapTiles.Add(new LowResolutionMapTile
            {
                LowerLeftRow = 0,
                LowerLeftColumn = 0,
                UpperRightRow = 9,
                UpperRightColumn = 9,
                AverageDifficulty = 15
            });

            var map = new Map(lowResolutionMapTiles);
            Assert.That(map.Cells.Length, Is.EqualTo(10));
            Assert.That(map.Cells[0].Length, Is.EqualTo(10));

        }

        [Test]
        public void DifficultyValuesSet()
        {
            List<LowResolutionMapTile> lowResolutionMapTiles = new List<LowResolutionMapTile>();
            lowResolutionMapTiles.Add(new LowResolutionMapTile
            {
                LowerLeftRow = 0,
                LowerLeftColumn = 0,
                UpperRightRow = 9,
                UpperRightColumn = 9,
                AverageDifficulty = 15
            });
            var map = new Map(lowResolutionMapTiles);
            Assert.That(map.Cells.All(row => row.All(col => col.Difficulty == 15 && col.IsExplored == false)));

        }


    }
}