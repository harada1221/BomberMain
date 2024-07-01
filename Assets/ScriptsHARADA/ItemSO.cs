using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create ItemData")]
public class ItemSO : ScriptableObject
{
    [SerializeField, Header("アイテムの効果")]
    private ItemType _itemType = default;
    [SerializeField, Header("アイテムの名前")]
    private string _itemName = default;
    [SerializeField, Header("効果値")]
    private int _elevatedValue = default;
    [SerializeField, Header("アイテム画像")]
    private Sprite _itemImage = default;
    public enum ItemType
    {
        FirePowerUP,
        Invincible,
        Heal,
        SpeedUP
    }

    public ItemType GetItemType { get => _itemType; }
    public int GetElevatedValue { get => _elevatedValue; }
    public string GetItemName { get => _itemName; }
    public Sprite GetItemImage { get => _itemImage; }

}
