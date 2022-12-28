using UnityEngine;
using System.Linq;

public sealed class TextureFabric : MonoBehaviour
{
    [System.Serializable]
    public class ColorPair
    {
        public ColorProperty.Type _type;
        public Color _color;
    }

    [System.Serializable]
    public class FormPair
    {
        public FormProperty.Type _type;
        public Sprite _sprite;
    }

    [SerializeField] private ColorPair[] _colorMap;
    [SerializeField] private FormPair[] _formMap;

    public static TextureFabric Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public (Color, Sprite) Create(Tile tile)
    {
        var color = _colorMap.First(t => t._type == tile.Color);
        var sprite = _formMap.First(t => t._type == tile.Form);

        return (color._color, sprite._sprite);
    }

}
