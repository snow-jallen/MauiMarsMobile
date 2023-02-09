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
            Map map = MakeMap();
            Assert.That(map.Cells.Count, Is.EqualTo(100));

        }

        [Test]
        public void DifficultyValuesSet()
        {
            Map map = MakeMap();
            Assert.That(map.Cells.All((kvp) => kvp.Value.Difficulty == 15 && kvp.Value.IsExplored == false));
        }

        [Test]
        public void GetCellsInView() 
        {
            Map map = MakeMap();
            var cellsInView = map.GetCellsInView(0, 0, Orientation.North);
        }

        private static Map MakeMap()
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
            return map;
        }

    }
}