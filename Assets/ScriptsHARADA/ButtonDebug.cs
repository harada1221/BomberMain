using UnityEngine;

public class ButtonDebug : MonoBehaviour
{
    private PlayerTypeSelect.PlayerType _playerType = default;

    private void Start()
    {
        // PlayerTypeSelect �R���|�[�l���g���A�^�b�`����Ă��邱�Ƃ��m�F
        PlayerTypeSelect playerTypeSelect = GetComponent<PlayerTypeSelect>();
        if (playerTypeSelect != null)
        {
            _playerType = playerTypeSelect.GetplayerType;
        }
    }

    public void TextDebug()
    {
        Debug.Log(_playerType);
    }
}