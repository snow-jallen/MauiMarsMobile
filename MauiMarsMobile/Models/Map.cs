using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MauiMarsMobile.Models;

public class Map
{
    public Dictionary<(int, int), Cell> Cells { get; }

    public Map(IEnumerable<LowResolutionMapTile> lowResMapTiles)
    {
        Cells = new(from tile in lowResMapTiles
                    from row in Enumerable.Range(0, lowResMapTiles.Max(t => t.UpperRightRow) + 1)
                    from col in Enumerable.Range(0, lowResMapTiles.Max(t => t.UpperRightColumn) + 1)
                    select new KeyValuePair<(int, int), Cell>((row, col), new Cell(row, col, tile.AverageDifficulty)));
    }

    public ViewableCells GetCellsInView(int row, int col, Orientation orientation)
    {
        (int r, int c) offset(int deltaRow, int deltaCol) => (row+deltaRow, col+deltaCol);

        Cell getCell(int deltaRow, int deltaCol)
        {
            var location = offset(deltaRow, deltaCol);
            if(Cells.ContainsKey(location))
            {
                return Cells[location];
            }
            return null;
        }

        return new ViewableCells
        {
            LLUU = getCell(-2, 2),
            LUU = getCell(-1, 2),
            UU = getCell(0, 2),
            RUU = getCell(1, 2),
            RRUU = getCell(2,2),
            LLU = getCell(-2,1),
            LU = getCell(-1,1),
            U = getCell(0,1),
            RU = getCell(1,1),
            RRU = getCell(2,1),
            LL = getCell(-2,0),
            L = getCell(-1,0),
            R = getCell(1,0),
            RR = getCell(2,0),
        };
    }
}

public class ViewableCells
{ 
    public Cell LLUU { get; init; }
    public Cell LUU { get; init; }
    public Cell UU { get; init; }
    public Cell RUU { get; init; }
    public Cell RRUU { get; init; }
    public Cell LLU { get; init; }
    public Cell LU { get; init; }
    public Cell U { get; init; }
    public Cell RU { get; init; }
    public Cell RRU { get; init; }
    public Cell LL { get; init; }
    public Cell L { get; init; }
    public Cell R { get; init; }
    public Cell RR { get; init; }
}


public enum Orientation
{
    North,
    East,
    South,
    West
}
