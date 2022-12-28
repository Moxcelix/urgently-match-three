
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
        return tile != null && predicateDelegate(this, tile);
    }

    public bool Equals(Tile tile, Property property)
    {
        return tile != null && property.Equals(this, tile);
    }
}