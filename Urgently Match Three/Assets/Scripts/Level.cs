
public class Level
{
    private Tile[,] _tiles;

    public void Check() { }
    void a()
    {
        _tiles[0, 0].Equals(_tiles[0, 1], (Tile a, Tile b) => { return a.Color == b.Color; });
    }
}
