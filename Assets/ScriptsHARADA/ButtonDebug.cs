using UnityEngine;

public class ButtonDebug : MonoBehaviour
{
    private PlayerTypeSelect.PlayerType _playerType = default;

    private void Start()
    {
        // PlayerTypeSelect コンポーネントがアタッチされていることを確認
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