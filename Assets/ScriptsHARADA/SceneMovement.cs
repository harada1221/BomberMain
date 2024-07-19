using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®ƒV[ƒ“–¼")]
    private string _nextSceneName = default;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
