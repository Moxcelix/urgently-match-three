
public class Tile
{
    private Part.Color _color;
    private Part.Form _form;

    public Part.Color Color => _color;

    public delegate bool PredicateDelegate(Tile tileA, Tile tileB);

    public bool Equals(Tile tile, PredicateDelegate predicateDelegate)
    {
        if (tile == null)
            return false;

        return predicateDelegate(this, tile);
    }
}