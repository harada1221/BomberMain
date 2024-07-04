using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerCountDisplay : MonoBehaviour
{
    [SerializeField]
    private Text playerCountText = default;
    [SerializeField]
    private PlayerInput _playerObject = default;

    private void Start()
    {
        if (PlayerData.Instance == null)
        {
            return;
        }
        // �V���O���g�����猻�݂̃v���C���[�����擾���A�\��
        playerCountText.text = "Current Player Count: " + PlayerData.Instance.CurrentPlayerCount;
        // �v���C���[����
        for (int i = 0; i < PlayerData.Instance.CurrentPlayerCount; i++)
        {
            PlayerInput.Instantiate(
           prefab: _playerObject.gameObject,
           playerIndex: PlayerData.Instance.CurrentPlayerCount,
           pairWithDevice: PlayerData.Instance.InputDevices[i]
           );
        }

    }
}