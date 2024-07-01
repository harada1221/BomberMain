using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // �A�C�e���^�C�v
    private ItemSO.ItemType _itemType = default;
    // �A�C�e����
    private string _itemName = default;
    // ���ʒl
    private int _elevatedValue = default;
    // �A�C�e���C���[�W
    private Sprite _itemImage = default;

    public ItemSO.ItemType ItemType { get => _itemType; set => _itemType = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public int ElevatedValue { get => _elevatedValue; set => _elevatedValue = value; }
    public Sprite ItemImage { get => _itemImage; set => _itemImage = value; }

}
