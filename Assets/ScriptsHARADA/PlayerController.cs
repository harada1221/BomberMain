using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("移動の速さ")]
    private float _speed = 10f;
    [SerializeField, Header("最大HP")]
    private int _maxHp = 3;
    [SerializeField, Header("爆弾のクールタイム")]
    private float _bomCoolTime = 3f;
    [SerializeField, Header("爆弾の爆発方向")]
    private BomState _bomState = BomState.Straight;
    [SerializeField, Header("旗のクールタイム")]
    private float _flagCoolTime = 3f;

    // 生存状況
    private bool _isDead = false;
    // アニメーション
    private Animator _playerAnime = default;
    // myTransform
    private Transform _transform = default;
    private CharacterController _characterController = default;
    // 移動情報
    private Vector2 _inputMove = default;
    private float _verticalVelocity = default;
    private float _turnVelocity = default;

    public enum BomState
    {
        Straight,
        Cross
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
    /// 爆弾設置
    /// </summary>
    public void OnSetBom(InputAction.CallbackContext context)
    {
        // ボタンが押された瞬間に処理
        if (!context.performed)
        {
            return;
        }

        // 爆弾設置
        Debug.Log("爆弾設置");
    }

    /// <summary>
    /// 旗設置
    /// </summary>
    public void OnSetFlag(InputAction.CallbackContext context)
    {
        // ボタンが押された瞬間に処理
        if (!context.performed)
        {
            return;
        }

        // 旗設置
        Debug.Log("旗設置OR旗回収");

    }

    /// <summary>
    /// 初期処理
    /// </summary>
    private void Awake()
    {
        _transform = this.transform;
        _characterController = GetComponent<CharacterController>();
        _playerAnime = GetComponent<Animator>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {

        // 操作入力と鉛直方向速度から、現在速度を計算
        Vector3 moveVelocity = new Vector3(
            _inputMove.x * _speed,
            _verticalVelocity,
            _inputMove.y * _speed
        );
        // 現在フレームの移動量を移動速度から計算
        Vector3 moveDelta = moveVelocity * Time.deltaTime;

        // CharacterControllerに移動量を指定し、オブジェクトを動かす
        _characterController.Move(moveDelta);

        if (_inputMove != Vector2.zero)
        {
            _playerAnime.SetBool("Run", true);
            // 移動入力がある場合は、振り向き動作も行う

            // 操作入力からy軸周りの目標角度[deg]を計算
            float targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
                * Mathf.Rad2Deg + 90;

            // イージングしながら次の回転角度[deg]を計算
            float angleY = Mathf.SmoothDampAngle(
                _transform.eulerAngles.y,
                targetAngleY,
                ref _turnVelocity,
                0.1f
            );

            // オブジェクトの回転を更新
            _transform.rotation = Quaternion.Euler(0, angleY, 0);
        }
        else
        {
            _playerAnime.SetBool("Run", false);
        }
    }
}
