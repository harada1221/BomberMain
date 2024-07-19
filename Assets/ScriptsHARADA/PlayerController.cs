using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("�ړ��̑���")]
    private float _speed = 10f;
    [SerializeField, Header("�ő�HP")]
    private int _maxHp = 3;
    [SerializeField, Header("���e�̃N�[���^�C��")]
    private float _bomCoolTime = 3f;
    [SerializeField, Header("���e�̔�������")]
    private BomState _bomState = BomState.Straight;
    [SerializeField, Header("���̃N�[���^�C��")]
    private float _flagCoolTime = 3f;

    // ������
    private bool _isDead = false;
    // �A�j���[�V����
    private Animator _playerAnime = default;
    // myTransform
    private Transform _transform = default;
    private CharacterController _characterController = default;
    // �ړ����
    private Vector2 _inputMove = default;
    private float _verticalVelocity = default;
    private float _turnVelocity = default;

    public enum BomState
    {
        Straight,
        Cross
    }

    /// <summary>
    /// �ړ�Action
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
        _inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// ���e�ݒu
    /// </summary>
    public void OnSetBom(InputAction.CallbackContext context)
    {
        // �{�^���������ꂽ�u�Ԃɏ���
        if (!context.performed)
        {
            return;
        }

        // ���e�ݒu
        Debug.Log("���e�ݒu");
    }

    /// <summary>
    /// ���ݒu
    /// </summary>
    public void OnSetFlag(InputAction.CallbackContext context)
    {
        // �{�^���������ꂽ�u�Ԃɏ���
        if (!context.performed)
        {
            return;
        }

        // ���ݒu
        Debug.Log("���ݒuOR�����");

    }

    /// <summary>
    /// ��������
    /// </summary>
    private void Awake()
    {
        _transform = this.transform;
        _characterController = GetComponent<CharacterController>();
        _playerAnime = GetComponent<Animator>();
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void Update()
    {

        // ������͂Ɖ����������x����A���ݑ��x���v�Z
        Vector3 moveVelocity = new Vector3(
            _inputMove.x * _speed,
            _verticalVelocity,
            _inputMove.y * _speed
        );
        // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
        Vector3 moveDelta = moveVelocity * Time.deltaTime;

        // CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
        _characterController.Move(moveDelta);

        if (_inputMove != Vector2.zero)
        {
            _playerAnime.SetBool("Run", true);
            // �ړ����͂�����ꍇ�́A�U�����������s��

            // ������͂���y������̖ڕW�p�x[deg]���v�Z
            float targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
                * Mathf.Rad2Deg + 90;

            // �C�[�W���O���Ȃ��玟�̉�]�p�x[deg]���v�Z
            float angleY = Mathf.SmoothDampAngle(
                _transform.eulerAngles.y,
                targetAngleY,
                ref _turnVelocity,
                0.1f
            );

            // �I�u�W�F�N�g�̉�]���X�V
            _transform.rotation = Quaternion.Euler(0, angleY, 0);
        }
        else
        {
            _playerAnime.SetBool("Run", false);
        }
    }
}
