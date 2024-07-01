using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // アイテムタイプ
    private ItemSO.ItemType _itemType = default;
    // アイテム名
    private string _itemName = default;
    // 効果値
    private int _elevatedValue = default;
    // アイテムイメージ
    private Sprite _itemImage = default;

    public ItemSO.ItemType ItemType { get => _itemType; set => _itemType = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public int ElevatedValue { get => _elevatedValue; set => _elevatedValue = value; }
    public Sprite ItemImage { get => _itemImage; set => _itemImage = value; }

}
