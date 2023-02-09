namespace MMM.Tests;

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

        cellsInView.LLUU.Should().BeNull();
        cellsInView.LUU.Should().BeNull();
        cellsInView.UU.Should().BeEquivalentTo(map.Cells[(0, 2)]);
        cellsInView.RUU.Should().BeEquivalentTo(map.Cells[(1, 2)]);
        cellsInView.LLU.Should().BeNull();
        cellsInView.LU.Should().BeNull();
        cellsInView.LL.Should().BeNull();
        cellsInView.L.Should().BeNull();
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