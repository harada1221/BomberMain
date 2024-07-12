using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ArrowController : MonoBehaviour
{
    [SerializeField, Header("�ړ��̑���")]
    private float _speed = 3;
    [SerializeField, Header("ray�̏����ʒu")]
    private Transform _rayTransform = default;
    [SerializeField, Header("�^�[�Q�b�g�̃��C���[")]
    private LayerMask _targetLayer = default;
    [SerializeField, Header("�I�����̎l�p")]
    private GameObject _selectSquare = default;
    // �I�����̎l�p�ۑ�
    private GameObject _square = default;
    // �ړ�����
    private float _verticalVelocity = default;
    // ���͕���
    private Vector2 _inputMove = default;
    // �v���C���[�ԍ�
    private int _playerNum = default;
    // �|�W�V����
    private Transform _myTransform = default;
    // �ړ��\��
    private bool _isSelect = false;

    private const string PARENTNAME = "Canvas";

    public int PlayerNum
    {
        get { return _playerNum; }
        set { _playerNum = value; }
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Start()
    {
        _myTransform = this.transform;
        // �l�p�𐶐�
        _square = Instantiate(_selectSquare, GameObject.FindGameObjectWithTag(PARENTNAME).transform);
        switch (_playerNum)
        {
            case 0:
                this.GetComponent<Image>().color = Color.blue;
                _square.GetComponent<Image>().color = Color.blue;
                break;
            case 1:
                this.GetComponent<Image>().color = Color.red;
                _square.GetComponent<Image>().color = Color.red;
                break;
            case 2:
                this.GetComponent<Image>().color = Color.green;
                _square.GetComponent<Image>().color = Color.green;
                break;
            case 3:
                this.GetComponent<Image>().color = Color.yellow;
                _square.GetComponent<Image>().color = Color.yellow;
                break;
        }
        _square.SetActive(false);
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
    /// ����{�^��
    /// </summary>
    public void OnSetBom(InputAction.CallbackContext context)
    {
        // �{�^���������ꂽ�u�Ԃɏ���
        if (!context.performed || _isSelect == true)
        {
            return;
        }

        RaycastHit hit;
        // �{�^�����������Ƃ���UI�����邩
        if (Physics.Raycast(_rayTransform.position, Vector3.forward, out hit, Mathf.Infinity, _targetLayer))
        {
            PlayerTypeSelect playerType = hit.transform.GetComponent<PlayerTypeSelect>();
            if (playerType == null)
            {
                return;
            }
            // �L�����^�C�v�ۑ�
            PlayerTypeSelect.PlayerType type = playerType.GetplayerType;
            Debug.Log(type);
            _square.transform.position = playerType.transform.position;
            _isSelect = true;
            _square.SetActive(_isSelect);
            PlayerData.Instance.PlayerTypes[_playerNum] = type;
        }
    }

    /// <summary>
    /// �L�����Z���{�^��
    /// </summary>
    public void OnSetFlag(InputAction.CallbackContext context)
    {
        // �{�^���������ꂽ�u�Ԃɏ���
        if (!context.performed || _isSelect == false)
        {
            return;
        }
        _isSelect = false;
        _square.SetActive(_isSelect);
    }

    private void Update()
    {
        Vector3 rayDirection = Vector3.forward;  // ���C�̕������w��
        Debug.DrawRay(_rayTransform.position, rayDirection * 100f, Color.red, 2f);  // ���C������
        // ������͂Ɖ����������x����A���ݑ��x���v�Z
        Vector3 moveVelocity = new Vector3(
            _inputMove.x * _speed,
            _inputMove.y * _speed,
           _verticalVelocity
        );
        // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
        Vector3 moveDelta = moveVelocity * Time.deltaTime;

        _myTransform.position += moveDelta;
    }
}
