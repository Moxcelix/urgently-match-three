using UnityEngine;

public class Board
{
    private Tile[,] _tiles;

    private readonly int _width;
    private readonly int _height;

    private readonly Bounds _bounds;

    private int _figuresCount = 0; // for testing

    public int Width => _width;
    public int Height => _height;

    public Board(int width, int height)
    {
        _width = width;
        _height = height;
        _bounds = new Bounds(0, 0, _width, _height);
        _tiles = new Tile[_width, _height];
    }

    public Tile GetTile(int x, int y) 
    {
        return _tiles[x, y];
    }
    
    public void Check(Property property)
    {
        for (var i = 0; i < _width; i++)
        {
            for (var j = 0; j < _height; j++)
            {
                Check(property, i, j);
            }
        }
    }

    private void Check(Property property, int x, int y)
    {
        foreach (var figure in property.Figures)
        {
            for (var r = 0; r < Figure.rotationCount; r++)
            {
                if (IsFigure(figure, property, x, y, r))
                {
                    // do something
                    _figuresCount++;
                }
            }
        }
    }

    private bool IsFigure(Figure figure, Property property, int x, int y, int rotation)
    {
        if (!InRange(figure, x, y, rotation))
            return false;

        var points = figure.GetPoints(rotation);

        for (var i = 1; i < points.Length; i++)
        {
            Tile a = _tiles[points[i - 1].x + x, points[i - 1].y + y];
            Tile b = _tiles[points[i].x + x, points[i].y + y];

            if (!a.Equals(b, property))
            {
                return false;
            }
        }

        return true;
    }

    public void Test()
    {
        for (var i = 0; i < _width; i++)
        {
            for (var j = 0; j < _height; j++)
            {
                _tiles[i, j] = Random.Range(0, 4) switch
                {
                    0 => new Tile(ColorProperty.Type.RED, FormProperty.Type.SQUARE),
                    1 => new Tile(ColorProperty.Type.GREEN, FormProperty.Type.SQUARE),
                    2 => new Tile(ColorProperty.Type.BLUE, FormProperty.Type.SQUARE),
                    3 => new Tile(ColorProperty.Type.YELLOW, FormProperty.Type.SQUARE),
                    _ => _tiles[i, j]
                };
            }
        }

        Check(Property.Color);

        Debug.Log(_figuresCount);
    }

    private bool InRange(Figure figure, int x, int y, int rotation)
    {
        var bounds = figure.GetBounds(rotation);

        return _bounds.InRange(bounds.GetShiftBounds(x, y));
    }
}
