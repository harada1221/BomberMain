using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneMovement : MonoBehaviour
{
    [SerializeField, Header("à⁄ìÆÉVÅ[Éìñº")]
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
