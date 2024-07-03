using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C�l��
/// </summary>
public sealed class PlayerData : MonoBehaviour
{
    // �V���O���g���C���X�^���X
    public static PlayerData Instance { get; private set; }

    // �L�����N�^�[�I�����
    private GameObject[] _playerObject = default;

    // ���݂̃v���C���[��
    public int CurrentPlayerCount { get; set; }

    private void Awake()
    {
        // �C���X�^���X��ݒ�
        if (Instance == null)
        {
            Instance = this;
            // �I�u�W�F�N�g��ێ�
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// playerDevice���
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