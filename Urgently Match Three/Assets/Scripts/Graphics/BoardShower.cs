using UnityEngine;
using UnityEngine.UI;

public class BoardShower : MonoBehaviour
{
    [SerializeField] private RectTransform _boardRect;
    [SerializeField] private Cell _cellPrefab;

    private GridLayoutGroup _boardGrid;

    private readonly int _cellSize = 50;
    private readonly int _cellSpacing = 0;

    private Board _board;
    private Cell[,] _cells;

    public void Initialize(Board board)
    {
        _board = board;
        _boardRect.sizeDelta = new Vector2(_board.Width, _board.Height) * (_cellSize + _cellSpacing);
        _boardGrid = _boardRect.gameObject.GetComponent<GridLayoutGroup>();

        _boardGrid.cellSize = new Vector2(_cellSize, _cellSize);
        _boardGrid.spacing = new Vector2(_cellSpacing, _cellSpacing);

        _cells = new Cell[_board.Width, _board.Height];

        for (int i = 0; i < _board.Width; i++)
        {
            for (int j = 0; j < _board.Height; j++)
            {
                _cells[i, j] = Instantiate(_cellPrefab, _boardRect.transform);
                _cells[i, j].transform.localScale = Vector3.one;
                _cells[i, j].UpdateImage(_board.GetTile(i, j));
            }
        }
    }

    public void Show()
    {
        for (int i = 0; i < _board.Width; i++)
        {
            for (int j = 0; j < _board.Height; j++)
            {
                _cells[i, j].UpdateImage(_board.GetTile(i, j));
            }
        }
    }
}
