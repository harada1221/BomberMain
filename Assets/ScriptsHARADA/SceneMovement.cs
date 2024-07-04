using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneMovement : MonoBehaviour
{
    [SerializeField, Header("移動シーン名")]
    private string _nextSceneName = default;
    public void OnChangeScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(_nextSceneName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
