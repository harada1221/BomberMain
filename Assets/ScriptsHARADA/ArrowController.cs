using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ArrowController : MonoBehaviour
{
    [SerializeField, Header("移動の速さ")]
    private float _speed = 3;
    [SerializeField, Header("rayの初期位置")]
    private Transform _rayTransform = default;
    [SerializeField, Header("ターゲットのレイヤー")]
    private LayerMask _targetLayer = default;
    [SerializeField, Header("選択時の四角")]
    private GameObject _selectSquare = default;
    // 選択時の四角保存
    private GameObject _square = default;
    // 移動方向
    private float _verticalVelocity = default;
    // 入力方向
    private Vector2 _inputMove = default;
    // プレイヤー番号
    private int _playerNum = default;
    // ポジション
    private Transform _myTransform = default;
    // 移動可能か
    private bool _isSelect = false;

    private const string PARENTNAME = "Canvas";

    public int PlayerNum
    {
        get { return _playerNum; }
        set { _playerNum = value; }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
        _myTransform = this.transform;
        // 四角を生成
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
    /// 移動Action
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        _inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// 決定ボタン
    /// </summary>
    public void OnSetBom(InputAction.CallbackContext context)
    {
        // ボタンが押された瞬間に処理
        if (!context.performed || _isSelect == true)
        {
            return;
        }

        RaycastHit hit;
        // ボタンを押したときにUIがあるか
        if (Physics.Raycast(_rayTransform.position, Vector3.forward, out hit, Mathf.Infinity, _targetLayer))
        {
            PlayerTypeSelect playerType = hit.transform.GetComponent<PlayerTypeSelect>();
            if (playerType == null)
            {
                return;
            }
            // キャラタイプ保存
            PlayerTypeSelect.PlayerType type = playerType.GetplayerType;
            Debug.Log(type);
            _square.transform.position = playerType.transform.position;
            _isSelect = true;
            _square.SetActive(_isSelect);
            PlayerData.Instance.PlayerTypes[_playerNum] = type;
        }
    }

    /// <summary>
    /// キャンセルボタン
    /// </summary>
    public void OnSetFlag(InputAction.CallbackContext context)
    {
        // ボタンが押された瞬間に処理
        if (!context.performed || _isSelect == false)
        {
            return;
        }
        _isSelect = false;
        _square.SetActive(_isSelect);
    }

    private void Update()
    {
        Vector3 rayDirection = Vector3.forward;  // レイの方向を指定
        Debug.DrawRay(_rayTransform.position, rayDirection * 100f, Color.red, 2f);  // レイを可視化
        // 操作入力と鉛直方向速度から、現在速度を計算
        Vector3 moveVelocity = new Vector3(
            _inputMove.x * _speed,
            _inputMove.y * _speed,
           _verticalVelocity
        );
        // 現在フレームの移動量を移動速度から計算
        Vector3 moveDelta = moveVelocity * Time.deltaTime;

        _myTransform.position += moveDelta;
    }
}
