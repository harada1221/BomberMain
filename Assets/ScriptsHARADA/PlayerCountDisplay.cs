using UnityEngine;
using UnityEngine.UI;

public class PlayerCountDisplay : MonoBehaviour
{
    [SerializeField]
    private Text playerCountText = default;

    private void Start()
    {
        if(PlayerData.Instance == null)
        {
            return;
        }
        // シングルトンから現在のプレイヤー数を取得し、表示
        playerCountText.text = "Current Player Count: " + PlayerData.Instance.CurrentPlayerCount;
    }
}