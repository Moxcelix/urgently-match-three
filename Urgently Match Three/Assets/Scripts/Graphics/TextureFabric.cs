using UnityEngine;
using System.Linq;

public sealed class TextureFabric : MonoBehaviour
{
    [System.Serializable]
    public class PropertyPair<TPropertyType, TValue>
    {
        public TPropertyType _type;
        public TValue _value;
    }

    [SerializeField] private PropertyPair<ColorProperty.Type, Color>[] _colorMap;
    [SerializeField] private PropertyPair<FormProperty.Type, Sprite>[] _formMap;

    public static TextureFabric Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public (Color, Sprite) Create(Tile tile)
    {
        var color = _colorMap.First(t => t._type == tile.Color);
        var sprite = _formMap.First(t => t._type == tile.Form);

        return (color._value, sprite._value);
    }

}
