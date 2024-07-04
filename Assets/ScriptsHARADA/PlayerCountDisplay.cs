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
        // シングルトンから現在のプレイヤー数を取得し、表示
        playerCountText.text = "Current Player Count: " + PlayerData.Instance.CurrentPlayerCount;
        // プレイヤー生成
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