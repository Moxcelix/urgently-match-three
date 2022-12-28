using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _itemImage;

    private readonly Color _nullColor = new(1, 1, 1, 0);

    public void UpdateImage(Tile tile) 
    {
        if(tile == null)
        {
            _itemImage.color = _nullColor;

            return;
        }

        (Color color, Sprite sprite) = TextureFabric.Instance.Create(tile);

        _itemImage.color = color;
        _itemImage.sprite = sprite;
    }
}
