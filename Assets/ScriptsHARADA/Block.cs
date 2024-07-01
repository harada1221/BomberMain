using UnityEngine;

public class Block : MonoBehaviour
{
    // ����������Ă��邩
    private bool _isFlag = false;
    private Transform _myTransform = default;

    /// <summary>
    /// ����������
    /// </summary>
    private void Start()
    {
        _myTransform = this.transform;
    }

    /// <summary>
    /// ���̏�Ԃ�ω�
    /// </summary>
    public void ChangeFlag()
    {
        Debug.Log("�Ăяo��");
        _isFlag = !_isFlag;
        if(_isFlag)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    /// <summary>
    /// �u���b�N�����ł�����
    /// </summary>
    public void DestroyBlock()
    {
        if (_isFlag == false)
        {
            // �u���b�N���\���ɂ���
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// �A�C�e�����h���b�v������
    /// </summary>
    /// <param name="dropItem">�h���b�v����A�C�e��</param>
    public void ItemDrop(Item dropItem)
    {
        // �A�C�e���̍��W�ύX
        dropItem.transform.position = _myTransform.position;
        // �A�C�e����\��������
        dropItem.gameObject.SetActive(true);
    }


}
