using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMarsMobile.Models;

public class Map
{
    public Cell[][] Cells { get; }

    public Map(IEnumerable<LowResolutionMapTile> lowResMapTiles)
    {
        var maxCol = lowResMapTiles.Max(t => t.UpperRightColumn) + 1;
        var maxRow = lowResMapTiles.Max(t => t.UpperRightRow) + 1;
        Cell[][] cells = new Cell[maxRow][];
        foreach (var c in Enumerable.Range(0, maxRow))
        {
            cells[c] = new Cell[maxCol];
        }
        Cells = cells;

        foreach(var m in lowResMapTiles)
        {

        }

    }
}
