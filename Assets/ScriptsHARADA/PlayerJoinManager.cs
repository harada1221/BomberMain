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
    // PlayerInput���A�^�b�`����Ă���v���C���[�I�u�W�F�N�g
    [SerializeField] 
    private PlayerInput _playerPrefab = default;
    // �ő�Q���l��
    [SerializeField] 
    private int _maxPlayerCount = default;

    // Join�ς݂̃f�o�C�X���
    private InputDevice[] _joinedDevices = default;
    // ���݂̃v���C���[��
    private int _currentPlayerCount = 0;


    private void Awake()
    {
        // �ő�Q���\���Ŕz���������
        _joinedDevices = new InputDevice[_maxPlayerCount];

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
        if (_currentPlayerCount >= _maxPlayerCount)
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

        // PlayerInput�������������z�̃v���C���[���C���X�^���X��
        // ��Join�v�����̃f�o�C�X����R�Â��ăC���X�^���X�𐶐�����
        PlayerInput.Instantiate(
            prefab: _playerPrefab.gameObject,
            playerIndex: _currentPlayerCount,
            pairWithDevice: context.control.device
            );

        // Join�����f�o�C�X����ۑ�
        _joinedDevices[_currentPlayerCount] = context.control.device;

        _currentPlayerCount++;

        // �V���O���g���Ɍ��݂̃v���C���[����ۑ�
        PlayerData.Instance.CurrentPlayerCount = _currentPlayerCount;
    }
}