using UnityEngine;

public class TarGetSelect : MonoBehaviour
{
    [SerializeField, Header("�L�����N�^�[�I�����W")]
    private RectTransform[] _rectTransforms = default;

    public RectTransform[] RectTransforms { get => _rectTransforms; }
}
