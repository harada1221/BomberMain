using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneMovement : MonoBehaviour
{
    [SerializeField, Header("�ړ��V�[����")]
    private string _nextSceneName = default;
    public void OnChangeScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(_nextSceneName);
    }
}
