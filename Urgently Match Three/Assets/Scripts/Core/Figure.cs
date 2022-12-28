using UnityEngine;

public class Figure
{
    public static readonly Figure Oleg = new(new Vector2Int[] { new(0, 0), new(1, 0), new(2, 0) });
    public static readonly Figure Boba = new(new Vector2Int[] { new(0, 0), new(1, 0), new(1, 1) });
    public static readonly Figure Tola = new(new Vector2Int[] { new(0, 0), new(1, 0), new(0, 1), new(1, 1) });
    public static readonly Figure Tetr = new(new Vector2Int[] { new(0, 0), new(1, 0), new(1, 0), new(2, 0) });
    public static readonly Figure Lola = new(new Vector2Int[] { new(0, 0), new(1, 0), new(1, 1), new(2, 1) });
    public static readonly Figure Lala = new(new Vector2Int[] { new(0, 1), new(1, 1), new(1, 0), new(2, 0) });

    public const int rotationCount = 4;

    private readonly Vector2Int[][] _points;  // [rotation][number]
    private readonly Bounds[] _bounds;

    /* ------- ~unreal axis system~ --------+    
     |                                      |
     |             y                        |
     |             ?                        |
     |             |                        |
     |             |                        |
     |             +------? x               |
     |                                      |
     +------------------------------------ */

    public Figure(Vector2Int[] points)
    {
        _points = new Vector2Int[rotationCount][];
        _bounds = new Bounds[rotationCount];

        for (int i = 0; i < rotationCount; i++)
            _points[i] = (Vector2Int[])points.Clone();

        for (int j = 0; j < points.Length; j++)
            _bounds[0].Expand(_points[0][j]);

        for (int i = 1; i < rotationCount; i++)
        {
            for (int j = 0; j < points.Length; j++)
            {
                _points[i][j].x = _points[i - 1][j].y;
                _points[i][j].y = -_points[i - 1][j].x;

                _bounds[i].Expand(_points[i][j]);
            }
        }
    }

    public Bounds GetBounds(int rotation) 
    {
        if (rotation < 0 && rotation >= rotationCount)
            throw new System.ArgumentOutOfRangeException();

        return _bounds[rotation];
    }

    public Vector2Int[] GetPoints(int rotation)
    {
        if (rotation < 0 && rotation >= rotationCount)
            throw new System.ArgumentOutOfRangeException();

        return _points[rotation];
    }
}
