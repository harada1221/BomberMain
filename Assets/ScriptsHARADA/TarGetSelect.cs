using UnityEngine;

public class TarGetSelect : MonoBehaviour
{
    [SerializeField, Header("キャラクター選択座標")]
    private RectTransform[] _rectTransforms = default;

    public RectTransform[] RectTransforms { get => _rectTransforms; }
}
