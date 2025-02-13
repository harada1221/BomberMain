using UnityEngine;

public class Block : MonoBehaviour
{
    // 旗がおかれているか
    private bool _isFlag = false;
    private Transform _myTransform = default;

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
        _myTransform = this.transform;
    }

    /// <summary>
    /// 旗の状態を変化
    /// </summary>
    public void ChangeFlag()
    {
        _isFlag = !_isFlag;
    }

    /// <summary>
    /// ブロックを消滅させる
    /// </summary>
    public void DestroyBlock()
    {
        if (_isFlag == false)
        {
            // ブロックを非表示にする
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// アイテムをドロップさせる
    /// </summary>
    /// <param name="dropItem">ドロップするアイテム</param>
    public void ItemDrop(Item dropItem)
    {
        // アイテムの座標変更
        dropItem.transform.position = _myTransform.position;
        // アイテムを表示させる
        dropItem.gameObject.SetActive(true);
    }


}
