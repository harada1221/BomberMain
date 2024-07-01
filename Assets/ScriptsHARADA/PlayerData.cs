using UnityEngine;

/// <summary>
/// プレイ人数
/// </summary>
public sealed class PlayerData : MonoBehaviour
{
    // シングルトンインスタンス
    public static PlayerData Instance { get; private set; }

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
}