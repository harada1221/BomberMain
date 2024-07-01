using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create ItemData")]
public class ItemSO : ScriptableObject
{
    [SerializeField, Header("�A�C�e���̌���")]
    private ItemType _itemType = default;
    [SerializeField, Header("�A�C�e���̖��O")]
    private string _itemName = default;
    [SerializeField, Header("���ʒl")]
    private int _elevatedValue = default;
    [SerializeField, Header("�A�C�e���摜")]
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
