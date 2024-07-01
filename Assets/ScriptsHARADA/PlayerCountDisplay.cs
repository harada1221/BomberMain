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
        // �V���O���g�����猻�݂̃v���C���[�����擾���A�\��
        playerCountText.text = "Current Player Count: " + PlayerData.Instance.CurrentPlayerCount;
    }
}