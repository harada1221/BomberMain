using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイ人数
/// </summary>
public sealed class PlayerData : MonoBehaviour
{
    // シングルトンインスタンス
    public static PlayerData Instance { get; private set; }

    // キャラクター選択情報
    private GameObject[] _playerObject = default;

    // 現在のプレイヤー数
    public int CurrentPlayerCount { get; set; }

    private void Awake()
    {
        // インスタンスを設定
        if (Instance == null)
        {
            Instance = this;
            // オブジェクトを保持
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// playerDevice情報
    /// </summary>
    private class PlayerInfo
    {
        public InputDevice PairWithDevice { get; private set; } = default;

        public PlayerInfo(InputDevice pairWithDevice)
        {
            PairWithDevice = pairWithDevice;
        }
    }
}