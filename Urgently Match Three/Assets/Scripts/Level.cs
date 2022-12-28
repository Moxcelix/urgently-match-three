using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private BoardShower _boardShower;

    private Board _board = new(8, 8);

    private void Start()
    {
        PlaceRandomSquaresAndPrintCheckedFiguresCount();  // for testing

        _boardShower.Initialize(_board);
    }

    private void PlaceRandomSquaresAndPrintCheckedFiguresCount()
    {
        _board.FillRandomSquares();

        Debug.Log(_board.Check(Property.Form) + " figures marked to collapse");

        _board.ClearCollapsingStates();
    }

    // for testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceRandomSquaresAndPrintCheckedFiguresCount();
            _boardShower.Show();
        }
    }
}
