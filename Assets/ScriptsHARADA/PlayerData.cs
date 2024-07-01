using UnityEngine;

/// <summary>
/// �v���C�l��
/// </summary>
public sealed class PlayerData : MonoBehaviour
{
    // �V���O���g���C���X�^���X
    public static PlayerData Instance { get; private set; }

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
}