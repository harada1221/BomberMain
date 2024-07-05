using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C���[�̓��ގ��̊Ǘ��N���X�i�A�E�g�Q�[���j
/// </summary>
public class PlayerJoinManager : MonoBehaviour
{
    // �v���C���[���Q�[����Join���邽�߂�InputAction
    [SerializeField]
    private InputAction _inputAction = default;
    [SerializeField]
    private PlayerInput _playerInput = default;
    [SerializeField]
    private GameObject _parent = default;

    // Join�ς݂̃f�o�C�X���
    private InputDevice[] _joinedDevices = default;
    // ���݂̃v���C���[��
    private int _currentPlayerCount = 0;


    private void Awake()
    {
        // �ő�Q���\���Ŕz���������
        _joinedDevices = new InputDevice[PlayerData.Instance.MaxPlayer];

        // InputAction��L�������A�R�[���o�b�N��ݒ�
        _inputAction.Enable();
        _inputAction.performed += OnJoin;
    }

    private void OnDestroy()
    {
        _inputAction.Dispose();
    }

    /// <summary>
    /// �f�o�C�X�ɂ����Join�v�������΂����Ƃ��ɌĂ΂�鏈��
    /// </summary>
    private void OnJoin(InputAction.CallbackContext context)
    {
        // �v���C���[�����ő吔�ɒB���Ă�����A�������I��
        if (_currentPlayerCount >= PlayerData.Instance.MaxPlayer)
        {
            return;
        }

        // Join�v�����̃f�o�C�X�����ɎQ���ς݂̂Ƃ��A�������I��
        foreach (var device in _joinedDevices)
        {
            if (context.control.device == device)
            {
                return;
            }
        }

        GameObject gameObject = Instantiate(
             _playerInput.gameObject,
             _parent.transform
             );

        // Set the parent
        gameObject.transform.SetParent(_parent.transform);

        // Join�����f�o�C�X����ۑ�
        _joinedDevices[_currentPlayerCount] = context.control.device;
        PlayerData.Instance.InputDevices[_currentPlayerCount] = _joinedDevices[_currentPlayerCount];

        _currentPlayerCount++;

        // �V���O���g���Ɍ��݂̃v���C���[����ۑ�
        PlayerData.Instance.CurrentPlayerCount = _currentPlayerCount;

    }
}