using System.Collections.Generic;

public abstract class Property 
{
    public static readonly Property Color = new ColorProperty();
    public static readonly Property Form = new FormProperty();

    public abstract bool Equals(Tile a, Tile b);
    public abstract IEnumerable<Figure> Figures { get; }
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

        END
    }

    private readonly Figure[] _figures = {
        Figure.Tola,
        Figure.Boba, 
        Figure.Oleg, 
    };

    public override IEnumerable<Figure> Figures => _figures;

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

        END
    }

    private readonly Figure[] _figures = {
        Figure.Tetr,
        Figure.Lola,
        Figure.Lala,
        Figure.Oleg,
    };

    public override IEnumerable<Figure> Figures => _figures;

    public override bool Equals(Tile a, Tile b)
    {
        return a.Form == b.Form;
    }
}