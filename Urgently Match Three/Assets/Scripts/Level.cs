using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Image _image; // for testing

    private Board _board = new(10, 10);

    private void Start()
    {
        PlaceRandomSquaresAndPrintCheckedFiguresCount();  // for testing
    }

    private void Show() // for testing
    {
        Texture2D texture = new(_board.Width, _board.Height);

        for (var x = 0; x < _board.Width; x++)
            for (var y = 0; y < _board.Height; y++)
            {
                var color = Color.red;
                var type = _board.GetTile(x, y).Color;

                color = type switch
                {
                    ColorProperty.Type.RED => Color.red,
                    ColorProperty.Type.GREEN => Color.green,
                    ColorProperty.Type.BLUE => Color.blue,
                    ColorProperty.Type.YELLOW => Color.yellow,
                    _ => color
                };

                texture.SetPixel(x, y, color);
            }

        texture.filterMode = FilterMode.Point;
        texture.Apply();

        _image.sprite = Sprite.Create(texture, new Rect(0, 0, _board.Width, _board.Height), Vector2.zero);
    }

    private void PlaceRandomSquaresAndPrintCheckedFiguresCount()
    {
        _board.FillRandomSquares();

        Debug.Log(_board.Check(Property.Color) + " figures marked to collapse");

        _board.ClearCollapsingStates();
        
        Show();
    }

    // for testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceRandomSquaresAndPrintCheckedFiguresCount();
        }
    }
}
