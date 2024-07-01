using UnityEngine;

public class ItemManeger : MonoBehaviour
{
    [SerializeField, Header("アイテムデータ配列")]
    private ItemSO[] _items = default;
    [SerializeField, Header("アイテムの元")]
    private Item _itemObject = default;
    private Item[] _itemObjects = default;

    private void Awake()
    {
        _itemObjects = new Item[_items.Length];
        for (int i = 0; i < _items.Length; i++)
        {
            Item item = Instantiate(_itemObject);
            item.ItemType = _items[i].GetItemType;
            item.ItemName = _items[i].GetItemName;
            item.ElevatedValue = _items[i].GetElevatedValue;
            item.ItemImage = _items[i].GetItemImage;
            _itemObjects[i] = item;
            item.gameObject.SetActive(false);
        }
    }
}
