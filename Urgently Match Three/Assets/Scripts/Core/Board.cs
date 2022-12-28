using Random = UnityEngine.Random;

public class Board
{
    [System.Flags]
    private enum CollapsingState : short
    {
        IDLE = 0,
        COLLAPSE = 1,
    } 
    
    private readonly Tile[,] _tiles;
    private readonly CollapsingState[,] _collapsingStates;

    private readonly Bounds _bounds;
    
    public int Width { get; }
    public int Height { get; }

    public Board(int width, int height)
    {
        Width = width;
        Height = height;
        _bounds = new Bounds(0, 0, Width, Height);
        _tiles = new Tile[Width, Height];
        _collapsingStates = new CollapsingState[Width, Height];
    }

    public Tile GetTile(int x, int y) 
    {
        return _tiles[x, y];
    }
    
    public int Check(Property property)
    {
        var checkedFigures = 0;
        
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                checkedFigures += CheckCenter(property, i, j);
            }
        }

        return checkedFigures;
    }

    private int CheckCenter(Property property, int x, int y)
    {
        var checkedFigures = 0;
        
        foreach (var figure in property.Figures)
        {
            for (var r = 0; r < Figure.RotationCount; r++)
            {
                if (!IsFigureCanBeCollapsed(figure, property, x, y, r)) continue;
                
                SetCollapsingState(figure, property, x, y, r);
                    
                // Will be collapsed in other place 
                    
                ++checkedFigures;
            }
        }

        return checkedFigures;
    }

    private bool IsFigureCanBeCollapsed(Figure figure, Property property, int x, int y, int rotation)
    {
        if (!InRange(figure, x, y, rotation))
            return false;

        var points = figure.GetPoints(rotation);

        for (var i = 1; i < points.Length; i++)
        {
            var aX = points[i - 1].x + x;
            var aY = points[i - 1].y + y;
            var a = _tiles[aX, aY];

            var bX = points[i].x + x;
            var bY = points[i].y + y;
            var b = _tiles[bX, bY];

            if (
                _collapsingStates[aX, aY] is CollapsingState.COLLAPSE ||
                _collapsingStates[bX, bY] is CollapsingState.COLLAPSE ||
                !a.Equals(b, property)
            ) {
                return false;
            }
        }

        return true;
    }

    private void SetCollapsingState(Figure figure, Property property, int centerX, int centerY, int rotation)
    {
        foreach (var figPoint in figure.GetPoints(rotation))
        {
            var x = figPoint.x + centerX;
            var y = figPoint.y + centerY;

            _collapsingStates[x, y] = CollapsingState.COLLAPSE;
        }
    }
    
    public void ClearCollapsingStates()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _collapsingStates[i, j] = CollapsingState.IDLE;
            }
        }
    }

    public void FillRandomSquares()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                var color = (ColorProperty.Type)Random.Range(0, (int)ColorProperty.Type.END); 
                var form = (FormProperty.Type)Random.Range(0, (int)FormProperty.Type.END);

                _tiles[i, j] = new Tile(color, form);
            }
        }
    }
    
    private bool InRange(Figure figure, int x, int y, int rotation)
    {
        var bounds = figure.GetBounds(rotation);

        return _bounds.InRange(bounds.GetShiftBounds(x, y));
    }
}
