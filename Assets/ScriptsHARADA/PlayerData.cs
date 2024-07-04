using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C�l��
/// </summary>
public sealed class PlayerData : MonoBehaviour
{

    [SerializeField, Header("�ő�l��")]
    private int _maxPlayerCount = 4;
    // �V���O���g���C���X�^���X
    public static PlayerData Instance { get; private set; }

    // ���݂̃v���C���[��
    public int CurrentPlayerCount { get; set; }
    // �f�o�C�X���z��
    public InputDevice[] InputDevices{ get; set; }
    // �ő�v���C���[�l��
    public int MaxPlayer { get=>_maxPlayerCount;}

    private void Awake()
    {
        // �C���X�^���X��ݒ�
        if (Instance == null)
        {
            Instance = this;
            // �I�u�W�F�N�g��ێ�
            DontDestroyOnLoad(gameObject);
            InputDevices = new InputDevice[_maxPlayerCount];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}