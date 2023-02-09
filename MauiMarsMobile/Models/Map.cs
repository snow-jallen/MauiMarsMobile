using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMarsMobile.Models;

public class Map
{
    public Dictionary<(int, int), Cell> Cells { get; }

    public Map(IEnumerable<LowResolutionMapTile> lowResMapTiles)
    {
        var maxCol = lowResMapTiles.Max(t => t.UpperRightColumn) + 1;
        var maxRow = lowResMapTiles.Max(t => t.UpperRightRow) + 1;

        var cells = new Dictionary<(int, int), Cell>();

        foreach (var tile in lowResMapTiles)
        {
            for (int row = tile.LowerLeftRow; row <= tile.UpperRightRow; row++)
            {
                for (int col = tile.LowerLeftColumn; col <= tile.UpperRightColumn; col++)
                {
                    cells.Add((row, col),new Cell(row, col, tile.AverageDifficulty, false));
                }
            }
        }
        Cells = cells;

    }

    public object GetCellsInView(int v1, int v2, Orientation north)
    {
        throw new NotImplementedException();
    }
}

public enum Orientation
{
    North,
    East,
    South,
    West
}
