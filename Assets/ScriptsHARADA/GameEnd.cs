using UnityEngine;
using UnityEngine.InputSystem;

public class GameEnd : MonoBehaviour
{
    //�Q�[���I��:�{�^������Ăяo��
    public void EndGame(InputAction.CallbackContext context)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
