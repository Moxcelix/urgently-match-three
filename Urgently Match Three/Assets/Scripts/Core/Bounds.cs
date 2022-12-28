using UnityEngine;

public struct Bounds
{
    public int down;
    public int up;
    public int left;
    public int right;

    public Bounds(int left, int down, int right, int up) 
    {
        this.down = down;
        this.up = up;   
        this.left = left;
        this.right = right;
    }

    public void Expand(Vector2Int pos)
    {
        if (pos.x < left)
            left = pos.x;
        if (pos.x > right)
            right = pos.x;
        if (pos.y < down)
            down = pos.y;
        if (pos.y > up)
            up = pos.y;
    }

    public Bounds GetShiftBounds(int x, int y)
    {
        return new Bounds(left + x, down + y, right + x, up + y);
    }

    public bool InRange(Vector2Int pos) 
    {
        return InRange(pos.x, pos.y);
    }

    public bool InRange(int x, int y)
    {
        return (x >= left) && (x < right) && (y >= down) && (y < up);
    }

    public bool InRange(Bounds bounds) 
    {
        return InRange(bounds.left, bounds.down) && InRange(bounds.right, bounds.up);
    }
}