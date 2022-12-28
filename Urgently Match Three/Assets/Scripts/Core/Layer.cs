public abstract class Property 
{
    public static readonly Property Color = new ColorProperty();
    public static readonly Property Form = new FormProperty();

    public abstract bool Equals(Tile a, Tile b);
    public abstract Figure[] Figures { get; }
}

public sealed class ColorProperty : Property 
{
    public enum Type
    {
        RED,
        GREEN,
        BLUE,
        YELLOW,
        GREY,
        BLACK,
        MAGENTA,
        CYAN,
    }

    private readonly Figure[] _figures = new Figure[]
    {
        Figure.Oleg, 
        Figure.Boba, 
        Figure.Tola,
    };

    public override Figure[] Figures => _figures;

    public override bool Equals(Tile a, Tile b)
    {
        return a.Color == b.Color;
    }
}

public sealed class FormProperty : Property 
{
    public enum Type
    {
        SQUARE,
        CIRCLE,
        TRIANGLE,
        OCTAGON,
        HEXAGON,
        RHOMBUS,
    }

    private readonly Figure[] _figures = new Figure[]
    {
        Figure.Oleg,
        Figure.Lola,
        Figure.Lala,
        Figure.Tetr,
    };

    public override Figure[] Figures => _figures;

    public override bool Equals(Tile a, Tile b)
    {
        return a.Form == b.Form;
    }
}