using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMarsMobile.Models;

public class Cell
{
    public Cell( int row, int col, int diff, bool isExplored = false)
    {
        Row= row;
        Col= col;
        Difficulty = diff;
        IsExplored = isExplored;
    }
    public int Row { get; }
    public int Col { get;  }

    public int Difficulty { get; set; }
    public bool IsExplored { get; set; }  
}
