using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneMovement : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®ƒV[ƒ“–¼")]
    private string _nextSceneName = default;
    public void OnChangeScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(_nextSceneName);
    }
}
