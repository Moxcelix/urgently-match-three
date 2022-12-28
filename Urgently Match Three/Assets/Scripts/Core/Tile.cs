
public class Tile
{
    public ColorProperty.Type Color { get; private set; }
    public FormProperty.Type Form { get; private set; }


    public delegate bool PredicateDelegate(Tile tileA, Tile tileB);

    public Tile(ColorProperty.Type color, FormProperty.Type form)
    {
        Color = color;
        Form = form;
    }

    public bool Equals(Tile tile, PredicateDelegate predicateDelegate)
    {
        if (tile == null)
            return false;

        return predicateDelegate(this, tile);
    }

    public bool Equals(Tile tile, Property property)
    {
        if (tile == null)
            return false;

        return property.Equals(this, tile);
    }
}