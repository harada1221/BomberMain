using UnityEngine;
using UnityEngine.InputSystem;

public class PlyersPrefabData : MonoBehaviour
{
    [SerializeField, Header("プレイヤープレハブ")]
    private PlayerInput[] _playerInputs = default;
}
