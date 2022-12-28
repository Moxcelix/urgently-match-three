using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Image _image; // for testing

    private Board _board = new(10, 10);

    private void Start()
    {
        _board.Test();  // for testing
        Show();         // for testing
    }

    private void Show() // for testing
    {
        Texture2D texture = new(_board.Width, _board.Height);

        for (int x = 0; x < _board.Width; x++)
            for (int y = 0; y < _board.Height; y++)
            {
                Color color = Color.red;
                ColorProperty.Type type = _board.GetTile(x, y).Color;

                switch (type)
                {
                    case ColorProperty.Type.RED:
                        color = Color.red;
                        break;
                    case ColorProperty.Type.GREEN:
                        color = Color.green;
                        break;
                    case ColorProperty.Type.BLUE:
                        color = Color.blue;
                        break;
                    case ColorProperty.Type.YELLOW:
                        color = Color.yellow;
                        break;
                }

                texture.SetPixel(x, y, color);
            }

        texture.filterMode = FilterMode.Point;
        texture.Apply();

        _image.sprite = Sprite.Create(texture, new(0, 0, _board.Width, _board.Height), Vector2.zero);
    }

}

